
USE SoftUni;

-- 1. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
     BEGIN
         SELECT FirstName AS [First Name],
                LastName AS [Last Name]
         FROM Employees
         WHERE Salary > 35000;
     END; 

-- 2. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
(
                 @minSalary MONEY
)
AS
     BEGIN
         SELECT FirstName AS [First Name],
                LastName AS [Last Name]
         FROM Employees
         WHERE Salary >= @MinSalary;
     END;
	
-- 3. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith
(
                 @startsWith NVARCHAR(MAX)
)
AS
     BEGIN
         SELECT Name AS Town
         FROM Towns
         WHERE Name LIKE(@startsWith+'%');
     END;
		
-- 4. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown
(
                 @townName NVARCHAR(50)
)
AS
     BEGIN
         SELECT e.FirstName AS [First Name],
                e.LastName AS [Last Name]
         FROM Employees AS e
              JOIN Addresses AS a ON e.AddressID = a.AddressID
              JOIN Towns AS t ON a.TownID = t.TownID
         WHERE t.Name = @townName;
     END;
		
-- 5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel
(
                @salary MONEY
)
RETURNS VARCHAR(7)
     BEGIN
         IF(@salary IS NULL)
             BEGIN
                 RETURN NULL;
         END;
         IF(@salary < 30000)
             BEGIN
                 RETURN 'Low';
         END;
             ELSE
             BEGIN
                 IF(@salary <= 50000)
                     BEGIN
                         RETURN 'Average';
                 END;
         END;
         RETURN 'High';
     END;

-- 6. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel
(
                 @levelOfSalary VARCHAR(7)
)
AS
     BEGIN
         SELECT FirstName AS [First Name],
                LastName AS [Last Name]
         FROM Employees
         WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary;
     END;
		
-- 7. Define Function
CREATE FUNCTION ufn_IsWordComprised
(
                @setOfLetters NVARCHAR(MAX),
                @word         NVARCHAR(MAX)
)
RETURNS BIT
AS
     BEGIN
         DECLARE @currentIndex INT= 1;
         WHILE(@currentIndex <= LEN(@word))
             BEGIN
                 DECLARE @currentLetter CHAR= SUBSTRING(@word, @currentIndex, 1);
                 IF(CHARINDEX(@currentLetter, @setOfLetters) <= 0)
                     BEGIN
                         RETURN 0;
                 END;
                 SET @currentIndex+=1;
             END;
         RETURN 1;
     END;

-- 8. Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
(
                 @departmentId INT
)
AS
     BEGIN
         ALTER TABLE Employees ALTER COLUMN ManagerID INT;

         ALTER TABLE Employees ALTER COLUMN DepartmentID INT;

         UPDATE Employees
           SET
               DepartmentID = NULL
         WHERE EmployeeID IN
         (
         (
             SELECT EmployeeID
             FROM Employees
             WHERE DepartmentID = @departmentId
         )
         );

         UPDATE Employees
           SET
               ManagerID = NULL
         WHERE ManagerID IN
         (
         (
             SELECT EmployeeID
             FROM Employees
             WHERE DepartmentID = @departmentId
         )
         );

         ALTER TABLE Departments ALTER COLUMN ManagerID INT;

         UPDATE Departments
           SET
               ManagerID = NULL
         WHERE DepartmentID = @departmentId;

         DELETE FROM Departments
         WHERE DepartmentID = @departmentId;

         DELETE FROM EmployeesProjects
         WHERE EmployeeID IN
         (
         (
             SELECT EmployeeID
             FROM Employees
             WHERE DepartmentID = @departmentId
         )
         );

         DELETE FROM Employees
         WHERE DepartmentID = @departmentId;

         SELECT COUNT(*)
         FROM Employees
         WHERE DepartmentID = @departmentId;
     END;

-- 9. Employees with Three Projects
CREATE PROCEDURE usp_AssignProject
(
                 @emloyeeId INT,
                 @projectID INT
)
AS
     BEGIN
         BEGIN TRANSACTION;
         INSERT INTO EmployeesProjects(EmployeeID,
                                       ProjectID
                                      )
         VALUES
         (
                @emloyeeId,
                @projectID
         );
         IF(
           (
               SELECT COUNT(EmployeeID)
               FROM EmployeesProjects
               WHERE EmployeeID = @emloyeeId
           ) > 3)
             BEGIN
                 ROLLBACK;
                 RAISERROR('The employee has too many projects!', 16, 1);
         END;
         COMMIT;
     END;
	   

-- 10. Delete Employees

CREATE TABLE Deleted_Employees
(
             EmployeeId   INT IDENTITY,
             FirstName    NVARCHAR(50),
             LastName     NVARCHAR(50),
             MiddleName   NVARCHAR(50),
             JobTitle     NVARCHAR(50),
             DepartmentId INT,
             Salary       DECIMAL(15, 2),
             CONSTRAINT PK_Deleted_Employees PRIMARY KEY(EmployeeId),
             CONSTRAINT FK_Deleted_Employees_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId)
);
GO

CREATE TRIGGER tr_DeletedEmployeesSaver ON Employees
AFTER DELETE
AS
     BEGIN
         INSERT INTO Deleted_Employees
                SELECT FirstName,
                       LastName,
                       MiddleName,
                       JobTitle,
                       DepartmentID,
                       Salary
                FROM deleted;
     END;
	   
USE BANK; 

-- 11. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName
AS
     BEGIN
         SELECT CONCAT(FirstName+' ', LastName) AS [Full Name]
         FROM AccountHolders;
     END;
		 
-- 12. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan
(
                 @balance MONEY
)
AS
     BEGIN
         SELECT ah.FirstName AS [First Name],
                ah.LastName AS [Last Name]
         FROM AccountHolders AS ah
              JOIN Accounts AS a ON ah.Id = a.AccountHolderId
         GROUP BY ah.FirstName,
                  ah.LastName
         HAVING @balance < SUM(a.Balance);
     END;
		
-- 13. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue
(
                @sum                MONEY,
                @yearlyInterestRate FLOAT,
                @numberOfYears      INT
)
RETURNS MONEY
AS
     BEGIN
         RETURN @sum * (POWER(1 + @yearlyInterestRate, @numberOfYears));
     END;
	 
-- 14. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount
(
                 @accountId    INT,
                 @interestRate FLOAT
)
AS
     BEGIN
         SELECT a.Id AS [Account Id],
                ah.FirstName AS [First Name],
                ah.LastName AS [Last Name],
                a.Balance AS [Current Balance],
                dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
         FROM Accounts AS a
              JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
         WHERE a.Id = @accountId;
     END;
   
-- 15. Deposit Money
CREATE PROCEDURE usp_DepositMoney
(
                 @accountId   INT,
                 @moneyAmount MONEY
)
AS
     BEGIN
         IF(@moneyAmount < 0)
             BEGIN
                 RAISERROR('Cannot deposit negative value', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@accountId IS NULL
                    OR @moneyAmount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance+=@moneyAmount
         WHERE Id = @accountId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Account doesn''t exists', 16, 1);
         END;
         COMMIT;
     END;
   
-- 16. Withdraw Money
CREATE PROCEDURE usp_WithdrawMoney
(
                 @accountId   INT,
                 @moneyAmount MONEY
)
AS
     BEGIN
         IF(@moneyAmount < 0)
             BEGIN
                 RAISERROR('Cannot withdraw negative value', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@accountId IS NULL
                    OR @moneyAmount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance-=@moneyAmount
         WHERE Id = @accountId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Account doesn''t exists', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(0 >
                   (
                       SELECT Balance
                       FROM Accounts
                       WHERE Id = @accountId
                   ))
                     BEGIN
                         ROLLBACK;
                         RAISERROR('Balance not enough', 16, 1);
                 END;
         END;
         COMMIT;
     END;
   
-- 17. Money Transfer
CREATE PROCEDURE usp_TransferMoney
(
                 @senderId   INT,
                 @receiverId INT,
                 @amount     MONEY
)
AS
     BEGIN
         IF(@amount < 0)
             BEGIN
                 RAISERROR('Cannot transfer negative amount', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@senderId IS NULL
                    OR @receiverId IS NULL
                    OR @amount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;

-- Withdraw from the sender
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance-=@amount
         WHERE Id = @senderId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Sender''s account doesn''t exists', 16, 1);
         END;

-- Check sender's current balance
         IF(0 >
           (
               SELECT Balance
               FROM Accounts
               WHERE ID = @senderId
           ))
             BEGIN
                 ROLLBACK;
                 RAISERROR('Not enough funds', 16, 1);
         END;

-- Add money to the receiver
         UPDATE Accounts
           SET
               Balance+=@amount
         WHERE ID = @receiverId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Receiver''s account doesn''t exists', 16, 1);
         END;
         COMMIT;
     END;
   
-- 18. Create Table Logs
USE Bank;

CREATE TABLE Logs
(
             LogId     INT NOT NULL IDENTITY,
             AccountId INT NOT NULL,
             OldSum    MONEY NOT NULL,
             NewSum    MONEY NOT NULL,
             CONSTRAINT PK_Logs PRIMARY KEY(LogId),
             CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountId) REFERENCES Accounts(Id)
);
GO

CREATE TRIGGER tr_Accounts_Logs_After_Update ON Accounts
FOR UPDATE
AS
     BEGIN
         INSERT INTO Logs
         VALUES
         (
         (
             SELECT Id
             FROM deleted
         ),
         (
             SELECT Balance
             FROM deleted
         ),
         (
             SELECT Balance
             FROM inserted
         )
         );
     END;
	 
-- 19. Create Table Emails
CREATE TABLE NotificationEmails
(
             Id        INT NOT NULL IDENTITY,
             Recipient INT NOT NULL,
             Subject   NVARCHAR(50) NOT NULL,
             Body      NVARCHAR(255) NOT NULL,
             CONSTRAINT PK_NotificationEmails PRIMARY KEY(Id)
);
GO

CREATE TRIGGER tr_Logs_NotificationEmails ON Logs
FOR INSERT
AS
     BEGIN
         INSERT INTO NotificationEmails
         VALUES
         (
         (
             SELECT AccountId
             FROM inserted
         ),
         CONCAT('Balance change for account: ',
               (
                   SELECT AccountId
                   FROM inserted
               )),
         CONCAT('On ', FORMAT(GETDATE(), 'dd-MM-yyyy HH:mm'), ' your balance was changed from ',
               (
                   SELECT OldSum
                   FROM Logs
               ), ' to ',
               (
                   SELECT NewSum
                   FROM Logs
               ), '.')
         );
     END;

USE Diablo;

-- 20. Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames
(
                @gameName NVARCHAR(50)
)
RETURNS TABLE
AS
     RETURN
(
    SELECT SUM(ocbg.Cash) AS SumCash
    FROM
    (
        SELECT g.Name,
               ug.Cash,
               ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowN
        FROM Games AS g
             JOIN UsersGames AS ug ON ug.GameId = g.Id
        WHERE Name = @gameName
    ) AS ocbg
    WHERE ocbg.RowN % 2 != 0
);

CREATE TRIGGER tr_UserGameItems_LevelRestriction ON UserGameItems
INSTEAD OF UPDATE
AS
     BEGIN
         IF(
           (
               SELECT Level
               FROM UsersGames
               WHERE Id =
               (
                   SELECT UserGameId
                   FROM inserted
               )
           ) <
           (
               SELECT MinLevel
               FROM Items
               WHERE Id =
               (
                   SELECT ItemId
                   FROM inserted
               )
           ))
             BEGIN
                 RAISERROR('Your current level is not enough', 16, 1);
         END;

         INSERT INTO UserGameItems
         VALUES
         (
         (
             SELECT ItemId
             FROM inserted
         ),
         (
             SELECT UserGameId
             FROM inserted
         )
         );
     END;
	 
UPDATE ug
  SET
      ug.Cash+=50000
FROM UsersGames AS ug
     JOIN Users AS u ON u.Id = ug.UserId
     JOIN Games AS g ON g.Id = ug.GameId
WHERE u.FirstName IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali';

-- 21. Massive Shopping

DECLARE @gameId INT, @sum1 MONEY, @sum2 MONEY;

SELECT @gameId = usg.[Id]
FROM UsersGames AS usg
     JOIN Games AS g ON usg.[GameId] = g.[Id]
WHERE g.[Name] = 'Safflower';

SET @sum1 =
(
    SELECT SUM(i.Price)
    FROM Items AS i
    WHERE MinLevel BETWEEN 11 AND 12
);

SET @sum2 =
(
    SELECT SUM(i.Price)
    FROM Items AS i
    WHERE MinLevel BETWEEN 19 AND 21
);

BEGIN TRANSACTION;

IF
(
    SELECT Cash
    FROM UsersGames
    WHERE Id = @gameId
) < @sum1
    BEGIN
        ROLLBACK;
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @sum1
        WHERE Id = @gameId;

        INSERT INTO UserGameItems(UserGameId,
                                  ItemId
                                 )
               SELECT @gameId,
                      Id
               FROM Items
               WHERE MinLevel BETWEEN 11 AND 12;
        COMMIT;
END;

BEGIN TRANSACTION;

IF
(
    SELECT Cash
    FROM UsersGames
    WHERE Id = @gameId
) < @sum2
    BEGIN
        ROLLBACK;
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @sum2
        WHERE Id = @gameId;

        INSERT INTO UserGameItems(UserGameId,
                                  ItemId
                                 )
               SELECT @gameId,
                      Id
               FROM Items
               WHERE MinLevel BETWEEN 19 AND 21;
        COMMIT;
END;

SELECT i.Name AS 'Item Name'
FROM UserGameItems AS ugi
     JOIN Items AS i ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = @gameId;

BEGIN TRANSACTION;

BEGIN TRY
    INSERT INTO UserGameItems
           SELECT Id,
                  UserGameId
           FROM
           (
               SELECT i.Id,
                      ugi.UserGameId
               FROM Users AS u
                    JOIN UsersGames AS ug ON ug.UserId = u.Id
                    JOIN Games AS g ON g.Id = ug.GameId
                    JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
                    JOIN Items AS i ON i.Id = ugi.ItemId
               WHERE u.FirstName = 'Stamat'
                     AND g.Name = 'Safflower'
                     AND i.Id NOT IN
               (
                   SELECT ugiss.ItemId
                   FROM UserGameItems AS ugiss
                   WHERE ugiss.UserGameId = ugi.UserGameId
               )
           ) AS joined;
END TRY
BEGIN CATCH
    ROLLBACK;
    SELECT ERROR_MESSAGE();
END CATCH;

UPDATE ug
  SET
      ug.Cash -= i.Price
FROM Users AS u
     JOIN UsersGames AS ug ON ug.UserId = u.Id
     JOIN Games AS g ON g.Id = ug.GameId
     JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
     JOIN Items AS i ON i.Id = ugi.ItemId
WHERE u.FirstName = 'Stamat'
      AND g.Name = 'Safflower'
      AND i.Id NOT IN
(
    SELECT ugiss.ItemId
    FROM UserGameItems AS ugiss
    WHERE ugiss.UserGameId = ugi.UserGameId
);

IF(0 >
  (
      SELECT ug.Cash
      FROM Users AS u
           JOIN UsersGames AS ug ON ug.UserId = u.Id
           JOIN Games AS g ON g.Id = ug.GameId
      WHERE u.FirstName = 'Stamat'
            AND g.Name = 'Safflower'
  ))
    BEGIN
        ROLLBACK;
        RAISERROR('Money not enough', 16, 1);
END;

ROLLBACK;

SELECT i.Name AS 'Item Name' 
FROM Items AS i
JOIN UserGameItems AS ugi ON ugi.ItemId = i.Id
JOIN UsersGames AS ug ON ugi.UserGameId = ug.Id
JOIN Games AS g ON ug.GameId = g.Id
WHERE g.Name = 'Safflower'
ORDER BY i.Name

-- 22. Number of Users for Email Provider
SELECT [Email Provider],
       COUNT([Email Provider]) AS [Number Of Users]
FROM
(
    SELECT Email,
           SUBSTRING(Email, CHARINDEX('@', Email, 1)+1, LEN(Email)-CHARINDEX('@', Email, 1)) AS [Email Provider]
    FROM Users
) AS ins
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC,
         [Email Provider];
		 

-- 1. DDL
CREATE TABLE Owners
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Address VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
    Id INT PRIMARY KEY IDENTITY,
    AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
    Id INT PRIMARY KEY IDENTITY,
    AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(30) NOT NULL,
    BirthDate DATE NOT NULL,
    OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
    AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages
(
    CageId INT FOREIGN KEY REFERENCES Cages(Id),
    AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
    PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
    Id INT PRIMARY KEY IDENTITY,
    DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Address VARCHAR(50),
    AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
    DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

-- 2. Insert
INSERT INTO Volunteers
    (Name, PhoneNumber, Address, AnimalId, DepartmentId)
VALUES
    ('Anita Kostova', '0896365412' , 'Sofia, 5 Rosa str.', 15, 1),
    ('Dimitur Stoev', '0877564223', NULL, 42, 4),
    ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9 , 7),
    ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
    ('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals
    (Name, BirthDate, OwnerId, AnimalTypeId)
VALUES
    ('Giraffe', '2018-09-21', 21, 1),
    ('Harpy Eagle', '2015-04-17', 15, 3),
    ('Hamadryas Baboon', '2017-11-02', NULL, 1),
    ('Tuatara', '2021-06-30', 2, 4)

-- 3. Update
UPDATE Animals
SET Animals.OwnerId = 4
WHERE Animals.OwnerId IS NULL

-- 4. Delete
BEGIN TRANSACTION

DELETE FROM Volunteers
WHERE DepartmentId = 2

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'


ROLLBACK

-- 5. Volunteers
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
FROM Volunteers
ORDER BY Name ASC, AnimalId ASC, DepartmentId ASC;

-- 6. Animals 
SELECT Animals.Name, AnimalTypes.AnimalType, CONVERT(VARCHAR, Animals.BirthDate, 104) AS [BirthDate]
FROM Animals
    JOIN AnimalTypes ON AnimalTypes.Id = Animals.AnimalTypeId
ORDER BY Animals.Name ASC;

-- 7. Owners and Their Animals
SELECT TOP(5)
    Owners.Name, COUNT(*) AS [CountOfAnimals]
FROM Owners
    JOIN Animals ON Animals.OwnerId = Owners.Id
GROUP BY Owners.Name
ORDER BY CountOfAnimals DESC;

-- 8. Owners, Animals and Cages
SELECT CONCAT(Owners.Name, '-', Animals.Name) AS [OwnersAnimals], Owners.PhoneNumber, AnimalsCages.CageId
FROM Animals
    JOIN Owners ON Owners.Id = Animals.OwnerId
    JOIN AnimalTypes ON AnimalTypes.Id = Animals.AnimalTypeId
    JOIN AnimalsCages ON AnimalsCages.AnimalId = Animals.Id
WHERE AnimalTypes.AnimalType = 'Mammals'
ORDER BY Owners.Name ASC, Animals.Name DESC;

-- 9. Volunteers in Sofia
SELECT Name, PhoneNumber, TRIM(SUBSTRING(Address, CHARINDEX(', ', Address) + 1, LEN(Address))) AS [Address]
FROM Volunteers
    JOIN VolunteersDepartments ON VolunteersDepartments.Id = Volunteers.DepartmentId
WHERE VolunteersDepartments.DepartmentName = 'Education program assistant' AND Volunteers.Address LIKE '%Sofia%'
ORDER BY Name ASC;

-- 10. Animals for Adoption
SELECT Animals.Name, YEAR(Animals.BirthDate) AS [BirthYear], AnimalTypes.AnimalType
FROM Animals
    JOIN AnimalTypes ON AnimalTypes.Id = Animals.AnimalTypeId
WHERE DATEDIFF(YEAR, Animals.BirthDate, '2022-01-01') < 5 AND AnimalTypes.AnimalType != 'Birds' AND Animals.OwnerId IS NULL
ORDER BY Animals.Name ASC;

-- 11. All Volunteers in a Department
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
BEGIN

    DECLARE @count INT;

    SET @count = (
                SELECT COUNT(*)
                FROM Volunteers
                    JOIN VolunteersDepartments ON VolunteersDepartments.Id = Volunteers.DepartmentId
                GROUP BY VolunteersDepartments.DepartmentName
                HAVING VolunteersDepartments.DepartmentName = @VolunteersDepartment
                )
    RETURN @count
END;

-- 12. Animals with Owner or Not
CREATE OR ALTER PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
  SELECT Animals.Name,
  CASE 
  WHEN Animals.OwnerId IS NULL THEN 'For adoption'
  ELSE Owners.Name
  END AS [OwnersName]
   FROM Animals
  FULL JOIN Owners ON Owners.Id = Animals.OwnerId
  WHERE Animals.Name = @AnimalName
END;
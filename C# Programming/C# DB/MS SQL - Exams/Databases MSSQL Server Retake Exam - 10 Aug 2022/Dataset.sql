-- 1. DDL
CREATE DATABASE NationalTouristSitesOfBulgaria;

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Locations
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    Municipality VARCHAR(50),
    Province VARCHAR(50)
)

CREATE TABLE Sites
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) NOT NULL,
    LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    Establishment VARCHAR(15)
)

CREATE TABLE Tourists
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    Age INT CHECK (Age >= 0 AND Age <= 120) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    Nationality VARCHAR(30) NOT NULL,
    Reward VARCHAR(20),
)

CREATE TABLE SitesTourists
(
    TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
    SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
    PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
    TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
    BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
    PRIMARY KEY (TouristId, BonusPrizeId)
)

-- 2. Insert
INSERT INTO Tourists
    (Name, Age, PhoneNumber, Nationality, Reward)
VALUES
    ( 'Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
    ( 'Peter Bosh', 48, '+447911844141', 'UK', NULL),
    ( 'Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
    ( 'Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
    ( 'Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites
    (Name, LocationId, CategoryId, Establishment)
VALUES
    ('Ustra fortress', 90, 7, 'X'),
    ('Karlanovo Pyramids', 65, 7, NULL),
    ('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
    ('Sinite Kamani Natural Park', 17, 1, NULL),
    ('St. Petka of Bulgaria - Rupite', 92, 6, '1994')

-- 3. Update
UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL;

-- 4. Delete
DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = 5;

DELETE FROM BonusPrizes
WHERE Id = 5;

-- 5. Tourists
SELECT Name, Age, PhoneNumber, Nationality
FROM Tourists
ORDER BY Nationality ASC, Age DESC, Name ASC

-- 6. Sites with Their Location and Category
SELECT Sites.Name, Locations.Name, Sites.Establishment, Categories.Name
FROM Sites
    JOIN Locations ON Locations.Id = Sites.LocationId
    JOIN Categories ON Categories.Id = Sites.CategoryId
ORDER BY Categories.Name DESC, Locations.Name ASC, Sites.Name ASC;

-- 7. Count of Sites in Sofia Province
SELECT Locations.Province, Locations.Municipality, Locations.Name, [Count]
FROM
    (
    SELECT Sites.LocationId, COUNT(*) AS [Count]
    FROM Sites
    GROUP BY Sites.LocationId
) AS [SubQuery]
    JOIN Locations ON Locations.Id = SubQuery.LocationId
WHERE Locations.Province = 'Sofia'
ORDER BY Count DESC, Locations.Name ASC

-- 8. Tourist Sites established BC
SELECT Sites.Name, Locations.Name, Locations.Municipality, Locations.Province, Sites.Establishment
FROM Sites
    JOIN Locations ON Locations.Id = Sites.LocationId
WHERE SUBSTRING(Locations.Name, 1, 1) != 'B'
    AND SUBSTRING(Locations.Name, 1, 1) != 'M'
    AND SUBSTRING(Locations.Name, 1, 1) != 'D'
    AND Establishment LIKE '%BC%'
ORDER BY Sites.Name;

-- 9. Tourists with their Bonus Prizes
SELECT
    Tourists.Name,
    Tourists.Age,
    Tourists.PhoneNumber,
    Tourists.Nationality,
    ISNULL(BonusPrizes.Name, '(no bonus prize)') AS [Reward]
FROM Tourists
    FULL JOIN TouristsBonusPrizes ON TouristsBonusPrizes.TouristId = Tourists.Id
    LEFT JOIN BonusPrizes ON TouristsBonusPrizes.BonusPrizeId = BonusPrizes.Id
ORDER BY Tourists.Name ASC;

-- 10. Tourists visiting History and Archaeology sites
SELECT DISTINCT SUBSTRING(Tourists.Name, CHARINDEX(' ', Tourists.Name) + 1, LEN(Tourists.Name) - CHARINDEX(' ', Tourists.Name)) AS [LastName], Tourists.Nationality, Tourists.Age, Tourists.PhoneNumber
FROM Tourists
    JOIN SitesTourists ON Tourists.Id = SitesTourists.TouristId
    JOIN Sites ON Sites.Id = SitesTourists.SiteId
    JOIN Categories ON Categories.Id = Sites.CategoryId
WHERE Categories.Name = 'History and archaeology'
ORDER BY LastName ASC;

-- 11. Tourists Count on a Tourist Site 
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
BEGIN
    DECLARE @count INT;
    SET @count = (
                SELECT COUNT(*)
    FROM Sites
        JOIN SitesTourists ON SitesTourists.SiteId = Sites.Id
        JOIN Tourists ON Tourists.Id = SitesTourists.TouristId
    GROUP BY Sites.Name
    HAVING Sites.Name = @Site
             )

    RETURN @count;
END

-- 12. Annual Reward Lottery
CREATE OR ALTER PROCEDURE usp_AnnualRewardLottery
    @TouristName VARCHAR(50)
AS
BEGIN
    IF (
    (SELECT COUNT(Sites.Id)
    FROM Sites
        JOIN SitesTourists ON SitesTourists.SiteId = Sites.Id
        JOIN Tourists ON SitesTourists.TouristId = Tourists.Id
    WHERE Tourists.Name = @TouristName) >= 100)
   BEGIN
        UPDATE Tourists
    SET Reward = 'Gold badge'
    WHERE Tourists.Name = @TouristName
    END;

    ELSE IF (
    (SELECT COUNT(Sites.Id)
    FROM Sites
        JOIN SitesTourists ON SitesTourists.SiteId = Sites.Id
        JOIN Tourists ON SitesTourists.TouristId = Tourists.Id
    WHERE Tourists.Name = @TouristName) >= 50)
    BEGIN
        UPDATE Tourists
    SET Reward = 'Silver badge'
    WHERE Tourists.Name = @TouristName
    END;

ELSE IF (
    (SELECT COUNT(Sites.Id)
            FROM Sites
            JOIN SitesTourists ON SitesTourists.SiteId = Sites.Id
            JOIN Tourists ON SitesTourists.TouristId = Tourists.Id
            WHERE Tourists.Name = @TouristName) >= 25)
        BEGIN
            UPDATE Tourists
            SET Reward = 'Bronze badge'
            WHERE Tourists.Name = @TouristName
        END;

    SELECT Name, Reward
    FROM Tourists
    WHERE Name = @TouristName
END;
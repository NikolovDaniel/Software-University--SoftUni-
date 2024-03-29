-- 1. DDL
CREATE DATABASE Boardgames;

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(30) UNIQUE NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
    Website NVARCHAR(40) NOT NULL,
    Phone NVARCHAR(20) NOT NULL
)

CREATE TABLE PlayersRanges
(
    Id INT PRIMARY KEY IDENTITY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(18, 2) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
    PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE Creators
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
    CreatorId INT FOREIGN KEY REFERENCES Creators(Id),
    BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id),
    PRIMARY KEY (CreatorId, BoardgameId)
)

-- 2. Insert
BEGIN TRANSACTION
INSERT INTO Boardgames
    (Name, YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', 2019, 5.67, 1, 15, 7),
    ('Paris', 2016, 9.78, 7, 1, 5),
    ('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
    ('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
    ('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers
    (Name, AddressId, Website, Phone)
VALUES
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

-- 3. Update
UPDATE PlayersRanges
SET PlayersMax += 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET Name = CONCAT(Name, 'V2')
WHERE YearPublished >= 2020

-- 4. Delete
DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (1, 16, 31, 31)

DELETE FROM Boardgames
WHERE PublisherId IN (1, 16)

DELETE FROM Publishers
WHERE AddressId = 5;

DELETE FROM Addresses
WHERE SUBSTRING(Town, 1, 1) = 'L'

-- 5. Boardgames by Year of Publication
SELECT Name, Rating
FROM Boardgames
ORDER BY YearPublished, Name DESC;

-- 6. Boardgames by Category
SELECT Boardgames.Id, Boardgames.Name, YearPublished, Categories.Name
FROM Boardgames
    JOIN Categories ON Categories.Id = Boardgames.CategoryId
WHERE Categories.Name IN ('Strategy Games', 'Wargames')
ORDER BY Boardgames.YearPublished DESC;

-- 7. Creators without Boardgames
SELECT Creators.Id, CONCAT(Creators.FirstName, ' ', Creators.LastName) AS [CreatorName], Creators.Email
FROM Creators
FULL JOIN CreatorsBoardgames ON CreatorsBoardgames.CreatorId = Creators.Id
WHERE CreatorsBoardgames.CreatorId IS NULL
ORDER BY CreatorName ASC;


-- 8. First 5 Boardgames
SELECT TOP(5)
    Boardgames.Name, Boardgames.Rating, Categories.Name
FROM Boardgames
    JOIN PlayersRanges ON PlayersRanges.Id = Boardgames.PlayersRangeId
    JOIN Categories ON Categories.Id = Boardgames.CategoryId
WHERE (Rating > 7.00 AND CHARINDEX('a', Boardgames.Name) != 0) OR (Rating > 7.50 AND PlayersMin = 2 AND PlayersMax = 5)
ORDER BY Boardgames.Name ASC, Boardgames.Rating DESC;

-- 9. Creators with Emails
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [FullName], c.Email, MaxRating
FROM
    (
    SELECT Creators.FirstName, MAX(Boardgames.Rating) AS [MaxRating]
    FROM Creators
        JOIN CreatorsBoardgames ON CreatorsBoardgames.CreatorId = Creators.Id
        JOIN Boardgames ON Boardgames.Id = CreatorsBoardgames.BoardgameId
    GROUP BY Creators.FirstName
    ) AS [SubQuery]
    JOIN Creators AS c ON c.FirstName = SubQuery.FirstName
WHERE CHARINDEX('.com', c.Email) != 0
ORDER BY FullName ASC;

-- 10. Creators by Rating
SELECT *
FROM
    (
    SELECT Creators.LastName, CEILING(AVG(Rating)) AS [AverageRating], Publishers.Name
    FROM Creators
        JOIN CreatorsBoardgames ON CreatorsBoardgames.CreatorId = Creators.Id
        JOIN Boardgames ON CreatorsBoardgames.BoardgameId = Boardgames.Id
        JOIN Publishers ON Publishers.Id = Boardgames.PublisherId
    GROUP BY Creators.LastName, Publishers.Name
    HAVING Publishers.Name = 'Stonemaier Games'
    ORDER BY AVG(Rating) DESC
    ) AS [SubQuery]

-- 11. Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
BEGIN
  RETURN (
            SELECT COUNT(*) FROM Creators
            JOIN CreatorsBoardgames ON CreatorsBoardgames.CreatorId = Creators.Id
            JOIN Boardgames ON Boardgames.Id = CreatorsBoardgames.BoardgameId
            WHERE Creators.FirstName = @name
         )
END;

-- 12. Search for Boardgame with Specific Category
CREATE PROCEDURE usp_SearchByCategory
    @category VARCHAR(50)
AS
BEGIN
    SELECT 
    b.Name, 
    b.YearPublished, 
    b.Rating, 
    c.Name AS [CategoryName], 
    p.Name AS [PublisherName], 
    CONCAT(pr.PlayersMin, ' people') AS [MinPlayers], 
    CONCAT(pr.PlayersMax, ' people') AS [MaxPlayers]
    FROM Boardgames AS b
        JOIN Categories AS c ON c.Id = b.CategoryId
        JOIN Publishers AS p ON p.Id = b.PublisherId
        JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
    WHERE c.Name = @category
    ORDER BY p.Name ASC, b.YearPublished DESC; 
END;

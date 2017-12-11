CREATE DATABASE MovieCatalog

GO

USE MovieCatalog

GO

CREATE TABLE [dbo].[Movie] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (40)  NOT NULL,
    [ReleaseYear] INT           NULL,
    [Genre]       VARCHAR (100) NULL,
    [Duration]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT C_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Get Out', 2017, N'Thriller', 140)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Dilwale Dulhanya Lejaengy', 1998, N'Romance, Action', 200)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Fast and Furious', 2014, N'Thriller, Action', 140)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Perks of Being a Wall Flower', 2011, N'Romance, Drama', 135)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'SpiderMan: Homecoming', 2017, N'Action, Thriller', 122)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Romeo and Juliet', 1993, N'Romance', 175)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Hotel Transalvinya', 2017, N'Comedy, Drama', 103)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Scent of a Woman', 1996, N'Drama', 140)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Gangster', 2017, N'Horror', 130)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Happy Feet', 2006, N'Animation', 110)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Harry Potter VI - Halbblutprinz', 2009, N'Fantasy', 122)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Hercules',2014, N'Animation', 124)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'I am Legend',2007, N'Action', 128)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Identity', 2003, N'Horror', 127)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Kate & Leopold', 2001, N'Liebe', 150)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Jurassic World',2005, N'Action', 130)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'King Arthur',2004,'Historical', 120)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Laws of Attraction',2004,N'Liebe', 110)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Lion King',1994,N'Animation', 134)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Matrix Revolutions',2003,N'Sci-Fi', 185)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Next', 2007, N'Sci-Fi', 132)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Oblivion', 2013, N'Sci-Fi', 111)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Password Swordfish', 2001, N'Crime', 150)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'S.W.A.T',2003,N'Action', 130)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Half Light', 2006, N'Horror', 120)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Gone Girl', 2014, N'Crime', 110)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Gladiator', 2000, N'Historical', 160)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'From Hell', 2001, N'Fantasy', 180)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Frequency',2000, N'Sci-Fi', 120)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Gattaca',1997,N'Sci-Fi', 110)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Cowboys and Aliens',2011,N'Sci-Fi',100)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Constantine',	2005, N'Fantasy', 90)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Cool Runnings', 1993, N'Komodie', 120)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Avatar', 2009, N'Horror', 120)
INSERT INTO [dbo].[Movie] ([Title], [ReleaseYear], [Genre], [Duration]) VALUES (N'Babel', 2011, N'Drama', 120)

GO

CREATE PROCEDURE [dbo].[addRecord]
	@pTitle varchar(40),
	@pReleaseYear int,
	@pGenre VARCHAR(100),
	@pDuration int
AS
	INSERT INTO Movie (Title, ReleaseYear, Genre, Duration) VALUES (@pTitle,@pReleaseYear,@pGenre,@pDuration);

GO

CREATE PROCEDURE [dbo].[deleteRecord]
	@pID int
AS
	DELETE Movie
	WHERE id = @pID;

GO

CREATE PROCEDURE dbo.[retRecords]
	@TitlePhrase varchar(40)
AS
	declare @param VARCHAR(40)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Movie WHERE Title LIKE @param;

GO

CREATE PROCEDURE [dbo].[updateRecord]
	@pID int,
	@pTitle varchar(40),
	@pReleaseYear int,
	@pGenre VARCHAR(100),
	@pDuration int
AS
	UPDATE Movie
	SET Title = @pTitle, Genre = @pGenre, ReleaseYear = @pReleaseYear, Duration = @pDuration 
	WHERE id = @pID;

GO
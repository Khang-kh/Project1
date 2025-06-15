CREATE DATABASE DB4;
GO
select*from Team;
USE DB4;
GO

CREATE TABLE Actors(
    ActorID INT IDENTITY(1,1) PRIMARY KEY,
    ActorUsername NVARCHAR(100) NOT NULL,
    ActorPassword VARCHAR(100) NOT NULL,
    ActorEmail VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Roles(
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);
GO
CREATE TABLE Actors_Role(
    ActorID INT,
    RoleID INT,
    PRIMARY KEY(ActorID, RoleID),
    FOREIGN KEY (ActorID) REFERENCES Actors (ActorID) ON DELETE CASCADE,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID) ON DELETE CASCADE
); 
GO
--tài kho?n master ?c l?u s?n và không th? xóa 
INSERT INTO Actors (ActorUsername, ActorPassword, ActorEmail)
VALUES 
('master', 'master', 'master@example.com');
GO
INSERT INTO Roles (RoleName)
VALUES ('Master');
GO
INSERT INTO Actors_Role(ActorID, RoleID)
VALUES (1, 1);
GO
CREATE TABLE Team (
    teamID INT IDENTITY(1,1) PRIMARY KEY,
    nameTeam NVARCHAR(255) NOT NULL,
    logoUrl VARCHAR(255)
);
GO
CREATE TABLE Player(
    playerID INT IDENTITY(1,1) PRIMARY KEY,
    namePlayer NVARCHAR(255) NOT NULL,
    shirtNumber INT,
	avatarUrl VARCHAR(255),
	position NVARCHAR(50),
	age INT
);
GO
CREATE TABLE Team_Player(
    teamID INT,
    playerID INT,
    PRIMARY KEY (teamID, playerID),
    FOREIGN KEY (teamID) REFERENCES Team (teamID),
    FOREIGN KEY (playerID) REFERENCES Player(playerID)
);

GO
CREATE TABLE Tournament (
    tournamentID INT IDENTITY(1,1) PRIMARY KEY,
    tournamentName NVARCHAR(255) NOT NULL,
    avatarURL VARCHAR(512),
    startDate DATE,
    endDate DATE,
    score VARCHAR(200),
    championTeamID INT,
    FOREIGN KEY (championTeamID) REFERENCES Team(teamID)
);
GO
CREATE TABLE TournamentTeams (
    tournamentID INT NOT NULL,
    teamID INT NOT NULL,
    PRIMARY KEY (tournamentID, teamID),
    FOREIGN KEY (tournamentID) REFERENCES Tournament(tournamentID),
    FOREIGN KEY (teamID) REFERENCES Team(teamID)
);
GO

CREATE TABLE MatchSchedule(
MatchID INT IDENTITY(1,1)  PRIMARY KEY,
MatchTeamID_A INT NOT NULL,
MatchTeamID_B INT NOT NULL,
FOREIGN KEY (MatchTeamID_A) REFERENCES Team(teamID),
FOREIGN KEY (MatchTeamID_B) REFERENCES Team(teamID),
TournamentID INT NOT NULL,
FOREIGN KEY (TournamentID) REFERENCES Tournament(tournamentID), 
Logo1_url VARCHAR(255),
Logo2_url VARCHAR(255),
Location NVARCHAR(100),
MatchTime DATETIME NOT NULL,
status_name NVARCHAR(100),
Score1 INT,
Score2 INT
);
GO
CREATE TABLE TranDau (
    matchID INT IDENTITY(1,1) PRIMARY KEY,
    team1ID INT NOT NULL,
    team2ID INT NOT NULL,
    tournamentID INT,
    matchDate DATETIME NOT NULL,
    team1Score INT,
    team2Score INT,
    team1Win INT DEFAULT 0,
    team1Draw INT DEFAULT 0,
    team1Loss INT DEFAULT 0,
    team1Points INT DEFAULT 0,
    team2Win INT DEFAULT 0,
    team2Draw INT DEFAULT 0,
    team2Loss INT DEFAULT 0,
    team2Points INT DEFAULT 0,
    status NVARCHAR(100),
    createdAt DATETIME DEFAULT GETDATE(),
    updatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (team1ID) REFERENCES Team(teamID),
    FOREIGN KEY (team2ID) REFERENCES Team(teamID),
    FOREIGN KEY (tournamentID) REFERENCES Tournament(tournamentID)
);
GO
CREATE TABLE match_line_up(
    MatchID INT NOT NULL,
    teamID INT NOT NULL,
    playerID INT NOT NULL,
    PRIMARY KEY (MatchID, teamID, playerID),
    position VARCHAR(100),
    FOREIGN KEY (MatchID) REFERENCES MatchSchedule(MatchID),
    FOREIGN KEY (teamID) REFERENCES Team(teamID),
    FOREIGN KEY (playerID) REFERENCES Player(playerID)
);
GO
CREATE TABLE match_line_up_sub(
    MatchID INT NOT NULL,
    teamID INT NOT NULL,
    playerID INT NOT NULL,
    PRIMARY KEY (MatchID, teamID, playerID),
    position VARCHAR(100),
    FOREIGN KEY (MatchID) REFERENCES MatchSchedule(MatchID),
    FOREIGN KEY (teamID) REFERENCES Team(teamID),
    FOREIGN KEY (playerID) REFERENCES Player(playerID)
);
GO
CREATE TABLE Rank (
    rankID INT IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính t? ??ng t?ng
    teamID INT,                            -- ID ??i bóng
    tournamentID INT,                      -- ID gi?i ??u
    totalPoints INT,                       -- T?ng ?i?m
    totalWins INT,                         -- S? tr?n th?ng
    totalDraws INT,                        -- S? tr?n hòa
    totalLosses INT,                       -- S? tr?n thua
    totalGoals INT,                        -- T?ng s? bàn th?ng
    totalGoalsAgainst INT,                 -- T?ng s? bàn thua
    goalDifference INT,                    -- Hi?u s? bàn th?ng b?i
    rankPosition INT,                      -- V? trí x?p h?ng
    FOREIGN KEY (teamID) REFERENCES Team(teamID),       -- Liên k?t v?i b?ng ??i bóng
    FOREIGN KEY (tournamentID) REFERENCES Tournament(tournamentID)  -- Liên k?t v?i b?ng gi?i ??u
);
GO
CREATE TABLE TeamAchievement (
    teamAchievementID INT IDENTITY(1,1) PRIMARY KEY,
    teamID INT NOT NULL,
    tournamentID INT NOT NULL,
    tournamentName VARCHAR(255),
    FOREIGN KEY (teamID) REFERENCES Team(teamID),
    FOREIGN KEY (tournamentID) REFERENCES Tournament(tournamentID)
);
GO
CREATE TABLE Post (
    postID INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(255) NOT NULL,
    content NVARCHAR(MAX) NOT NULL,
    author NVARCHAR(255) NOT NULL,
    createdAt DATETIME DEFAULT GETDATE(),
    imageURL VARCHAR(512)
);
GO

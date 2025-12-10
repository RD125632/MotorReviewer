-- Create Tables
CREATE TABLE MRL.Brands (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE MRL.Categories (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL 
);

CREATE TABLE MRL.Motorcycles (
    Id INT IDENTITY PRIMARY KEY,
    BrandId INT NOT NULL, 
    CategoryId INT NOT NULL,        
    Model NVARCHAR(100) NOT NULL,
    Year INT NULL,
    EngineCC INT NULL,
    PowerHP INT NULL
	
	FOREIGN KEY (BrandId) REFERENCES Brands(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);


CREATE TABLE MRLAccounts.Users (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ExperienceLevel NVARCHAR(50) NULL   -- Beginner, Intermediate, Track, etc.
);

CREATE TABLE MRL.Reviews (
    Id INT IDENTITY PRIMARY KEY,
    MotorcycleId INT NOT NULL,
    UserId INT NOT NULL,                   
    ReviewDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    HandlingScore decimal(3,1) NOT NULL,    -- 1-10
    EngineScore decimal(3,1) NOT NULL,       -- 1-10
    ComfortScore decimal(3,1) NOT NULL,     -- 1-10
    BrakesScore decimal(3,1) NOT NULL,      -- 1-10
    StabilityScore decimal(3,1) NOT NULL,   -- 1-10
    ValueScore decimal(3,1) NOT NULL,       -- 1-10

    OverallScore AS (
        (HandlingScore + EngineScore + ComfortScore + BrakesScore + StabilityScore + ValueScore) / 6.0
    ) PERSISTED,

    RoadType NVARCHAR(50) NULL,        -- City, Highway, Twisties, Track
    ConditionDry BIT NULL,             -- 1 = Dry, 0 = Wet
    TempC INT NULL,                -- approx temperature
    Comment NVARCHAR(MAX) NULL,

    FOREIGN KEY (MotorcycleId) REFERENCES MRL.Motorcycles(Id),
    FOREIGN KEY (UserId) REFERENCES MRLAccounts.Users(Id)
);

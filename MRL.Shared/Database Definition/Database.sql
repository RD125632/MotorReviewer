CREATE DATABASE MotorcycleReviewList;

-- Create server logins
CREATE LOGIN MRLUserLogin WITH PASSWORD = '@Welkom01';
CREATE LOGIN MRLAdminLogin WITH PASSWORD = '@Welkom01';

-- Use database
USE MotorcycleReviewList;
GO

-- Create Schemas
CREATE SCHEMA MRL;
CREATE SCHEMA MRLAccounts;
GO

-- Create User
CREATE USER MRLUser FOR LOGIN MRLUserLogin;
GRANT SELECT, INSERT, UPDATE ON SCHEMA::MRL TO MRLUser;

-- Create Admin
CREATE USER MRLAdmin FOR LOGIN MRLAdminLogin;
ALTER ROLE db_owner ADD MEMBER MRLAdmin;

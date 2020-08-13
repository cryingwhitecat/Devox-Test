CREATE TABLE ActivityType
(
	ActivityTypeID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	ActivityType nvarchar(100) NOT NULL
);
GO
CREATE TABLE Employee
(
	EmployeeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Sex nvarchar(50) CHECK (Sex IN ('Male','Female')),
	DOB datetime NOT NULL
);
GO
CREATE TABLE Project
(
	ProjectID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ProjectName nvarchar(100) NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL CHECK (EndDate > StartDate)
);
GO
CREATE TABLE [Role]
(
	RoleID int IDENTITY(1,1) PRIMARY KEY, 
	RoleName nvarchar(100) NOT NULL
);
GO
CREATE TABLE Activity
(
	ActivityID int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	ActivityDate datetime NOT NULL,
	EmployeeID int NOT NULL,
	EmployeeRoleID int NOT NULL,
	ActivityTypeID int NOT NULL,
	DurationInHours float NOT NULL,
	CONSTRAINT FK_Activity_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
	CONSTRAINT FK_Activity_Role FOREIGN KEY (EmployeeRoleID) REFERENCES [Role](RoleID),
	CONSTRAINT FK_Activity_Type FOREIGN KEY (ActivityTypeID) REFERENCES ActivityType(ActivityTypeID)
)

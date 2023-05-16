CREATE TABLE dbo.ApplicationRole	(	Id				INT PRIMARY KEY,
										RoleName		VARCHAR(50) NOT NULL,
										CreatedBy		INT NOT NULL,
										CreatedOn		DATETIME NOT NULL,
										UpdatedBy		INT NOT NULL,
										UpdatedOn		DATETIME NOT NULL)

CREATE TABLE dbo.ApplicationUser	(	Id				INT IDENTITY PRIMARY KEY,
										Username		VARCHAR(100) NOT NULL,
										PasswordHash	VARCHAR(500) NOT NULL,
										RoleRid			INT NOT NULL,
										CreatedBy		INT NOT NULL,
										CreatedOn		DATETIME NOT NULL,
										UpdatedBy		INT NOT NULL,
										UpdatedOn		DATETIME NOT NULL,
										CONSTRAINT FK_ApplicationUser_ApplicationRole FOREIGN KEY (RoleRid) REFERENCES ApplicationRole(Id))


CREATE TABLE dbo.Department		(	Id			INT IDENTITY PRIMARY KEY,
									DeptName	VARCHAR(50) NOT NULL,
									DeptCode	VARCHAR(10) NOT NULL,
									CreatedBy	INT NOT NULL,
									CreatedOn	DATETIME NOT NULL,
									UpdatedBy	INT NOT NULL,
									UpdatedOn	DATETIME NOT NULL)

CREATE TABLE dbo.Employee		(	Id			INT	IDENTITY PRIMARY KEY,
									EmpName		VARCHAR(100) NOT NULL,
									EmpCode		VARCHAR(15) NOT NULL,
									Designation	VARCHAR(50) NOT NULL,
									Salary		DECIMAL(18,2) NULL,
									ManagerId	INT NOT NULL,
									DeptId		INT NOT NULL,
									IsActive	BIT NOT NULL,
									CreatedBy	INT NOT NULL,
									CreatedOn	DATETIME NOT NULL,
									UpdatedBy	INT NOT NULL,
									UpdatedOn	DATETIME NOT NULL,
									CONSTRAINT  FK_Employee_Department FOREIGN KEY (DeptId) REFERENCES Department(Id),
									CONSTRAINT  FK_Employee_ApplicationUser FOREIGN KEY (Id) REFERENCES ApplicationUser(Id),
									CONSTRAINT  FK_Employee_EmpManager FOREIGN KEY (ManagerId) REFERENCES Employee(Id))



GO


INSERT INTO dbo.ApplicationRole VALUES (1, 'Admin',0,GETDATE(),0,GETDATE())
INSERT INTO dbo.ApplicationRole VALUES (2, 'Employee',1,GETDATE(),1,GETDATE())


USE Nedeljni_I_Bozic;

CREATE PROCEDURE Get_AllGender
AS
	select GenderId, Name  from tblGender
GO

CREATE PROCEDURE Get_AllRole
AS
	select RoleId, Name  from tblRole
GO

CREATE PROCEDURE Get_AllQualifications
AS
	select QualificationsId, Name  from tblQualifications
GO

CREATE PROCEDURE Get_AllMaritalStatus
AS
	select MaritalStatusId, Name  from tblMaritalStatus
GO

CREATE PROCEDURE Get_AllLevelOfResponsibility
AS
	select LevelOfResponsibilityId, Name  from tblLevelOfResponsibility
GO

CREATE PROCEDURE Get_AllAdministratorType
AS
	select AdministratorTypeId, Name  from tblAdministratorType
GO

CREATE PROCEDURE Get_AllSectors
AS
	select SectorId, Name, Description  from tblSector
GO

CREATE PROCEDURE Get_AllPositions
AS
	select PositionId, Name, Description  from tblPosition
GO

CREATE PROCEDURE Get_AllRealizationStatus
AS
	select RealizationStatusId, Name  from tblRealizationStatus
GO


CREATE PROCEDURE Login_MasterUser
@Username nvarchar(100), @Password nvarchar(max)
AS
	select Username from tblMasterAcount
	where Username=@Username and Password=@Password
GO

CREATE  PROCEDURE Insert_CompaniUser
	@FirstName nvarchar(100),@LastName nvarchar(100), 
	@JMBG bigint, @GenderId int,  
	@Address nvarchar(100),@MaritalStatusId  int,
	@Username nvarchar(100),  @Password nvarchar(max),
    @RoleId int	
AS
	insert into tblCompanyUser(FirstName, LastName, JMBG, GenderId, Address, MaritalStatusId, Username, Password, RoleId) 
	Values(@FirstName, @LastName, @JMBG, @GenderId, @Address, @MaritalStatusId, @Username, @Password, @RoleId)
	select SCOPE_IDENTITY()
GO

CREATE  PROCEDURE Insert_AdminUser
    @CompanyUserId int,  
    @AdministratorTypeId  int,
	@ExpirationDate date
AS
	insert into tblCompanyAdministrator(CompanyUserId, AdministratorTypeId, ExpirationDate) 
	Values(@CompanyUserId, @AdministratorTypeId, @ExpirationDate)
	select SCOPE_IDENTITY()
GO













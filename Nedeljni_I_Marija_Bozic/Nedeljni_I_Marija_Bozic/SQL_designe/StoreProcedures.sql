
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

CREATE PROCEDURE Check_UniqueUsernameMaster
@Username nvarchar(100)
AS
	select Username from tblMasterAcount
	where Username=@Username
GO

CREATE PROCEDURE Check_UniqueUsername
@Username nvarchar(100)
AS
	select Username from tblCompanyUser
	where Username=@Username
GO

CREATE PROCEDURE Check_UniqueJmbg
@JMBG nvarchar(100)
AS
	select JMBG from tblCompanyUser
	where JMBG=@JMBG
GO

CREATE PROCEDURE Check_UniqueEmail
@Email nvarchar(100)
AS
	select Email from tblCompanyMenager
	where Email=@Email
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

CREATE or alter  PROCEDURE Insert_Menager
    @CompanyUserId int,  
    @Email nvarchar(100),
	@BackupPassword nvarchar(max),
	@NumOfSuccessfulProjects int,
	@NumberOfOffice int
AS
	insert into tblCompanyMenager(CompanyUserId, Email, BackupPassword, NumOfSuccessfulProjects, NumberOfOffice) 
	Values(@CompanyUserId, @Email, @BackupPassword,  @NumOfSuccessfulProjects, @NumberOfOffice)
	select SCOPE_IDENTITY()
GO

CREATE or alter  PROCEDURE Insert_Worker
    @CompanyUserId int,  
    @ManagerId int,
	@SectorId int  ,
	@PositionId int ,
	@YearsOfService int,
	@QualificationsId int

AS
	if @PositionId=0
	begin
	insert into tblCompanyWorker(CompanyUserId, ManagerId, SectorId, YearsOfService, QualificationsId) 
	Values(@CompanyUserId, @ManagerId, @SectorId,  @YearsOfService, @QualificationsId )
	select SCOPE_IDENTITY()
	end
	if @PositionId!=0
	begin
	insert into tblCompanyWorker(CompanyUserId, ManagerId, SectorId, PositionId, YearsOfService, QualificationsId) 
	Values(@CompanyUserId, @ManagerId, @SectorId,  @PositionId, @YearsOfService, @QualificationsId )
	select SCOPE_IDENTITY()
	end
GO



 


CREATE or alter PROCEDURE Get_AllMenagers
AS
	select tblCompanyUser.CompanyUserId,FirstName, LastName, tblGender.Name,
	 tblCompanyMenager.Email,
	 tblCompanyMenager.NumOfSuccessfulProjects, tblCompanyMenager.NumberOfOffice 
	 from tblCompanyUser
	left join tblCompanyMenager on   tblCompanyUser.CompanyUserId=tblCompanyMenager.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
GO










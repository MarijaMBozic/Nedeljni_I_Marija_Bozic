
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

CREATE PROCEDURE Check_UniquePositionName
@Name nvarchar(100)
AS
	select Name  from tblPosition
	where Name=@Name
GO

CREATE PROCEDURE Check_UniqueSectorName
@Name nvarchar(100)
AS
	select Name  from tblSector
	where Name=@Name
GO

CREATE PROCEDURE Login_MasterUser
@Username nvarchar(100), @Password nvarchar(max)
AS
	select Username from tblMasterAcount
	where Username=@Username and Password=@Password
GO

CREATE PROCEDURE Login_User
@Username nvarchar(100), @Password nvarchar(max)
AS
	select CompanyUserId, FirstName, LastName, Username, RoleId from tblCompanyUser
	where Username=@Username and Password=@Password
GO

CREATE  PROCEDURE Login_UserBackupPass
@Username nvarchar(100), @Password nvarchar(max)
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, Username, RoleId from tblCompanyUser
	left join tblCompanyMenager on tblCompanyUser.CompanyUserId=tblCompanyMenager.CompanyUserId
	where Username=@Username and BackupPassword=@Password
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

CREATE  PROCEDURE Insert_Menager
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

CREATE   PROCEDURE Insert_Worker
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

CREATE  PROCEDURE Get_AllMenagersId
AS
	select  CompanyMenagerId from tblCompanyMenager
GO

CREATE  PROCEDURE Get_MenagerByUserId
@CompanyUserId int
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, 
	tblCompanyMenager.Email, tblCompanyMenager.LevelOfResponsibilityId, 
	tblCompanyMenager.NumOfSuccessfulProjects, tblCompanyMenager.NumberOfOffice,  CompanyMenagerId
	from tblCompanyUser
	left join tblCompanyMenager on   tblCompanyUser.CompanyUserId=tblCompanyMenager.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	where tblCompanyUser.CompanyUserId=@CompanyUserId and RoleId=1
GO

CREATE  PROCEDURE Get_WorkerByUserId
@CompanyUserId int
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, tblSector.Name, tblPosition.Name, YearsOfService,
	tblQualifications.Name
	from tblCompanyUser
	left join tblCompanyWorker on   tblCompanyUser.CompanyUserId=tblCompanyWorker.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	left join tblSector on tblCompanyWorker.SectorId=tblSector.SectorId
	left join tblPosition on tblCompanyWorker.PositionId=tblPosition.PositionId
	left join tblQualifications on tblCompanyWorker.QualificationsId=tblQualifications.QualificationsId
	where tblCompanyUser.CompanyUserId=@CompanyUserId and RoleId=3
GO

CREATE  PROCEDURE Get_AllWorkersByMenagerId
@MenagerId int
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, tblSector.Name, tblPosition.Name, YearsOfService,
	tblQualifications.Name
	from tblCompanyUser
	left join tblCompanyWorker on   tblCompanyUser.CompanyUserId=tblCompanyWorker.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	left join tblSector on tblCompanyWorker.SectorId=tblSector.SectorId
	left join tblPosition on tblCompanyWorker.PositionId=tblPosition.PositionId
	left join tblQualifications on tblCompanyWorker.QualificationsId=tblQualifications.QualificationsId
	where tblCompanyWorker.ManagerId=@MenagerId 
GO

CREATE  PROCEDURE Get_AllWorkers
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, tblSector.Name, tblPosition.Name, YearsOfService,
	tblQualifications.Name
	from tblCompanyUser
	left join tblCompanyWorker on   tblCompanyUser.CompanyUserId=tblCompanyWorker.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	left join tblSector on tblCompanyWorker.SectorId=tblSector.SectorId
	left join tblPosition on tblCompanyWorker.PositionId=tblPosition.PositionId
	left join tblQualifications on tblCompanyWorker.QualificationsId=tblQualifications.QualificationsId
	where RoleId=3
GO

CREATE  PROCEDURE Get_AllMenagerWithoutLevelOfResponsibility
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, 
	tblCompanyMenager.Email, tblCompanyMenager.LevelOfResponsibilityId, 
	tblCompanyMenager.NumOfSuccessfulProjects, tblCompanyMenager.NumberOfOffice,  CompanyMenagerId
	from tblCompanyUser
	left join tblCompanyMenager on   tblCompanyUser.CompanyUserId=tblCompanyMenager.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	where  RoleId=1 and LevelOfResponsibilityId is null
GO

CREATE  PROCEDURE Get_AllMenagerList
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, 
	tblCompanyMenager.Email, tblCompanyMenager.LevelOfResponsibilityId, 
	tblCompanyMenager.NumOfSuccessfulProjects, tblCompanyMenager.NumberOfOffice,  CompanyMenagerId
	from tblCompanyUser
	left join tblCompanyMenager on   tblCompanyUser.CompanyUserId=tblCompanyMenager.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	where  RoleId=1
GO

CREATE PROCEDURE Get_AdminByUserId
@CompanyUserId int
AS
	select tblCompanyUser.CompanyUserId, FirstName, LastName, JMBG, tblGender.Name, Address, 
	tblMaritalStatus.Name, Username, 
	tblAdministratorType.Name, tblCompanyAdministrator.ExpirationDate
	from tblCompanyUser
	left join tblCompanyWorker on   tblCompanyUser.CompanyUserId=tblCompanyWorker.CompanyUserId
	left join tblGender on tblCompanyUser.GenderId=tblGender.GenderId
	left join tblMaritalStatus on tblCompanyUser.MaritalStatusId=tblMaritalStatus.MaritalStatusId
	left join tblCompanyAdministrator on tblCompanyUser.CompanyUserId=tblCompanyAdministrator.CompanyUserId
	left join tblAdministratorType on tblCompanyAdministrator.AdministratorTypeId=tblAdministratorType.AdministratorTypeId
	where tblCompanyUser.CompanyUserId=@CompanyUserId and RoleId=2
GO


CREATE PROCEDURE Insert_Sector
    @Name  nvarchar(100),
	@Description nvarchar(400)
AS
	insert into tblSector(Name, Description) 
	Values(@Name, @Description)
	select SCOPE_IDENTITY()
GO

CREATE PROCEDURE Insert_Position
    @Name  nvarchar(100),
	@Description nvarchar(400)
AS
	insert into tblPosition(Name, Description) 
	Values(@Name, @Description)
	select SCOPE_IDENTITY()
GO

CREATE PROCEDURE Update_LevelOfResponsibility
    @LevelId nvarchar(100),
	@MenagerId nvarchar(400)
AS
	update tblCompanyMenager
	set LevelOfResponsibilityId=@LevelId
	where CompanyMenagerId=@MenagerId
GO
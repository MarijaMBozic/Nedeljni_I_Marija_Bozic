IF DB_ID('Nedeljni_I_Bozic') IS NULL
CREATE DATABASE Nedeljni_I_Bozic
GO
USE Nedeljni_I_Bozic;

drop table if exists tblWorkersOnProject 
drop table if exists tblProject
drop table if exists tblCompanyAdministrator
drop table if exists tblCompanyWorker
drop table if exists tblCompanyMenager
drop table if exists tblCompanyUser
drop table if exists tblRealizationStatus
drop table if exists tblPosition
drop table if exists tblSector
drop table if exists tblAdministratorType
drop table if exists tblLevelOfResponsibility
drop table if exists tblQualifications
drop table if exists tblMaritalStatus
drop table if exists tblRole
drop table if exists tblGender

create table tblGender (
   GenderId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null
   )

create table tblRole(
   RoleId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null
   )

create table tblMaritalStatus (
   MaritalStatusId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null
   )

create table tblQualifications(
   QualificationsId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null
   )

create table tblLevelOfResponsibility(
   LevelOfResponsibilityId       int            identity (1,1) primary key,   
   Name                          int          not null
   )

create table tblAdministratorType(
   AdministratorTypeId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null
   )

create table tblSector(
   SectorId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null,
   Description    nvarchar(100)          not null
   )

create table tblPosition(
   PositionId       int            identity (1,1) primary key,   
   Name           nvarchar(100)          not null,
   Description    nvarchar(100)          not null
   )

   create table tblRealizationStatus(
   RealizationStatusId       int            identity (1,1) primary key,   
   Name                      nvarchar(100)          not null, 
   )

create table tblCompanyUser (
   CompanyUserId       int            identity (1,1) primary key,   
   FirstName           nvarchar(100)          not null,
   LastName            nvarchar(100)          not null,
   JMBG                bigint    unique       not null,
   GenderId            int                    not null,
   FOREIGN KEY (GenderId) REFERENCES tblGender(GenderId), 
   Address             nvarchar(100)          not null,
   MaritalStatusId       int                  not null,
   FOREIGN KEY (MaritalStatusId) REFERENCES tblMaritalStatus(MaritalStatusId), 
   Username            nvarchar(100)  unique  not null,
   Password            nvarchar(max)          not null,
   RoleId              int					  not null,
   FOREIGN KEY (RoleId) REFERENCES tblRole(RoleId)
)

create table tblCompanyWorker(
   CompanyWorkerId       int            identity (1,1) primary key, 
   CompanyUserId         int                    not null,
   FOREIGN KEY (CompanyUserId) REFERENCES tblCompanyUser(CompanyUserId),
   ManagerId         int                    not null,
   FOREIGN KEY (ManagerId) REFERENCES tblCompanyUser(CompanyUserId),  
   SectorId              int                    not null,
   FOREIGN KEY (SectorId) REFERENCES tblSector(SectorId), 
   PositionId            int                  not null,
   FOREIGN KEY (PositionId) REFERENCES tblPosition(PositionId), 
   YearsOfService        int                  not null,
   Salary                money,
   QualificationsId      int				  not null,
   FOREIGN KEY (QualificationsId) REFERENCES tblQualifications(QualificationsId)
)

create table tblCompanyMenager(
   CompanyMenagerId      int            identity (1,1) primary key, 
   CompanyUserId         int                    not null,
   FOREIGN KEY (CompanyUserId) REFERENCES tblCompanyUser(CompanyUserId),  
   Email                 nvarchar(100) unique   not null,
   BackupPassword        nvarchar(max)          not null,
   LevelOfResponsibilityId    int               not null,
   FOREIGN KEY (LevelOfResponsibilityId) REFERENCES tblLevelOfResponsibility(LevelOfResponsibilityId), 
   NumOfSuccessfulProjects    int,
   Salary                money,
   NumberOfOffice        int			        not null
)

create table tblCompanyAdministrator(
   CompanyAdministratorId      int            identity (1,1) primary key, 
   CompanyUserId               int                    not null,
   FOREIGN KEY (CompanyUserId) REFERENCES tblCompanyUser(CompanyUserId),  
   AdministratorTypeId               int              not null,
   FOREIGN KEY (AdministratorTypeId) REFERENCES tblAdministratorType(AdministratorTypeId),
   ExpirationDate              date                    not null
)

create table tblProject(
	ProjectId      int            identity (1,1) primary key, 
	Name           nvarchar(100)          not null,
	ClientName     nvarchar(100)          not null,
	Description    nvarchar(500)          not null,
    DateOfConclusionOfContract  date      not null,
	ManagerWhoSignedContractId  int       not null,
    FOREIGN KEY (ManagerWhoSignedContractId) REFERENCES tblCompanyUser(CompanyUserId),  
	StartDateProject            date      not null,
	EndDateProject              date      not null,
	HourlyRate                  int       not null,
	RealizationStatusId         int       not null,
	FOREIGN KEY (RealizationStatusId) REFERENCES tblRealizationStatus(RealizationStatusId), 
	ManagerId  int       not null,
    FOREIGN KEY (ManagerId) REFERENCES tblCompanyUser(CompanyUserId)  
)

create table tblWorkersOnProject(
   WorkersOnProjectId      int            identity (1,1) primary key, 
   ProjectId               int                    not null,
   FOREIGN KEY (ProjectId) REFERENCES tblProject(ProjectId),
   CompanyUserId           int                    not null,
   FOREIGN KEY (CompanyUserId) REFERENCES tblCompanyUser(CompanyUserId), 
)

ALTER TABLE tblProject
  ADD CONSTRAINT uq_projectname UNIQUE(Name, ClientName);


insert into tblRole(Name)
values('Manager'),
	  ('Administrator'),
      ('Worker')

insert into tblGender(Name)
values('Male'),
	  ('Female'),
      ('Something else'),
	  ('Dont wont to declare')

insert into tblMaritalStatus(Name)
values('Unmarried'),
	  ('Married'),
      ('Divorced')
insert into tblQualifications(Name)
values('I'),
	  ('II'),
      ('III'),
	  ('IV'),
      ('V'),
	  ('VI'),
      ('VII')

insert into tblLevelOfResponsibility(Name)
values(0),
	  (1),
      (2)

insert into tblAdministratorType(Name)
values('Team'),
	  ('System'),
      ('Local')

insert into tblRealizationStatus(Name)
values('0'),
	  ('1'),
      ('2')


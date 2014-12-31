use CWXT

/*==============================================================*/
/* Table: 计划生育模块库表v1.0                                  */
/*==============================================================*/

if exists (select 1
            from  sysobjects
           where  id = object_id('CWBirthInfo')
            and   type = 'U')
   drop table CWBirthInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CWFamilySpecHelp')
            and   type = 'U')
   drop table CWFamilySpecHelp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CWInfo')
            and   type = 'U')
   drop table CWInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CWNewMarrige')
            and   type = 'U')
   drop table CWNewMarrige
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CWOneChild')
            and   type = 'U')
   drop table CWOneChild
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CWOneChildAward')
            and   type = 'U')
   drop table CWOneChildAward
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CWPerInfo')
            and   type = 'U')
   drop table CWPerInfo
go

/*==============================================================*/
/* Table: CWBirthInfo                                           */
/*==============================================================*/
create table CWBirthInfo (
   PKID                 int                  identity,
   FK_CWID              int                  null,
   ChildName            nvarchar(20)         null,
   Sex                  int                  null,
   BirthDate            datetime             null,
   BirthNo              nvarchar(20)         null,
   IsPlan               int                  null,
   ExpectDate           datetime             null,
   ChildAddress         nvarchar(255)        null,
   HolderName           nvarchar(20)         null,
   HolderIDCardNo       nvarchar(20)         null,
   FathName             nvarchar(20)         null,
   FathIDCardNo         nvarchar(20)         null,
   FathAddress          nvarchar(255)        null,
   FathLinkPhone        nvarchar(100)        null,
   MothName             nvarchar(20)         null,
   MothIDCardNo         nvarchar(20)         null,
   MothAddress          nvarchar(255)        null,
   MothLinkPhone        nvarchar(100)        null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   ModifyUser           int                  null,
   ModifyTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWBIRTHINFO primary key (PKID)
)
go

/*==============================================================*/
/* Table: CWFamilySpecHelp                                      */
/*==============================================================*/
create table CWFamilySpecHelp (
   PKID                 int                  identity,
   FK_CWID              int                  null,
   AppIDCardNo          nvarchar(20)         null,
   AppName              nvarchar(20)         null,
   Sex                  int                  null,
   HolderPorp           int                  null,
   HelpType             int                  null,
   RealMonth            int                  null,
   HelpMoney            decimal(18,2)        null,
   HelpNo               nvarchar(20)         null,
   HelpYear             char(4)              null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWFAMILYSPECHELP primary key (PKID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWFamilySpecHelp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HolderPorp')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWFamilySpecHelp', 'column', 'HolderPorp'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  农业、非农业',
   'user', @CurrentUser, 'table', 'CWFamilySpecHelp', 'column', 'HolderPorp'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWFamilySpecHelp')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HelpType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWFamilySpecHelp', 'column', 'HelpType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  伤残、死亡',
   'user', @CurrentUser, 'table', 'CWFamilySpecHelp', 'column', 'HelpType'
go

/*==============================================================*/
/* Table: CWInfo                                                */
/*==============================================================*/
create table CWInfo (
   PKID                 int                  identity,
   VillageName          nvarchar(100)        null,
   Location             nvarchar(255)        null,
   District             int                  null,
   TotalPeps            int                  null,
   IndusValue           decimal(18,2)        null,
   VillageChief         nvarchar(20)         null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   ModifyUser           int                  null,
   ModifyTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWINFO primary key (PKID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'District')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWInfo', 'column', 'District'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  上海市金山区',
   'user', @CurrentUser, 'table', 'CWInfo', 'column', 'District'
go

/*==============================================================*/
/* Table: CWNewMarrige                                          */
/*==============================================================*/
create table CWNewMarrige (
   PKID                 int                  identity,
   FK_CWID              int                  null,
   MaleIDCardNo         nvarchar(20)         null,
   MaleName             nvarchar(20)         null,
   MaleAddress          nvarchar(255)        null,
   MaleLinkPhone        nvarchar(100)        null,
   FemaleIDCardNo       nvarchar(20)         null,
   FemaleName           nvarchar(20)         null,
   FemaleAddress        nvarchar(255)        null,
   FemaleLinkPhone      nvarchar(100)        null,
   MarrigeDate          datetime             null,
   IsPregnant           int                  null,
   ExpectDate           datetime             null,
   VillageDate          datetime             null,
   MarrigeNo            nvarchar(20)         null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWNEWMARRIGE primary key (PKID)
)
go

/*==============================================================*/
/* Table: CWOneChild                                            */
/*==============================================================*/
create table CWOneChild (
   FKID                 int                  identity,
   FK_CWID              int                  null,
   IDCardNo             nvarchar(20)         null,
   ChildName            nvarchar(20)         null,
   Sex                  int                  null,
   FathIDCardNo         nvarchar(20)         null,
   MothIDCardNo         nvarchar(20)         null,
   OneChildNo           nvarchar(20)         null,
   IssueOrg             nvarchar(100)        null,
   BirthDate            datetime             null,
   InSchool             nvarchar(100)        null,
   FamilyAddress        nvarchar(255)        null,
   FamilyIncome         decimal(18,2)        null,
   InsuNo               nvarchar(20)         null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   ModifyUser           int                  null,
   ModifyTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWONECHILD primary key (FKID)
)
go

/*==============================================================*/
/* Table: CWOneChildAward                                       */
/*==============================================================*/
create table CWOneChildAward (
   FKID                 int                  identity,
   FK_CWID              int                  null,
   OwnIDCardNo          nvarchar(20)         null,
   OwnName              nvarchar(20)         null,
   ChildIDCardNo        nvarchar(20)         null,
   ChildName            nvarchar(20)         null,
   BirthDate            datetime             null,
   OneChildNo           nvarchar(20)         null,
   RealMonth            int                  null,
   AwardFee             decimal(18,2)        null,
   LinkPhone            nvarchar(50)         null,
   AuthName             nvarchar(20)         null,
   ABCNo                nvarchar(50)         null,
   AuthIDCardNo         nvarchar(20)         null,
   AwardYear            char(4)              null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWONECHILDAWARD primary key (FKID)
)
go

/*==============================================================*/
/* Table: CWPerInfo                                             */
/*==============================================================*/
create table CWPerInfo (
   PKID                 int                  identity,
   FK_CWID              int                  null,
   IDCardNo             nvarchar(20)         not null,
   Name                 varchar(20)          null,
   Sex                  int                  null,
   Nation               int                  null,
   Politics             int                  null,
   IsHolder             int                  null,
   HolderName           nvarchar(20)         null,
   HolderIDCardNo       nvarchar(20)         null,
   HolderPorp           int                  null,
   HolderAddress        nvarchar(255)        null,
   LiveAddress          nvarchar(255)        null,
   LinkPhone            nvarchar(100)        null,
   WorkUnit             nvarchar(100)        null,
   MarrigeStatus        int                  null,
   MarrigeDate          datetime             null,
   MarrigeNo            nvarchar(50)         null,
   MarrigeName          nvarchar(20)         null,
   MarrigeIDCardNo      nvarchar(20)         null,
   Children             int                  null,
   IsSingle             int                  null,
   ChildName1           nvarchar(20)         null,
   ChildIDCardNo1       nvarchar(20)         null,
   ChildAddress1        nvarchar(255)        null,
   BirthNo1             nvarchar(20)         null,
   BirthDate1           datetime             null,
   AdoptNo1             nvarchar(50)         null,
   ChildName2           nvarchar(20)         null,
   ChildIDCardNo2       nvarchar(20)         null,
   ChildAddress2        nvarchar(255)        null,
   BirthNo2             nvarchar(50)         null,
   BirthDate2           datetime             null,
   AdoptNo2             nvarchar(50)         null,
   ChildName3           nvarchar(20)         null,
   ChildIDCardNo3       nvarchar(20)         null,
   ChildAddress3        nvarchar(255)        null,
   BirthNo3             nvarchar(50)         null,
   BirthDate3           datetime             null,
   AdoptNo3             nvarchar(50)         null,
   CreateUser           int                  null,
   CreateTime           datetime             null,
   ModifyUser           int                  null,
   ModifyTime           datetime             null,
   Memo                 nvarchar(255)        null,
   constraint PK_CWPERINFO primary key (PKID)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Sex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  男、女',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Nation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Nation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  汉族、回族...',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Nation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Politics')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Politics'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  中共党员、团员、群众',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Politics'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsHolder')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'IsHolder'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  是、否',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'IsHolder'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HolderPorp')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'HolderPorp'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  农业、非农业',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'HolderPorp'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MarrigeStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'MarrigeStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  已婚、离婚、丧偶',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'MarrigeStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('CWPerInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Children')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Children'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '字典表Dictionary  无子女（未生育未收养）、无子女（独生子女死亡）、有独生子女、有多个子女',
   'user', @CurrentUser, 'table', 'CWPerInfo', 'column', 'Children'
go

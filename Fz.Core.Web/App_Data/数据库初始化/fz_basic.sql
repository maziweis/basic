if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dict_edition_and_subject') and o.name = 'FK_DICT_EDI_REFERENCE_DICT_EDI')
alter table dict_edition_and_subject
   drop constraint FK_DICT_EDI_REFERENCE_DICT_EDI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dict_edition_and_subject') and o.name = 'FK_DICT_EDI_REFERENCE_DICT_SUB')
alter table dict_edition_and_subject
   drop constraint FK_DICT_EDI_REFERENCE_DICT_SUB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_class') and o.name = 'FK_SY_CLASS_REFERENCE_SY_GRADE')
alter table sy_class
   drop constraint FK_SY_CLASS_REFERENCE_SY_GRADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_nav') and o.name = 'FK_SY_NAV_REFERENCE_SY_SYSTE')
alter table sy_nav
   drop constraint FK_SY_NAV_REFERENCE_SY_SYSTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_role_and_nav') and o.name = 'FK_SY_ROLE__REFERENCE_SY_NAV')
alter table sy_role_and_nav
   drop constraint FK_SY_ROLE__REFERENCE_SY_NAV
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_role_and_nav') and o.name = 'FK_SY_ROLE__REFERENCE_SY_ROLE')
alter table sy_role_and_nav
   drop constraint FK_SY_ROLE__REFERENCE_SY_ROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_student') and o.name = 'FK_SY_STUDE_REFERENCE_SY_GRADE')
alter table sy_student
   drop constraint FK_SY_STUDE_REFERENCE_SY_GRADE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_student') and o.name = 'FK_SY_STUDE_REFERENCE_SY_CLASS')
alter table sy_student
   drop constraint FK_SY_STUDE_REFERENCE_SY_CLASS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_student') and o.name = 'FK_SY_STUDE_REFERENCE_SY_USER')
alter table sy_student
   drop constraint FK_SY_STUDE_REFERENCE_SY_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_teacher') and o.name = 'FK_SY_TEACH_REFERENCE_SY_USER')
alter table sy_teacher
   drop constraint FK_SY_TEACH_REFERENCE_SY_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_teacher_and_class_and_subject') and o.name = 'FK_SY_TEACH_REFERENCE_DICT_SUB')
alter table sy_teacher_and_class_and_subject
   drop constraint FK_SY_TEACH_REFERENCE_DICT_SUB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_teacher_and_class_and_subject') and o.name = 'FK_SY_TEACH_REFERENCE_SY_TEACH')
alter table sy_teacher_and_class_and_subject
   drop constraint FK_SY_TEACH_REFERENCE_SY_TEACH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_teacher_and_class_and_subject') and o.name = 'FK_SY_TEACH_REFERENCE_SY_CLASS')
alter table sy_teacher_and_class_and_subject
   drop constraint FK_SY_TEACH_REFERENCE_SY_CLASS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_user_and_role') and o.name = 'FK_SY_USER__REFERENCE_SY_USER')
alter table sy_user_and_role
   drop constraint FK_SY_USER__REFERENCE_SY_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('sy_user_and_role') and o.name = 'FK_SY_USER__REFERENCE_SY_ROLE')
alter table sy_user_and_role
   drop constraint FK_SY_USER__REFERENCE_SY_ROLE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_edition')
            and   type = 'U')
   drop table dict_edition
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_edition_and_subject')
            and   type = 'U')
   drop table dict_edition_and_subject
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_resource_type')
            and   type = 'U')
   drop table dict_resource_type
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_subject')
            and   type = 'U')
   drop table dict_subject
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_textbook')
            and   type = 'U')
   drop table dict_textbook
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_textbook_catalog')
            and   type = 'U')
   drop table dict_textbook_catalog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dict_textbook_resource')
            and   type = 'U')
   drop table dict_textbook_resource
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_class')
            and   type = 'U')
   drop table sy_class
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_grade')
            and   type = 'U')
   drop table sy_grade
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_init')
            and   type = 'U')
   drop table sy_init
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_nav')
            and   type = 'U')
   drop table sy_nav
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_role')
            and   type = 'U')
   drop table sy_role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_role_and_nav')
            and   type = 'U')
   drop table sy_role_and_nav
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_school')
            and   type = 'U')
   drop table sy_school
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_student')
            and   type = 'U')
   drop table sy_student
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_system')
            and   type = 'U')
   drop table sy_system
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_teacher')
            and   type = 'U')
   drop table sy_teacher
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_teacher_and_class_and_subject')
            and   type = 'U')
   drop table sy_teacher_and_class_and_subject
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_user')
            and   type = 'U')
   drop table sy_user
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_user_and_role')
            and   type = 'U')
   drop table sy_user_and_role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('sy_user_ticket')
            and   type = 'U')
   drop table sy_user_ticket
go

/*==============================================================*/
/* Table: dict_edition                                          */
/*==============================================================*/
create table dict_edition (
   Id                   int                  not null,
   Name                 varchar(50)          not null,
   Sort                 int                  null,
   IsEnabled            bit                  not null,
   constraint PK_DICT_EDITION primary key (Id)
)
go

/*==============================================================*/
/* Table: dict_edition_and_subject                              */
/*==============================================================*/
create table dict_edition_and_subject (
   EditionId            int                  not null,
   SubjectId            int                  not null,
   IsEnabled            bit                  not null,
   constraint PK_DICT_EDITION_AND_SUBJECT primary key (EditionId, SubjectId)
)
go

/*==============================================================*/
/* Table: dict_resource_type                                    */
/*==============================================================*/
create table dict_resource_type (
   ID                   int                  identity,
   GUID                 varchar(50)          not null,
   CodeName             varchar(100)         not null,
   Seq                  int                  null,
   ParentID             int                  not null,
   Path                 varchar(300)         null,
   CreateDateTime       datetime             null,
   ModifyDateTime       datetime             null,
   Deleted              int                  not null,
   constraint PK_DICT_RESOURCE_TYPE primary key (ID)
)
go

/*==============================================================*/
/* Table: dict_subject                                          */
/*==============================================================*/
create table dict_subject (
   Id                   int                  identity,
   Name                 varchar(50)          not null,
   Sort                 int                  null,
   IsEnabled            bit                  not null,
   IsSystem             bit                  not null,
   constraint PK_DICT_SUBJECT primary key (Id)
)
go

/*==============================================================*/
/* Table: dict_textbook                                         */
/*==============================================================*/
create table dict_textbook (
   Id                   int                  identity,
   Stage                int                  not null,
   Subject              int                  not null,
   Grade                int                  not null,
   Booklet              int                  not null,
   Edition              int                  not null,
   BookName             varchar(100)         not null,
   ConfigFile           varchar(200)         null,
   Cover                varchar(200)         null,
   Remark               varchar(500)         null,
   CreateDateTime       datetime             null,
   ModifyDateTime       datetime             null,
   Deleted              int                  not null,
   constraint PK_DICT_TEXTBOOK primary key (Id)
)
go

/*==============================================================*/
/* Table: dict_textbook_catalog                                 */
/*==============================================================*/
create table dict_textbook_catalog (
   Id                   int                  identity,
   BookId               int                  not null,
   FolderName           varchar(500)         not null,
   Seq                  int                  null,
   ParentId             int                  null,
   CreateDateTime       datetime             null,
   ModifyDateTime       datetime             null,
   Deleted              int                  not null,
   Type                 int                  null,
   PageStart            int                  null,
   PageEnd              int                  null,
   constraint PK_DICT_TEXTBOOK_CATALOG primary key (Id)
)
go

/*==============================================================*/
/* Table: dict_textbook_resource                                */
/*==============================================================*/
create table dict_textbook_resource (
   BookId               int                  not null,
   PageIndex            int                  not null,
   Content              varchar(8000)        null,
   constraint PK_DICT_TEXTBOOK_RESOURCE primary key (BookId, PageIndex)
)
go

/*==============================================================*/
/* Table: sy_class                                              */
/*==============================================================*/
create table sy_class (
   Id                   int                  identity,
   GradeId              int                  not null,
   Name                 varchar(50)          not null,
   Year                 int                  null,
   Sort                 int                  null,
   IsGraduate           bit                  not null,
   IsEnabled            bit                  not null,
   constraint PK_SY_CLASS primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_grade                                              */
/*==============================================================*/
create table sy_grade (
   Id                   int                  identity,
   SGradeId             int                  not null,
   Name                 varchar(50)          not null,
   Year                 int                  not null,
   Sort                 int                  null,
   IsGraduate           bit                  not null,
   IsEnabled            bit                  not null,
   constraint PK_SY_GRADE primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_init                                               */
/*==============================================================*/
create table sy_init (
   Id                   char(36)             not null,
   SchoolName           varchar(100)         not null,
   AuthMessage          varchar(500)         null,
   constraint PK_SY_INIT primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_nav                                                */
/*==============================================================*/
create table sy_nav (
   Id                   int                  identity,
   SId                  int                  not null,
   PId                  int                  null,
   Type                 int                  not null,
   Name                 varchar(100)         not null,
   Url                  varchar(700)         null,
   PageOpen             int                  not null,
   Icon                 varchar(50)          null,
   Level                int                  not null,
   IsSystem             bit                  not null,
   Sort                 int                  null,
   IsEnabled            bit                  not null,
   constraint PK_SY_NAV primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-栏目，2-导航',
   'user', @CurrentUser, 'table', 'sy_nav', 'column', 'Type'
go

/*==============================================================*/
/* Table: sy_role                                               */
/*==============================================================*/
create table sy_role (
   Id                   int                  identity,
   Name                 varchar(50)          not null,
   Type                 int                  not null,
   IsSystem             bit                  not null,
   IsEnabled            bit                  not null,
   Remark               varchar(300)         null,
   constraint PK_SY_ROLE primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_role_and_nav                                       */
/*==============================================================*/
create table sy_role_and_nav (
   RoleId               int                  not null,
   NavId                int                  not null,
   constraint PK_SY_ROLE_AND_NAV primary key (RoleId, NavId)
)
go

/*==============================================================*/
/* Table: sy_school                                             */
/*==============================================================*/
create table sy_school (
   Id                   int                  not null,
   Name                 varchar(100)         not null,
   Code                 varchar(100)         null,
   Principal            varchar(30)          null,
   Webhome              varchar(400)         null,
   Overview             varchar(8000)        null,
   Address              varchar(400)         null,
   Email                varchar(100)         null,
   Tel                  varchar(30)          null,
   constraint PK_SY_SCHOOL primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_student                                            */
/*==============================================================*/
create table sy_student (
   Id                   int                  identity,
   UserId               char(36)             null,
   Code                 varchar(50)          null,
   Name                 varchar(50)          not null,
   Sex                  varchar(10)          null,
   Grade                int                  null,
   Class                int                  null,
   Year                 int                  null,
   IsGraduate           bit                  not null,
   constraint PK_SY_STUDENT primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_system                                             */
/*==============================================================*/
create table sy_system (
   Id                   int                  identity,
   PId                  int                  null,
   Type                 int                  not null,
   Name                 varchar(100)         not null,
   Url                  varchar(700)         null,
   PageOpen             int                  not null,
   Icon                 varchar(50)          null,
   Level                int                  not null,
   IsSystem             bit                  not null,
   Sort                 int                  null,
   IsEnabled            bit                  not null,
   IsNav                bit                  not null,
   constraint PK_SY_SYSTEM primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-栏目，2-导航',
   'user', @CurrentUser, 'table', 'sy_system', 'column', 'Type'
go

/*==============================================================*/
/* Table: sy_teacher                                            */
/*==============================================================*/
create table sy_teacher (
   Id                   int                  identity,
   UserId               char(36)             null,
   Code                 varchar(50)          null,
   Name                 varchar(50)          not null,
   Sex                  varchar(10)          null,
   Subject              int                  null,
   Dept                 int                  null,
   Post                 int                  null,
   constraint PK_SY_TEACHER primary key (Id)
)
go

/*==============================================================*/
/* Table: sy_teacher_and_class_and_subject                      */
/*==============================================================*/
create table sy_teacher_and_class_and_subject (
   TeacherId            int                  not null,
   ClassId              int                  not null,
   Subject              int                  not null,
   constraint PK_SY_TEACHER_AND_CLASS_AND_SU primary key (TeacherId, ClassId, Subject)
)
go

/*==============================================================*/
/* Table: sy_user                                               */
/*==============================================================*/
create table sy_user (
   Id                   char(36)             not null,
   Account              varchar(50)          not null,
   Password             varchar(90)          not null,
   Name                 varchar(50)          not null,
   Type                 int                  not null,
   IsSystem             bit                  not null,
   IsExpires            bit                  not null,
   ExpiresTime          datetime             null,
   IsEnabled            bit                  not null,
   CreateTime           datetime             not null,
   AvatarUrl            varchar(360)         null,
   constraint PK_SY_USER primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-教职工，2-学生，3-家长，4-方直管理账号',
   'user', @CurrentUser, 'table', 'sy_user', 'column', 'Type'
go

/*==============================================================*/
/* Table: sy_user_and_role                                      */
/*==============================================================*/
create table sy_user_and_role (
   UserId               char(36)             not null,
   RoleId               int                  not null,
   Time                 datetime             not null,
   constraint PK_SY_USER_AND_ROLE primary key (UserId, RoleId)
)
go

/*==============================================================*/
/* Table: sy_user_ticket                                        */
/*==============================================================*/
create table sy_user_ticket (
   Id                   varchar(200)         not null,
   Account              varchar(50)          not null,
   Ip                   varchar(30)          not null,
   ExpiresTime          datetime             not null,
   IsDelete             bit                  not null,
   constraint PK_SY_USER_TICKET primary key (Id)
)
go

alter table dict_edition_and_subject
   add constraint FK_DICT_EDI_REFERENCE_DICT_EDI foreign key (EditionId)
      references dict_edition (Id)
go

alter table dict_edition_and_subject
   add constraint FK_DICT_EDI_REFERENCE_DICT_SUB foreign key (SubjectId)
      references dict_subject (Id)
go

alter table sy_class
   add constraint FK_SY_CLASS_REFERENCE_SY_GRADE foreign key (GradeId)
      references sy_grade (Id)
go

alter table sy_nav
   add constraint FK_SY_NAV_REFERENCE_SY_SYSTE foreign key (SId)
      references sy_system (Id)
go

alter table sy_role_and_nav
   add constraint FK_SY_ROLE__REFERENCE_SY_NAV foreign key (NavId)
      references sy_nav (Id)
go

alter table sy_role_and_nav
   add constraint FK_SY_ROLE__REFERENCE_SY_ROLE foreign key (RoleId)
      references sy_role (Id)
go

alter table sy_student
   add constraint FK_SY_STUDE_REFERENCE_SY_GRADE foreign key (Grade)
      references sy_grade (Id)
go

alter table sy_student
   add constraint FK_SY_STUDE_REFERENCE_SY_CLASS foreign key (Class)
      references sy_class (Id)
go

alter table sy_student
   add constraint FK_SY_STUDE_REFERENCE_SY_USER foreign key (UserId)
      references sy_user (Id)
go

alter table sy_teacher
   add constraint FK_SY_TEACH_REFERENCE_SY_USER foreign key (UserId)
      references sy_user (Id)
go

alter table sy_teacher_and_class_and_subject
   add constraint FK_SY_TEACH_REFERENCE_DICT_SUB foreign key (Subject)
      references dict_subject (Id)
go

alter table sy_teacher_and_class_and_subject
   add constraint FK_SY_TEACH_REFERENCE_SY_TEACH foreign key (TeacherId)
      references sy_teacher (Id)
go

alter table sy_teacher_and_class_and_subject
   add constraint FK_SY_TEACH_REFERENCE_SY_CLASS foreign key (ClassId)
      references sy_class (Id)
go

alter table sy_user_and_role
   add constraint FK_SY_USER__REFERENCE_SY_USER foreign key (UserId)
      references sy_user (Id)
go

alter table sy_user_and_role
   add constraint FK_SY_USER__REFERENCE_SY_ROLE foreign key (RoleId)
      references sy_role (Id)
go




/*==================================================================================资源库开始=========================================================================================*/
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('r_resource') and o.name = 'FK_R_RESOUR_REFERENCE_R_FILES')
alter table r_resource
   drop constraint FK_R_RESOUR_REFERENCE_R_FILES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('r_resource_approve') and o.name = 'FK_RESOURCE_REFERENCE_APPROVE')
alter table r_resource_approve
   drop constraint FK_RESOURCE_REFERENCE_APPROVE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('r_resource_down') and o.name = 'FK_RESOURCE_REFERENCE_DOWN')
alter table r_resource_down
   drop constraint FK_RESOURCE_REFERENCE_DOWN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('r_resource_favorite') and o.name = 'FK_RESOURCE_REFERENCE_FAVORITE')
alter table r_resource_favorite
   drop constraint FK_RESOURCE_REFERENCE_FAVORITE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('r_files')
            and   type = 'U')
   drop table r_files
go

if exists (select 1
            from  sysobjects
           where  id = object_id('r_resource')
            and   type = 'U')
   drop table r_resource
go

if exists (select 1
            from  sysobjects
           where  id = object_id('r_resource_approve')
            and   type = 'U')
   drop table r_resource_approve
go

if exists (select 1
            from  sysobjects
           where  id = object_id('r_resource_down')
            and   type = 'U')
   drop table r_resource_down
go

if exists (select 1
            from  sysobjects
           where  id = object_id('r_resource_favorite')
            and   type = 'U')
   drop table r_resource_favorite
go

if exists (select 1
            from  sysobjects
           where  id = object_id('r_textbook')
            and   type = 'U')
   drop table r_textbook
go

/*==============================================================*/
/* Table: r_files                                               */
/*==============================================================*/
create table r_files (
   Id                   varchar(50)          not null,
   FileName             varchar(400)         not null,
   FileDescription      varchar(400)         null,
   FileExtension        varchar(20)          not null,
   FileSize             int                  not null,
   FilePath             varchar(400)         not null,
   FileType             int                  not null,
   FinishStatus         bit                  not null,
   EncryptStatus        int                  not null,
   ConvertStatus        int                  not null,
   UploadTime           datetime             null,
   Width                int                  not null,
   Height               int                  not null,
   constraint PK_R_FILES primary key (Id)
)
go

/*==============================================================*/
/* Table: r_resource                                            */
/*==============================================================*/
create table r_resource (
   ResourceID           varchar(50)          not null,
   FileID               varchar(50)          not null,
   Number               float                null,
   ResourceName         varchar(500)         collate Chinese_PRC_CI_AS null,
   Description          varchar(1000)        collate Chinese_PRC_CI_AS null,
   ResourceType         int                  null,
   ResourceStyle        int                  null,
   ResourceSize         decimal              null,
   FileType             varchar(20)          collate Chinese_PRC_CI_AS null,
   ResourceScanNum      int                  null,
   ResourceCollectNum   int                  null,
   ResourceDowLoadNum   int                  null,
   SubjectID            int                  null,
   EditionID            int                  null,
   GradeID              int                  null,
   SchoolStage          int                  null,
   BookReelID           int                  null,
   Catalog              int                  null,
   ResourceLevel        int                  null,
   KeyWords             varchar(2000)        collate Chinese_PRC_CI_AS null,
   TeachingStep         int                  null,
   TeachingStyle        int                  null,
   IsVerify             int                  null,
   Purview              int                  null,
   IsDelete             int                  null,
   BreviaryImgUrl       varchar(800)         collate Chinese_PRC_CI_AS null,
   IsRecommend          int                  null,
   MaterialID           varchar(50)          null,
   AppraisedCounts      int                  null,
   CollectCounts        int                  null,
   TeachingModules      varchar(100)         collate Chinese_PRC_CI_AS null,
   Applicable           varchar(100)         collate Chinese_PRC_CI_AS null,
   ModifyDate           datetime             null,
   Copyright            int                  null,
   CopyrightName        varchar(100)         collate Chinese_PRC_CI_AS null,
   ComeFrom             varchar(100)         collate Chinese_PRC_CI_AS null,
   Sort                 int                  null,
   ResourceClass        int                  null,
   TimeSpan             int                  null,
   ShareStauts          int                  null,
   ResourceCreaterID    varchar(50)          collate Chinese_PRC_CI_AS null,
   ResourceCreateDate   datetime             null,
   ResourceCreaterName  varchar(50)          null,
   constraint PK_R_RESOURCE primary key (ResourceID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资源信息',
   'user', @CurrentUser, 'table', 'r_resource'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0为否，1为是',
   'user', @CurrentUser, 'table', 'r_resource', 'column', 'IsVerify'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '默认为0,1代表已经删除',
   'user', @CurrentUser, 'table', 'r_resource', 'column', 'IsDelete'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-方直自主版权，2-方直争议版权，3-用户上传非原创，4-用户上传原创',
   'user', @CurrentUser, 'table', 'r_resource', 'column', 'Copyright'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0 未分享  1 分享',
   'user', @CurrentUser, 'table', 'r_resource', 'column', 'ShareStauts'
go

/*==============================================================*/
/* Table: r_resource_approve                                    */
/*==============================================================*/
create table r_resource_approve (
   Id                   int                  identity,
   ApproveUId           varchar(50)          not null,
   ResourceID           varchar(50)          not null,
   ApproveTime          datetime             not null,
   DisposeUId           varchar(50)          null,
   DisposeTime          datetime             null,
   DisposeState         int                  not null,
   DisposeResult        int                  null,
   constraint PK_R_RESOURCE_APPROVE primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资源分享审批表',
   'user', @CurrentUser, 'table', 'r_resource_approve'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-同意，2-不同意',
   'user', @CurrentUser, 'table', 'r_resource_approve', 'column', 'DisposeResult'
go

/*==============================================================*/
/* Table: r_resource_down                                       */
/*==============================================================*/
create table r_resource_down (
   UId                  varchar(50)          not null,
   ResourceID           varchar(50)          not null,
   CreateTime           datetime             not null,
   constraint PK_R_RESOURCE_DOWN primary key (UId, ResourceID, CreateTime)
)
go

/*==============================================================*/
/* Table: r_resource_favorite                                   */
/*==============================================================*/
create table r_resource_favorite (
   UId                  varchar(50)          not null,
   ResourceID           varchar(50)          not null,
   CreateTime           datetime             not null,
   constraint PK_R_RESOURCE_FAVORITE primary key (UId, ResourceID)
)
go

/*==============================================================*/
/* Table: r_textbook                                            */
/*==============================================================*/
create table r_textbook (
   Id                   varchar(36)          not null,
   ClssId               int                  not null,
   ClssName             varchar(100)         null,
   TextBookPath         varchar(100)         null,
   ThumbnailsPath       varchar(100)         null,
   constraint PK_R_TEXTBOOK primary key (Id)
)
go

alter table r_resource
   add constraint FK_R_RESOUR_REFERENCE_R_FILES foreign key (FileID)
      references r_files (Id)
go

alter table r_resource_approve
   add constraint FK_RESOURCE_REFERENCE_APPROVE foreign key (ResourceID)
      references r_resource (ResourceID)
go

alter table r_resource_down
   add constraint FK_RESOURCE_REFERENCE_DOWN foreign key (ResourceID)
      references r_resource (ResourceID)
go

alter table r_resource_favorite
   add constraint FK_RESOURCE_REFERENCE_FAVORITE foreign key (ResourceID)
      references r_resource (ResourceID)
go





/*==================================================================================数据初始化=========================================================================================*/

--数据初始化

--学校
INSERT INTO [dbo].[sy_school]([Id],[Name]) VALUES (1,'XXX小学')
GO

--系统导航
SET IDENTITY_INSERT [dbo].[sy_system] ON
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (1, NULL, 1, N'基础平台', NULL, 1, NULL, 1, 1, 901, 1, 1)
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (2, 1, 2, N'数据权限中心', N'/SyUserManager/Index', 1, NULL, 2, 1, 902, 1, 1)
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (3, NULL, 1, N'教学平台', NULL, 1, NULL, 1, 1, 201, 1, 1)
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (4, 3, 2, N'同步备课', N'http://192.168.3.2:4322/PreLesson/page/UserStandBook.aspx?type=1', 2, NULL, 2, 1, 202, 1, 0)
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (5, 3, 2, N'互动教学', N'http://192.168.3.2:4322/AttLesson/Page/SelectBook.aspx?type=1', 2, NULL, 2, 1, 203, 1, 0)
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (6, NULL, 1, N'资源平台', NULL, 1, NULL, 1, 1, 101, 1, 1)
INSERT [dbo].[sy_system] ([Id], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled], [IsNav]) VALUES (7, 6, 2, N'同步资源库', N'/ResourceHome/Index', 1, NULL, 2, 1, 102, 1, 1)
SET IDENTITY_INSERT [dbo].[sy_system] OFF
GO

--导航
SET IDENTITY_INSERT [dbo].[sy_nav] ON
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (1, 2, NULL, 3, N'数据权限中心', NULL, 1, NULL, 1, 1, 10, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (2, 2, 1, 1, N'用户权限', NULL, 1, N'a1', 1, 1, 101, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (3, 2, 2, 2, N'管理员用户', N'/SyUserManager/Index', 1, NULL, 2, 1, 102, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (4, 2, 2, 2, N'教职工用户', N'/SyUserTeacher/Index', 1, NULL, 2, 1, 103, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (5, 2, 2, 2, N'学生用户', N'/SyUserStudent/Index', 1, NULL, 2, 1, 104, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (6, 2, 2, 2, N'角色管理', N'/SyRole/Index', 1, NULL, 2, 1, 105, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (7, 2, 1, 1, N'应用管理', NULL, 1, N'a2', 1, 1, 201, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (8, 2, 7, 2, N'门户管理', NULL, 1, NULL, 2, 1, 202, 0)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (9, 2, 7, 2, N'资源库管理', NULL, 1, NULL, 2, 1, 203, 0)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (10, 2, 7, 2, N'题库管理', NULL, 1, NULL, 2, 1, 204, 0)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (11, 2, 1, 1, N'基础数据', NULL, 1, N'a3', 1, 1, 301, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (12, 2, 11, 2, N'学校信息', N'/SySchool/Index', 1, NULL, 2, 1, 302, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (13, 2, 11, 2, N'年级管理', N'/SyGrade/Index', 1, NULL, 2, 1, 303, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (14, 2, 11, 2, N'班级管理', N'/SyClass/Index', 1, NULL, 2, 1, 304, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (15, 2, 11, 2, N'学科管理', N'/DictSubject/Index', 1, NULL, 2, 1, 305, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (16, 2, 1, 1, N'运维管理', NULL, 1, N'a4', 1, 1, 401, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (17, 2, 16, 2, N'系统导航', N'/SyNavSystem/Index', 1, NULL, 2, 1, 402, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (18, 2, 16, 2, N'左侧导航', N'/SyNav/Index', 1, NULL, 2, 1, 403, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (19, 2, 16, 2, N'运行监控', N'/SyLogPerf/Index', 1, NULL, 2, 1, 404, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (21, 2, 16, 2, N'初始设置', N'/SyInit/Index', 1, NULL, 2, 1, 405, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (22, 7, NULL, 3, N'同步资源库', NULL, 1, NULL, 1, 1, 15, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (23, 7, 22, 1, N'资源首页', N'/ResourceHome/Index', 1, N't1', 1, 1, 10, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (24, 7, 22, 1, N'资源检索', NULL, 1, N't2', 1, 1, 20, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (25, 7, 24, 2, N'语文', N'/ResourceSearch/Index/1', 1, NULL, 2, 1, 21, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (26, 7, 24, 2, N'数学', N'/ResourceSearch/Index/2', 1, NULL, 2, 1, 22, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (27, 7, 24, 2, N'英语', N'/ResourceSearch/Index/3', 1, NULL, 2, 1, 23, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (28, 7, 22, 1, N'我的资源', NULL, 1, N't3', 1, 1, 30, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (29, 7, 28, 2, N'全部资源', N'/Resource/Index/0', 1, NULL, 2, 1, 31, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (30, 7, 28, 2, N'我的收藏', N'/Resource/Index/1', 1, NULL, 2, 1, 32, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (31, 7, 28, 2, N'我的上传', N'/Resource/Index/2', 1, NULL, 2, 1, 33, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (32, 7, 22, 1, N'资源上传', N'/ResourceUpLoad/Index', 1, N't4', 1, 1, 40, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (33, 7, 22, 1, N'资源动态', NULL, 1, N't5', 1, 1, 50, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (34, 7, 33, 2, N'语文', N'/ResourceDynamic/Index/1', 1, NULL, 2, 1, 51, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (35, 7, 33, 2, N'数学', N'/ResourceDynamic/Index/2', 1, NULL, 2, 1, 52, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (36, 7, 33, 2, N'英语', N'/ResourceDynamic/Index/3', 1, NULL, 2, 1, 53, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (37, 7, 22, 1, N'资源审核', NULL, 1, N't6', 1, 1, 60, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (38, 7, 37, 2, N'语文', N'/ResourceApprove/Index/1', 1, NULL, 2, 1, 61, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (39, 7, 37, 2, N'数学', N'/ResourceApprove/Index/2', 1, NULL, 2, 1, 62, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (40, 7, 37, 2, N'英语', N'/ResourceApprove/Index/3', 1, NULL, 2, 1, 63, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (41, 4, NULL, 3, N'同步备课', NULL, 1, NULL, 1, 1, 20, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (42, 5, NULL, 3, N'互动教学', NULL, 1, NULL, 1, 1, 25, 1)
INSERT [dbo].[sy_nav] ([Id], [SId], [PId], [Type], [Name], [Url], [PageOpen], [Icon], [Level], [IsSystem], [Sort], [IsEnabled]) VALUES (50, 2, 7, 2, N'互动课堂', N'/SyLogRoomOper/Index', 1, NULL, 2, 1, 205, 1)
SET IDENTITY_INSERT [dbo].[sy_nav] OFF
GO

--角色表
SET IDENTITY_INSERT [dbo].[sy_role] ON
INSERT [dbo].[sy_role] ([Id], [Name], [Type], [IsSystem], [IsEnabled], [Remark]) VALUES (1, N'超级管理员', 4, 1, 1, NULL)
INSERT [dbo].[sy_role] ([Id], [Name], [Type], [IsSystem], [IsEnabled], [Remark]) VALUES (2, N'管理员', 4, 1, 1, NULL)
INSERT [dbo].[sy_role] ([Id], [Name], [Type], [IsSystem], [IsEnabled], [Remark]) VALUES (3, N'教师', 12, 1, 1, NULL)
INSERT [dbo].[sy_role] ([Id], [Name], [Type], [IsSystem], [IsEnabled], [Remark]) VALUES (4, N'学生', 26, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[sy_role] OFF
GO

--角色导航权限
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 1)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 2)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 3)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 4)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 5)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 6)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 7)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 11)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 12)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 13)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 14)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 15)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 16)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 17)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 18)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 19)
--INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 20)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 21)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (1, 50)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (2, 1)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (2, 2)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (2, 3)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (2, 4)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (2, 5)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (2, 6)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (3, 22)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (3, 28)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (3, 29)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (3, 30)
INSERT [dbo].[sy_role_and_nav] ([RoleId], [NavId]) VALUES (3, 31)
GO

--用户表
INSERT INTO [dbo].[sy_user]([Id],[Account],[Password],[Name],[Type],[IsSystem],[IsExpires],[IsEnabled],[CreateTime]) VALUES ('92E0AF7A-4C21-456C-82E8-B27E51CC3EDB','admin',HashBytes('MD5','1'),'方直管理员',4,'true','false','true','2010-1-1')
GO

--用户与角色关系表
INSERT INTO [dbo].[sy_user_and_role]([UserId],[RoleId],[Time]) VALUES ('92E0AF7A-4C21-456C-82E8-B27E51CC3EDB',1,'1900-01-01')
GO

--学科表
SET IDENTITY_INSERT [dbo].[dict_subject] ON
INSERT [dbo].[dict_subject] ([Id], [Name], [Sort], [IsEnabled], [IsSystem]) VALUES (1, N'语文', 1, 1, 1)
INSERT [dbo].[dict_subject] ([Id], [Name], [Sort], [IsEnabled], [IsSystem]) VALUES (2, N'数学', 2, 1, 1)
INSERT [dbo].[dict_subject] ([Id], [Name], [Sort], [IsEnabled], [IsSystem]) VALUES (3, N'英语', 3, 1, 1)
SET IDENTITY_INSERT [dbo].[dict_subject] OFF
GO

--版本表
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (1, N'人教PEP版', 1, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (2, N'外教一册', 2, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (3, N'北京版', 3, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (4, N'牛津上海版', 4, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (5, N'牛津上海全国版', 5, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (6, N'牛津少儿英语Let''s go', 6, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (7, N'新牛津幼儿英语 New English First!', 7, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (8, N'北师大版(一起)', 8, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (9, N'外研新标准(一起)', 9, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (10, N'人教版新起点', 10, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (11, N'冀教版(一起)', 11, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (12, N'科普版', 12, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (13, N'江苏牛津', 13, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (14, N'湘少版', 14, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (15, N'陕旅版', 15, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (16, N'人教版精通', 16, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (17, N'外研新交际', 17, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (18, N'朗文新派少儿英语', 18, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (19, N'译林新版', 19, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (20, N'湘教版', 20, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (21, N'牛津深圳版', 21, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (22, N'江苏译林', 22, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (24, N'广州版', 24, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (25, N'牛津上海本地版', 25, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (26, N'人教版语文', 26, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (27, N'人教版', 27, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (28, N'北京版数学', 28, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (29, N'语文S版', 29, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (30, N'山东版', 30, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (31, N'闽教版', 31, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (32, N'人教精通版', 32, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (33, N'人教新目标', 33, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (34, N'剑桥英语青少版', 34, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (35, N'牛津深圳版', 35, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (36, N'牛津译林版', 36, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (37, N'仁爱版', 37, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (39, N'广东版', 39, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (40, N'山东版小学英语三年级下册', 40, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (41, N'山东版小学英语四年级下册', 41, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (42, N'山东版小学英语五年级下册', 42, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (43, N'深港朗文版', 43, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (44, N'广州口语', 44, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (45, N'儿童英语', 45, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (46, N'广西人教版', 46, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (47, N'教科版', 47, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (48, N'鲁科版', 48, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (49, N'语文社必修', 49, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (50, N'语文A版', 50, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (51, N'西师大版', 51, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (52, N'浙教版', 52, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (53, N'鄂教版', 53, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (54, N'沪教版', 54, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (55, N'长春版', 55, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (56, N'鲁教版', 56, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (57, N'新课标标准实验版', 57, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (58, N'青岛版', 58, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (59, N'鲁人版', 59, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (60, N'粤教版', 60, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (61, N'外研新标准(三起)', 9, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (62, N'北师大版(三起)', 8, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (63, N'冀教版(三起)', 11, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (64, N'北师大版', 61, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (65, N'苏教版', 62, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (66, N'人教版(2016)', 63, 1)
INSERT [dbo].[dict_edition] ([Id], [Name], [Sort], [IsEnabled]) VALUES (67, N'小学英语拼读教程(全国通用版)', 64, 1)

--版本与学科关系表
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (1, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (2, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (3, 2, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (3, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (4, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (5, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (6, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (7, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (8, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (9, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (10, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (14, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (15, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (16, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (21, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (22, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (24, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (25, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (26, 1, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (27, 1, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (27, 2, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (28, 2, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (29, 1, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (30, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (31, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (33, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (39, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (44, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (61, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (63, 3, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (64, 2, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (65, 2, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (66, 1, 1)
INSERT [dbo].[dict_edition_and_subject] ([EditionId], [SubjectId], [IsEnabled]) VALUES (67, 3, 1)

--年级表
SET IDENTITY_INSERT [dbo].[sy_grade] ON
INSERT [dbo].[sy_grade] ([Id], [SGradeId], [Name], [Year], [Sort], [IsEnabled], [IsGraduate]) VALUES (1, 2, N'一年级', 2017, 1, 1, 0)
INSERT [dbo].[sy_grade] ([Id], [SGradeId], [Name], [Year], [Sort], [IsEnabled], [IsGraduate]) VALUES (2, 3, N'二年级', 2016, 2, 1, 0)
INSERT [dbo].[sy_grade] ([Id], [SGradeId], [Name], [Year], [Sort], [IsEnabled], [IsGraduate]) VALUES (3, 4, N'三年级', 2015, 3, 1, 0)
INSERT [dbo].[sy_grade] ([Id], [SGradeId], [Name], [Year], [Sort], [IsEnabled], [IsGraduate]) VALUES (4, 5, N'四年级', 2014, 4, 1, 0)
INSERT [dbo].[sy_grade] ([Id], [SGradeId], [Name], [Year], [Sort], [IsEnabled], [IsGraduate]) VALUES (5, 6, N'五年级', 2013, 5, 1, 0)
INSERT [dbo].[sy_grade] ([Id], [SGradeId], [Name], [Year], [Sort], [IsEnabled], [IsGraduate]) VALUES (6, 7, N'六年级', 2012, 6, 1, 0)
SET IDENTITY_INSERT [dbo].[sy_grade] OFF
GO

--班级表
SET IDENTITY_INSERT [dbo].[sy_class] ON
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (1, 1, N'一班', 6, 1, 2017, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (2, 1, N'二班', 7, 1, 2017, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (3, 1, N'三班', 8, 1, 2017, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (4, 1, N'四班', 9, 1, 2017, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (5, 1, N'五班', 10, 1, 2017, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (6, 2, N'一班', 11, 1, 2016, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (7, 2, N'二班', 12, 1, 2016, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (8, 2, N'三班', 13, 1, 2016, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (9, 2, N'四班', 14, 1, 2016, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (10, 2, N'五班', 15, 1, 2016, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (11, 3, N'一班', 16, 1, 2015, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (12, 3, N'二班', 17, 1, 2015, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (13, 3, N'三班', 18, 1, 2015, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (14, 3, N'四班', 19, 1, 2015, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (15, 3, N'五班', 20, 1, 2015, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (16, 4, N'一班', 21, 1, 2014, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (17, 4, N'二班', 22, 1, 2014, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (18, 4, N'三班', 23, 1, 2014, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (19, 4, N'四班', 24, 1, 2014, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (20, 4, N'五班', 25, 1, 2014, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (21, 5, N'一班', 26, 1, 2013, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (22, 5, N'二班', 27, 1, 2013, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (23, 5, N'三班', 28, 1, 2013, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (24, 5, N'四班', 29, 1, 2013, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (25, 5, N'五班', 30, 1, 2013, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (26, 6, N'一班', 31, 1, 2012, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (27, 6, N'二班', 32, 1, 2012, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (28, 6, N'三班', 33, 1, 2012, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (29, 6, N'四班', 34, 1, 2012, 0)
INSERT [dbo].[sy_class] ([Id], [GradeId], [Name], [Sort], [IsEnabled], [Year], [IsGraduate]) VALUES (30, 6, N'五班', 35, 1, 2012, 0)
SET IDENTITY_INSERT [dbo].[sy_class] OFF
GO

--教材
SET IDENTITY_INSERT [dbo].[dict_textbook] ON
INSERT [dbo].[dict_textbook] ([Id], [Stage], [Subject], [Grade], [Booklet], [Edition], [BookName], [ConfigFile], [Cover], [Remark], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (266, 2, 3, 5, 2, 21, N'牛津深圳版小学英语四年级下册', N'Course/TextBook/SZ4B/db.js', N'Course/TextBook/SZ4B/pagebg/fm.jpg', N'', CAST(0x0000A56F00AB307A AS DateTime), CAST(0x0000A56F00AB307A AS DateTime), 0)
INSERT [dbo].[dict_textbook] ([Id], [Stage], [Subject], [Grade], [Booklet], [Edition], [BookName], [ConfigFile], [Cover], [Remark], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (413, 2, 1, 2, 2, 66, N'人教版(2016)小学语文一年级下册', N'Course/TextBook/RJYW1B/db.js', N'Course/TextBook/RJYW1B/pagebg/fm.gif', N'新版', CAST(0x0000A6E80119A7E8 AS DateTime), CAST(0x0000A6E80119A7E8 AS DateTime), 0)
INSERT [dbo].[dict_textbook] ([Id], [Stage], [Subject], [Grade], [Booklet], [Edition], [BookName], [ConfigFile], [Cover], [Remark], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (421, 2, 2, 5, 2, 64, N'北师大版小学数学四年级下册', N'Course/TextBook/BSDSX4B/db.js', N'Course/TextBook/BSDSX4B/pagebg/fm/fm.gif', N'', CAST(0x0000A72B00A394F9 AS DateTime), CAST(0x0000A72B00A394F9 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[dict_textbook] OFF

--教材目录
SET IDENTITY_INSERT [dbo].[dict_textbook_catalog] ON
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282795, 266, N'Module 1 Using my five senses', 1, 0, CAST(0x0000A56F00AB8D8C AS DateTime), CAST(0x0000A56F00AB8D8C AS DateTime), 0, NULL, 2, 17)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282796, 266, N'Unit 1 Touch and feel', 1, 282795, CAST(0x0000A56F00AB8D8D AS DateTime), CAST(0x0000A56F00AB8D8D AS DateTime), 0, NULL, 2, 5)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282797, 266, N'Listen and say', 1, 282796, CAST(0x0000A56F00AB8D8D AS DateTime), CAST(0x0000A56F00AB8D8D AS DateTime), 0, NULL, 2, 2)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282798, 266, N'Look and learn', 2, 282796, CAST(0x0000A56F00AB8D8E AS DateTime), CAST(0x0000A56F00AB8D8E AS DateTime), 0, NULL, 3, 3)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282799, 266, N'Ask and answer', 3, 282796, CAST(0x0000A56F00AB8D8E AS DateTime), CAST(0x0000A56F00AB8D8E AS DateTime), 0, NULL, 3, 3)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282800, 266, N'Enjoy a story', 4, 282796, CAST(0x0000A56F00AB8D8E AS DateTime), CAST(0x0000A56F00AB8D8E AS DateTime), 0, NULL, 4, 4)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282801, 266, N'Listen and enjoy', 5, 282796, CAST(0x0000A56F00AB8D8F AS DateTime), CAST(0x0000A56F00AB8D8F AS DateTime), 0, NULL, 5, 5)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282802, 266, N'Learn the sounds', 6, 282796, CAST(0x0000A56F00AB8D8F AS DateTime), CAST(0x0000A56F00AB8D8F AS DateTime), 0, NULL, 5, 5)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282803, 266, N'Unit 2 Smell and taste', 2, 282795, CAST(0x0000A56F00AB8D8F AS DateTime), CAST(0x0000A56F00AB8D8F AS DateTime), 0, NULL, 6, 9)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282804, 266, N'Listen and say', 1, 282803, CAST(0x0000A56F00AB8D90 AS DateTime), CAST(0x0000A56F00AB8D90 AS DateTime), 0, NULL, 6, 6)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282805, 266, N'Look and learn', 2, 282803, CAST(0x0000A56F00AB8D90 AS DateTime), CAST(0x0000A56F00AB8D90 AS DateTime), 0, NULL, 7, 7)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282806, 266, N'Play a game', 3, 282803, CAST(0x0000A56F00AB8D90 AS DateTime), CAST(0x0000A56F00AB8D90 AS DateTime), 0, NULL, 7, 7)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282807, 266, N'Enjoy a story', 4, 282803, CAST(0x0000A56F00AB8D91 AS DateTime), CAST(0x0000A56F00AB8D91 AS DateTime), 0, NULL, 8, 8)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282808, 266, N'Draw and write', 5, 282803, CAST(0x0000A56F00AB8D91 AS DateTime), CAST(0x0000A56F00AB8D91 AS DateTime), 0, NULL, 9, 9)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282809, 266, N'Learn the sounds', 6, 282803, CAST(0x0000A56F00AB8D91 AS DateTime), CAST(0x0000A56F00AB8D91 AS DateTime), 0, NULL, 9, 9)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282810, 266, N'Unit 3 Look and see', 3, 282795, CAST(0x0000A56F00AB8D92 AS DateTime), CAST(0x0000A56F00AB8D92 AS DateTime), 0, NULL, 10, 13)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282811, 266, N'Listen and say', 1, 282810, CAST(0x0000A56F00AB8D93 AS DateTime), CAST(0x0000A56F00AB8D93 AS DateTime), 0, NULL, 10, 10)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282812, 266, N'Look and learn', 2, 282810, CAST(0x0000A56F00AB8D93 AS DateTime), CAST(0x0000A56F00AB8D93 AS DateTime), 0, NULL, 11, 11)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282813, 266, N'Sing a song', 3, 282810, CAST(0x0000A56F00AB8D93 AS DateTime), CAST(0x0000A56F00AB8D93 AS DateTime), 0, NULL, 11, 11)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282814, 266, N'Enjoy a story', 4, 282810, CAST(0x0000A56F00AB8D93 AS DateTime), CAST(0x0000A56F00AB8D93 AS DateTime), 0, NULL, 12, 12)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282815, 266, N'Make and say', 5, 282810, CAST(0x0000A56F00AB8D94 AS DateTime), CAST(0x0000A56F00AB8D94 AS DateTime), 0, NULL, 13, 13)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282816, 266, N'Learn the sounds', 6, 282810, CAST(0x0000A56F00AB8D94 AS DateTime), CAST(0x0000A56F00AB8D94 AS DateTime), 0, NULL, 13, 13)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282817, 266, N'Revision 1', 4, 282795, CAST(0x0000A56F00AB8D94 AS DateTime), CAST(0x0000A56F00AB8D94 AS DateTime), 0, NULL, 14, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282818, 266, N'Let''s revise (I)', 1, 282817, CAST(0x0000A56F00AB8D95 AS DateTime), CAST(0x0000A56F00AB8D95 AS DateTime), 0, NULL, 14, 14)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282819, 266, N'Play a game', 2, 282817, CAST(0x0000A56F00AB8D95 AS DateTime), CAST(0x0000A56F00AB8D95 AS DateTime), 0, NULL, 14, 14)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282820, 266, N'Let''s revise (II)', 3, 282817, CAST(0x0000A56F00AB8D96 AS DateTime), CAST(0x0000A56F00AB8D96 AS DateTime), 0, NULL, 15, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282821, 266, N'Read and write', 4, 282817, CAST(0x0000A56F00AB8D96 AS DateTime), CAST(0x0000A56F00AB8D96 AS DateTime), 0, NULL, 15, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282822, 266, N'Think and circle', 5, 282817, CAST(0x0000A56F00AB8D96 AS DateTime), CAST(0x0000A56F00AB8D96 AS DateTime), 0, NULL, 15, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282823, 266, N'Project 1', 5, 282795, CAST(0x0000A56F00AB8D96 AS DateTime), CAST(0x0000A56F00AB8D96 AS DateTime), 0, NULL, 16, 17)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282824, 266, N'Module 2 My favourite things', 8, 0, CAST(0x0000A56F00AB8D97 AS DateTime), CAST(0x0000A56F00AB8D97 AS DateTime), 0, NULL, 18, 33)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282825, 266, N'Unit 4 Subjects', 1, 282824, CAST(0x0000A56F00AB8D97 AS DateTime), CAST(0x0000A56F00AB8D97 AS DateTime), 0, NULL, 18, 21)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282826, 266, N'Listen and say', 1, 282825, CAST(0x0000A56F00AB8D98 AS DateTime), CAST(0x0000A56F00AB8D98 AS DateTime), 0, NULL, 18, 18)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282827, 266, N'Look and learn', 2, 282825, CAST(0x0000A56F00AB8D99 AS DateTime), CAST(0x0000A56F00AB8D99 AS DateTime), 0, NULL, 19, 19)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282828, 266, N'Do a survey', 3, 282825, CAST(0x0000A56F00AB8D99 AS DateTime), CAST(0x0000A56F00AB8D99 AS DateTime), 0, NULL, 19, 19)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282829, 266, N'Look and read', 4, 282825, CAST(0x0000A56F00AB8D99 AS DateTime), CAST(0x0000A56F00AB8D99 AS DateTime), 0, NULL, 20, 20)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282830, 266, N'Think and write', 5, 282825, CAST(0x0000A56F00AB8D99 AS DateTime), CAST(0x0000A56F00AB8D99 AS DateTime), 0, NULL, 21, 21)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282831, 266, N'Learn the sounds', 6, 282825, CAST(0x0000A56F00AB8D9A AS DateTime), CAST(0x0000A56F00AB8D9A AS DateTime), 0, NULL, 21, 21)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282832, 266, N'Unit 5 Sport', 2, 282824, CAST(0x0000A56F00AB8D9A AS DateTime), CAST(0x0000A56F00AB8D9A AS DateTime), 0, NULL, 22, 25)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282833, 266, N'Listen and say', 1, 282832, CAST(0x0000A56F00AB8D9B AS DateTime), CAST(0x0000A56F00AB8D9B AS DateTime), 0, NULL, 22, 22)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282834, 266, N'Look and learn', 2, 282832, CAST(0x0000A56F00AB8D9B AS DateTime), CAST(0x0000A56F00AB8D9B AS DateTime), 0, NULL, 23, 23)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282835, 266, N'Ask and answer', 3, 282832, CAST(0x0000A56F00AB8D9B AS DateTime), CAST(0x0000A56F00AB8D9B AS DateTime), 0, NULL, 23, 23)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282836, 266, N'Say and act', 4, 282832, CAST(0x0000A56F00AB8D9C AS DateTime), CAST(0x0000A56F00AB8D9C AS DateTime), 0, NULL, 24, 24)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282837, 266, N'Think and write', 5, 282832, CAST(0x0000A56F00AB8D9C AS DateTime), CAST(0x0000A56F00AB8D9C AS DateTime), 0, NULL, 25, 25)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282838, 266, N'Learn the sounds', 6, 282832, CAST(0x0000A56F00AB8D9C AS DateTime), CAST(0x0000A56F00AB8D9C AS DateTime), 0, NULL, 25, 25)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282839, 266, N'Unit 6 Music', 3, 282824, CAST(0x0000A56F00AB8D9C AS DateTime), CAST(0x0000A56F00AB8D9C AS DateTime), 0, NULL, 26, 29)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282840, 266, N'Listen and say', 1, 282839, CAST(0x0000A56F00AB8D9D AS DateTime), CAST(0x0000A56F00AB8D9D AS DateTime), 0, NULL, 26, 26)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282841, 266, N'Look and learn', 2, 282839, CAST(0x0000A56F00AB8D9D AS DateTime), CAST(0x0000A56F00AB8D9D AS DateTime), 0, NULL, 27, 27)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282842, 266, N'Ask and answer', 3, 282839, CAST(0x0000A56F00AB8D9E AS DateTime), CAST(0x0000A56F00AB8D9E AS DateTime), 0, NULL, 27, 27)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282843, 266, N'Enjoy a story', 4, 282839, CAST(0x0000A56F00AB8D9E AS DateTime), CAST(0x0000A56F00AB8D9E AS DateTime), 0, NULL, 28, 28)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282844, 266, N'Sing a song', 5, 282839, CAST(0x0000A56F00AB8D9E AS DateTime), CAST(0x0000A56F00AB8D9E AS DateTime), 0, NULL, 29, 29)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282845, 266, N'Learn the sounds', 6, 282839, CAST(0x0000A56F00AB8D9F AS DateTime), CAST(0x0000A56F00AB8D9F AS DateTime), 0, NULL, 29, 29)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282846, 266, N'Revision 2', 4, 282824, CAST(0x0000A56F00AB8D9F AS DateTime), CAST(0x0000A56F00AB8D9F AS DateTime), 0, NULL, 30, 31)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282847, 266, N'Let''s revise (I）', 1, 282846, CAST(0x0000A56F00AB8D9F AS DateTime), CAST(0x0000A56F00AB8D9F AS DateTime), 0, NULL, 30, 30)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282848, 266, N'Write and say', 2, 282846, CAST(0x0000A56F00AB8DA0 AS DateTime), CAST(0x0000A56F00AB8DA0 AS DateTime), 0, NULL, 30, 30)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282849, 266, N'Let''s revise (II）', 3, 282846, CAST(0x0000A56F00AB8DA0 AS DateTime), CAST(0x0000A56F00AB8DA0 AS DateTime), 0, NULL, 31, 31)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282850, 266, N'Play a game', 4, 282846, CAST(0x0000A56F00AB8DA0 AS DateTime), CAST(0x0000A56F00AB8DA0 AS DateTime), 0, NULL, 31, 31)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282851, 266, N'Think and circle', 5, 282846, CAST(0x0000A56F00AB8DA1 AS DateTime), CAST(0x0000A56F00AB8DA1 AS DateTime), 0, NULL, 31, 31)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282852, 266, N'Project 2', 5, 282824, CAST(0x0000A56F00AB8DA1 AS DateTime), CAST(0x0000A56F00AB8DA1 AS DateTime), 0, NULL, 32, 33)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282853, 266, N'Module 3 My colourful life', 13, 0, CAST(0x0000A56F00AB8DA1 AS DateTime), CAST(0x0000A56F00AB8DA1 AS DateTime), 0, NULL, 34, 49)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282854, 266, N'Unit 7 My day', 1, 282853, CAST(0x0000A56F00AB8DA2 AS DateTime), CAST(0x0000A56F00AB8DA2 AS DateTime), 0, NULL, 34, 37)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282855, 266, N'Listen and say', 1, 282854, CAST(0x0000A56F00AB8DA3 AS DateTime), CAST(0x0000A56F00AB8DA3 AS DateTime), 0, NULL, 34, 34)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282856, 266, N'Look and learn', 2, 282854, CAST(0x0000A56F00AB8DA3 AS DateTime), CAST(0x0000A56F00AB8DA3 AS DateTime), 0, NULL, 35, 35)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282857, 266, N'Ask and answer', 3, 282854, CAST(0x0000A56F00AB8DA3 AS DateTime), CAST(0x0000A56F00AB8DA3 AS DateTime), 0, NULL, 35, 35)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282858, 266, N'Enjoy a story', 4, 282854, CAST(0x0000A56F00AB8DA4 AS DateTime), CAST(0x0000A56F00AB8DA4 AS DateTime), 0, NULL, 36, 36)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282859, 266, N'Think and write', 5, 282854, CAST(0x0000A56F00AB8DA4 AS DateTime), CAST(0x0000A56F00AB8DA4 AS DateTime), 0, NULL, 37, 37)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282860, 266, N'Learn the sounds', 6, 282854, CAST(0x0000A56F00AB8DA4 AS DateTime), CAST(0x0000A56F00AB8DA4 AS DateTime), 0, NULL, 37, 37)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282861, 266, N'Unit 8 Days of the week', 2, 282853, CAST(0x0000A56F00AB8DA5 AS DateTime), CAST(0x0000A56F00AB8DA5 AS DateTime), 0, NULL, 38, 41)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282862, 266, N'Listen and say', 1, 282861, CAST(0x0000A56F00AB8DA5 AS DateTime), CAST(0x0000A56F00AB8DA5 AS DateTime), 0, NULL, 38, 38)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282863, 266, N'Look and learn', 2, 282861, CAST(0x0000A56F00AB8DA5 AS DateTime), CAST(0x0000A56F00AB8DA5 AS DateTime), 0, NULL, 39, 39)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282864, 266, N'Think and write', 3, 282861, CAST(0x0000A56F00AB8DA6 AS DateTime), CAST(0x0000A56F00AB8DA6 AS DateTime), 0, NULL, 39, 39)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282865, 266, N'Enjoy a story', 4, 282861, CAST(0x0000A56F00AB8DA6 AS DateTime), CAST(0x0000A56F00AB8DA6 AS DateTime), 0, NULL, 40, 40)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282866, 266, N'Listen and enjoy', 5, 282861, CAST(0x0000A56F00AB8DA6 AS DateTime), CAST(0x0000A56F00AB8DA6 AS DateTime), 0, NULL, 41, 41)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282867, 266, N'Learn the sounds', 6, 282861, CAST(0x0000A56F00AB8DA7 AS DateTime), CAST(0x0000A56F00AB8DA7 AS DateTime), 0, NULL, 41, 41)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282868, 266, N'Unit 9 A friend in Australia', 3, 282853, CAST(0x0000A56F00AB8DA7 AS DateTime), CAST(0x0000A56F00AB8DA7 AS DateTime), 0, NULL, 42, 45)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282869, 266, N'Listen and say', 1, 282868, CAST(0x0000A56F00AB8DA8 AS DateTime), CAST(0x0000A56F00AB8DA8 AS DateTime), 0, NULL, 42, 42)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282870, 266, N'Look and learn', 2, 282868, CAST(0x0000A56F00AB8DA8 AS DateTime), CAST(0x0000A56F00AB8DA8 AS DateTime), 0, NULL, 43, 43)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282871, 266, N'Play a game', 3, 282868, CAST(0x0000A56F00AB8DA8 AS DateTime), CAST(0x0000A56F00AB8DA8 AS DateTime), 0, NULL, 43, 43)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282872, 266, N'Look and read', 4, 282868, CAST(0x0000A56F00AB8DA8 AS DateTime), CAST(0x0000A56F00AB8DA8 AS DateTime), 0, NULL, 44, 44)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282873, 266, N'Learn the sounds', 5, 282868, CAST(0x0000A56F00AB8DA9 AS DateTime), CAST(0x0000A56F00AB8DA9 AS DateTime), 0, NULL, 45, 45)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282874, 266, N'Revision 3', 4, 282853, CAST(0x0000A56F00AB8DA9 AS DateTime), CAST(0x0000A56F00AB8DA9 AS DateTime), 0, NULL, 46, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282875, 266, N'Let''s revise (I)', 1, 282874, CAST(0x0000A56F00AB8DAA AS DateTime), CAST(0x0000A56F00AB8DAA AS DateTime), 0, NULL, 46, 46)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282876, 266, N'Read and write', 2, 282874, CAST(0x0000A56F00AB8DAA AS DateTime), CAST(0x0000A56F00AB8DAA AS DateTime), 0, NULL, 46, 46)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282877, 266, N'Let''s revise (II)', 3, 282874, CAST(0x0000A56F00AB8DAB AS DateTime), CAST(0x0000A56F00AB8DAB AS DateTime), 0, NULL, 47, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282878, 266, N'Tick and say', 4, 282874, CAST(0x0000A56F00AB8DAB AS DateTime), CAST(0x0000A56F00AB8DAB AS DateTime), 0, NULL, 47, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282879, 266, N'Think and circle', 5, 282874, CAST(0x0000A56F00AB8DAB AS DateTime), CAST(0x0000A56F00AB8DAB AS DateTime), 0, NULL, 47, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282880, 266, N'Project 3', 5, 282853, CAST(0x0000A56F00AB8DAB AS DateTime), CAST(0x0000A56F00AB8DAB AS DateTime), 0, NULL, 48, 49)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282881, 266, N'Module 4 Things we enjoy', 24, 0, CAST(0x0000A56F00AB8DAC AS DateTime), CAST(0x0000A56F00AB8DAC AS DateTime), 0, NULL, 50, 63)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282882, 266, N'Unit 10 My garden', 1, 282881, CAST(0x0000A56F00AB8DAC AS DateTime), CAST(0x0000A56F00AB8DAC AS DateTime), 0, NULL, 50, 53)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282883, 266, N'Listen and say', 1, 282882, CAST(0x0000A56F00AB8DAD AS DateTime), CAST(0x0000A56F00AB8DAD AS DateTime), 0, NULL, 50, 50)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282884, 266, N'Look and learn', 2, 282882, CAST(0x0000A56F00AB8DAD AS DateTime), CAST(0x0000A56F00AB8DAD AS DateTime), 0, NULL, 51, 51)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282885, 266, N'Think and say', 3, 282882, CAST(0x0000A56F00AB8DAE AS DateTime), CAST(0x0000A56F00AB8DAE AS DateTime), 0, NULL, 51, 51)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282886, 266, N'Enjoy a story', 4, 282882, CAST(0x0000A56F00AB8DAE AS DateTime), CAST(0x0000A56F00AB8DAE AS DateTime), 0, NULL, 52, 52)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282887, 266, N'Read and match', 5, 282882, CAST(0x0000A56F00AB8DAE AS DateTime), CAST(0x0000A56F00AB8DAE AS DateTime), 0, NULL, 53, 53)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282888, 266, N'Unit 11 Children''s Day', 2, 282881, CAST(0x0000A56F00AB8DAE AS DateTime), CAST(0x0000A56F00AB8DAE AS DateTime), 0, NULL, 54, 57)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282889, 266, N'Listen and say', 1, 282888, CAST(0x0000A56F00AB8DAF AS DateTime), CAST(0x0000A56F00AB8DAF AS DateTime), 0, NULL, 54, 54)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282890, 266, N'Look and learn', 2, 282888, CAST(0x0000A56F00AB8DB0 AS DateTime), CAST(0x0000A56F00AB8DB0 AS DateTime), 0, NULL, 55, 55)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282891, 266, N'Think and write', 3, 282888, CAST(0x0000A56F00AB8DB0 AS DateTime), CAST(0x0000A56F00AB8DB0 AS DateTime), 0, NULL, 55, 55)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282892, 266, N'Look and read', 4, 282888, CAST(0x0000A56F00AB8DB0 AS DateTime), CAST(0x0000A56F00AB8DB0 AS DateTime), 0, NULL, 56, 56)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282893, 266, N'Do a survey', 5, 282888, CAST(0x0000A56F00AB8DB0 AS DateTime), CAST(0x0000A56F00AB8DB0 AS DateTime), 0, NULL, 57, 57)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282894, 266, N'Unit 12 The ugly duckling', 3, 282881, CAST(0x0000A56F00AB8DB1 AS DateTime), CAST(0x0000A56F00AB8DB1 AS DateTime), 0, NULL, 58, 61)
GO
print 'Processed 100 total records'
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (282895, 266, N'Project 4', 4, 282881, CAST(0x0000A56F00AB8DB1 AS DateTime), CAST(0x0000A56F00AB8DB1 AS DateTime), 0, NULL, 62, 63)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (298465, 266, N'Word list 1', 24, 0, CAST(0x0000A6B10106A058 AS DateTime), CAST(0x0000A6B10106A058 AS DateTime), 0, NULL, 64, 66)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (298466, 266, N'Word list 2', 24, 0, CAST(0x0000A6B10106AD82 AS DateTime), CAST(0x0000A6B10106AD82 AS DateTime), 0, NULL, 67, 69)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (298467, 266, N'Daily expressions', 24, 0, CAST(0x0000A6B10106BDBE AS DateTime), CAST(0x0000A6B10106BDBE AS DateTime), 0, NULL, 70, 70)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300000, 413, N'识字一', 1, 0, CAST(0x0000A6E8011CFB2A AS DateTime), CAST(0x0000A6E8011CFB2A AS DateTime), 0, NULL, 2, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300001, 413, N'1 春夏秋冬', 1, 300000, CAST(0x0000A6E8011CFB2C AS DateTime), CAST(0x0000A6E8011CFB2C AS DateTime), 0, NULL, 2, 3)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300002, 413, N'2 姓氏歌', 2, 300000, CAST(0x0000A6E8011CFB2C AS DateTime), CAST(0x0000A6E8011CFB2C AS DateTime), 0, NULL, 4, 5)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300003, 413, N'3 小青蛙', 3, 300000, CAST(0x0000A6E8011CFB2D AS DateTime), CAST(0x0000A6E8011CFB2D AS DateTime), 0, NULL, 6, 7)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300004, 413, N'4 猜字谜', 4, 300000, CAST(0x0000A6E8011CFB2E AS DateTime), CAST(0x0000A6E8011CFB2E AS DateTime), 0, NULL, 9, 10)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300005, 413, N'语文园地一', 5, 300000, CAST(0x0000A6E8011CFB2E AS DateTime), CAST(0x0000A6E8011CFB2E AS DateTime), 0, NULL, 11, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300006, 413, N'课文一', 3, 0, CAST(0x0000A6E8011CFB2F AS DateTime), CAST(0x0000A6E8011CFB2F AS DateTime), 0, NULL, 17, 28)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300007, 413, N'1 吃水不忘挖井人', 1, 300006, CAST(0x0000A6E8011CFB2F AS DateTime), CAST(0x0000A6E8011CFB2F AS DateTime), 0, NULL, 17, 18)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300008, 413, N'2 我多想去看看', 2, 300006, CAST(0x0000A6E8011CFB30 AS DateTime), CAST(0x0000A6E8011CFB30 AS DateTime), 0, NULL, 19, 20)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300009, 413, N'3 一个接一个', 3, 300006, CAST(0x0000A6E8011CFB31 AS DateTime), CAST(0x0000A6E8011CFB31 AS DateTime), 0, NULL, 21, 23)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300010, 413, N'4 四个太阳', 4, 300006, CAST(0x0000A6E8011CFB31 AS DateTime), CAST(0x0000A6E8011CFB31 AS DateTime), 0, NULL, 24, 25)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300011, 413, N'语文园地二', 5, 300006, CAST(0x0000A6E8011CFB32 AS DateTime), CAST(0x0000A6E8011CFB32 AS DateTime), 0, NULL, 26, 28)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300012, 413, N'课文二', 3, 0, CAST(0x0000A6E8011CFB32 AS DateTime), CAST(0x0000A6E8011CFB32 AS DateTime), 0, NULL, 29, 42)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300013, 413, N'5 小公鸡和小鸭子', 1, 300012, CAST(0x0000A6E8011CFB33 AS DateTime), CAST(0x0000A6E8011CFB33 AS DateTime), 0, NULL, 29, 31)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300014, 413, N'6 树和喜鹊', 2, 300012, CAST(0x0000A6E8011CFB34 AS DateTime), CAST(0x0000A6E8011CFB34 AS DateTime), 0, NULL, 32, 34)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300015, 413, N'7 怎么都快乐', 3, 300012, CAST(0x0000A6E8011CFB34 AS DateTime), CAST(0x0000A6E8011CFB34 AS DateTime), 0, NULL, 35, 37)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300016, 413, N'语文园地三', 4, 300012, CAST(0x0000A6E8011CFB35 AS DateTime), CAST(0x0000A6E8011CFB35 AS DateTime), 0, NULL, 39, 42)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300017, 413, N'课文三', 4, 0, CAST(0x0000A6E8011CFB35 AS DateTime), CAST(0x0000A6E8011CFB35 AS DateTime), 0, NULL, 43, 53)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300018, 413, N'8 静夜思', 1, 300017, CAST(0x0000A6E8011CFB36 AS DateTime), CAST(0x0000A6E8011CFB36 AS DateTime), 0, NULL, 43, 43)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300019, 413, N'9 夜色', 2, 300017, CAST(0x0000A6E8011CFB37 AS DateTime), CAST(0x0000A6E8011CFB37 AS DateTime), 0, NULL, 44, 45)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300020, 413, N'10 端午粽', 3, 300017, CAST(0x0000A6E8011CFB37 AS DateTime), CAST(0x0000A6E8011CFB37 AS DateTime), 0, NULL, 46, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300021, 413, N'11 彩虹', 4, 300017, CAST(0x0000A6E8011CFB38 AS DateTime), CAST(0x0000A6E8011CFB38 AS DateTime), 0, NULL, 48, 50)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300022, 413, N'语文园地四', 5, 300017, CAST(0x0000A6E8011CFB38 AS DateTime), CAST(0x0000A6E8011CFB38 AS DateTime), 0, NULL, 51, 53)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300023, 413, N'识字二', 5, 0, CAST(0x0000A6E8011CFB39 AS DateTime), CAST(0x0000A6E8011CFB39 AS DateTime), 0, NULL, 54, 66)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300024, 413, N'5 动物儿歌', 1, 300023, CAST(0x0000A6E8011CFB3A AS DateTime), CAST(0x0000A6E8011CFB3A AS DateTime), 0, NULL, 54, 55)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300025, 413, N'6 古对今', 2, 300023, CAST(0x0000A6E8011CFB3A AS DateTime), CAST(0x0000A6E8011CFB3A AS DateTime), 0, NULL, 56, 57)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300026, 413, N'7 操场上', 3, 300023, CAST(0x0000A6E8011CFB3B AS DateTime), CAST(0x0000A6E8011CFB3B AS DateTime), 0, NULL, 58, 59)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300027, 413, N'8 人之初', 4, 300023, CAST(0x0000A6E8011CFB3B AS DateTime), CAST(0x0000A6E8011CFB3B AS DateTime), 0, NULL, 60, 61)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300028, 413, N'语文园地五', 5, 300023, CAST(0x0000A6E8011CFB3C AS DateTime), CAST(0x0000A6E8011CFB3C AS DateTime), 0, NULL, 63, 66)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300029, 413, N'课文四', 6, 0, CAST(0x0000A6E8011CFB3C AS DateTime), CAST(0x0000A6E8011CFB3C AS DateTime), 0, NULL, 67, 81)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300030, 413, N'12 古诗二首', 1, 300029, CAST(0x0000A6E8011CFB3D AS DateTime), CAST(0x0000A6E8011CFB3D AS DateTime), 0, NULL, 67, 69)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300031, 413, N'池上', 1, 300030, CAST(0x0000A6E8011CFB3E AS DateTime), CAST(0x0000A6E8011CFB3E AS DateTime), 0, NULL, 67, 67)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300032, 413, N'小池', 2, 300030, CAST(0x0000A6E8011CFB3E AS DateTime), CAST(0x0000A6E8011CFB3E AS DateTime), 0, NULL, 68, 69)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300033, 413, N'13 荷叶圆圆', 2, 300029, CAST(0x0000A6E8011CFB3F AS DateTime), CAST(0x0000A6E8011CFB3F AS DateTime), 0, NULL, 70, 72)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300034, 413, N'14 要下雨了', 3, 300029, CAST(0x0000A6E8011CFB40 AS DateTime), CAST(0x0000A6E8011CFB40 AS DateTime), 0, NULL, 73, 76)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300035, 413, N'语文园地六', 4, 300029, CAST(0x0000A6E8011CFB40 AS DateTime), CAST(0x0000A6E8011CFB40 AS DateTime), 0, NULL, 77, 81)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300036, 413, N'课文五', 7, 0, CAST(0x0000A6E8011CFB41 AS DateTime), CAST(0x0000A6E8011CFB41 AS DateTime), 0, NULL, 82, 101)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300037, 413, N'15 文具的家', 1, 300036, CAST(0x0000A6E8011CFB41 AS DateTime), CAST(0x0000A6E8011CFB41 AS DateTime), 0, NULL, 82, 84)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300038, 413, N'16 一分钟', 2, 300036, CAST(0x0000A6E8011CFB42 AS DateTime), CAST(0x0000A6E8011CFB42 AS DateTime), 0, NULL, 85, 87)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300039, 413, N'17 动物王国开大会', 3, 300036, CAST(0x0000A6E8011CFB43 AS DateTime), CAST(0x0000A6E8011CFB43 AS DateTime), 0, NULL, 88, 93)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300040, 413, N'18 小猴子下山', 4, 300036, CAST(0x0000A6E8011CFB43 AS DateTime), CAST(0x0000A6E8011CFB43 AS DateTime), 0, NULL, 94, 96)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300041, 413, N'语文园地七', 5, 300036, CAST(0x0000A6E8011CFB44 AS DateTime), CAST(0x0000A6E8011CFB44 AS DateTime), 0, NULL, 98, 101)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300042, 413, N'课文六', 8, 0, CAST(0x0000A6E8011CFB44 AS DateTime), CAST(0x0000A6E8011CFB44 AS DateTime), 0, NULL, 102, 116)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300043, 413, N'19 棉花姑娘', 1, 300042, CAST(0x0000A6E8011CFB45 AS DateTime), CAST(0x0000A6E8011CFB45 AS DateTime), 0, NULL, 102, 105)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300044, 413, N'20 咕咚', 2, 300042, CAST(0x0000A6E8011CFB46 AS DateTime), CAST(0x0000A6E8011CFB46 AS DateTime), 0, NULL, 106, 108)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300045, 413, N'21 小壁虎借尾巴', 3, 300042, CAST(0x0000A6E8011CFB46 AS DateTime), CAST(0x0000A6E8011CFB46 AS DateTime), 0, NULL, 109, 112)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300046, 413, N'语文园地八', 4, 300042, CAST(0x0000A6E8011CFB47 AS DateTime), CAST(0x0000A6E8011CFB47 AS DateTime), 0, NULL, 113, 116)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300939, 421, N'小数的意义和加减法', 1, 0, CAST(0x0000A72B00A3C35E AS DateTime), CAST(0x0000A72B00A3C35E AS DateTime), 0, 1, 2, 19)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300940, 421, N'小数的意义（一）', 1, 300939, CAST(0x0000A72B00A3C35F AS DateTime), CAST(0x0000A72B00A3C35F AS DateTime), 0, 2, 2, 3)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300941, 421, N'小数的意义（二）', 2, 300939, CAST(0x0000A72B00A3C361 AS DateTime), CAST(0x0000A72B00A3C361 AS DateTime), 0, 2, 4, 5)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300942, 421, N'小数的意义（三）', 3, 300939, CAST(0x0000A72B00A3C362 AS DateTime), CAST(0x0000A72B00A3C362 AS DateTime), 0, 2, 6, 8)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300943, 421, N'比大小', 4, 300939, CAST(0x0000A72B00A3C363 AS DateTime), CAST(0x0000A72B00A3C363 AS DateTime), 0, 2, 9, 10)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300944, 421, N'买菜', 5, 300939, CAST(0x0000A72B00A3C364 AS DateTime), CAST(0x0000A72B00A3C364 AS DateTime), 0, 2, 11, 12)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300945, 421, N'比身高', 6, 300939, CAST(0x0000A72B00A3C365 AS DateTime), CAST(0x0000A72B00A3C365 AS DateTime), 0, 2, 13, 15)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300946, 421, N'歌手大赛', 7, 300939, CAST(0x0000A72B00A3C366 AS DateTime), CAST(0x0000A72B00A3C366 AS DateTime), 0, 2, 16, 17)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300947, 421, N'练习一', 8, 300939, CAST(0x0000A72B00A3C367 AS DateTime), CAST(0x0000A72B00A3C367 AS DateTime), 0, 2, 18, 19)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300948, 421, N'认识三角形和四边形', 2, 0, CAST(0x0000A72B00A3C368 AS DateTime), CAST(0x0000A72B00A3C368 AS DateTime), 0, 1, 20, 32)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300949, 421, N'图形分类', 1, 300948, CAST(0x0000A72B00A3C36A AS DateTime), CAST(0x0000A72B00A3C36A AS DateTime), 0, 2, 20, 21)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300950, 421, N'三角形分类', 2, 300948, CAST(0x0000A72B00A3C36B AS DateTime), CAST(0x0000A72B00A3C36B AS DateTime), 0, 2, 22, 23)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300951, 421, N'探索与发现：三角形内角和', 3, 300948, CAST(0x0000A72B00A3C36C AS DateTime), CAST(0x0000A72B00A3C36C AS DateTime), 0, 2, 24, 26)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300952, 421, N'探索与发现：三角形边的关系', 4, 300948, CAST(0x0000A72B00A3C36D AS DateTime), CAST(0x0000A72B00A3C36D AS DateTime), 0, 2, 27, 28)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300953, 421, N'四边形分类', 5, 300948, CAST(0x0000A72B00A3C36E AS DateTime), CAST(0x0000A72B00A3C36E AS DateTime), 0, 2, 29, 30)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300954, 421, N'练习二', 6, 300948, CAST(0x0000A72B00A3C36F AS DateTime), CAST(0x0000A72B00A3C36F AS DateTime), 0, 2, 31, 32)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300955, 421, N'小数乘法', 3, 0, CAST(0x0000A72B00A3C370 AS DateTime), CAST(0x0000A72B00A3C370 AS DateTime), 0, 1, 33, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300956, 421, N'买文具', 1, 300955, CAST(0x0000A72B00A3C372 AS DateTime), CAST(0x0000A72B00A3C372 AS DateTime), 0, 2, 33, 34)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300957, 421, N'小数点搬家', 2, 300955, CAST(0x0000A72B00A3C373 AS DateTime), CAST(0x0000A72B00A3C373 AS DateTime), 0, 2, 35, 37)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300958, 421, N'街心广场', 3, 300955, CAST(0x0000A72B00A3C374 AS DateTime), CAST(0x0000A72B00A3C374 AS DateTime), 0, 2, 38, 39)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300959, 421, N'包装', 4, 300955, CAST(0x0000A72B00A3C375 AS DateTime), CAST(0x0000A72B00A3C375 AS DateTime), 0, 2, 40, 41)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300960, 421, N'蚕丝', 5, 300955, CAST(0x0000A72B00A3C376 AS DateTime), CAST(0x0000A72B00A3C376 AS DateTime), 0, 2, 42, 43)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300961, 421, N'手拉手', 6, 300955, CAST(0x0000A72B00A3C377 AS DateTime), CAST(0x0000A72B00A3C377 AS DateTime), 0, 2, 44, 45)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300962, 421, N'练习三', 7, 300955, CAST(0x0000A72B00A3C378 AS DateTime), CAST(0x0000A72B00A3C378 AS DateTime), 0, 2, 46, 47)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300963, 421, N'整理与复习', 4, 0, CAST(0x0000A72B00A3C379 AS DateTime), CAST(0x0000A72B00A3C379 AS DateTime), 0, 1, 48, 52)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300964, 421, N'我学到了什么', 1, 300963, CAST(0x0000A72B00A3C37B AS DateTime), CAST(0x0000A72B00A3C37B AS DateTime), 0, 2, 48, 48)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300965, 421, N'我的成长足迹', 2, 300963, CAST(0x0000A72B00A3C37C AS DateTime), CAST(0x0000A72B00A3C37C AS DateTime), 0, 2, 49, 49)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300966, 421, N'我提出的问题', 3, 300963, CAST(0x0000A72B00A3C37D AS DateTime), CAST(0x0000A72B00A3C37D AS DateTime), 0, 2, 49, 49)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300967, 421, N'我的数学日记', 4, 300963, CAST(0x0000A72B00A3C37E AS DateTime), CAST(0x0000A72B00A3C37E AS DateTime), 0, 2, 49, 49)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300968, 421, N'巩固应用', 5, 300963, CAST(0x0000A72B00A3C37F AS DateTime), CAST(0x0000A72B00A3C37F AS DateTime), 0, 2, 50, 52)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300969, 421, N'观察物体', 5, 0, CAST(0x0000A72B00A3C380 AS DateTime), CAST(0x0000A72B00A3C380 AS DateTime), 0, 1, 53, 60)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300970, 421, N'看一看', 1, 300969, CAST(0x0000A72B00A3C382 AS DateTime), CAST(0x0000A72B00A3C382 AS DateTime), 0, 2, 53, 54)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300971, 421, N'我说你搭', 2, 300969, CAST(0x0000A72B00A3C383 AS DateTime), CAST(0x0000A72B00A3C383 AS DateTime), 0, 2, 55, 56)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300972, 421, N'搭一搭', 3, 300969, CAST(0x0000A72B00A3C384 AS DateTime), CAST(0x0000A72B00A3C384 AS DateTime), 0, 2, 57, 58)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300973, 421, N'练习四', 4, 300969, CAST(0x0000A72B00A3C385 AS DateTime), CAST(0x0000A72B00A3C385 AS DateTime), 0, 2, 59, 60)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300974, 421, N'认识方程', 6, 0, CAST(0x0000A72B00A3C386 AS DateTime), CAST(0x0000A72B00A3C386 AS DateTime), 0, 1, 61, 75)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300975, 421, N'字母表示数', 1, 300974, CAST(0x0000A72B00A3C388 AS DateTime), CAST(0x0000A72B00A3C388 AS DateTime), 0, 2, 61, 63)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300976, 421, N'等量关系', 2, 300974, CAST(0x0000A72B00A3C389 AS DateTime), CAST(0x0000A72B00A3C389 AS DateTime), 0, 2, 64, 65)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300977, 421, N'方程', 3, 300974, CAST(0x0000A72B00A3C38A AS DateTime), CAST(0x0000A72B00A3C38A AS DateTime), 0, 2, 66, 67)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300978, 421, N'解方程（一）', 4, 300974, CAST(0x0000A72B00A3C38B AS DateTime), CAST(0x0000A72B00A3C38B AS DateTime), 0, 2, 68, 69)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300979, 421, N'解方程（二）', 5, 300974, CAST(0x0000A72B00A3C38E AS DateTime), CAST(0x0000A72B00A3C38E AS DateTime), 0, 2, 70, 71)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300980, 421, N'猜数游戏', 6, 300974, CAST(0x0000A72B00A3C38F AS DateTime), CAST(0x0000A72B00A3C38F AS DateTime), 0, 2, 72, 73)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300981, 421, N'练习五', 7, 300974, CAST(0x0000A72B00A3C390 AS DateTime), CAST(0x0000A72B00A3C390 AS DateTime), 0, 2, 74, 75)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300982, 421, N'数学好玩', 7, 0, CAST(0x0000A72B00A3C391 AS DateTime), CAST(0x0000A72B00A3C391 AS DateTime), 0, 1, 76, 82)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300983, 421, N'密铺', 1, 300982, CAST(0x0000A72B00A3C393 AS DateTime), CAST(0x0000A72B00A3C393 AS DateTime), 0, 2, 76, 78)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300984, 421, N'奥运中的数学', 2, 300982, CAST(0x0000A72B00A3C394 AS DateTime), CAST(0x0000A72B00A3C394 AS DateTime), 0, 2, 79, 80)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300985, 421, N'优化', 3, 300982, CAST(0x0000A72B00A3C395 AS DateTime), CAST(0x0000A72B00A3C395 AS DateTime), 0, 2, 81, 82)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300986, 421, N'数据的表示和分析', 8, 0, CAST(0x0000A72B00A3C396 AS DateTime), CAST(0x0000A72B00A3C396 AS DateTime), 0, 1, 83, 95)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300987, 421, N'生日', 1, 300986, CAST(0x0000A72B00A3C398 AS DateTime), CAST(0x0000A72B00A3C398 AS DateTime), 0, 2, 83, 84)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300988, 421, N'栽蒜苗（一）', 2, 300986, CAST(0x0000A72B00A3C399 AS DateTime), CAST(0x0000A72B00A3C399 AS DateTime), 0, 2, 85, 87)
GO
print 'Processed 200 total records'
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300989, 421, N'栽蒜苗（二）', 3, 300986, CAST(0x0000A72B00A3C39A AS DateTime), CAST(0x0000A72B00A3C39A AS DateTime), 0, 2, 88, 89)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300990, 421, N'平均数', 4, 300986, CAST(0x0000A72B00A3C39B AS DateTime), CAST(0x0000A72B00A3C39B AS DateTime), 0, 2, 90, 92)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300991, 421, N'练习六', 5, 300986, CAST(0x0000A72B00A3C39C AS DateTime), CAST(0x0000A72B00A3C39C AS DateTime), 0, 2, 93, 95)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300992, 421, N'总复习', 9, 0, CAST(0x0000A72B00A3C39D AS DateTime), CAST(0x0000A72B00A3C39D AS DateTime), 0, 1, 96, 102)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300993, 421, N'回顾与交流', 1, 300992, CAST(0x0000A72B00A3C39F AS DateTime), CAST(0x0000A72B00A3C39F AS DateTime), 0, 2, 96, 97)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300994, 421, N'数与代数', 1, 300993, CAST(0x0000A72B00A3C3A1 AS DateTime), CAST(0x0000A72B00A3C3A1 AS DateTime), 0, 3, 96, 96)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300995, 421, N'图形与几何', 2, 300993, CAST(0x0000A72B00A3C3A2 AS DateTime), CAST(0x0000A72B00A3C3A2 AS DateTime), 0, 3, 97, 97)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300996, 421, N'统计与概率', 3, 300993, CAST(0x0000A72B00A3C3A3 AS DateTime), CAST(0x0000A72B00A3C3A3 AS DateTime), 0, 3, 97, 97)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300997, 421, N'练习', 2, 300992, CAST(0x0000A72B00A3C3A4 AS DateTime), CAST(0x0000A72B00A3C3A4 AS DateTime), 0, 2, 98, 102)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300998, 421, N'数与代数', 1, 300997, CAST(0x0000A72B00A3C3A6 AS DateTime), CAST(0x0000A72B00A3C3A6 AS DateTime), 0, 3, 98, 100)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (300999, 421, N'图形与几何', 2, 300997, CAST(0x0000A72B00A3C3A7 AS DateTime), CAST(0x0000A72B00A3C3A7 AS DateTime), 0, 3, 101, 101)
INSERT [dbo].[dict_textbook_catalog] ([Id], [BookId], [FolderName], [Seq], [ParentId], [CreateDateTime], [ModifyDateTime], [Deleted], [Type], [PageStart], [PageEnd]) VALUES (301000, 421, N'统计与概率', 3, 300997, CAST(0x0000A72B00A3C3A8 AS DateTime), CAST(0x0000A72B00A3C3A8 AS DateTime), 0, 3, 102, 102)
SET IDENTITY_INSERT [dbo].[dict_textbook_catalog] OFF

--资源类型表
SET IDENTITY_INSERT [dbo].[dict_resource_type] ON
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (1, N'df7825e4-5a9c-487a-b954-9987a705b420', N'媒体素材', 1, 0, N'\1', CAST(0x0000A4A701033644 AS DateTime), CAST(0x0000A4A701033644 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (2, N'767189de-91a2-4c85-a109-5af51c15c1b3', N'文本', 2, 1, N'\1\2', CAST(0x0000A4A701033F05 AS DateTime), CAST(0x0000A4A701033F05 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (3, N'28ceb922-96df-4e75-a400-4249b6439419', N'图形', 3, 1, N'\1\3', CAST(0x0000A4A701034535 AS DateTime), CAST(0x0000A4A701034535 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (4, N'3df1d24b-22cf-4a01-b057-7429b4d648dc', N'视频', 4, 1, N'\1\4', CAST(0x0000A4A701034C08 AS DateTime), CAST(0x0000A4A701034C08 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (5, N'24e1ec8b-9fc5-4ba4-8fab-f870efcb9f2c', N'音频', 5, 1, N'\1\5', CAST(0x0000A4A701035503 AS DateTime), CAST(0x0000A4A701035503 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (6, N'66f25d39-3e17-467d-b082-80dc18c014d1', N'动画', 6, 1, N'\1\6', CAST(0x0000A4A701035A43 AS DateTime), CAST(0x0000A4A701035A43 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (7, N'd1a2815c-6c22-4d85-8e9a-0b9b14706ffb', N'量规集', 7, 0, N'\7', CAST(0x0000A4A70103681F AS DateTime), CAST(0x0000A4A70103681F AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (8, N'c282139b-95ac-4c0e-b16a-174686c4cadb', N'试题', 8, 7, N'\7\8', CAST(0x0000A4A701036DF9 AS DateTime), CAST(0x0000A4A701036DF9 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (9, N'a3cd62b1-26a5-4406-a1d0-e82853a0f163', N'试卷', 9, 7, N'\7\9', CAST(0x0000A4A701037688 AS DateTime), CAST(0x0000A4A701037688 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (10, N'd4752eea-97d2-421f-8c0b-9f35213ea782', N'课件', 10, 0, N'\10', CAST(0x0000A4A701037F18 AS DateTime), CAST(0x0000A4AB009907F6 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (11, N'1fd8b7a7-e20e-4a0c-a7e9-49d30087fb7a', N'案例', 11, 0, N'\11', CAST(0x0000A4A7010389FE AS DateTime), CAST(0x0000A4A7010389FE AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (12, N'7acb483c-d3c5-405c-8ef9-2d9fcd35d4f6', N'教案', 12, 11, N'\11\12', CAST(0x0000A4A701039085 AS DateTime), CAST(0x0000A4A701039085 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (13, N'4e703c41-33a0-4a26-8382-dd1e45b194d8', N'学案', 13, 11, N'\11\13', CAST(0x0000A4A701039A03 AS DateTime), CAST(0x0000A4A701039A03 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (14, N'c3a1b103-55f8-46f4-aec4-20ba733794e9', N'学生作品', 14, 11, N'\11\14', CAST(0x0000A4A70103A287 AS DateTime), CAST(0x0000A4A70103A287 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (15, N'f6ce6155-8ae4-4f50-a3ed-ff6dc0b5fc56', N'教学设计', 15, 11, N'\11\15', CAST(0x0000A4A70103AB1A AS DateTime), CAST(0x0000A4A70103AB1A AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (16, N'c05181c1-f953-495e-9b40-0656db15aa30', N'文献资料', 16, 0, N'\16', CAST(0x0000A4A70103B68A AS DateTime), CAST(0x0000A4A70103B68A AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (17, N'5ed7e111-6569-4a9c-b44e-e1d4ea08310c', N'论文', 17, 16, N'\16\17', CAST(0x0000A4A70103BC58 AS DateTime), CAST(0x0000A4A70103BC58 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (18, N'8fde1a30-eb94-414d-9ec8-d2b2e4813fab', N'报告', 18, 16, N'\16\18', CAST(0x0000A4A70103C19A AS DateTime), CAST(0x0000A4A70103C19A AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (19, N'6465c8c1-a650-4433-aaf8-9f54ace933d7', N'教学大纲', 19, 16, N'\16\19', CAST(0x0000A4A70103CA25 AS DateTime), CAST(0x0000A4A70103CA25 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (20, N'e67e5ccb-86ee-41b5-8c5a-7d8d7726c54b', N'工具书', 20, 16, N'\16\20', CAST(0x0000A4A70103D67B AS DateTime), CAST(0x0000A4A70103D67B AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (21, N'9fd25366-c29a-4b44-b69d-f8176c71be28', N'其他', 21, 16, N'\16\21', CAST(0x0000A4A70103DEB1 AS DateTime), CAST(0x0000A4A70103DEB1 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (22, N'7d6c2844-9f4f-4f79-b291-d9a6f994a3a6', N'课程', 22, 0, N'\22', CAST(0x0000A4A70103E7D5 AS DateTime), CAST(0x0000A4A70103E7D5 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (23, N'9051988e-5d3f-4888-ac3b-464d200fa275', N'教与学工具和模板', 23, 0, N'\23', CAST(0x0000A4A701040094 AS DateTime), CAST(0x0000A4A701040094 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (24, N'36b2e209-1261-4d3c-96dd-4feec8971f9b', N'课程设计软件', 24, 23, N'\23\24', CAST(0x0000A4A7010408CA AS DateTime), CAST(0x0000A4A701041D09 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (25, N'3b70953c-a87a-4d94-a4a1-804b2d35e820', N'学习工具软件', 25, 23, N'\23\25', CAST(0x0000A4A7010415C7 AS DateTime), CAST(0x0000A4A7010415C7 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (26, N'd2e0d9ea-67d5-4aff-990b-df1b90bc96a9', N'教学方法模板', 26, 23, N'\23\26', CAST(0x0000A4A701042C5C AS DateTime), CAST(0x0000A4A701042C5C AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (27, N'334c945c-51e9-4636-b2f7-ccdc5ee939af', N'互动课件', 27, 1, N'\1\27', CAST(0x0000A4AB00A50761 AS DateTime), CAST(0x0000A502009CF86B AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (28, N'7c77bdbc-a9c7-4f53-b1eb-4f23f525334d', N'图片', 28, 1, N'\1\28', CAST(0x0000A4AC0114824B AS DateTime), CAST(0x0000A4AC0114824B AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (29, N'c854310a-387a-47e5-b89d-570f03f644c8', N'自然拼读', 29, 22, N'\22\29', CAST(0x0000A71A00B61951 AS DateTime), CAST(0x0000A71A00B61951 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (30, N'b0346bc5-3437-4fe2-a44a-2dbf55a66714', N'课文动画', 30, 29, N'\22\29\30', CAST(0x0000A71A00B627B6 AS DateTime), CAST(0x0000A71A00B627B6 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (31, N'df589ae1-6ab3-4552-9a23-8bf0e25d2fbe', N'跟读故事', 31, 29, N'\22\29\31', CAST(0x0000A71A00B63410 AS DateTime), CAST(0x0000A71A00B63410 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (32, N'44682c51-7554-435f-93ad-cdf8502d7e20', N'歌曲歌谣', 32, 29, N'\22\29\32', CAST(0x0000A71A00B643F0 AS DateTime), CAST(0x0000A71A00B643F0 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (33, N'c9dfe1f7-f243-4b2c-88a3-e078ae39bb05', N'操练课件', 33, 29, N'\22\29\33', CAST(0x0000A71A00B6526C AS DateTime), CAST(0x0000A71A00B6526C AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (34, N'22c79071-e969-47af-8260-8c652f26553b', N'习题课件', 34, 29, N'\22\29\34', CAST(0x0000A71A00B65AD9 AS DateTime), CAST(0x0000A71A00B65AD9 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (35, N'aef89671-1cbb-411a-aa95-f0bd427e09ac', N'电子教材', 35, 0, N'\35', CAST(0x0000A71A00B67487 AS DateTime), CAST(0x0000A71A00B67487 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (36, N'f6d3cf01-5aa7-4b40-9852-f756d0e484ed', N'英语', 36, 35, N'\35\36', CAST(0x0000A71A00B68433 AS DateTime), CAST(0x0000A71A00B68433 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (37, N'd099877b-cad1-4302-87a2-13cbbcf9cfd3', N'语文', 37, 35, N'\35\37', CAST(0x0000A71A00B68AA5 AS DateTime), CAST(0x0000A71A00B68AA5 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (38, N'c10c9411-7554-41ec-a2b7-402341269cd8', N'数学', 38, 35, N'\35\38', CAST(0x0000A71A00B6909E AS DateTime), CAST(0x0000A71A00B6909E AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (39, N'12872cf2-287a-42cd-8daf-a2c47d744b24', N'操练课件', 39, 1, N'\1\39', CAST(0x0000A72400E6E026 AS DateTime), CAST(0x0000A72400E6E026 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (40, N'76af287f-be02-4511-9249-27fce129b579', N'阅读课件', 40, 1, N'\1\40', CAST(0x0000A72400E6FCAA AS DateTime), CAST(0x0000A72400E6FCAA AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (41, N'df3e2af6-cca9-4daa-b0c5-572b88a70cab', N'微课', 41, 1, N'\1\41', CAST(0x0000A72400E709EA AS DateTime), CAST(0x0000A72400E709EA AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (42, N'a6471e65-3422-4ea2-855e-9496d20ae964', N'例题动画', 42, 1, N'\1\42', CAST(0x0000A72400E718EE AS DateTime), CAST(0x0000A72400E718EE AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (43, N'5b4f5cb4-990c-484a-a1b9-c524b4f732e4', N'电子书页', 42, 1, N'\1\43', CAST(0x0000A731012E9E35 AS DateTime), CAST(0x0000A73600E51BF2 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (44, N'294fcdf7-db65-481c-b5a1-a3492e900c45', N'交互课件', 43, 27, N'\1\27\44', CAST(0x0000A73600B2C07A AS DateTime), CAST(0x0000A73600B2C07A AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (45, N'0da4aea8-c411-4cbd-8a25-37bc75bb020a', N'习题课件', 44, 27, N'\1\27\45', CAST(0x0000A73600B2CA7D AS DateTime), CAST(0x0000A73600B2CA7D AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (46, N'8850c9e2-1615-4ca1-aebf-a18cbd85bd4d', N'阅读课件', 45, 27, N'\1\27\46', CAST(0x0000A73600B2D731 AS DateTime), CAST(0x0000A73600B2D731 AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (47, N'c14b6765-cae1-45bf-9202-c591a387eaa0', N'流媒体动画', 46, 6, N'\1\6\47', CAST(0x0000A73600B2E6ED AS DateTime), CAST(0x0000A73600B2E6ED AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (48, N'7378601e-e37a-4ad8-a6bc-63e394829063', N'角色扮演动画', 47, 6, N'\1\6\48', CAST(0x0000A73600B2F4AC AS DateTime), CAST(0x0000A73600B2F4AC AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (49, N'355b6bae-a37b-4828-8cbd-fb0c8b7053b3', N'歌曲歌谣动画', 48, 6, N'\1\6\49', CAST(0x0000A73600B3038A AS DateTime), CAST(0x0000A73600B3038A AS DateTime), 0)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (50, N'ae45fc67-f94f-4e89-92b9-7d3250ee0d81', N'全文跟读', 49, 43, N'\1\43\50', CAST(0x0000A73600B3175B AS DateTime), CAST(0x0000A73600B3175B AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (51, N'721e0fc2-cc17-4040-8450-38a7c76ba067', N'报听写', 50, 43, N'\1\43\51', CAST(0x0000A73600B32B1A AS DateTime), CAST(0x0000A73600B32B1A AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (52, N'f6a4f74d-7608-4ad1-b065-754bb9894673', N'课文点读', 51, 43, N'\1\43\52', CAST(0x0000A73600B33C20 AS DateTime), CAST(0x0000A73600B33C20 AS DateTime), 1)
INSERT [dbo].[dict_resource_type] ([ID], [GUID], [CodeName], [Seq], [ParentID], [Path], [CreateDateTime], [ModifyDateTime], [Deleted]) VALUES (53, N'67f2f597-4038-4d33-8911-73cb34931665', N'报听写课件', 52, 27, N'\1\27\53', CAST(0x0000A73600E4F055 AS DateTime), CAST(0x0000A73600E4F055 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[dict_resource_type] OFF
GO
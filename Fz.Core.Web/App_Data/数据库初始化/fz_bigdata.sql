if exists (select 1
            from  sysobjects
           where  id = object_id('data_room_log_operation')
            and   type = 'U')
   drop table data_room_log_operation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('log_error')
            and   type = 'U')
   drop table log_error
go

if exists (select 1
            from  sysobjects
           where  id = object_id('log_operation')
            and   type = 'U')
   drop table log_operation
go

/*==============================================================*/
/* Table: data_room_log_operation                               */
/*==============================================================*/
create table data_room_log_operation (
   Id                   char(36)             not null,
   CreateUserId         char(36)             not null,
   CreateUserType       int                  not null,
   CreateTime           datetime             not null,
   OperId               int                  not null,
   OperContent          varchar(2000)        null,
   constraint PK_DATA_ROOM_LOG_OPERATION primary key (Id)
)
go

/*==============================================================*/
/* Table: log_error                                             */
/*==============================================================*/
create table log_error (
   Id                   varchar(36)          not null,
   Type                 int                  not null,
   ControllerName       varchar(50)          null,
   ActionName           varchar(50)          null,
   HttpMethod           varchar(10)          null,
   Url                  varchar(500)         null,
   Message              varchar(1000)        null,
   CreateIp             varchar(50)          not null,
   CreateTime           datetime             not null,
   CreateUserId         varchar(36)          null,
   CreateUserName       varchar(50)          null,
   CreateAccount        varchar(50)          null,
   constraint PK_LOG_ERROR primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-Web应用，2-WebApi，3-WebServices，4-WCF',
   'user', @CurrentUser, 'table', 'log_error', 'column', 'Type'
go

/*==============================================================*/
/* Table: log_operation                                         */
/*==============================================================*/
create table log_operation (
   Id                   varchar(36)          not null,
   Type                 int                  not null,
   ControllerName       varchar(50)          null,
   ActionName           varchar(50)          null,
   HttpMethod           varchar(10)          null,
   Url                  varchar(500)         null,
   ResponseTime         decimal(18,4)        null,
   RenderTime           decimal(18,4)        null,
   TotalTime            decimal(18,4)        null,
   CreateIp             varchar(50)          not null,
   CreateTime           datetime             not null,
   CreateUserId         varchar(36)          null,
   CreateUserName       varchar(50)          null,
   CreateAccount        varchar(50)          null,
   constraint PK_LOG_OPERATION primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1-Web应用，2-WebApi，3-WebServices，4-WCF',
   'user', @CurrentUser, 'table', 'log_operation', 'column', 'Type'
go

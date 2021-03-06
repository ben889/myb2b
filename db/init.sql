/****** Object:  Table [dbo].[Roles]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[AutoAssignment] [bit] NOT NULL,
	[IconFile] [nvarchar](100) NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY NONCLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动分配' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'AutoAssignment'
GO
/****** Object:  Table [dbo].[RoleGroups]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleGroups](
	[RoleGroupID] [int] IDENTITY(0,1) NOT NULL,
	[RoleGroupName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
 CONSTRAINT [PK_RoleGroups] PRIMARY KEY NONCLUSTERED 
(
	[RoleGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] NOT NULL,
	[PermissionCode] [varchar](50) NOT NULL,
	[ModuleID] [int] NULL,
	[TabID] [int] NULL,
	[PermissionKey] [varchar](50) NOT NULL,
	[PermissionName] [varchar](50) NOT NULL,
	[ViewOrder] [int] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Permission] UNIQUE NONCLUSTERED 
(
	[PermissionKey] ASC,
	[PermissionCode] ASC,
	[TabID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](2000) NOT NULL,
	[AddDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fun_getPY]    Script Date: 08/22/2015 14:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  
获取汉字的首拼音  
如果是非汉字字符 
--select [dbo].[fun_getPY]('李茼') 
*/  
CREATE function [dbo].[fun_getPY]   
 (   
    @str nvarchar(4000)   
 )   
returns nvarchar(4000)   
as   
begin   
  declare @word nchar(1),@PY nvarchar(4000)   
  
  set @PY=''   
  
  while len(@str)>0
  begin   
    set @word=left(@str,1)   
  
    --如果非汉字字符，返回原字符   
    set @PY=@PY+(case when unicode(@word) between 19968 and 19968+20901   
            then ( 
                select top 1 PY    
                from    
                (    
                     select 'A' as PY,N'驁' as word   
                     union all select 'B',N'簿'   
                     union all select 'C',N'錯'   
                     union all select 'D',N'鵽'   
                     union all select 'E',N'樲'   
                     union all select 'F',N'鰒'   
                     union all select 'G',N'腂'   
                     union all select 'H',N'夻'   
                     union all select 'J',N'攈'   
                     union all select 'K',N'穒'   
                     union all select 'L',N'鱳'   
                     union all select 'M',N'旀'   
                     union all select 'N',N'桛'   
                     union all select 'O',N'漚'   
                     union all select 'P',N'曝'   
                     union all select 'Q',N'囕'   
                     union all select 'R',N'鶸'   
                     union all select 'S',N'蜶'   
                     union all select 'T',N'籜'   
                     union all select 'W',N'鶩'   
                     union all select 'X',N'鑂'   
                     union all select 'Y',N'韻'   
                     union all select 'Z',N'咗'   
                ) T    
  
				where word>=@word collate Chinese_PRC_CS_AS_KS_WS    
                order by PY ASC   
                )    
                else @word    
                end)   

    set @str=right(@str,len(@str)-1)
	
  end 
  
  return upper(@PY)  
  
end
GO
/****** Object:  Table [dbo].[EventLogTypes]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventLogTypes](
	[LogTypeKey] [nvarchar](35) NOT NULL,
	[LogTypeFriendlyName] [nvarchar](50) NOT NULL,
	[LogTypeDescription] [nvarchar](128) NOT NULL,
	[LogTypeOwner] [nvarchar](100) NULL,
	[LogTypeCSSClass] [nvarchar](40) NULL,
 CONSTRAINT [PK_EventLogTypes] PRIMARY KEY CLUSTERED 
(
	[LogTypeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ad]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ad](
	[adid] [int] IDENTITY(1,1) NOT NULL,
	[adname] [nvarchar](50) NULL,
	[adimg] [nvarchar](100) NULL,
	[adlink] [nvarchar](255) NULL,
	[adblank] [tinyint] NULL,
	[status] [tinyint] NULL,
	[click] [int] NULL,
	[adpositionid] [int] NULL,
	[suffix] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ad] PRIMARY KEY CLUSTERED 
(
	[adid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'adname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'adimg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'adlink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打开方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'adblank'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'click'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后缀' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ad', @level2type=N'COLUMN',@level2name=N'suffix'
GO
/****** Object:  Table [dbo].[AdPosition]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdPosition](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[width] [int] NULL,
	[height] [int] NULL,
	[filetype] [nvarchar](50) NULL,
	[call_index] [varchar](50) NULL,
 CONSTRAINT [PK_AdPosition] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdPosition', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdPosition', @level2type=N'COLUMN',@level2name=N'width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdPosition', @level2type=N'COLUMN',@level2name=N'height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdPosition', @level2type=N'COLUMN',@level2name=N'filetype'
GO
/****** Object:  Table [dbo].[Tabs]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tabs](
	[TabID] [int] NOT NULL,
	[TabName] [nvarchar](50) NULL,
	[TabUrl] [nvarchar](200) NULL,
	[ParentId] [int] NULL,
	[Level] [int] NULL,
	[OrderByNo] [int] NULL,
	[Icon] [nvarchar](200) NULL,
	[DisPlay] [bit] NULL,
	[TabKey] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Tabs] PRIMARY KEY CLUSTERED 
(
	[TabID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tabs', @level2type=N'COLUMN',@level2name=N'Icon'
GO
/****** Object:  Table [dbo].[TabPermission]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabPermission](
	[TabPermissionID] [int] IDENTITY(1,1) NOT NULL,
	[TabID] [int] NULL,
	[PermissionID] [int] NOT NULL,
	[AllowAccess] [bit] NOT NULL,
	[RoleID] [int] NULL,
	[UserID] [int] NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
 CONSTRAINT [PK_TabPermission] PRIMARY KEY CLUSTERED 
(
	[TabPermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TabPermission] UNIQUE NONCLUSTERED 
(
	[TabID] ASC,
	[RoleID] ASC,
	[PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](256) NULL,
	[DisplayName] [nvarchar](128) NOT NULL,
	[LastIPAddress] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[IsLock] [bit] NULL,
	[LastLoginDate] [datetime] NULL,
	[Comment] [ntext] NULL,
	[UserType] [varchar](50) NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY NONCLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DisplayName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登陆IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastIPAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreatedByUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreatedOnDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否被锁定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsLock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登陆日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserType'
GO
/****** Object:  StoredProcedure [dbo].[UspOutputData]    Script Date: 08/22/2015 14:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SQL Server里面导出SQL脚本(表数据的insert语句)
CREATE PROCEDURE [dbo].[UspOutputData] 
@tablename sysname 
AS 
declare @column varchar(1000) 
declare @columndata varchar(1000) 
declare @sql varchar(4000) 
declare @xtype tinyint 
declare @name sysname 
declare @objectId int 
declare @objectname sysname 
declare @ident int 
set nocount on 
set @objectId=object_id(@tablename) 
if @objectId is null -- 判断对象是否存在 
begin 
print 'The object not exists' 
return 
end 
set @objectname=rtrim(object_name(@objectId)) 
if @objectname is null or charindex(@objectname,@tablename)=0 --此判断不严密 
begin 
print 'object not in current database' 
return 
end 
if OBJECTPROPERTY(@objectId,'IsTable') < > 1 -- 判断对象是否是table 
begin 
print 'The object is not table' 
return 
end 
select @ident=status&0x80 from syscolumns where id=@objectid and status&0x80=0x80 
if @ident is not null 
print 'SET IDENTITY_INSERT '+@TableName+' ON' 
declare syscolumns_cursor cursor
for select c.name,c.xtype from syscolumns c where c.id=@objectid order by c.colid 
open syscolumns_cursor 
set @column='' 
set @columndata='' 
fetch next from syscolumns_cursor into @name,@xtype 
while @@fetch_status < >-1 
begin 
if @@fetch_status < >-2 
begin 
if @xtype not in(189,34,35,99,98) --timestamp不需处理，image,text,ntext,sql_variant 暂时不处理 
begin 
set @column=@column+case when len(@column)=0 then'' else ','end+@name 
set @columndata=@columndata+case when len(@columndata)=0 then '' else ','','','
end 
+case when @xtype in(167,175) then '''''''''+'+@name+'+''''''''' --varchar,char 
when @xtype in(231,239) then '''N''''''+'+@name+'+''''''''' --nvarchar,nchar 
when @xtype=61 then '''''''''+convert(char(23),'+@name+',121)+''''''''' --datetime 
when @xtype=58 then '''''''''+convert(char(16),'+@name+',120)+''''''''' --smalldatetime 
when @xtype=36 then '''''''''+convert(char(36),'+@name+')+''''''''' --uniqueidentifier 
else @name end 
end 
end 
fetch next from syscolumns_cursor into @name,@xtype 
end 
close syscolumns_cursor 
deallocate syscolumns_cursor 
set @sql='set nocount on select ''insert '+@tablename+'('+@column+') values(''as ''--'','+@columndata+','')'' from '+@tablename 
print '--'+@sql 
exec(@sql) 
if @ident is not null 
print 'SET IDENTITY_INSERT '+@TableName+' OFF'
GO
/****** Object:  StoredProcedure [dbo].[Users_GetPageUsers]    Script Date: 08/22/2015 14:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Date Generated: 2011年2月18日
--------------------------------------------------------------------------------------------------------------------------
--declare @total int
--exec [Users_GetPageUsers]
--'','',1,15,@total output
CREATE PROCEDURE [dbo].[Users_GetPageUsers]
(
	@WhereClause varchar (2000),
	@OrderBy     varchar (2000),
	@PageIndex   int,
	@PageSize    int,
	@TotalRows	 int Output
)
AS

BEGIN
	DECLARE @PageLowerBound int
	DECLARE @PageUpperBound int
	
	-- Set the page bounds
	SET @PageLowerBound =(@PageIndex-1)*@PageSize
	SET @PageUpperBound = @PageIndex * @PageSize

	-- Create a temp table to store the select results
	Create table #temp(Total int)
	CREATE TABLE #PageIndex
	(
	    [IndexId] int IDENTITY (1, 1) NOT NULL,
		UserID int
	)
	
	-- Insert into the temp table
	DECLARE @SQL AS nvarchar(4000)
	SET @SQL = 'INSERT INTO #PageIndex ([UserID])'
	SET @SQL = @SQL + ' SELECT'
	IF @PageSize > 0
	BEGIN
		SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
	END
	SET @SQL = @SQL + ' O.[UserID]'
	SET @SQL = @SQL + ' FROM [Users] O'
	IF LEN(@WhereClause) > 0
	BEGIN
		SET @SQL = @SQL + ' WHERE ' + @WhereClause
	END
	IF LEN(@OrderBy) > 0
	BEGIN
		SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
	END
	
	-- Populate the temp table
	EXEC sp_executesql @SQL

	-- Return paged results
	SELECT O.*
	FROM
	    [Users] O
		INNER JOIN #PageIndex PageIndex ON
		O.[UserID] = PageIndex.[UserID]
	WHERE
	    PageIndex.IndexId > @PageLowerBound	
	    
	ORDER BY PageIndex.IndexId
	
	-- get row count
	SET @SQL = 'INSERT INTO #temp SELECT COUNT(*)'
	SET @SQL = @SQL + ' FROM [Users] O'
	IF LEN(@WhereClause) > 0
	BEGIN
		SET @SQL = @SQL + ' WHERE ' + @WhereClause
	END
	PRINT @SQL
	--EXEC (@SQL)
	SELECT @TotalRows=Total from #temp
END

--endregion
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesCompanys]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesCompanys](
	[RoleID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[DataPermissionType] [smallint] NULL,
 CONSTRAINT [PK_RolesCompanys] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'如小于或等于0则通用(系统定义的角色)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolesCompanys', @level2type=N'COLUMN',@level2name=N'CompanyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据权限类型0为自已权限1为企业数据权限2为部门数据权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RolesCompanys', @level2type=N'COLUMN',@level2name=N'DataPermissionType'
GO
/****** Object:  StoredProcedure [dbo].[Ad_GetPageAd]    Script Date: 08/22/2015 14:14:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ad_GetPageAd]
(
	@WhereClause varchar (2000),
	@OrderBy     varchar (2000),
	@PageIndex   int,
	@PageSize    int,
	@TotalRows	 int Output
)
AS
SET NOCOUNT ON

BEGIN
	DECLARE @PageLowerBound int
	DECLARE @PageUpperBound int
	
	-- Set the page bounds
	SET @PageLowerBound =(@PageIndex-1)*@PageSize
	SET @PageUpperBound = @PageIndex * @PageSize

	-- Create a temp table to store the select results
	Create table #temp(Total int)
	CREATE TABLE #PageIndex
	(
	    [IndexId] int IDENTITY (1, 1) NOT NULL,
		id int
	)
	
	-- Insert into the temp table
	DECLARE @SQL AS nvarchar(4000)
	SET @SQL = 'INSERT INTO #PageIndex ([id])'
	SET @SQL = @SQL + ' SELECT'
	IF @PageSize > 0
	BEGIN
		SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
	END
	SET @SQL = @SQL + ' O.[adid]'
	SET @SQL = @SQL + ' FROM [dbo].[Ad] O left join AdPosition T ON T.id=O.adpositionid'
	IF LEN(@WhereClause) > 0
	BEGIN
		SET @SQL = @SQL + ' WHERE ' + @WhereClause
	END
	IF LEN(@OrderBy) > 0
	BEGIN
		SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
	END
	
	-- Populate the temp table
	EXEC sp_executesql @SQL

	-- Return paged results
	SELECT O.*,T.name as positionname
	FROM
	    [dbo].[Ad] O
		INNER JOIN #PageIndex PageIndex ON
		O.[adid] = PageIndex.[id]
		left join AdPosition T ON T.id=O.adpositionid
	WHERE
	    PageIndex.IndexId > @PageLowerBound		
	ORDER BY PageIndex.IndexId
	
	-- get row count
	SET @SQL = 'INSERT INTO #temp SELECT COUNT(1)'
	SET @SQL = @SQL + ' FROM [dbo].[Ad] O left join AdPosition T ON T.id=O.adpositionid'
	IF LEN(@WhereClause) > 0
	BEGIN
		SET @SQL = @SQL + ' WHERE ' + @WhereClause
	END
	EXEC (@SQL)
	SELECT @TotalRows=Total from #temp
END

--endregion
GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 08/22/2015 14:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EventLog](
	[LogEventID] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeKey] [nvarchar](35) NOT NULL,
	[LogFriendlyName] [nvarchar](100) NULL,
	[LogUserID] [int] NULL,
	[LogUserName] [nvarchar](50) NULL,
	[LogCreateDate] [datetime] NOT NULL,
	[LogServerName] [nvarchar](50) NOT NULL,
	[LogUserIP] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EventLog] PRIMARY KEY CLUSTERED 
(
	[LogEventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_EventLog_LogCreateDate]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[EventLog] ADD  CONSTRAINT [DF_EventLog_LogCreateDate]  DEFAULT (getdate()) FOR [LogCreateDate]
GO
/****** Object:  Default [DF_Notice_AddDate]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Notice] ADD  CONSTRAINT [DF_Notice_AddDate]  DEFAULT (getdate()) FOR [AddDate]
GO
/****** Object:  Default [DF_Permission_ViewOrder]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_ViewOrder]  DEFAULT ((9999)) FOR [ViewOrder]
GO
/****** Object:  Default [DF_Permission_CreatedOnDate]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_CreatedOnDate]  DEFAULT (getdate()) FOR [CreatedOnDate]
GO
/****** Object:  Default [DF_Roles_AutoAssignment]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_AutoAssignment]  DEFAULT ((0)) FOR [AutoAssignment]
GO
/****** Object:  Default [DF_Roles_CreatedOnDate]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_CreatedOnDate]  DEFAULT (getdate()) FOR [CreatedOnDate]
GO
/****** Object:  Default [DF_Roles_LastModifiedOnDate]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_LastModifiedOnDate]  DEFAULT (getdate()) FOR [LastModifiedOnDate]
GO
/****** Object:  Default [DF_RolesCompanys_DataPermissionType]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[RolesCompanys] ADD  CONSTRAINT [DF_RolesCompanys_DataPermissionType]  DEFAULT ((0)) FOR [DataPermissionType]
GO
/****** Object:  Default [DF_TabPermission_AllowAccess]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[TabPermission] ADD  CONSTRAINT [DF_TabPermission_AllowAccess]  DEFAULT ((1)) FOR [AllowAccess]
GO
/****** Object:  Default [DF_Tabs_DisPlay]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Tabs] ADD  CONSTRAINT [DF_Tabs_DisPlay]  DEFAULT ((1)) FOR [DisPlay]
GO
/****** Object:  Default [DF_Users_DisplayName]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DisplayName]  DEFAULT ('') FOR [DisplayName]
GO
/****** Object:  Default [DF_Users_IsDeleted]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Users_CreatedOnDate]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedOnDate]  DEFAULT (getdate()) FOR [CreatedOnDate]
GO
/****** Object:  Default [DF_Users_IsLockedOut]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsLockedOut]  DEFAULT ((0)) FOR [IsLock]
GO
/****** Object:  Default [DF_Users_Type]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Type]  DEFAULT ((2)) FOR [UserType]
GO
/****** Object:  ForeignKey [FK_EventLog_EventLog]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[EventLog]  WITH CHECK ADD  CONSTRAINT [FK_EventLog_EventLog] FOREIGN KEY([LogTypeKey])
REFERENCES [dbo].[EventLogTypes] ([LogTypeKey])
GO
ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_EventLog]
GO
/****** Object:  ForeignKey [FK_RolesCompanys_Roles]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[RolesCompanys]  WITH CHECK ADD  CONSTRAINT [FK_RolesCompanys_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[RolesCompanys] CHECK CONSTRAINT [FK_RolesCompanys_Roles]
GO
/****** Object:  ForeignKey [FK_UserRoles_Roles]    Script Date: 08/22/2015 14:14:39 ******/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO

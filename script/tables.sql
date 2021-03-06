USE [CWXT]
GO

IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CWXT].[dbo].[UserDataPermission]') AND type in (N'U'))
BEGIN
	DROP	TABLE	[CWXT].[dbo].[UserDataPermission]
END
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CWXT].[dbo].[User]') AND type in (N'U'))
BEGIN
	DROP	TABLE	[CWXT].[dbo].[User]
END
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CWXT].[dbo].[RoleMenu]') AND type in (N'U'))
BEGIN
	DROP	TABLE	[CWXT].[dbo].[RoleMenu]
END
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CWXT].[dbo].[Role]') AND type in (N'U'))
BEGIN
	DROP	TABLE	[CWXT].[dbo].[Role]
END
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CWXT].[dbo].[Menu]') AND type in (N'U'))
BEGIN
	DROP	TABLE	[CWXT].[dbo].[Menu]
END
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CWXT].[dbo].[Dictionary]') AND type in (N'U'))
BEGIN
	DROP	TABLE	[CWXT].[dbo].[Dictionary]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDataPermission]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserDataPermission](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[FK_User] [int] NULL,
	[FK_Dictionary] [int] NULL,
	[Type] [int] NULL,
	[IsValid] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[Memo] [nvarchar](200) NULL,
	[Level] [int] NULL,
 CONSTRAINT [UserDataPermission_PK] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](300) NULL,
	[ChineseName] [nvarchar](50) NULL,
	[EnglishName] [nvarchar](50) NULL,
	[Gender] [bit] NULL,
	[Title] [nvarchar](100) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Birthday] [datetime] NULL,
	[FK_Role] [int] NULL,
	[FK_UserLevel] [int] NULL,
	[FK_UserType] [int] NULL,
	[LastModifyPasswordTime] [datetime] NULL,
	[IsReserved] [bit] NULL,
	[IsValid] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [user_pk] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleMenu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleMenu](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[FK_Role] [int] NULL,
	[FK_Menu] [int] NULL,
	[IsValid] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [RoleMenu_PK] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[RoleCode] [nvarchar](50) NULL,
	[RoleName] [nvarchar](50) NULL,
	[IsReserved] [bit] NULL,
	[IsValid] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [Role_PK] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UDF_GetArrayFromString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
/*************************************************************************
 *	函数名称		UDF_GetArrayFromString
 *	作    者		Tony Zhang
 *	完成日期		2007-01-16
 * 	修改历史
 *	作    用		将制定字符串以某特定字符串分割，返回一个表集合
 *	备    注		
 * 	测    试        SELECT x FROM UDF_GetArrayFromString(''1,2,B,C'','','')
 * 	注    意		
 *************************************************************************/
CREATE FUNCTION [dbo].[UDF_GetArrayFromString]
(
@SourceString 	NVARCHAR(4000),	/* 源字符串 */
@Pattern	NVARCHAR(50)	/* 分隔符 */
)
RETURNS @Dummy TABLE (x NVARCHAR(50))
AS
BEGIN
	DECLARE @i1 INT	SET @i1 = 1
	DECLARE @i2 INT SET @i2 = 1
	DECLARE @len INT 

	IF @Pattern IS NULL OR @Pattern = ''''	SET @Pattern = '',''
	SET @len = LEN(@Pattern)
	
	IF LEN(@SourceString) >= @len AND SUBSTRING(@SourceString,LEN(@SourceString),@len) <> @Pattern
		SET @SourceString = @SourceString + @Pattern
	
	WHILE @i2 > 0
	BEGIN
		SET @i2 = CHARINDEX(@Pattern,@SourceString,@i1)
		IF @i2 = 0	BREAK

		INSERT INTO @Dummy SELECT SUBSTRING(@SourceString,@i1,@i2-@i1)
		SET @i1 = @i2 + @len
	END

	RETURN
END



' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPagedRecords]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

/* 创建过程/函数 GetPagedRecords。                                                                   */
/*

exec GetPagedRecords @tblName=''SysUser'',@PageSize=20,@doCount=1,@PageIndex=2,@fldName=''PKID''

*/
CREATE            PROCEDURE [dbo].[GetPagedRecords]

@tblName   	varchar(255),       -- 表名
@strGetFields 	varchar(MAX) = ''*'',  -- 需要返回的列 
@fldName 	varchar(255)=''PKID'',      -- 排序的字段名
@PageSize   	int = 10,          -- 页尺寸
@PageIndex  	int = 1,           -- 页码
@doCount  	bit = 0,   -- 返回记录总数, 非 0 值则返回
@OrderType 	bit = 0,  -- 设置排序类型, 非 0 值则降序
@strWhere  	varchar(8000) = '''',  -- 查询条件 (注意: 不要加 where)
@strJoin	varchar(8000) = '''',  -- 连接表达式
@finalOrder	varchar(255) = ''''	-- 最终结果集的排序表达式
AS

declare @strSQL   varchar(MAX),@strSQL2 varchar(MAX),@strSQL3 varchar(MAX)       -- 主语句
declare @strTmp   varchar(110)        -- 临时变量
declare @strOrder varchar(400)        -- 排序类型
DECLARE @PKID varchar(50)
DECLARE @IDX INT

SET @PKID = @fldName
SET @IDX = CHARINDEX(''.'',@fldName)
IF @IDX <> 0
	SET @PKID = SUBSTRING(@fldName,@IDX+1,LEN(@fldName)-@IDX+1)

--如果@doCount传递过来的不是0，就执行总数统计。以下的所有代码都是@doCount为0的情况
if @doCount != 0
begin
	if @strWhere !=''''
		set @strSQL = ''select count(*) as Total from '' + @tblName + '' '' + @strJoin + '' where ''+@strWhere
	else
		set @strSQL = ''select count(*) as Total from '' + @tblName + '' '' + @strJoin

	print @strSQL
	exec(@strSQL)
end  

if @OrderType != 0
begin
	set @strTmp = ''<(select min''
	set @strOrder = '' order by '' + @fldName +'' desc''
end
else
begin
	set @strTmp = ''>(select max''
	set @strOrder = '' order by '' + @fldName +'' asc''
end

-- 如果指定了自定义的排序表达式，则使用自定义的排序表达式
if @finalOrder <> ''''
	--set @strOrder = '' order by '' + @finalOrder + '' ''
	set @finalOrder = '' order by '' + @finalOrder + '' ''
else
	set @finalOrder = @strOrder

--如果是第一页，这样会加快执行速度
if @PageIndex = 1
begin
	if @strWhere != ''''   
		set @strSQL = ''select top '' + str(@PageSize) +'' ''+@strGetFields+ ''  from '' + @tblName + '' '' + @strJoin  + '' where '' + @strWhere + '' '' + @finalOrder--@strOrder
	else
		set @strSQL = ''select top '' + str(@PageSize) +'' ''+@strGetFields+ ''  from ''+ @tblName + '' '' + @strJoin +  '' ''+ @finalOrder--@strOrder
	print @strSQL
end
else
begin
	if @strWhere = ''''
		set @strSQL = ''select top '' + str(@PageSize) +'' ''+@strGetFields+ ''  from ''
		    + @tblName + '' '' + @strJoin + '' where '' + @fldName + '''' + @strTmp + ''(tblTmp.''+ @PKID + '') from (select top '' + str((@PageIndex-1)*@PageSize) + '' ''+ @fldName + '' from '' + @tblName + '' '' + @strJoin + '' '' + @strOrder + '') as tblTmp)''+ @finalOrder--@strOrder
	else
	begin
		/*
		set @strSQL = ''select top '' + str(@PageSize) +'' ''+@strGetFields+ ''  from ''
		        + @tblName + '' '' + @strJoin +  '' where '' + @fldName + '''' + @strTmp + ''(tblTmp.''
		        + @PKID + '') from (select top '' + str((@PageIndex-1)*@PageSize) + '' ''
		        + @fldName + '' from '' + @tblName + '' '' + @strJoin +  '' where '' + @strWhere + '' ''
		        + @strOrder + '') as tblTmp) and '' + @strWhere + '' '' + @strOrder
		*/
		
		set @strSQL = ''select top '' + str(@PageSize) +'' ''+@strGetFields+ ''  from ''
		        + @tblName + '' '' + @strJoin +  '' where '' + @fldName + '''' + @strTmp + ''(tblTmp.''
		        + @PKID + '') from (select top '' + str((@PageIndex-1)*@PageSize) + '' ''

		/* Andy Modify 2007-06-15 */
		/*
		set @strSQL2 = @fldName + '' from '' + @tblName + '' '' + @strJoin +  '' where '' + @strWhere + '' ''
		        + @strOrder + '') as tblTmp) and '' + @strWhere + '' '' + @finalOrder--@strOrder
		*/
		set @strSQL2 = @fldName + '' from '' + @tblName + '' '' + @strJoin +  '' where '' + @strWhere + '' ''
		
		set @strSQL3 = @strOrder + '') as tblTmp) and '' + @strWhere + '' '' + @finalOrder--@strOrder
			

	end
end

--print @strSQL
--print @strSQL2
--print @strSQL3

--返回记录集
exec (@strSQL + @strSQL2 + @strSQL3)

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Menu](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[ChineseName] [nvarchar](50) NULL,
	[EnglishName] [nvarchar](50) NULL,
	[URL] [nvarchar](500) NULL,
	[Parent] [int] NULL,
	[DisplayOrder] [int] NULL,
	[IsValid] [bit] NULL,
	[IsLeaf] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [Menu_PK] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dictionary]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dictionary](
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Parent] [int] NULL,
	[Type] [int] NULL,
	[Path] [nvarchar](200) NULL,
	[Level] [int] NULL,
	[IsValid] [bit] NULL,
	[CreateUser] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [int] NULL,
	[ModifyTime] [datetime] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [Dictionary_PK] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END

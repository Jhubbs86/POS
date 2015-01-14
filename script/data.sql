TRUNCATE TABLE [CWXT].[dbo].[Role]
TRUNCATE TABLE [CWXT].[dbo].[Dictionary]
TRUNCATE TABLE [CWXT].[dbo].[Menu]
TRUNCATE TABLE [CWXT].[dbo].[RoleMenu]
TRUNCATE TABLE [CWXT].[dbo].[User]
TRUNCATE TABLE [CWXT].[dbo].[UserDataPermission]
/*
SELECT * FROM [Role]
*/
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Role] WHERE [IsValid] = 1 AND [RoleName] = '总部系统管理员' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Role]
           (
				[RoleCode]
				,[RoleName]
				,[IsReserved]
				,[IsValid]
				,[CreateUser]
				,[CreateTime]
				,[ModifyUser]
				,[ModifyTime]
				,[Memo]
			)
     VALUES
           (
				'HQ Admin'
				,'总部系统管理员'
				,1
				,1
				,NULL
				,NULL
				,NULL
				,NULL
				,NULL
			)
END

/*
SELECT * FROM [Menu]
*/
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '系统管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     VALUES
           (
				'系统管理'
				,''
				,0
				,1
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '基础数据' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     VALUES
           (
				'基础数据'
				,''
				,0
				,2
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '计划生育' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     VALUES
           (
				'计划生育'
				,''
				,0
				,3
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '用户组管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '用户组管理','SystemManage/RoleManage/RoleList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '系统管理'
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '用户管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '用户管理','SystemManage/UserManage/UserList.aspx',Menu.PKID,2,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '系统管理'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '权限管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '权限管理','SystemManage/PermissionManage/UIPermission.aspx',Menu.PKID,3,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '系统管理'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '修改口令' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '修改口令','SystemManage/UserManage/UserModifyPassword.aspx',Menu.PKID,4,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '系统管理'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '切换用户' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '切换用户','Logout.aspx?__action=switch',Menu.PKID,5,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '系统管理'
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '村务信息' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '村务信息','JHSY/CWInfoManage/CWInfoList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '人员信息' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '人员信息','JHSY/CWPerInfo/CWPerInfoList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '新婚登记' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '新婚登记','JHSY/CWNewMarrige/CWNewMarrigeList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '出生小孩信息' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '出生小孩信息','JHSY/CWBirthInfo/CWBirthInfoList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '独生子女统计' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '独生子女统计','JHSY/CWOneChild/CWOneChildList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '独生子女奖励费统计' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '独生子女奖励费统计','JHSY/CWOneChildAward/CWOneChildAwardList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '计生家庭特别扶助统计' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
				,[IsLeaf]
			)
     SELECT '计生家庭特别扶助统计','JHSY/CWFamilySpecHelp/CWFamilySpecHelpList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '计划生育'
END

/*
SELECT * FROM RoleMenu
*/
IF  NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[RoleMenu] WHERE [IsValid] = 1 AND FK_Role = 1 HAVING(COUNT(*)>0))
BEGIN
	INSERT INTO [CWXT].[dbo].[RoleMenu]
           (
				[FK_Role]
				,[FK_Menu]
				,[IsValid]
				,[CreateUser]
				,[CreateTime]
				,[ModifyUser]
				,[ModifyTime]
				,[Memo]
			)
     SELECT	1,Menu.PKID,1,1,GETDATE(),1,GETDATE(),NULL
	 FROM	[CWXT].[dbo].[Menu] WHERE IsValid = 1
END

/*
SELECT * FROM [User] 
*/
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[User] WHERE [IsValid] = 1 AND [Alias] = 'admin' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[User]
           (
				[Alias]
				,[Password]
				,[ChineseName]
				,[EnglishName]
				,[Gender]
				,[FK_Role]
				,[LastModifyPasswordTime]
				,[IsReserved]
				,[IsValid]
				,[IsActive]
			)
     VALUES
           (
				'admin'
				,'DQgsS08q6vtn/Q6laKmX6dPrwOs='
				,'系统管理员'
				,'Administrator'
				,1
				,1
				,GETDATE()
				,1
				,1
				,1
			)
END
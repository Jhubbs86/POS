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
			)
     VALUES
           (
				'系统管理'
				,NULL
				,0
				,1
				,1
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '基础数据管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     VALUES
           (
				'基础数据管理'
				,NULL
				,0
				,2
				,1
			)
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '业务管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     VALUES
           (
				'业务管理'
				,NULL
				,0
				,3
				,1
			)
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
			)
     SELECT '用户管理',NULL,Menu.PKID,1,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '系统管理'
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
			)
     SELECT '权限管理',NULL,Menu.PKID,2,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '系统管理'
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
			)
     SELECT '用户组管理','SystemManage/RoleManage/RoleList.aspx',Menu.PKID,1,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '用户管理'
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '用户信息管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '用户信息管理','SystemManage/UserManage/UserList.aspx',Menu.PKID,2,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '用户管理'
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '修改口令（个人）' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '修改口令（个人）','SystemManage/UserManage/UserModifyPassword.aspx',Menu.PKID,3,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '用户管理'
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
			)
     SELECT '切换用户','Logout.aspx?__action=switch',Menu.PKID,4,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '用户管理'
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '界面权限管理' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '界面权限管理','SystemManage/PermissionManage/UIPermission.aspx',Menu.PKID,1,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '权限管理'
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
	 FROM	Menu WHERE IsValid = 1
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
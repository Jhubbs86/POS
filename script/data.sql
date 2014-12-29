/*
SELECT * FROM [Role]
*/
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Role] WHERE [IsValid] = 1 AND [RoleName] = '�ܲ�ϵͳ����Ա' HAVING(COUNT(*)>0))
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
				,'�ܲ�ϵͳ����Ա'
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
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = 'ϵͳ����' HAVING(COUNT(*)>0))
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
				'ϵͳ����'
				,NULL
				,0
				,1
				,1
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�������ݹ���' HAVING(COUNT(*)>0))
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
				'�������ݹ���'
				,NULL
				,0
				,2
				,1
			)
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = 'ҵ�����' HAVING(COUNT(*)>0))
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
				'ҵ�����'
				,NULL
				,0
				,3
				,1
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�û�����' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '�û�����',NULL,Menu.PKID,1,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = 'Ȩ�޹���' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT 'Ȩ�޹���',NULL,Menu.PKID,2,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�û������' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '�û������','SystemManage/RoleManage/RoleList.aspx',Menu.PKID,1,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '�û�����'
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�û���Ϣ����' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '�û���Ϣ����','SystemManage/UserManage/UserList.aspx',Menu.PKID,2,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '�û�����'
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�޸Ŀ�����ˣ�' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '�޸Ŀ�����ˣ�','SystemManage/UserManage/UserModifyPassword.aspx',Menu.PKID,3,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '�û�����'
END
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�л��û�' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '�л��û�','Logout.aspx?__action=switch',Menu.PKID,4,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = '�û�����'
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '����Ȩ�޹���' HAVING(COUNT(*)>0))
BEGIN
     INSERT INTO [CWXT].[dbo].[Menu]
           (
				[ChineseName]
				,[URL]
				,[Parent]
				,[DisplayOrder]
				,[IsValid]
			)
     SELECT '����Ȩ�޹���','SystemManage/PermissionManage/UIPermission.aspx',Menu.PKID,1,1
     FROM   Menu WHERE IsValid = 1 AND [ChineseName] = 'Ȩ�޹���'
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
				,'ϵͳ����Ա'
				,'Administrator'
				,1
				,1
				,GETDATE()
				,1
				,1
				,1
			)
END
TRUNCATE TABLE [CWXT].[dbo].[Role]
TRUNCATE TABLE [CWXT].[dbo].[Dictionary]
TRUNCATE TABLE [CWXT].[dbo].[Menu]
TRUNCATE TABLE [CWXT].[dbo].[RoleMenu]
TRUNCATE TABLE [CWXT].[dbo].[User]
TRUNCATE TABLE [CWXT].[dbo].[UserDataPermission]
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
				,[IsLeaf]
			)
     VALUES
           (
				'ϵͳ����'
				,''
				,0
				,1
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '��������' HAVING(COUNT(*)>0))
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
				'��������'
				,''
				,0
				,2
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�ƻ�����' HAVING(COUNT(*)>0))
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
				'�ƻ�����'
				,''
				,0
				,3
				,1
				,0
			)
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
				,[IsLeaf]
			)
     SELECT '�û������','SystemManage/RoleManage/RoleList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
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
				,[IsLeaf]
			)
     SELECT '�û�����','SystemManage/UserManage/UserList.aspx',Menu.PKID,2,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
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
				,[IsLeaf]
			)
     SELECT 'Ȩ�޹���','SystemManage/PermissionManage/UIPermission.aspx',Menu.PKID,3,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�޸Ŀ���' HAVING(COUNT(*)>0))
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
     SELECT '�޸Ŀ���','SystemManage/UserManage/UserModifyPassword.aspx',Menu.PKID,4,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
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
				,[IsLeaf]
			)
     SELECT '�л��û�','Logout.aspx?__action=switch',Menu.PKID,5,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = 'ϵͳ����'
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '������Ϣ' HAVING(COUNT(*)>0))
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
     SELECT '������Ϣ','JHSY/CWInfoManage/CWInfoList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '��Ա��Ϣ' HAVING(COUNT(*)>0))
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
     SELECT '��Ա��Ϣ','JHSY/CWPerInfo/CWPerInfoList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '�»�Ǽ�' HAVING(COUNT(*)>0))
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
     SELECT '�»�Ǽ�','JHSY/CWNewMarrige/CWNewMarrigeList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '����С����Ϣ' HAVING(COUNT(*)>0))
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
     SELECT '����С����Ϣ','JHSY/CWBirthInfo/CWBirthInfoList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '������Ůͳ��' HAVING(COUNT(*)>0))
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
     SELECT '������Ůͳ��','JHSY/CWOneChild/CWOneChildList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '������Ů������ͳ��' HAVING(COUNT(*)>0))
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
     SELECT '������Ů������ͳ��','JHSY/CWOneChildAward/CWOneChildAwardList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '������ͥ�ر����ͳ��' HAVING(COUNT(*)>0))
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
     SELECT '������ͥ�ر����ͳ��','JHSY/CWFamilySpecHelp/CWFamilySpecHelpList.aspx',Menu.PKID,1,1,1
     FROM   [CWXT].[dbo].[Menu] WHERE IsValid = 1 AND [ChineseName] = '�ƻ�����'
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
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

--add by zcz
IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '组织' HAVING(COUNT(*)>0))
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
				'组织'
				,''
				,0
				,4
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '统战' HAVING(COUNT(*)>0))
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
				'统战'
				,''
				,0
				,5
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '工会' HAVING(COUNT(*)>0))
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
				'工会'
				,''
				,0
				,6
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '妇联' HAVING(COUNT(*)>0))
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
				'妇联'
				,''
				,0
				,7
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '民政社救' HAVING(COUNT(*)>0))
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
				'民政社救'
				,''
				,0
				,8
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '老龄' HAVING(COUNT(*)>0))
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
				'老龄'
				,''
				,0
				,9
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '护塘小区管理' HAVING(COUNT(*)>0))
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
				'护塘小区管理'
				,''
				,0
				,10
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '老年活动室' HAVING(COUNT(*)>0))
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
				'老年活动室'
				,''
				,0
				,11
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '门卫' HAVING(COUNT(*)>0))
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
				'门卫'
				,''
				,0
				,12
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '丧事简办' HAVING(COUNT(*)>0))
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
				'丧事简办'
				,''
				,0
				,13
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '各类证明' HAVING(COUNT(*)>0))
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
				'各类证明'
				,''
				,0
				,14
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '纪检' HAVING(COUNT(*)>0))
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
				'纪检'
				,''
				,0
				,15
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '调解' HAVING(COUNT(*)>0))
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
				'调解'
				,''
				,0
				,16
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '安全' HAVING(COUNT(*)>0))
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
				'安全'
				,''
				,0
				,17
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '农副业' HAVING(COUNT(*)>0))
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
				'农副业'
				,''
				,0
				,18
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '河道保洁' HAVING(COUNT(*)>0))
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
				'河道保洁'
				,''
				,0
				,19
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '市场管理' HAVING(COUNT(*)>0))
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
				'市场管理'
				,''
				,0
				,20
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '水电管理' HAVING(COUNT(*)>0))
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
				'水电管理'
				,''
				,0
				,21
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '综治群众工作室' HAVING(COUNT(*)>0))
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
				'综治群众工作室'
				,''
				,0
				,22
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '宣传' HAVING(COUNT(*)>0))
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
				'宣传'
				,''
				,0
				,23
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '文教卫生' HAVING(COUNT(*)>0))
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
				'文教卫生'
				,''
				,0
				,24
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '红十字' HAVING(COUNT(*)>0))
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
				'红十字'
				,''
				,0
				,25
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '经济管理' HAVING(COUNT(*)>0))
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
				'经济管理'
				,''
				,0
				,26
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '出纳' HAVING(COUNT(*)>0))
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
				'出纳'
				,''
				,0
				,27
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '卫生室' HAVING(COUNT(*)>0))
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
				'卫生室'
				,''
				,0
				,28
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '土地房屋' HAVING(COUNT(*)>0))
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
				'土地房屋'
				,''
				,0
				,29
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '治保' HAVING(COUNT(*)>0))
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
				'治保'
				,''
				,0
				,30
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '民兵' HAVING(COUNT(*)>0))
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
				'民兵'
				,''
				,0
				,31
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '家庭财产保险管理' HAVING(COUNT(*)>0))
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
				'家庭财产保险管理'
				,''
				,0
				,32
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '团支部' HAVING(COUNT(*)>0))
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
				'团支部'
				,''
				,0
				,33
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '电子政务平台管理' HAVING(COUNT(*)>0))
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
				'电子政务平台管理'
				,''
				,0
				,34
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '会议记录' HAVING(COUNT(*)>0))
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
				'会议记录'
				,''
				,0
				,35
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '会务接待' HAVING(COUNT(*)>0))
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
				'会务接待'
				,''
				,0
				,36
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '会场布置' HAVING(COUNT(*)>0))
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
				'会场布置'
				,''
				,0
				,37
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '电教设施管理' HAVING(COUNT(*)>0))
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
				'电教设施管理'
				,''
				,0
				,38
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '科普活动室' HAVING(COUNT(*)>0))
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
				'科普活动室'
				,''
				,0
				,39
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '村级招商引资' HAVING(COUNT(*)>0))
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
				'村级招商引资'
				,''
				,0
				,40
				,1
				,0
			)
END



IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '水利排管' HAVING(COUNT(*)>0))
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
				'水利排管'
				,''
				,0
				,41
				,1
				,0
			)
END

IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '农业组织化' HAVING(COUNT(*)>0))
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
				'农业组织化'
				,''
				,0
				,42
				,1
				,0
			)
END


IF   NOT EXISTS (SELECT COUNT(*) FROM [CWXT].[dbo].[Menu] WHERE [IsValid] = 1 AND [ChineseName] = '项目建设协调' HAVING(COUNT(*)>0))
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
				'项目建设协调'
				,''
				,0
				,43
				,1
				,0
			)
END


--end add


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
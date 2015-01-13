USE [CWXT]

/*
SELECT * FROM CWBirthInfo
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWBirthInfo]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWBirthInfo' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWBirthInfo] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWFamilySpecHelp
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWFamilySpecHelp]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWFamilySpecHelp' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWFamilySpecHelp] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWInfo
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWInfo]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWInfo' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWInfo] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWNewMarrige
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWNewMarrige]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWNewMarrige' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWNewMarrige] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWOneChild
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWOneChild]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWOneChild' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWOneChild] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWOneChildAward
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWOneChildAward]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWOneChildAward' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWOneChildAward] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWPerInfo
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWPerInfo]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWPerInfo' and b.xtype='u' and a.name='IsValid')
	BEGIN
		ALTER TABLE [CWPerInfo] ADD [IsValid]  BIT
	END
END

/*
SELECT * FROM CWOneChild
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWOneChild]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWOneChild' and b.xtype='u' and a.name='PKID')
		AND
		EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWOneChild' and b.xtype='u' and a.name='FKID')
	BEGIN
		exec sp_rename 'CWOneChild.FKID','PKID','column';
	END
END

/*
SELECT * FROM CWOneChildAward
*/
IF	EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CWOneChildAward]') AND type in (N'U'))
BEGIN
	IF	NOT EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWOneChildAward' and b.xtype='u' and a.name='PKID')
		AND
		EXISTS(SELECT 1 FROM syscolumns a,sysobjects b  WHERE a.id=b.id and b.name='CWOneChildAward' and b.xtype='u' and a.name='FKID')
	BEGIN
		exec sp_rename 'CWOneChildAward.FKID','PKID','column';
	END
END
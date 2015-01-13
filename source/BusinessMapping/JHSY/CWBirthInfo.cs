using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// 村务出生小孩信息
	/// </summary>
	public class CWBirthInfo : BusinessObject
	{
		public CWBirthInfo()
		{
			this.TableName = "[CWBirthInfo]";
			this.PKID = new IntField("[PKID]", "");
            this.FK_CWID = new IntField("[FK_CWID]", "");
            this.ChildName = new StringField("[ChildName]", "");
            this.Sex = new IntField("[Sex]", "");
            this.BirthDate = new DateField("[BirthDate]", "");
            this.BirthNo = new StringField("[BirthNo]", "");
            this.IsPlan = new IntField("[IsPlan]", "");
            this.ExpectDate = new DateField("[ExpectDate]", "");
            this.ChildAddress = new StringField("[ChildAddress]", "");
            this.HolderName = new StringField("[HolderName]", "");
            this.HolderIDCardNo = new StringField("[HolderIDCardNo]", "");
            this.FathName = new StringField("[FathName]", "");
            this.FathIDCardNo = new StringField("[FathIDCardNo]", "");
            this.FathAddress = new StringField("[FathAddress]", "");
            this.FathLinkPhone = new StringField("[FathLinkPhone]", "");
            this.MothName = new StringField("[MothName]", "");
            this.MothIDCardNo = new StringField("[MothIDCardNo]", "");
            this.MothAddress = new StringField("[MothAddress]", "");
            this.MothLinkPhone = new StringField("[MothLinkPhone]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.ModifyUser = new IntField("[ModifyUser]", "");
            this.ModifyTime = new DateField("[ModifyTime]", "");
            this.IsValid = new BoolField("[IsValid]", "");
            this.Memo = new StringField("[Memo]", "");

            this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new CWBirthInfo();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 所属村镇
        /// </summary>
        [ForeignKey("CWInfo", "PKID", "VillageName", "CWVillageName")]
        public IntField FK_CWID;
        /// <summary>
        /// 小孩姓名
        /// </summary>
        public StringField ChildName;
        /// <summary>
        /// 性别 字典表Dictionary  男、女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "SexInfo")]
        public IntField Sex;
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateField BirthDate;
        /// <summary>
        /// 出生证编号
        /// </summary>
        public StringField BirthNo;
        /// <summary>
        /// 是否计划 字典表Dictionary  是、否
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "IsPlanfo")]
        public IntField IsPlan;
        /// <summary>
        /// 预产期
        /// </summary>
        public DateField ExpectDate;
        /// <summary>
        /// 户籍地址
        /// </summary>
        public StringField ChildAddress;
        /// <summary>
        /// 户主姓名
        /// </summary>
        public StringField HolderName;
        /// <summary>
        /// 户主身份证号
        /// </summary>
        public StringField HolderIDCardNo;
        /// <summary>
        /// 父亲姓名
        /// </summary>
        public StringField FathName;
        /// <summary>
        /// 父亲身份证号
        /// </summary>
        public StringField FathIDCardNo;
        /// <summary>
        /// 父亲户籍地址
        /// </summary>
        public StringField FathAddress;
        /// <summary>
        /// 父亲联系方式
        /// </summary>
        public StringField FathLinkPhone;
        /// <summary>
        /// 母亲姓名
        /// </summary>
        public StringField MothName;
        /// <summary>
        /// 母亲身份证号
        /// </summary>
        public StringField MothIDCardNo;
        /// <summary>
        /// 母亲户籍地址
        /// </summary>
        public StringField MothAddress;
        /// <summary>
        /// 母亲联系方式
        /// </summary>
        public StringField MothLinkPhone;
        /// <summary>
        /// 创建人
        /// </summary>
        [ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
        public IntField CreateUser;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateField CreateTime;
        /// <summary>
        /// 最后修改人
        /// </summary>
        [ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
        public IntField ModifyUser;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateField ModifyTime;
        /// <summary>
        /// 是否有效 删除用
        /// </summary>
        public BoolField IsValid;
        /// <summary>
        /// 备注
        /// </summary>
        public StringField Memo;
	}
}
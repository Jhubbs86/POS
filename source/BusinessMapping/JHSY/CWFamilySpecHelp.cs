using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// 计生家庭特别扶助统计
	/// </summary>
	public class CWFamilySpecHelp : BusinessObject
	{
		public CWFamilySpecHelp()
		{
			this.TableName = "[CWFamilySpecHelp]";
			this.PKID = new IntField("[PKID]", "");
            this.FK_CWID = new IntField("[FK_CWID]", "");
            this.AppIDCardNo = new StringField("[AppIDCardNo]", "");
            this.AppName = new StringField("[AppName]", "");
            this.Sex = new IntField("[Sex]", "");
            this.HolderPorp = new IntField("[HolderPorp]", "");
            this.HelpType = new IntField("[HelpType]", "");
            this.RealMonth = new IntField("[RealMonth]", "");
            this.HelpMoney = new DecimalField("[HelpMoney]", "");
            this.HelpNo = new StringField("[HelpNo]", "");
            this.HelpYear = new StringField("[HelpYear]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.IsValid = new BoolField("[IsValid]", "");
            this.Memo = new StringField("[Memo]", "");

            this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new CWFamilySpecHelp();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 所属村镇
        /// </summary>
        [ForeignKey("CWInfo", "PKID", "VillageName", "CWVillageName")]
        public IntField FK_CWID;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public StringField AppIDCardNo;
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public StringField AppName;
        /// <summary>
        /// 性别 字典表Dictionary  男、女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "SexInfo")]
        public IntField Sex;
        /// <summary>
        /// 户口性质 字典表Dictionary  农业、非农业
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "HolderPorpInfo")]
        public IntField HolderPorp;
        /// <summary>
        /// 扶助类型 字典表Dictionary  伤残、死亡
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "HelpTypeInfo")]
        public IntField HelpType;
        /// <summary>
        /// 享受时间
        /// </summary>
        public IntField RealMonth;
        /// <summary>
        /// 享受金额
        /// </summary>
        public DecimalField HelpMoney;
        /// <summary>
        /// 发放证编号
        /// </summary>
        public StringField HelpNo;
        /// <summary>
        /// 年份
        /// </summary>
        public StringField HelpYear;
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
        /// 是否有效 删除用
        /// </summary>
        public BoolField IsValid;
        /// <summary>
        /// 备注
        /// </summary>
        public StringField Memo;
	}
}
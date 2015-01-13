using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// 独生子女奖励费统计
	/// </summary>
	public class CWOneChildAward : BusinessObject
	{
		public CWOneChildAward()
		{
			this.TableName = "[CWOneChildAward]";
            this.PKID = new IntField("[PKID]", "");
            this.FK_CWID = new IntField("[FK_CWID]", "");
            this.OwnIDCardNo = new StringField("[OwnIDCardNo]", "");
            this.OwnName = new StringField("[OwnName]", "");
            this.ChildIDCardNo = new StringField("[ChildIDCardNo]", "");
            this.ChildName = new StringField("[ChildName]", "");
            this.BirthDate = new DateField("[BirthDate]", "");
            this.OneChildNo = new StringField("[OneChildNo]", "");
            this.RealMonth = new IntField("[RealMonth]", "");
            this.AwardFee = new DecimalField("[AwardFee]", "");
            this.LinkPhone = new StringField("[LinkPhone]", "");
            this.AuthName = new StringField("[AuthName]", "");
            this.ABCNo = new StringField("[ABCNo]", "");
            this.AuthIDCardNo = new StringField("[AuthIDCardNo]", "");
            this.AwardYear = new StringField("[AwardYear]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.IsValid = new BoolField("[IsValid]", "");
            this.Memo = new StringField("[Memo]", "");

            this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new CWOneChildAward();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 所属村镇
        /// </summary>
        [ForeignKey("CWInfo", "PKID", "VillageName", "CWVillageName")]
        public IntField FK_CWID;
        /// <summary>
        /// 享受人身份证号
        /// </summary>
        public StringField OwnIDCardNo;
        /// <summary>
        /// 享受人姓名
        /// </summary>
        public StringField OwnName;
        /// <summary>
        /// 孩子身份证号
        /// </summary>
        public StringField ChildIDCardNo;
        /// <summary>
        /// 孩子姓名
        /// </summary>
        public StringField ChildName;
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateField BirthDate;
        /// <summary>
        /// 独生子女光荣证号
        /// </summary>
        public StringField OneChildNo;
        /// <summary>
        /// 享受月数
        /// </summary>
        public IntField RealMonth;
        /// <summary>
        /// 金额
        /// </summary>
        public DecimalField AwardFee;
        /// <summary>
        /// 联系电话
        /// </summary>
        public StringField LinkPhone;
        /// <summary>
        /// 持卡人姓名
        /// </summary>
        public StringField AuthName;
        /// <summary>
        /// 农行卡号
        /// </summary>
        public StringField ABCNo;
        /// <summary>
        /// 持卡人身份证号
        /// </summary>
        public StringField AuthIDCardNo;
        /// <summary>
        /// 年份
        /// </summary>
        public StringField AwardYear;
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
using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// 独生子女统计
	/// </summary>
	public class CWOneChild : BusinessObject
	{
		public CWOneChild()
		{
			this.TableName = "[CWOneChild]";
            this.PKID = new IntField("[PKID]", "");
            this.FK_CWID = new IntField("[FK_CWID]", "");
            this.IDCardNo = new StringField("[IDCardNo]", "");
            this.ChildName = new StringField("[ChildName]", "");
            this.Sex = new IntField("[Sex]", "");
            this.FathIDCardNo = new StringField("[FathIDCardNo]", "");
            this.MothIDCardNo = new StringField("[MothIDCardNo]", "");
            this.OneChildNo = new StringField("[OneChildNo]", "");
            this.IssueOrg = new StringField("[IssueOrg]", "");
            this.BirthDate = new DateField("[BirthDate]", "");
            this.InSchool = new StringField("[InSchool]", "");
            this.FamilyAddress = new StringField("[FamilyAddress]", "");
            this.FamilyIncome = new DecimalField("[FamilyIncome]", "");
            this.InsuNo = new StringField("[InsuNo]", "");
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
			return new CWOneChild();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 所属村镇
        /// </summary>
        [ForeignKey("CWInfo", "PKID", "VillageName", "CWVillageName")]
        public IntField FK_CWID;
        /// <summary>
        /// 身份证号
        /// </summary>
        public StringField IDCardNo;
        /// <summary>
        /// 姓名
        /// </summary>
        public StringField ChildName;
        /// <summary>
        /// 性别 字典表Dictionary  男、女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "SexInfo")]
        public IntField Sex;
        /// <summary>
        /// 父亲身份证号
        /// </summary>
        public StringField FathIDCardNo;
        /// <summary>
        /// 母亲身份证号
        /// </summary>
        public StringField MothIDCardNo;
        /// <summary>
        /// 光荣证号
        /// </summary>
        public StringField OneChildNo;
        /// <summary>
        /// 发证机关
        /// </summary>
        public StringField IssueOrg;
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateField BirthDate;
        /// <summary>
        /// 就读学校
        /// </summary>
        public StringField InSchool;
        /// <summary>
        /// 家庭居住地址
        /// </summary>
        public StringField FamilyAddress;
        /// <summary>
        /// 家庭人均收入
        /// </summary>
        public DecimalField FamilyIncome;
        /// <summary>
        /// 独生子女保险卡号
        /// </summary>
        public StringField InsuNo;
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
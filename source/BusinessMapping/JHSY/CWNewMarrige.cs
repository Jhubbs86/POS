using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// 新婚登记
	/// </summary>
	public class CWNewMarrige : BusinessObject
	{
		public CWNewMarrige()
		{
			this.TableName = "[CWNewMarrige]";
			this.PKID = new IntField("[PKID]", "");
            this.FK_CWID = new IntField("[FK_CWID]", "");
            this.MaleIDCardNo = new StringField("[MaleIDCardNo]", "");
            this.MaleName = new StringField("[MaleName]", "");
            this.MaleAddress = new StringField("[MaleAddress]", "");
            this.MaleLinkPhone = new StringField("[MaleLinkPhone]", "");
            this.FemaleIDCardNo = new StringField("[FemaleIDCardNo]", "");
            this.FemaleName = new StringField("[FemaleName]", "");
            this.FemaleAddress = new StringField("[FemaleAddress]", "");
            this.FemaleLinkPhone = new StringField("[FemaleLinkPhone]", "");
            this.MarrigeDate = new DateField("[MarrigeDate]", "");
            this.IsPregnant = new IntField("[IsPregnant]", "");
            this.ExpectDate = new DateField("[ExpectDate]", "");
            this.VillageDate = new DateField("[VillageDate]", "");
            this.MarrigeNo = new StringField("[MarrigeNo]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.IsValid = new BoolField("[IsValid]", "");
            this.Memo = new StringField("[Memo]", "");
            
            this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new CWNewMarrige();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 所属村镇
        /// </summary>
        [ForeignKey("CWInfo", "PKID", "VillageName", "CWVillageName")]
        public IntField FK_CWID;
        /// <summary>
        /// 男方身份证号
        /// </summary>
        public StringField MaleIDCardNo;
        /// <summary>
        /// 男方姓名
        /// </summary>
        public StringField MaleName;
        /// <summary>
        /// 男方户籍地址
        /// </summary>
        public StringField MaleAddress;
        /// <summary>
        /// 男方联系方式
        /// </summary>
        public StringField MaleLinkPhone;
        /// <summary>
        /// 女方身份证号
        /// </summary>
        public StringField FemaleIDCardNo;
        /// <summary>
        /// 女方姓名
        /// </summary>
        public StringField FemaleName;
        /// <summary>
        /// 女方户籍地址
        /// </summary>
        public StringField FemaleAddress;
        /// <summary>
        /// 女方联系方式
        /// </summary>
        public StringField FemaleLinkPhone;
        /// <summary>
        /// 结婚登记日期
        /// </summary>
        public DateField MarrigeDate;
        /// <summary>
        /// 是否怀孕 字典表Dictionary  是、否
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "IsPregnantInfo")]
        public IntField IsPregnant;
        /// <summary>
        /// 预产期
        /// </summary>
        public DateField ExpectDate;
        /// <summary>
        /// 村委登记日期
        /// </summary>
        public DateField VillageDate;
        /// <summary>
        /// 结婚登记证号
        /// </summary>
        public StringField MarrigeNo;
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
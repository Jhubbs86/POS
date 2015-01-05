using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
    /// <summary>
    /// 村务人员信息
    /// </summary>
    public class CWPerInfo : BusinessObject
    {
        public CWPerInfo()
        {
            this.TableName = "[CWPerInfo]";
            this.PKID = new IntField("[PKID]", "");
            this.FK_CWID = new IntField("[FK_CWID]", "");
            this.IDCardNo = new StringField("[IDCardNo]", "");
            this.Name = new StringField("[Name]", "");
            this.Sex = new IntField("[Sex]", "");
            this.Nation = new IntField("[Nation]", "");
            this.Politics = new IntField("[Politics]", "");
            this.IsHolder = new IntField("[IsHolder]", "");
            this.HolderName = new StringField("[HolderName]", "");
            this.HolderIDCardNo = new StringField("[HolderIDCardNo]", "");
            this.HolderPorp = new IntField("[HolderPorp]", "");
            this.HolderAddress = new StringField("[HolderAddress]", "");
            this.LiveAddress = new StringField("[LiveAddress]", "");
            this.LinkPhone = new StringField("[LinkPhone]", "");
            this.WorkUnit = new StringField("[WorkUnit]", "");
            this.MarrigeStatus = new IntField("[MarrigeStatus]", "");
            this.MarrigeDate = new DateField("[MarrigeDate]", "");
            this.MarrigeNo = new StringField("[MarrigeNo]", "");
            this.MarrigeName = new StringField("[MarrigeName]", "");
            this.MarrigeIDCardNo = new StringField("[MarrigeIDCardNo]", "");
            this.Children = new IntField("[Children]", "");
            this.IsSingle = new IntField("[IsSingle]", "");
            this.ChildName1 = new StringField("[ChildName1]", "");
            this.ChildIDCardNo1 = new StringField("[ChildIDCardNo1]", "");
            this.ChildAddress1 = new StringField("[ChildAddress1]", "");
            this.BirthNo1 = new StringField("[BirthNo1]", "");
            this.BirthDate1 = new DateField("[BirthDate1]", "");
            this.AdoptNo1 = new StringField("[AdoptNo1]", "");
            this.ChildName2 = new StringField("[ChildName2]", "");
            this.ChildIDCardNo2 = new StringField("[ChildIDCardNo2]", "");
            this.ChildAddress2 = new StringField("[ChildAddress2]", "");
            this.BirthNo2 = new StringField("[BirthNo2]", "");
            this.BirthDate2 = new DateField("[BirthDate2]", "");
            this.AdoptNo2 = new StringField("[AdoptNo2]", "");
            this.ChildName3 = new StringField("[ChildName3]", "");
            this.ChildIDCardNo3 = new StringField("[ChildIDCardNo3]", "");
            this.ChildAddress3 = new StringField("[ChildAddress3]", "");
            this.BirthNo3 = new StringField("[BirthNo3]", "");
            this.BirthDate3 = new DateField("[BirthDate3]", "");
            this.AdoptNo3 = new StringField("[AdoptNo3]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.ModifyUser = new IntField("[ModifyUser]", "");
            this.ModifyTime = new DateField("[ModifyTime]", "");
            this.Memo = new StringField("[Memo]", "");
            //this.IsValid = new BoolField("[IsValid]", "");

            //this.IsValid.Value = true;
        }

        public override BusinessObject Clone()
        {
            return new CWPerInfo();
        }

        [PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("CWInfo", "PKID", "VillageName", "CWVillageName")]
        public IntField FK_CWID;
        /// <summary>
        /// 
        /// </summary>
        public StringField IDCardNo;
        /// <summary>
        /// 
        /// </summary>
        public StringField Name;
        /// <summary>
        /// 字典表Dictionary  男、女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "SexInfo")]
        public IntField Sex;
        /// <summary>
        /// 字典表Dictionary  汉族、回族...
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "NationInfo")]
        public IntField Nation;
        /// <summary>
        /// 字典表Dictionary  中共党员、团员、群众
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "PoliticsInfo")]
        public IntField Politics;
        /// <summary>
        /// 字典表Dictionary  是、否
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "IsHolderInfo")]
        public IntField IsHolder;
        /// <summary>
        /// 
        /// </summary>
        public StringField HolderName;
        /// <summary>
        /// 
        /// </summary>
        public StringField HolderIDCardNo;
        /// <summary>
        /// 字典表Dictionary  农业、非农业
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "HolderPorpInfo")]
        public IntField HolderPorp;
        /// <summary>
        /// 
        /// </summary>
        public StringField HolderAddress;
        /// <summary>
        /// 
        /// </summary>
        public StringField LiveAddress;
        /// <summary>
        /// 
        /// </summary>
        public StringField LinkPhone;
        /// <summary>
        /// 
        /// </summary>
        public StringField WorkUnit;
        /// <summary>
        /// 字典表Dictionary  已婚、离婚、丧偶
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "MarrigeStatusInfo")]
        public IntField MarrigeStatus;
        /// <summary>
        /// 
        /// </summary>
        public DateField MarrigeDate;
        /// <summary>
        /// 
        /// </summary>
        public StringField MarrigeNo;
        /// <summary>
        /// 
        /// </summary>
        public StringField MarrigeName;
        /// <summary>
        /// 
        /// </summary>
        public StringField MarrigeIDCardNo;
        /// <summary>
        /// 字典表Dictionary  无子女（未生育未收养）、无子女（独生子女死亡）、有独生子女、有多个子女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "ChildrenInfo")]
        public IntField Children;
        /// <summary>
        /// 
        /// </summary>
        public IntField IsSingle;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildName1;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildIDCardNo1;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildAddress1;
        /// <summary>
        /// 
        /// </summary>
        public StringField BirthNo1;
        /// <summary>
        /// 
        /// </summary>
        public DateField BirthDate1;
        /// <summary>
        /// 
        /// </summary>
        public StringField AdoptNo1;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildName2;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildIDCardNo2;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildAddress2;
        /// <summary>
        /// 
        /// </summary>
        public StringField BirthNo2;
        /// <summary>
        /// 
        /// </summary>
        public DateField BirthDate2;
        /// <summary>
        /// 
        /// </summary>
        public StringField AdoptNo2;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildName3;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildIDCardNo3;
        /// <summary>
        /// 
        /// </summary>
        public StringField ChildAddress3;
        /// <summary>
        /// 
        /// </summary>
        public StringField BirthNo3;
        /// <summary>
        /// 
        /// </summary>
        public DateField BirthDate3;
        /// <summary>
        /// 
        /// </summary>
        public StringField AdoptNo3;
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
        public IntField CreateUser;
        /// <summary>
        /// 
        /// </summary>
        public DateField CreateTime;
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
        public IntField ModifyUser;
        /// <summary>
        /// 
        /// </summary>
        public DateField ModifyTime;
        /// <summary>
        /// 
        /// </summary>
        public StringField Memo;
        /// <summary>
        /// 
        /// </summary>
        //public BoolField IsValid;
    }
}
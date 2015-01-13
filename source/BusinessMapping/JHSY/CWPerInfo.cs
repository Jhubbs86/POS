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
            this.IsValid = new BoolField("[IsValid]", "");

            this.IsValid.Value = true;
        }

        public override BusinessObject Clone()
        {
            return new CWPerInfo();
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
        public StringField Name;
        /// <summary>
        /// 性别 字典表Dictionary  男、女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "SexInfo")]
        public IntField Sex;
        /// <summary>
        /// 民族 字典表Dictionary  汉族、回族...
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "NationInfo")]
        public IntField Nation;
        /// <summary>
        /// 政治面貌 字典表Dictionary  中共党员、团员、群众
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "PoliticsInfo")]
        public IntField Politics;
        /// <summary>
        /// 是否户主 字典表Dictionary  是、否
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "IsHolderInfo")]
        public IntField IsHolder;
        /// <summary>
        /// 户主姓名
        /// </summary>
        public StringField HolderName;
        /// <summary>
        /// 户主身份证号
        /// </summary>
        public StringField HolderIDCardNo;
        /// <summary>
        /// 户口性质 字典表Dictionary  农业、非农业
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "HolderPorpInfo")]
        public IntField HolderPorp;
        /// <summary>
        /// 户籍地址
        /// </summary>
        public StringField HolderAddress;
        /// <summary>
        /// 居住地址
        /// </summary>
        public StringField LiveAddress;
        /// <summary>
        /// 联系电话
        /// </summary>
        public StringField LinkPhone;
        /// <summary>
        /// 工作单位
        /// </summary>
        public StringField WorkUnit;
        /// <summary>
        /// 结婚状况 字典表Dictionary  已婚、离婚、丧偶
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "MarrigeStatusInfo")]
        public IntField MarrigeStatus;
        /// <summary>
        /// 结婚登记日期
        /// </summary>
        public DateField MarrigeDate;
        /// <summary>
        /// 结婚登记证明号
        /// </summary>
        public StringField MarrigeNo;
        /// <summary>
        /// 对象姓名
        /// </summary>
        public StringField MarrigeName;
        /// <summary>
        /// 对象身份证号
        /// </summary>
        public StringField MarrigeIDCardNo;
        /// <summary>
        /// 子女情况 字典表Dictionary  无子女（未生育未收养）、无子女（独生子女死亡）、有独生子女、有多个子女
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "ChildrenInfo")]
        public IntField Children;
        /// <summary>
        /// 是否独生
        /// </summary>
        public IntField IsSingle;
        /// <summary>
        /// 小孩姓名1
        /// </summary>
        public StringField ChildName1;
        /// <summary>
        /// 小孩身份证号1
        /// </summary>
        public StringField ChildIDCardNo1;
        /// <summary>
        /// 小孩户籍地址1
        /// </summary>
        public StringField ChildAddress1;
        /// <summary>
        /// 小孩出生证号1
        /// </summary>
        public StringField BirthNo1;
        /// <summary>
        /// 出生日期1
        /// </summary>
        public DateField BirthDate1;
        /// <summary>
        /// 收养文书号1
        /// </summary>
        public StringField AdoptNo1;
        /// <summary>
        /// 小孩姓名2
        /// </summary>
        public StringField ChildName2;
        /// <summary>
        /// 小孩身份证号2
        /// </summary>
        public StringField ChildIDCardNo2;
        /// <summary>
        /// 小孩户籍地址2
        /// </summary>
        public StringField ChildAddress2;
        /// <summary>
        /// 小孩出生证号2
        /// </summary>
        public StringField BirthNo2;
        /// <summary>
        /// 出生日期2
        /// </summary>
        public DateField BirthDate2;
        /// <summary>
        /// 收养文书号2
        /// </summary>
        public StringField AdoptNo2;
        /// <summary>
        /// 小孩姓名3
        /// </summary>
        public StringField ChildName3;
        /// <summary>
        /// 小孩身份证号3
        /// </summary>
        public StringField ChildIDCardNo3;
        /// <summary>
        /// 小孩户籍地址3
        /// </summary>
        public StringField ChildAddress3;
        /// <summary>
        /// 小孩出生证号3
        /// </summary>
        public StringField BirthNo3;
        /// <summary>
        /// 出生日期3
        /// </summary>
        public DateField BirthDate3;
        /// <summary>
        /// 收养文书号3
        /// </summary>
        public StringField AdoptNo3;
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
        /// 备注
        /// </summary>
        public StringField Memo;
        /// <summary>
        /// 是否有效 删除用
        /// </summary>
        public BoolField IsValid;
    }
}
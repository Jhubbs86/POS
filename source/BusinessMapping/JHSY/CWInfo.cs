using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
    /// <summary>
    /// 村务信息
    /// </summary>
    public class CWInfo : BusinessObject
    {
        public CWInfo()
        {
            this.TableName = "[CWInfo]";
            this.PKID = new IntField("[PKID]", "");
            this.VillageName = new StringField("[VillageName]", "");
            this.Location = new StringField("[Location]", "");
            this.District = new IntField("[District]", "");
            this.TotalPeps = new IntField("[TotalPeps]", "");
            this.IndusValue = new DecimalField("[IndusValue]", "");
            this.VillageChief = new StringField("[VillageChief]", "");
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
            return new CWInfo();
        }

        [PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 
        /// </summary>
        public StringField VillageName;
        /// <summary>
        /// 
        /// </summary>
        public StringField Location;
        /// <summary>
        /// 字典表Dictionary  上海市金山区
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "DistrictInfo")]
        public IntField District;
        /// <summary>
        /// 
        /// </summary>
        public IntField TotalPeps;
        /// <summary>
        /// 
        /// </summary>
        public DecimalField IndusValue;
        /// <summary>
        /// 
        /// </summary>
        public StringField VillageChief;
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
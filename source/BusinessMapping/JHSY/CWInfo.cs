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
            this.IsValid = new BoolField("[IsValid]", "");

            this.IsValid.Value = true;
        }

        public override BusinessObject Clone()
        {
            return new CWInfo();
        }

        [PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;
        /// <summary>
        /// 村名称
        /// </summary>
        public StringField VillageName;
        /// <summary>
        /// 地理位置
        /// </summary>
        public StringField Location;
        /// <summary>
        /// 所属行政区 字典表Dictionary  上海市金山区
        /// </summary>
        [ForeignKey("Dictionary", "PKID", "Name", "DistrictInfo")]
        public IntField District;
        /// <summary>
        /// 总人数
        /// </summary>
        public IntField TotalPeps;
        /// <summary>
        /// 工业总产值
        /// </summary>
        public DecimalField IndusValue;
        /// <summary>
        /// 村长
        /// </summary>
        public StringField VillageChief;
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
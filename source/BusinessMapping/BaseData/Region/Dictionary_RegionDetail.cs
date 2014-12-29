using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
    /// <summary>
    /// Dictionary_RegionDetail -- Business Mapping Model
    /// </summary>
    public class Dictionary_RegionDetail : BusinessObject
    {
        public Dictionary_RegionDetail()
        {
            this.TableName = "[Dictionary_RegionDetail]";
            this.PKID = new IntField("[PKID]", "");
            this.Code = new StringField("[Code]", "");
            this.Name = new StringField("[Name]", "");
            this.FK_Dictionary = new IntField("[FK_Dictionary]", "");
            this.FK_District = new IntField("FK_District", "");
            this.TrafficInfo = new StringField("[TrafficInfo]", "");
            this.MapURL = new StringField("[MapURL]", "");
            this.DisplayOrder = new IntField("[Order]", "");
            this.Level = new IntField("[Level]", "");
            this.IsValid = new BoolField("[IsValid]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.ModifyUser = new IntField("[ModifyUser]", "");
            this.ModifyTime = new DateField("[ModifyTime]", "");
            this.Memo = new StringField("[Memo]", "");

            this.Address = new StringField("[Address]", "");
            this.TeamName = new StringField("[TeamName]", "");
            this.TeamMark = new StringField("[TeamMark]", "");
            this.Chief = new StringField("[Chief]", "");
            this.ChiefID = new StringField("[ChiefID]", "");
            this.Supervision = new StringField("[Supervision]", "");
            this.SupervisionID = new StringField("[SupervisionID]", "");
            this.Avatar = new StringField("[Avatar]", "");

            this.IsValid.Value = true;
        }

        public override BusinessObject Clone()
        {
            return new Dictionary_RegionDetail();
        }

        [PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;

        public StringField Code;

        public StringField Name;

        public IntField FK_Dictionary;

        [ForeignKey("District", "PKID", "Name", "DistrictName")]
        public IntField FK_District;

        public StringField TrafficInfo;

        public StringField MapURL;

        public IntField DisplayOrder;

        public IntField Level;

        public BoolField IsValid;

        [ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
        public IntField CreateUser;

        public DateField CreateTime;

        [ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
        public IntField ModifyUser;

        public DateField ModifyTime;

        public StringField Memo;

        public StringField Address;

        public StringField TeamName;

        public StringField TeamMark;

        public StringField Chief;

        public StringField ChiefID;

        public StringField Supervision;

        public StringField SupervisionID;

        public StringField Avatar;
    }
}


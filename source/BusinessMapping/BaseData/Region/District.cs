using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
    /// <summary>
    /// District -- Business Mapping Model
    /// </summary>
    public class District : BusinessObject
    {
        public District()
        {
            this.TableName = "[District]";
            this.PKID = new IntField("[PKID]", "");
            this.Code = new StringField("[Code]", "");
            this.Name = new StringField("[Name]", "");
            this.FK_Dictionary = new IntField("[FK_Dictionary]", "");
            this.DisplayOrder = new IntField("[Order]", "");
            this.IsValid = new BoolField("[IsValid]", "");
            this.CreateUser = new IntField("[CreateUser]", "");
            this.CreateTime = new DateField("[CreateTime]", "");
            this.ModifyUser = new IntField("[ModifyUser]", "");
            this.ModifyTime = new DateField("[ModifyTime]", "");
            this.Memo = new StringField("[Memo]", "");

            this.IsValid.Value = true;
        }

        public override BusinessObject Clone()
        {
            return new District();
        }

        [PrimaryKey(PrimaryKeyPolicy.Auto)]
        public IntField PKID;

        public StringField Code;

        public StringField Name;

        [ForeignKey("Dictionary", "PKID", "Name", "CityName")]
        public IntField FK_Dictionary;

        public IntField DisplayOrder;

        public BoolField IsValid;

        [ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
        public IntField CreateUser;

        public DateField CreateTime;

        [ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
        public IntField ModifyUser;

        public DateField ModifyTime;

        public StringField Memo;
    }
}


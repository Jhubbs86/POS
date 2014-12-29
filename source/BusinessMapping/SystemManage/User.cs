using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// User -- Business Mapping Model
	/// </summary>
	public class User : BusinessObject
	{
		public User()
		{
			this.TableName = "[User]";
			this.PKID = new IntField("PKID", "");
			this.Alias = new StringField("Alias", "");
			this.Password = new StringField("Password", "");
			this.ChineseName = new StringField("ChineseName", "");
			this.EnglishName = new StringField("EnglishName", "");
			this.Gender = new BoolField("Gender", "");
			this.Title = new StringField("Title", "");
			this.Mobile = new StringField("Mobile", "");
			this.Email = new StringField("Email", "");
			this.Address = new StringField("Address", "");
			this.Birthday = new DateField("Birthday", "");
			this.FK_Role = new IntField("FK_Role", "");
			this.LastModifyPasswordTime = new DateField("LastModifyPasswordTime", "");
			this.IsReserved = new BoolField("IsReserved", "");
			this.IsValid = new BoolField("IsValid", "");
			this.IsActive = new BoolField("IsActive", "");
			this.CreateUser = new IntField("CreateUser", "");
			this.CreateTime = new DateField("CreateTime", "");
			this.ModifyUser = new IntField("ModifyUser", "");
			this.ModifyTime = new DateField("ModifyTime", "");
			this.Memo = new StringField("Memo", "");			

			this.IsReserved.Value = false;
			this.IsValid.Value = true;
			this.IsActive.Value = false;
		}

		public override BusinessObject Clone()
		{
			return new User();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField Alias;

		public StringField Password;

		public StringField ChineseName;

		public StringField EnglishName;

		public BoolField Gender;

		public StringField Title;

		public StringField Mobile;

		public StringField Email;

		public StringField Address;

		public DateField Birthday;

		[ForeignKey("Role", "PKID", "RoleName", "RoleName")]
		public IntField FK_Role;

		public DateField LastModifyPasswordTime;

		public BoolField IsReserved;

		public BoolField IsValid;

		public BoolField IsActive;

		[ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
		public IntField CreateUser;

		public DateField CreateTime;

		[ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
		public IntField ModifyUser;

		public DateField ModifyTime;

		public StringField Memo;		
	}
}


using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// UserLevel -- Business Mapping Model
	/// </summary>
	public class UserLevel : BusinessObject
	{
		public UserLevel()
		{
			this.TableName = "UserLevel";
			this.PKID = new IntField("PKID", "");
			this.Code = new StringField("Code", "");
			this.LevelName = new StringField("LevelName", "");
			this.IsReserved = new BoolField("IsReserved", "");
			this.IsValid = new BoolField("IsValid", "");
			this.CreateUser = new IntField("CreateUser", "");
			this.CreateTime = new DateField("CreateTime", "");
			this.ModifyUser = new IntField("ModifyUser", "");
			this.ModifyTime = new DateField("ModifyTime", "");
			this.Memo = new StringField("Memo", "");

			this.IsReserved.Value = false;
			this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new UserLevel();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField Code;

		public StringField LevelName;

		public BoolField IsReserved;

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


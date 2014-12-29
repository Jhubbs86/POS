using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// UserDataPermission -- Business Mapping Model
	/// </summary>
	public class UserDataPermission : BusinessObject
	{
		public UserDataPermission()
		{
			this.TableName = "[UserDataPermission]";
			this.PKID = new IntField("[PKID]", "");
			this.FK_User = new IntField("[FK_User]", "");
			this.FK_Dictionary = new IntField("[FK_Dictionary]", "");
			this.Type = new IntField("[Type]", "");
			this.IsValid = new BoolField("[IsValid]", "");
			this.CreateUser = new IntField("[CreateUser]", "");
			this.CreateTime = new DateField("[CreateTime]", "");
			this.ModifyUser = new IntField("[ModifyUser]", "");
			this.ModifyTime = new DateField("[ModifyTime]", "");
			this.Memo = new StringField("[Memo]", "");
			this.Level = new IntField("[Level]", "");


			this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new UserDataPermission();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		//[ForeignKey("[User]", "PKID", "ChineseName", "UserName")]
		public IntField FK_User;

		//[ForeignKey("[Dictionary]", "PKID", "Name", "DictionaryName")]
		public IntField FK_Dictionary;

		public IntField Type;

		public BoolField IsValid;

		[ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
		public IntField CreateUser;

		public DateField CreateTime;

		[ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
		public IntField ModifyUser;

		public DateField ModifyTime;

		public StringField Memo;

		public IntField Level;
	}
}


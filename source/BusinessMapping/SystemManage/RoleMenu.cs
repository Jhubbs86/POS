using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// RoleMenu -- Business Mapping Model
	/// </summary>
	public class RoleMenu : BusinessObject
	{
		public RoleMenu()
		{
			this.TableName = "RoleMenu";
			this.PKID = new IntField("PKID", "");
			this.FK_Role = new IntField("FK_Role", "");
			this.FK_Menu = new IntField("FK_Menu", "");
			this.IsValid = new BoolField("IsValid", "");
			this.CreateUser = new IntField("CreateUser", "");
			this.CreateTime = new DateField("CreateTime", "");
			this.ModifyUser = new IntField("ModifyUser", "");
			this.ModifyTime = new DateField("ModifyTime", "");
			this.Memo = new StringField("Memo", "");

			this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new RoleMenu();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		[ForeignKey("Role", "PKID", "RoleName", "RoleName")]
		public IntField FK_Role;

		[ForeignKey("Menu", "PKID", "ChineseName", "MenuChineseName")]
		public IntField FK_Menu;

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


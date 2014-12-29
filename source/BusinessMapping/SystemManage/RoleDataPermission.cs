using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// RoleDataPermission -- Business Mapping Model
	/// </summary>
	public class RoleDataPermission : BusinessObject
	{
		public RoleDataPermission()
		{
			this.TableName = "RoleDataPermission";
			this.PKID = new IntField("PKID", "");
			this.FK_Role = new IntField("FK_Role", "");
			this.FK_Dictionary = new IntField("FK_Dictionary", "");
			this.Type = new IntField("Type", "");
			this.IsValid = new BoolField("IsValid", "");
			this.CreateUser = new IntField("CreateUser", "");
			this.CreateTime = new DateField("CreateTime", "");
			this.ModifyUser = new IntField("ModifyUser", "");
			this.ModifyTime = new DateField("ModifyTime", "");
			this.Memo = new StringField("Memo", "");

			this.IsValid.Value = true;
			this.CreateTime.Value = this.ModifyTime.Value = DateTime.Now;
		}

		public override BusinessObject Clone()
		{
			return new RoleDataPermission();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		[ForeignKey("Role", "PKID", "RoleName", "RoleName")]
		public IntField FK_Role;

		[ForeignKey("Dictionary", "PKID", "Name", "RegionName")]
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
	}
}


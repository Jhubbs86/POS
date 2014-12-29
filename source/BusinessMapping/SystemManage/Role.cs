using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// Role -- Business Mapping Model
	/// </summary>
	public class Role : BusinessObject
	{
		public Role()
		{
			this.TableName = "Role";
			this.PKID = new IntField("PKID", "");
			this.RoleCode = new StringField("RoleCode", "");
			this.RoleName = new StringField("RoleName", "");
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
			return new Role();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField RoleCode;

		public StringField RoleName;

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


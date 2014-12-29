using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// OperationLog -- Business Mapping Model
	/// </summary>
	public class OperationLog : BusinessObject
	{
		public OperationLog()
		{
			this.TableName = "OperationLog";
			this.PKID = new IntField("PKID", "");
			this.Module = new StringField("Module", "");
			this.Description = new StringField("Description", "");
			this.IsValid = new BoolField("IsValid", "");
			this.CreateUser = new IntField("CreateUser", "");
			this.CreateTime = new DateField("CreateTime", "");
			this.Memo = new StringField("Memo", "");

			this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new OperationLog();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField Module;

		public StringField Description;

		public BoolField IsValid;

		[ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
		public IntField CreateUser;

		public DateField CreateTime;

		public StringField Memo;
	}
}


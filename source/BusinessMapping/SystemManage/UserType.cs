using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// UserType -- Business Mapping Model
	/// </summary>
	public class UserType : BusinessObject
	{
		public UserType()
		{
			this.TableName = "UserType";
			this.PKID = new IntField("PKID", "");
			this.Name = new StringField("Name", "");
			this.IsValid = new BoolField("IsValid", "");
			this.Memo = new StringField("Memo", "");

			this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new UserType();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField Name;

		public BoolField IsValid;

		public StringField Memo;
	}
}


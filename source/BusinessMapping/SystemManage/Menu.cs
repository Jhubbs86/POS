using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// Menu -- Business Mapping Model
	/// </summary>
	public class Menu : BusinessObject
	{
		public Menu()
		{
			this.TableName = "Menu";
			this.PKID = new IntField("PKID", "");
			this.ChineseName = new StringField("ChineseName", "");
			this.EnglishName = new StringField("EnglishName", "");
			this.URL = new StringField("URL", "");
			this.Parent = new IntField("Parent", "");
			this.IsValid = new BoolField("IsValid", "");
            this.DisplayOrder = new IntField("DisplayOrder", "");
			this.CreateUser = new IntField("CreateUser", "");
			this.CreateTime = new DateField("CreateTime", "");
			this.ModifyUser = new IntField("ModifyUser", "");
			this.ModifyTime = new DateField("ModifyTime", "");
			this.Memo = new StringField("Memo", "");

			this.IsValid.Value = true;
		}

		public override BusinessObject Clone()
		{
			return new Menu();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField ChineseName;

		public StringField EnglishName;

		public StringField URL;

		public IntField Parent;

		public BoolField IsValid;

		public IntField DisplayOrder;

		[ForeignKey("[User]", "PKID", "Alias", "CreateUserName")]
		public IntField CreateUser;

		public DateField CreateTime;

		[ForeignKey("[User]", "PKID", "Alias", "ModifyUserName")]
		public IntField ModifyUser;

		public DateField ModifyTime;

		public StringField Memo;
	}
}


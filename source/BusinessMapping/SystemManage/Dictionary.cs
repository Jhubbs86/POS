using System;
using Wicresoft.BusinessObject;

namespace BusinessMapping
{
	/// <summary>
	/// Dictionary -- Business Mapping Model
	/// </summary>
	public class Dictionary : BusinessObject
	{
		public Dictionary()
		{
			this.TableName = "Dictionary";
			this.PKID = new IntField("PKID", "");
			this.Code = new StringField("Code", "");
			this.Name = new StringField("Name", "");
			this.Parent = new IntField("Parent", "");
			this.Type = new IntField("Type", "");
			this.Path = new StringField("Path", "");
			this.Level = new IntField("Level", "");
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
			return new Dictionary();
		}

		[PrimaryKey(PrimaryKeyPolicy.Auto)]
		public IntField PKID;

		public StringField Code;

		public StringField Name;

		[ForeignKey("Dictionary", "PKID", "Name", "ParentName")]
		public IntField Parent;

		public IntField Type;

		public StringField Path;

		public IntField Level;

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


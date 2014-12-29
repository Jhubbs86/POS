using System;
using Wicresoft.BusinessObject;


namespace BusinessView
{
	/// <summary>
	/// ������ͼ�������ռ䣬����λ��BusinessView�µĵ�һ��
	/// </summary>
	public class UserLevelDefaultView : BusinessObjectView
	{
		public UserLevelDefaultView() : base("UserLevel", "�û�����")
		{
			ViewItemCollection vic = new ViewItemCollection();
			vic.Add(new ViewItem("CreateUser", "������"));
			vic.Add(new ViewItem("CreateTime",	"����ʱ��"));
			vic.Add(new ViewItem("ModifyUser", "����޸���"));
			vic.Add(new ViewItem("ModifyTime", "����޸�ʱ��"));

			this.PKField = new ViewItem("PKID", "PKID");
			this.DisplayField = new ViewItem("LevelName", "��������", true);
			this.VisibleColumnCollection = vic;
		}

		public override int LoadData(int pageNumber, int pageSize)
		{
			int totalCount = 0;
			BusinessRule.SystemManage.UserLevel rule = new BusinessRule.SystemManage.UserLevel();
			this.tblSchema = rule.GetUserLevelList(out totalCount, pageSize, pageNumber, BusinessRule.Common.OrderByType.ASC, this.CurrentFilter);
		
			return totalCount;
		}
	}
}

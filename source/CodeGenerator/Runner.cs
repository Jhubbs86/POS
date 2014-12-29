using System;
using System.Windows.Forms;

namespace CodeGenerator
{
	/// <summary>
	/// Runner 的摘要说明。
	/// </summary>
	public class Runner
	{
		[MTAThread]
		static void Main()
		{
			Application.Run(new FrmMain());
		}
	}
}

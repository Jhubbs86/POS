using System;
using System.Windows.Forms;

namespace CodeGenerator
{
	/// <summary>
	/// Runner ��ժҪ˵����
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

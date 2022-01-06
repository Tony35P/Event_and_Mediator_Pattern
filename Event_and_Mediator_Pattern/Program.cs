using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_and_Mediator_Pattern
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Member member = new Member();

			member.DataChange += Member_DataChange; //設定要先講
			member.Name = "Allen"; // 這裡要觸發

			string name = member.Name;

		}

		private static void Member_DataChange()
		{
			Console.WriteLine("有事件被觸發了");
		}
	}

	delegate void DataChangeHandler();

	class Member
	{
		public event DataChangeHandler DataChange;
		
		private string _Name;

		public string Name
		{
			get { return _Name; }
			set 
			{
				_Name = value;
				if (DataChange != null)
				{
					DataChange();
				}
				 
			}
		}
	}
}

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

			Member member2 = new Member();
			member2.DataChange += Member_DataChange;
			member2.Name = "Tony";

		}

		

		private static void Member_DataChange(Member sender)
		{
			Console.WriteLine(sender.Name);
		}
	}

	delegate void DataChangeHandler(Member sender);

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
					DataChange(this);
				}
				 
			}
		}
	}
}

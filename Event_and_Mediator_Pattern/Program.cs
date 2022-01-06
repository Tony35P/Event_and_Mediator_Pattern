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
			//Member member = new Member();

			//member.DataChange += Member_DataChange; //設定要先講
			//member.Name = "Allen"; // 這裡要觸發
			//string name = member.Name;

			//Member member2 = new Member();
			//member2.DataChange += Member_DataChange;
			//member2.Name = "Tony";


			VIP vip = new VIP();
			vip.DataChange += Member_DataChange;
			vip.Name = "Tony";
		}



		private static void Member_DataChange(Member sender, EventArgs arg)
		{
			Console.WriteLine(sender.Name);
		}
	}

	delegate void DataChangeHandler(Member sender,EventArgs args);

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
				
				 OnDataChange(EventArgs.Empty);
			}
		}

		protected virtual void OnDataChange(EventArgs args)
		{
			if (DataChange != null)
			{
				DataChange(this, args);
			}
		}
	}

	class VIP:Member
	{
		private string _Email;
		public string Email
		{
			get { return _Email; }
			set
			{
				_Email = value;
				
				OnDataChange(EventArgs.Empty);
			}
		}

		protected override void OnDataChange(EventArgs args)
		{
			//... 事件觸發前
			base.OnDataChange(args); //不想觸發事件就刪掉
			//... 事件觸發後
		}
	}
}

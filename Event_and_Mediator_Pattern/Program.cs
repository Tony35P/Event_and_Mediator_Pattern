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
			member.Name = "Allen";

			string name = member.Name;


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
				DataChange();
				_Name = value; 
			}
		}
	}
}

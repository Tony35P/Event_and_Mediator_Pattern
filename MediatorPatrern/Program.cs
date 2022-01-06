using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatrern
{
	internal class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class CartMediator
	{
		private readonly ICartService _cart;
		private readonly IOrderService _order;
		private readonly IStockService _stock;

		public CartMediator(ICartService cart, IOrderService order, IStockService stock )
		{
			_cart = cart;
			_order = order;
			_stock = stock;
		}
	}

	public interface ICartService
	{

	}
	public interface IOrderService
	{ 
	}
	public interface IStockService
	{

	}
}

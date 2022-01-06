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
			ICartService cart = new CartService();
			IOrderService order = new OrderService();
			IStockService stock = new StockService();
			
			var mediator = new CartMediator(cart,order,stock);

			int productId = 99;
			cart.CheckOut(productId); //逼逼叫
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

			_cart.RequestCheckOut += _cart_RequestCheckOut;
		}

		private void _cart_RequestCheckOut(ICartService sender, int productId)
		{
			_order.PlaceOrder(productId); //下訂單
			_stock.Update(productId,1); // 減少庫存
			_cart.EmptyCart(); // 清空購物車
		}
	}
	public class CartService : ICartService
	{
		public event CheckOutEventHandler RequestCheckOut;

		public void CheckOut(int productId)
		{
			OnRequestCheckout(productId);
		}

		public void EmptyCart()
		{
			Console.WriteLine("購物車已清空");
		}

		protected virtual void OnRequestCheckout(int prodctId)
		{
			if(RequestCheckOut != null)
			{
				RequestCheckOut(this, prodctId);
			}
		}

	}
	public class OrderService : IOrderService
	{
		public void PlaceOrder(int productId)
		{
			Console.WriteLine("OrderService建立一筆新訂單");
		}
	}

	public class StockService : IStockService
	{
		public void Update(int productId, int qty)
		{
			Console.WriteLine($"商品編號{productId} 少了{qty}");
		}
	}

	public delegate void CheckOutEventHandler(ICartService sender, int productId);
	public interface ICartService
	{
		event CheckOutEventHandler RequestCheckOut;
		void CheckOut(int productId);
		void EmptyCart();
	}
	public interface IOrderService
	{
		void PlaceOrder(int productId);
	}
	public interface IStockService
	{
		void Update(int productId, int qty);
	}
}

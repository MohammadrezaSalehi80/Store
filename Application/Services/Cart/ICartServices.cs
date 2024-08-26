using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities;
using cartDomain = Store.Domain.Entities.Cart;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Cart
{
    public interface ICartServices
    {
        public ResultDto AddCart(long ProducrId, Guid BrowserId);
        public ResultDto RemoveCart(long ProducrId, Guid BrowserId);
        public ResultDto<CartDto> GetCart(Guid BrowserId);
    }

    public class CartServices : ICartServices
    {
        private readonly IDataBaseContext _dataBaseContext;

        public CartServices(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto AddCart(long ProducrId, Guid BrowserId)
        {
            var cart = _dataBaseContext.Carts.Where(p => p.BrowserId == BrowserId && p.IsFinished == false)
                .FirstOrDefault();

            if (cart != null)
            {
                cartDomain.CartItem HasItam = _dataBaseContext.CartItems
                    .Where(p => p.CartId == cart.Id && p.ProductId == ProducrId).FirstOrDefault();
                if (HasItam != null)
                {
                    HasItam.Count++;
                }
                else
                {
                    var GetProduct = _dataBaseContext.Products.Where(p => p.Id == ProducrId).FirstOrDefault();
                    cartDomain.CartItem cartItem = new cartDomain.CartItem()
                    {
                        Product = GetProduct,
                        Cart = cart,
                        Price = GetProduct.Price,
                        Count = 1,
                        CreateDate = DateTime.Now

                    };
                    _dataBaseContext.CartItems.Add(cartItem);
                }
            }
            else
            {
                cartDomain.Cart newCart = new cartDomain.Cart()
                {
                    BrowserId = BrowserId,
                    IsFinished = false,
                    CreateDate = DateTime.Now
                };

                var GetProduct = _dataBaseContext.Products.Where(p => p.Id == ProducrId).FirstOrDefault();
                cartDomain.CartItem item = new cartDomain.CartItem()
                {
                    Cart = newCart,
                    CreateDate = DateTime.Now,
                    Count = 1,
                    Price = GetProduct.Price
                };

                newCart.CartItems.Add(item);

                _dataBaseContext.Carts.Add(newCart);
                _dataBaseContext.CartItems.Add(item);
            }

            _dataBaseContext.SaveChanges();

            return new ResultDto() { IsSuccess= true, Message = "IsSuccess" };

        }

        public ResultDto<CartDto> GetCart(Guid BrowserId)
        {
            throw new NotImplementedException();
        }

        public ResultDto RemoveCart(long ProducrId, Guid BrowserId)
        {
            var Cart = _dataBaseContext.Carts.Where(p=>p.BrowserId == BrowserId && p.IsFinished == false)
                .FirstOrDefault();

            if(Cart != null)
            {
                var item = _dataBaseContext.CartItems.Where(p=> p.CartId == Cart.Id).ToList();
                if(item.Count > 0)
                {
                    foreach(var cartitem in item)
                    {
                        cartitem.IsRemoved = true;
                        cartitem.RemoveDate = DateTime.Now;
                    }
                }

                Cart.IsRemoved= true;

            }

            return new ResultDto()
            {
                IsSuccess= true,
                Message = "IsSuccess"
            };

        }
    }


    public class CartDto
    {
        public List<CartItemsDto> CartItemsDto;
    }

    public class CartItemsDto
    {
        public Store.Domain.Entities.Product.Product Product { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
    }
}

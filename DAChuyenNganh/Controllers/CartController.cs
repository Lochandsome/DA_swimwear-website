using DAChuyenNganh.Application.Interfaces;
using DAChuyenNganh.Extensions;
using DAChuyenNganh.Models;
using DAChuyenNganh.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAChuyenNganh.Controllers
{
    public class CartController : Controller
    {
        IProductService _productService;
        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        #region AJAX JQUERY REQUEST
        // lấy ra cái danh mục của giỏ hàng
        public IActionResult GetCart()
        {
            var session = HttpContext.Session.Get<List<ShoppingCartViewModel>>(CommonConstants.CartSession);
            if (session == null)
                session = new List<ShoppingCartViewModel>();
            return new OkObjectResult(session);
        }

        // dùng để xóa toàn bộ sản phẩm trong giỏ hàng
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CommonConstants.CartSession);
            return new OkObjectResult("OK");
        }

        // dùng để thêm mới 1 sản phẩm vào giỏ hàng
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity, int color, int size)
        {
            // lấy ra chi tiết sản phẩm 
            var product = _productService.GetById(productId);

            // nhận các danh sách mặt hàng trong giỏ hangf 
            var session = HttpContext.Session.Get<List<ShoppingCartViewModel>>(CommonConstants.CartSession);
            if (session != null)
            { //kiểm tra sp có khác null k nếu 
                // chuyển đổi chuỗi thành 1 đối tượng
                bool hasChanged = false;

                // kiểm tra sản phẩm tồn tại trong giỏ hàng theo  id
                if (session.Any(x => x.Product.Id == productId))
                { // kiểm tra có sp nào chưa nếu có r thì tăng lên 1
                    foreach (var item in session)
                    {
                        // cập nhật số lượng sản phẩm theo id
                        if (item.Product.Id == productId)
                        {  //tăng lên 1, kt giá khuyến mãi nếu có giá km thì lấy theo giá đó
                            item.Quantity += quantity;
                            item.Price = product.PromotionPrice ?? product.Price;
                            hasChanged = true;
                        }
                    }
                }
                else
                {
                    session.Add(new ShoppingCartViewModel()
                    {
                        Product = product,
                        Quantity = quantity,
                        ColorId = color,
                        SizeId = size,
                        Price = product.PromotionPrice ?? product.Price
                    });
                    hasChanged = true;
                }

                // cập nhật lại giỏ hàng
                if (hasChanged)
                {
                    HttpContext.Session.Set(CommonConstants.CartSession, session);
                }
            }
            else
            {
                // thêm giỏ hàng mới
                var cart = new List<ShoppingCartViewModel>();
                cart.Add(new ShoppingCartViewModel()
                {
                    Product = product,
                    Quantity = quantity,
                    ColorId = color,
                    SizeId = size,
                    Price = product.PromotionPrice ?? product.Price
                });
                HttpContext.Session.Set(CommonConstants.CartSession, cart);
            }
            return new OkObjectResult(productId);
        }

        // xóa 1 sản phẩm trong giỏ hàng
        public IActionResult RemoveFromCart(int productId)
        {
            var session = HttpContext.Session.Get<List<ShoppingCartViewModel>>(CommonConstants.CartSession);
            if (session != null)
            {
                bool hasChanged = false;
                foreach (var item in session)
                {
                    if (item.Product.Id == productId)
                    {
                        session.Remove(item);
                        hasChanged = true;
                        break;
                    }
                }
                if (hasChanged)
                {
                    HttpContext.Session.Set(CommonConstants.CartSession, session);
                }
                return new OkObjectResult(productId);
            }
            return new EmptyResult();
        }

        // cập nhật sản phẩm trong giỏ hàng
        public IActionResult UpdateCart(int productId, int quantity)
        {
            var session = HttpContext.Session.Get<List<ShoppingCartViewModel>>(CommonConstants.CartSession);
            if (session != null)
            {
                bool hasChanged = false;
                foreach (var item in session)
                {
                    if (item.Product.Id == productId)
                    {
                        var product = _productService.GetById(productId);
                        item.Product = product;
                        item.Quantity = quantity;
                        item.Price = product.PromotionPrice ?? product.Price;
                        hasChanged = true;
                    }
                }
                if (hasChanged)
                {
                    HttpContext.Session.Set(CommonConstants.CartSession, session);
                }
                return new OkObjectResult(productId);
            }
            return new EmptyResult();
        }
        #endregion
    }
}

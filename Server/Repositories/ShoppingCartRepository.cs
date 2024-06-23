﻿using Server.Entities;

namespace Server.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ServerDbContext _serverDbContext;
        private readonly IdentityContext _identityContext;
        public ShoppingCartRepository(ServerDbContext serverDbContext, IdentityContext identityContext)
        {
            _serverDbContext = serverDbContext;
            _identityContext = identityContext;
        }
        public ShoppingCart GetShoppingCartById(string shoppingCartId)
        {
            return _serverDbContext.ShoppingCart.FirstOrDefault(x => x.Id == shoppingCartId);
        }
        public List<ShoppingCart> GetShoppingCarts()
        {
            return _serverDbContext.ShoppingCart.ToList();
        }
        public void CreateShoppingCart(ShoppingCart model)
        {
            var shoppingcart = new ShoppingCart
            {
                Id = model.Id,
                UserId = model.UserId,
                ProductAddedShCartId = model.ProductAddedShCartId,
                TotalAmount = model.TotalAmount
            };
            _serverDbContext.ShoppingCart.Add(shoppingcart);
            _serverDbContext.SaveChanges();
        }
        public void UpdateShoppingCart (ShoppingCart model)
        {
            var existingShoppingCart = _serverDbContext.ShoppingCart.FirstOrDefault(p => p.Id == model.Id);
            if (existingShoppingCart != null)
            {
                existingShoppingCart.Id = model.Id;
                existingShoppingCart.UserId = model.UserId;
                existingShoppingCart.ProductAddedShCartId = model.ProductAddedShCartId;
                existingShoppingCart.TotalAmount = model.TotalAmount;

                _serverDbContext.SaveChanges();
            }
        }
        public void DeleteShoppingCart (string shoppingCartId)
        {
            var shoppingcartToDelete = _serverDbContext.ShoppingCart.FirstOrDefault(p => p.Id == shoppingCartId);
            if (shoppingcartToDelete != null)
            {
                _serverDbContext.ShoppingCart.Remove(shoppingcartToDelete);
                _serverDbContext.SaveChanges();
            }
        }
        public ShoppingCart CreateFirstShoppingCartByUsername(string userName)
        {
            string userId = null;
            string shoppingcart = null;

            if (!string.IsNullOrEmpty(userName))
            {
                var user = _identityContext.Users.FirstOrDefault(x => x.UserName == userName);
                if (user != null)
                {
                    userId = user.Id;
                }
            }

            if (!string.IsNullOrEmpty(userId))
            {
                var cart = _serverDbContext.ShoppingCart.FirstOrDefault(p => p.UserId == userId);
                if (cart != null)
                {
                    shoppingcart = cart.Id;
                }
            }

            if (string.IsNullOrEmpty(shoppingcart))
            {
                var shoppingCartId = Guid.NewGuid().ToString();

                var result = new ShoppingCart
                {
                    Id = shoppingCartId,
                    UserId = userId,
                    ProductAddedShCartId = 0,
                    TotalAmount = 0
                };

                _serverDbContext.ShoppingCart.Add(result);
                _serverDbContext.SaveChanges();
                return result;
            }
            return new ShoppingCart(); // sau poți returna `null` dacă preferi să indic că nu a fost creat un nou coș de cumpărături
        }
    }
}

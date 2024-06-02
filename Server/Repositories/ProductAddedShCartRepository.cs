﻿using Server.Entities;

namespace Server.Repositories
{
    public class ProductAddedShCartRepository : IProductAddedShCartRepository
    {
        private readonly ServerDbContext _serverDbContext;
        public ProductAddedShCartRepository(ServerDbContext serverDbContext)
        {
            _serverDbContext = serverDbContext;
        }
        public ProductAddedShCart GetProductAddedShCartById(int productaddedshcartid) 
        {
            return _serverDbContext.ProductAddedShCart.FirstOrDefault(x => x.Id == productaddedshcartid);
        }
        public List<ProductAddedShCart> GetProductAddedShCart()
        {
            return _serverDbContext.ProductAddedShCart.ToList();
        }
        public void CreateProductAddedShCart(ProductAddedShCart model)
        {
            var productaddedshcartid = new ProductAddedShCart
            {
                Id = model.Id,
                UsertId = model.UsertId,
                ShoppingCartId = model.ShoppingCartId,
                ProductId = model.ProductId,
                SelectedQuantity = model.SelectedQuantity
            };
            _serverDbContext.ProductAddedShCart.Add(productaddedshcartid);
            _serverDbContext.SaveChanges();
        }
        public void UpdateProductAddedShCart (ProductAddedShCart model)
        {
            var existingProductAdded = _serverDbContext.ProductAddedShCart.FirstOrDefault(p => p.Id == model.Id);
            if (existingProductAdded != null)
            {
                existingProductAdded.Id = model.Id;
                existingProductAdded.UsertId = model.UsertId;
                existingProductAdded.ShoppingCartId = model.ShoppingCartId;
                existingProductAdded.ProductId = model.ProductId;
                existingProductAdded.SelectedQuantity = model.SelectedQuantity;  

                _serverDbContext.SaveChanges();
            }
        }
        public void DeleteProductAddedShCart (int productaddedshcartid) 
        {
            var productaddedshcartidToDelete = _serverDbContext.ProductAddedShCart.FirstOrDefault(p => p.Id == productaddedshcartid);
            if (productaddedshcartidToDelete != null)
            {
                _serverDbContext.ProductAddedShCart.Remove(productaddedshcartidToDelete);
                _serverDbContext.SaveChanges();
            }
        }
    }
}

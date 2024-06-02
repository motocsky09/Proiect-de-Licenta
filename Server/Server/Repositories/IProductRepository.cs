using Server.Entities;

namespace Server.Repositories
{
    public interface IProductRepository
    {
        public Product GetProductById (int productid);
        public List<Product> GetProducts();
        public void CreateProduct(Product model);

        public void UpdateProduct(Product model);

        public void DeleteProduct(int productid);
    }
}

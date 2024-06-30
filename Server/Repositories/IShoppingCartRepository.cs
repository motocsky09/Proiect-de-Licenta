using Server.Entities;

namespace Server.Repositories
{
    public interface IShoppingCartRepository
    {
        public ShoppingCart GetShoppingCartById(string shoppingcartId);
        public List<ShoppingCart> GetShoppingCarts();
        public void CreateShoppingCart(ShoppingCart model);
        public void UpdateShoppingCart(ShoppingCart model);
        public void DeleteShoppingCart (string shoppingcartId);

        public ShoppingCart CreateFirstShoppingCartByUsername(string username);

        public ProductAddedShCart AddProductInShoppingCart(ProductAddedShCart model);

        public string GetShoppingCartIdByUserName(string userId);
    }
}

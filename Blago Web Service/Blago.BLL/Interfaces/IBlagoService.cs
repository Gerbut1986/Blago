namespace Blago.BLL.Interfaces
{
    using DTO;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IBlagoService
    {
        #region Category Service:
        void Insert(CategoryDto model);
        IEnumerable<CategoryDto> ReadCategories();
        Task<List<CategoryDto>> ReadCategoriesAsync();
        void Update(CategoryDto model);
        void DeleteCategory(int id);
        #endregion

        #region Product Service:
        void Insert(ProductDto model);
        Task InsertAsync(ProductDto model);
        IEnumerable<ProductDto> ReadProducts();
        Task<List<ProductDto>> ReadProductsAsync();
        void Update(ProductDto model);
        void DeleteProduct(int id);
        #endregion

        #region Cart Service:
        void Insert(CartDto model);
        IEnumerable<CartDto> ReadCarts();
        Task<List<CartDto>> ReadCartsAsync();
        void Update(CartDto model);
        void DeleteCart(int id);
        #endregion

        #region Main Balance Service:
        void Insert(MainBalanceDto model);
        Task InsertAsync(MainBalanceDto model);
        IEnumerable<MainBalanceDto> ReadMainBalances();
        Task<List<MainBalanceDto>> ReadMainBalancesAsync();
        void Update(MainBalanceDto model);
        void DeleteMainBalance(MainBalanceDto entity);
        Task DeleteMainBalanceAsync(int id);
        #endregion

        #region Order Service:
        void Insert(OrderDto model);
        Task InsertAsync(OrderDto model);
        IEnumerable<OrderDto> ReadOrders();
        Task<List<OrderDto>> ReadOrdersAsync();
        void Update(OrderDto model);
        void DeleteOrder(OrderDto entity);
        Task DeleteOrderAsync(int id);
        #endregion
    }
}

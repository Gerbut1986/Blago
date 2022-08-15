namespace Blago.PL.Models
{
    using Blago.BLL.DTO;
    using System.Collections.Generic;

    public class StaticTables
    {
        public static List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public static List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public static List<CartDto> Carts { get; set; } = new List<CartDto>(); 
        public static List<WithdrawDto> Withdrawals { get; set; } = new List<WithdrawDto>();
        public static List<RefMemberDto> RefMembers { get; set; } = new List<RefMemberDto>();
        public static List<MessageDto> Messages { get; set; } = new List<MessageDto>();
        public static List<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public static List<MainBalanceDto> MainBalances { get; set; } = new List<MainBalanceDto>();

        public static void ClearAllTbls()
        {
            Categories = new List<CategoryDto>();
            Products = new List<ProductDto>();
            Carts = new List<CartDto>();
            Withdrawals = new List<WithdrawDto>();
            RefMembers = new List<RefMemberDto>();
            Messages = new List<MessageDto>();
            MainBalances = new List<MainBalanceDto>();
            Orders = new List<OrderDto>();
        }
    }
}
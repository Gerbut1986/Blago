namespace Blago.BLL.Services
{
    using System;
    using Interfaces;
    using System.Linq;
    using System.Threading.Tasks;
    using Blago.BLL.DTO;
    using Blago.DAL.UOF;
    using System.Collections.Generic;
    using Blago.DAL.Entities;
    using Blago.DAL.Interfaces;

    public class BlagoService : IBlagoService
    {
        readonly IUnitOfWork Db;

        #region Constructor:
        public BlagoService(string strConn)
        {
            Db = new UnitOfWork(strConn);
        }
        #endregion

        #region Cart Service:
        public void Insert(CartDto dto)
        {
            try
            {
                var model = new ShopingCart
                {
                    ItemsPrice = dto.ItemsPrice,
                    OrderDate = dto.OrderDate,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    UserId = dto.UserId,
                    ProductName = dto.ProductName,
                    ProductPhoto = dto.ProductPhoto
                };
                Db.Carts.Create(model);
            }
            catch { throw new Exception($"Method - '{nameof(Insert)}({dto.GetType().Name})'"); }
        }

        public IEnumerable<CartDto> ReadCarts()
        {
            var list = Db.Carts.GetAll().ToList();
            var listDTO = new List<CartDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new CartDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].ItemsPrice = list[i].ItemsPrice;
                listDTO[i].OrderDate = list[i].OrderDate;
                listDTO[i].Price = list[i].Price;
                listDTO[i].Quantity = list[i].Quantity;
                listDTO[i].UserId = list[i].UserId;
                listDTO[i].ProductName = list[i].ProductName;
                listDTO[i].ProductPhoto = list[i].ProductPhoto;
            }
            return listDTO;
        }

        public async Task<List<CartDto>> ReadCartsAsync()
        {
            var l = await Db.Carts.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<CartDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new CartDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].ItemsPrice = list[i].ItemsPrice;
                listDTO[i].OrderDate = list[i].OrderDate;
                listDTO[i].Price = list[i].Price;
                listDTO[i].Quantity = list[i].Quantity;
                listDTO[i].UserId = list[i].UserId;
                listDTO[i].ProductName = list[i].ProductName; 
                listDTO[i].ProductPhoto = list[i].ProductPhoto;
            }
            return listDTO;
        }

        public void Update(CartDto dto)
        {
            try
            {
                var model = new ShopingCart
                {
                    ItemsPrice = dto.ItemsPrice,
                    OrderDate = dto.OrderDate,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    UserId = dto.UserId,
                    ProductName = dto.ProductName,
                    ProductPhoto = dto.ProductPhoto
                };
                Db.Carts.Update(model);
            }
            catch { throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public void DeleteCart(int id)
        {
            try
            {
                Db.Carts.DeleteAsync(id);
            }
            catch { throw new Exception($"Method - '{nameof(DeleteCart)}({id})'"); }
        }
        #endregion

        #region Product Service:
        public void Insert(ProductDto dto)
        {

        }

        public void InsertAsync(ProductDto dto)
        {
            try
            {
                var model = new Product
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    CategoryId = dto.CategoryId,
                    Date = dto.Date,
                    Description = dto.Description,
                    IsStock = dto.IsStock,
                    Photo = dto.Photo,
                    Price = dto.Price
                };
                Db.Products.Create(model);
            }
            catch { throw new Exception($"Method - '{nameof(Insert)}({dto.GetType().Name})'"); }
        }

        public IEnumerable<ProductDto> ReadProducts()
        {
            var list = Db.Products.GetAll().ToList();
            var listDTO = new List<ProductDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new ProductDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Name = list[i].Name;
                listDTO[i].Code = list[i].Code;
                listDTO[i].CategoryId = list[i].CategoryId;
                listDTO[i].Date = list[i].Date;
                listDTO[i].Description = list[i].Description;
                listDTO[i].IsStock = list[i].IsStock;
                listDTO[i].Photo = list[i].Photo;
                listDTO[i].Price = list[i].Price;
            }
            return listDTO;
        }

        public async Task<List<ProductDto>> ReadProductsAsync()
        {
            var l = await Db.Products.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<ProductDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new ProductDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Name = list[i].Name;
                listDTO[i].Code = list[i].Code;
                listDTO[i].CategoryId = list[i].CategoryId;
                listDTO[i].Date = list[i].Date;
                listDTO[i].Description = list[i].Description;
                listDTO[i].IsStock = list[i].IsStock;
                listDTO[i].Photo = list[i].Photo;
                listDTO[i].Price = list[i].Price;
            }
            return listDTO;
        }

        public void Update(ProductDto dto)
        {
            try
            {
                var model = new Product
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    CategoryId = dto.CategoryId,
                    Date = dto.Date,
                    Description = dto.Description,
                    IsStock = dto.IsStock,
                    Photo = dto.Photo,
                    Price = dto.Price
                };
                Db.Products.Update(model);
            }
            catch { throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                Db.Products.DeleteAsync(id);
            }
            catch { throw new Exception($"Method - '{nameof(DeleteProduct)}({id})'"); }
        }
        #endregion

        #region Category Service:
        public void Insert(CategoryDto dto)
        {
            try
            {
                var model = new Category
                {
                    Name = dto.Name,
                    TagName = dto.TagName,
                    Photo = dto.Photo
                };
                Db.Categories.Create(model);
            }
            catch { throw new Exception($"Method - '{nameof(Insert)}({dto.GetType().Name})'"); }
        }

        public IEnumerable<CategoryDto> ReadCategories()
        {
            var list = Db.Categories.GetAll().ToList();
            var listDTO = new List<CategoryDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new CategoryDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Name = list[i].Name;
                listDTO[i].TagName = list[i].TagName;
                listDTO[i].Photo = list[i].Photo;
            }
            return listDTO;
        }

        public async Task<List<CategoryDto>> ReadCategoriesAsync()
        {
            var l = await Db.Categories.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<CategoryDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new CategoryDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Name = list[i].Name;
                listDTO[i].TagName = list[i].TagName;
                listDTO[i].Photo = list[i].Photo;
            }
            return listDTO;
        }

        public void Update(CategoryDto dto)
        {
            try
            {
                var model = new Category
                {
                    Name = dto.Name,
                    TagName = dto.TagName,
                    Photo = dto.Photo
                };
                Db.Categories.Update(model);
            }
            catch { throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                Db.Categories.DeleteAsync(id);
            }
            catch { throw new Exception($"Method - '{nameof(DeleteCategory)}({id})'"); }
        }
        #endregion

        #region Withdrawals Service:
        public void Insert(WithdrawDto dto)
        {
            try
            {
                var model = new Withdrawal
                {
                    Status = dto.Status,
                    Amount = dto.Amount,
                    DateWithdraw = dto.DateWithdraw,
                    Message = dto.Message,
                    NumberCard = dto.NumberCard,
                    UserId = dto.UserId
                };
                Db.Withdrawals.Create(model);
            }
            catch (Exception ex){ string err = ex.Message; }
        }

        public IEnumerable<WithdrawDto> ReadWithdrawals()
        {
            var list = Db.Withdrawals.GetAll().ToList();
            var listDTO = new List<WithdrawDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new WithdrawDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].UserId = list[i].UserId;
                listDTO[i].DateWithdraw = list[i].DateWithdraw;
                listDTO[i].Amount = list[i].Amount;
                listDTO[i].Message = list[i].Message;
                listDTO[i].NumberCard = list[i].NumberCard;
                listDTO[i].Status = list[i].Status;
            }
            return listDTO;
        }

        public async Task<List<WithdrawDto>> ReadWithdrawalsAsync()
        {
            var l = await Db.Withdrawals.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<WithdrawDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new WithdrawDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].UserId = list[i].UserId;
                listDTO[i].DateWithdraw = list[i].DateWithdraw;
                listDTO[i].Amount = list[i].Amount; 
                listDTO[i].Message = list[i].Message;
                listDTO[i].NumberCard = list[i].NumberCard; 
                listDTO[i].Status = list[i].Status;
            }
            return listDTO;
        }

        public void Update(WithdrawDto dto)
        {
            try
            {
                var model = new Withdrawal
                {
                    Status = dto.Status,
                    Amount = dto.Amount,
                    DateWithdraw = dto.DateWithdraw,
                    Message = dto.Message,
                    NumberCard = dto.NumberCard,
                    UserId = dto.UserId
                };
                Db.Withdrawals.Update(model);
            }
            catch { throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public void DeleteWithdrawal(int id)
        {
            try
            {
                Db.Withdrawals.DeleteAsync(id);
            }
            catch { throw new Exception($"Method - '{nameof(DeleteCategory)}({id})'"); }
        }
        #endregion

        #region Referal Members Service:
        public void Insert(RefMemberDto dto)
        {
            try
            {
                var model = new RefMember
                {
                    DateRegister = dto.DateRegister,
                    MemberId = dto.MemberId,
                    OwnerId = dto.OwnerId,
                    RefNumber = dto.RefNumber,
                    InvitedBy = dto.InvitedBy
                };
                Db.RefMembers.Create(model);
            }
            catch { throw new Exception($"Method - '{nameof(Insert)}({dto.GetType().Name})'"); }
        }

        public async Task InsertAsync(RefMemberDto dto)
        {
            try
            {
                var model = new RefMember
                {
                    DateRegister = dto.DateRegister,
                    MemberId = dto.MemberId,
                    OwnerId = dto.OwnerId,
                    RefNumber = dto.RefNumber,
                    InvitedBy = dto.InvitedBy
                };
                await Db.RefMembers.CreateAsync(model);
            }
            catch { throw new Exception($"Method - '{nameof(Insert)}({dto.GetType().Name})'"); }
        }

        public IEnumerable<RefMemberDto> ReadRefMembers()
        {
            var list = Db.RefMembers.GetAll().ToList();
            var listDTO = new List<RefMemberDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new RefMemberDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].DateRegister = list[i].DateRegister;
                listDTO[i].MemberId = list[i].MemberId;
                listDTO[i].OwnerId = list[i].OwnerId;
                listDTO[i].RefNumber = list[i].RefNumber;
                listDTO[i].InvitedBy = list[i].InvitedBy;
            }
            return listDTO;
        }

        public async Task<List<RefMemberDto>> ReadRefMembersAsync()
        {
            var l = await Db.RefMembers.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<RefMemberDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new RefMemberDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].DateRegister = list[i].DateRegister;
                listDTO[i].MemberId = list[i].MemberId;
                listDTO[i].OwnerId = list[i].OwnerId;
                listDTO[i].RefNumber = list[i].RefNumber;
                listDTO[i].InvitedBy = list[i].InvitedBy;
            }
            return listDTO;
        }

        public void Update(RefMemberDto dto)
        {
            try
            {
                var model = new RefMember
                {
                    DateRegister = dto.DateRegister,
                    MemberId = dto.MemberId,
                    OwnerId = dto.OwnerId,
                    InvitedBy = dto.InvitedBy,
                    RefNumber = dto.RefNumber
                };
                Db.RefMembers.Update(model);
            }
            catch { throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public void DeleteRefMember(int id)
        {
            try
            {
                Db.RefMembers.DeleteAsync(id);
            }
            catch { throw new Exception($"Method - '{nameof(DeleteRefMember)}({id})'"); }
        }
        #endregion

        #region Messages Service:
        public void Insert(MessageDto dto)
        {
            try
            {
                var model = new Messages
                {
                    Title = dto.Title,
                    Status = dto.Status,
                    DateSend = dto.DateSend,
                    Message = dto.Message,
                    RecipientId = dto.RecipientId,
                    SenderId = dto.SenderId
                };
                Db.Messages.Create(model);
            }
            catch { throw new Exception($"Method - '{nameof(Insert)}({dto.GetType().Name})'"); }
        }

        public IEnumerable<MessageDto> ReadMessages()
        {
            var list = Db.Messages.GetAll().ToList();
            var listDTO = new List<MessageDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new MessageDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].DateSend = list[i].DateSend;
                listDTO[i].Title = list[i].Title;
                listDTO[i].Status = list[i].Status;
                listDTO[i].Message = list[i].Message;
                listDTO[i].RecipientId = list[i].RecipientId;
                listDTO[i].SenderId = list[i].SenderId;
            }
            return listDTO;
        }

        public async Task<List<MessageDto>> ReadMessagesAsync()
        {
            var l = await Db.Messages.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<MessageDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new MessageDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Title = list[i].Title; 
                listDTO[i].Status = list[i].Status;
                listDTO[i].DateSend = list[i].DateSend;
                listDTO[i].Message = list[i].Message;
                listDTO[i].RecipientId = list[i].RecipientId; 
                listDTO[i].SenderId = list[i].SenderId;
            }
            return listDTO;
        }

        public void Update(MessageDto dto)
        {
            try
            {
                var model = new Messages
                {
                    Title = dto.Title,
                    Status = dto.Status,
                    DateSend = dto.DateSend,
                    Message = dto.Message,
                    RecipientId = dto.RecipientId,
                    SenderId = dto.SenderId
                };
                Db.Messages.Update(model);
            }
            catch { throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public void DeleteMessage(int id)
        {
            try
            {
                Db.Messages.DeleteAsync(id);
            }
            catch { throw new Exception($"Method - '{nameof(DeleteMessage)}({id})'"); }
        }
        #endregion

        #region Main Balances Service:
        public void Insert(MainBalanceDto dto)
        {
            try
            {
                var model = new MainBalance
                {
                    Date = dto.Date,
                    UserId = dto.UserId,
                    Amount = dto.Amount
                };
                Db.MainBalances.Create(model);
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public async Task InsertAsync(MainBalanceDto dto)
        {
            try
            {
                var model = new MainBalance
                {
                    Date = dto.Date,
                    UserId = dto.UserId,
                    Amount = dto.Amount
                };
                await Db.MainBalances.CreateAsync(model);
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public IEnumerable<MainBalanceDto> ReadMainBalances()
        {
            var list = Db.MainBalances.GetAll().ToList();
            var listDTO = new List<MainBalanceDto>();
            for (int i = 0; i < list.Count; i++)
            {

                listDTO.Add(new MainBalanceDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Date = list[i].Date;
                listDTO[i].Amount = list[i].Amount;
                listDTO[i].UserId = list[i].UserId;
            }
            return listDTO;
        }

        public async Task<List<MainBalanceDto>> ReadMainBalancesAsync()
        {
            var l = await Db.MainBalances.GetAllAsync();
            var list = l.ToList();
            var listDTO = new List<MainBalanceDto>();
            for (int i = 0; i < list.Count; i++)
            {
                listDTO.Add(new MainBalanceDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].Date = list[i].Date;
                listDTO[i].Amount = list[i].Amount;
                listDTO[i].UserId = list[i].UserId;
            }
            return listDTO;
        }

        public void Update(MainBalanceDto dto)
        {
            try
            {
                var model = new MainBalance
                {
                    Id = dto.Id,
                    Date = dto.Date,
                    UserId = dto.UserId,
                    Amount = dto.Amount
                };
                Db.MainBalances.Update(model);
            }
            catch(Exception ex) { var errorMsg = ex.Message; throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public async Task UpdateAsync(MainBalanceDto dto)
        {
            try
            {
                var model = new MainBalance
                {
                    Id = dto.Id,
                    Date = dto.Date,
                    UserId = dto.UserId,
                    Amount = dto.Amount
                };
                await Db.MainBalances.UpdateAsync(model.Id);
            }
            catch (Exception ex) { var errorMsg = ex.Message; throw new Exception($"Method - '{nameof(Update)}({dto.GetType().Name})'"); }
        }

        public string DeleteMainBalance(MainBalanceDto mb)
        {
            try
            {
                var mainB = new MainBalance
                {
                    Amount = mb.Amount,
                    Date = mb.Date,
                    UserId = mb.UserId,
                    Id = mb.Id
                };
                Db.MainBalances.Delete(mainB);
                return "Success!";
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public async Task DeleteMainBalanceAsync(int id)
        {
            try
            {
               await Db.MainBalances.DeleteAsync(id);
            }
            catch(Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }
        #endregion

        #region Orders Service:
        public void Insert(OrderDto dto)
        {
            try
            {
                var model = new Order
                {
                    OrderDate = dto.OrderDate,
                    UserId = dto.UserId,
                    TotalSum = dto.TotalSum
                };
                Db.Orders.Create(model);
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public async Task InsertAsync(OrderDto dto)
        {
            try
            {
                var model = new Order
                {
                    OrderDate = dto.OrderDate,
                    UserId = dto.UserId,
                    TotalSum = dto.TotalSum
                };
                await Db.Orders.CreateAsync(model);
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public IEnumerable<OrderDto> ReadOrders()
        {
            var list = Db.Orders.GetAll().ToList();
            var listDTO = new List<OrderDto>();
            for (int i = 0; i < list.Count; i++)
            {

                listDTO.Add(new OrderDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].OrderDate = list[i].OrderDate;
                listDTO[i].TotalSum = list[i].TotalSum;
                listDTO[i].UserId = list[i].UserId;
            }
            return listDTO;
        }

        public async Task<List<OrderDto>> ReadOrdersAsync()
        {
            var list = await Db.Orders.GetAllAsync();
            var listDTO = new List<OrderDto>();
            for (int i = 0; i < list.Count; i++)
            {

                listDTO.Add(new OrderDto());
                listDTO[i].Id = list[i].Id;
                listDTO[i].OrderDate = list[i].OrderDate;
                listDTO[i].TotalSum = list[i].TotalSum;
                listDTO[i].UserId = list[i].UserId;
            }
            return listDTO;
        }

        public void Update(OrderDto dto)
        {
            try
            {
                var model = new Order
                {
                    OrderDate = dto.OrderDate,
                    UserId = dto.UserId,
                    TotalSum = dto.TotalSum
                };
                Db.Orders.Update(model);
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public void DeleteOrder(OrderDto dto)
        {
            try
            {
                var model = new Order
                {
                    OrderDate = dto.OrderDate,
                    UserId = dto.UserId,
                    TotalSum = dto.TotalSum
                };
                Db.Orders.Delete(model);
            }
            catch (Exception ex) { throw new Exception($"{ex.Message}\n{ex.StackTrace}"); }
        }

        public Task DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IBlagoService.InsertAsync(ProductDto model)
        {
            throw new NotImplementedException();
        }

        void IBlagoService.DeleteMainBalance(MainBalanceDto entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

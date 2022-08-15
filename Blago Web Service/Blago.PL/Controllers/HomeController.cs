using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blago.BLL.DTO;
using Blago.BLL.DTO.EmailEntity;
using Blago.BLL.Services;
using Blago.PL.Models;
using Blago.PL.Models.Logic;
using Microsoft.AspNet.Identity.Owin;

namespace Blago.PL.Controllers
{
    internal enum WithdrawError
    {
        AmountEmpty,
        AmountLess5000,
        CartNumberEmpty,
    }

    public class HomeController : Controller
    {
        // Here will be stored info 'bout all income with a referal's sells:
        private static double[] LevelsProcents = new double[5];
        private static Models.Logic.ReferalLogic RefLogic { get; set; }
        private static string RefLink { get; set; }
        private string Token { get; set; }
        static bool isWithdrawal = false, isWithdrawalError = false,
            isWelcome = false, isRegDataUpd = false, isMessageSent = false, isBalanceIsLess = false, isUserBuyProduct = false;
        private string CurrentUserEmail;
        private readonly BlagoService db;
        static List<ApplicationUser> AllUsers { get; set; }
        private static Dictionary<DateTime, string> BalancesSorted { get; set; }

        public HomeController()
        {
            db = new BlagoService(Init.ConnectionStr);
        }

        private ApplicationUser CurrentLocalUser { get; set; }
        public ApplicationUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public ApplicationUser GetCurrUser(string afterReg = null)
        {
            if (afterReg != null)
                return UserManager.Users.FirstOrDefault(n => n.Email.Equals(CurrentUserEmail));
            return UserManager.Users.FirstOrDefault(n => n.Email.Equals(CurrentUserEmail));
        }

        public ActionResult WelcomeEnter()
        {
            isWelcome = true;
            return RedirectToAction("mainpage");
        }

        public async Task<ActionResult> MainPage(string currEmail)
        {
            if (CurrentUserEmail != null || currEmail != null)
            {
                AllUsers = UserManager.Users.ToList();
                //CurrentLocalUser = GetCurrUser(currEmail);
                await FillRefLink(RefLink);
                StaticTables.RefMembers = StaticTables.RefMembers.Where(r => r.OwnerId == CurrentLocalUser.UserId).ToList();
                ViewBag.PhoneId = CurrentLocalUser.PhoneNumber.Trim(new char[] { '+' });
                await LoadAllDataFromTables();
                var dict = Separate2Tables();
                BalancesSorted = dict.OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                // Checking if user maked an order(from Orders table):
                if (StaticTables.Orders.Count != 0)
                {
                    //if (StaticTables.Orders.FirstOrDefault(f => f.UserId == CurrentLocalUser.UserId) != null)  // Если юзер купил продукт
                    // {
                    isUserBuyProduct = true;
                    //}
                }
                var firstLevelPercent = RefLogic.GetPercentFrom1stReferal(isUserBuyProduct, CurrentLocalUser.UserId);
                { ViewBag.FirstPercent = firstLevelPercent; }
                { ViewBag.Level1Percent = RefLogic.GetPercents1Level(isUserBuyProduct); }
                { ViewBag.Level2Percent = RefLogic.GetPercents2Level(isUserBuyProduct, db); }
                { ViewBag.Level3Percent = RefLogic.GetPercents3Level(isUserBuyProduct); }
                { ViewBag.Level4Percent = RefLogic.GetPercents4Level(isUserBuyProduct); }
                { ViewBag.Level5Percent = RefLogic.GetPercents5Level(isUserBuyProduct); }
                { ViewBag.Level1Cnt = RefLogic.Get1Level(); }
                { ViewBag.Level2Cnt = RefLogic.Get2Level(); }
                { ViewBag.Level3Cnt = RefLogic.Get3Level(); }
                { ViewBag.Level4Cnt = RefLogic.Get4Level(); }
                { ViewBag.Level5Cnt = RefLogic.Get5Level(); }
            }
            else return RedirectToAction("Index");

            { ViewBag.IsRegDataUpd = isRegDataUpd; }
            { ViewBag.Users = AllUsers; }
            { ViewBag.Withdrawals = StaticTables.Withdrawals; }
            { ViewBag.Referals = StaticTables.RefMembers; }
            { ViewBag.Balances = StaticTables.MainBalances; }
            { ViewBag.Messages = StaticTables.Messages; }
            { ViewBag.BalWithdr = BalancesSorted; }
            { ViewBag.CurrentUser = CurrentLocalUser; }
            { ViewBag.IsWithdrawalError = isWithdrawalError; }
            { ViewBag.IsWithdrawal = isWithdrawal; }
            { ViewBag.IsWelcome = isWelcome; }
            { ViewBag.IsMessageSent = isMessageSent; }
            { ViewBag.IsBalanceLess = isBalanceIsLess; }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> MainPage(object param, Filter filter)
        {
            string button = string.Empty;
            try
            {
                button =
                   Request.Params.Cast<string>().Where(p => p.StartsWith("btn")).Select(p => p.Substring("btn".Length)).First().Remove(0, 1);
            }
            catch { }
            if (button != null)
            {
                switch (button)
                {
                    case "Filter":
                        await CheckFillOutTbl(StaticTables.Withdrawals);
                        await CheckFillOutTbl(StaticTables.MainBalances);
                        StaticTables.Withdrawals =
                            (from c in StaticTables.Withdrawals
                             where c.DateWithdraw >= filter.From && c.DateWithdraw <= filter.To
                             where c.Status == "В ожидании.."
                             where c.UserId == CurrentLocalUser.UserId
                             select c)
                            .ToList();
                        StaticTables.MainBalances =
                            (from c in StaticTables.MainBalances
                             where c.Date >= filter.From && c.Date <= filter.To
                             where c.UserId == CurrentLocalUser.UserId
                             select c)
                            .ToList();
                        break;
                    case "buy 1":
                        db.Insert(new OrderDto
                        {
                            OrderDate = DateTime.Now,
                            TotalSum = 250, //StaticTables.Products.FirstOrDefault(f=>f.Id==1).Price,
                            UserId = CurrentLocalUser.UserId
                        });
                        break;
                }
            }

            if (StaticTables.Orders.Count != 0 || StaticTables.Orders != null)
            {
                //if (StaticTables.Orders.FirstOrDefault(f => f.UserId == CurrentLocalUser.UserId) != null)  // Если юзер купил продукт
                // {
                isUserBuyProduct = true;
                //}
            }
            var firstLevelPercent = RefLogic.GetPercentFrom1stReferal(isUserBuyProduct, CurrentLocalUser.UserId);

            { ViewBag.FirstPercent = firstLevelPercent; }
            { ViewBag.FirstPercent = firstLevelPercent; }
            { ViewBag.Level1Percent = RefLogic.GetPercents1Level(isUserBuyProduct); }
            { ViewBag.Level2Percent = RefLogic.GetPercents2Level(isUserBuyProduct, db); }
            { ViewBag.Level3Percent = RefLogic.GetPercents3Level(isUserBuyProduct); }
            { ViewBag.Level4Percent = RefLogic.GetPercents4Level(isUserBuyProduct); }
            { ViewBag.Level5Percent = RefLogic.GetPercents5Level(isUserBuyProduct); }
            { ViewBag.Level1Cnt = RefLogic.Get1Level(); }
            { ViewBag.Level2Cnt = RefLogic.Get2Level(); }
            { ViewBag.Level3Cnt = RefLogic.Get3Level(); }
            { ViewBag.Level4Cnt = RefLogic.Get4Level(); }
            { ViewBag.Level5Cnt = RefLogic.Get5Level(); }
            { ViewBag.IsRegDataUpd = isRegDataUpd; }
            { ViewBag.Users = AllUsers; }
            { ViewBag.Referals = StaticTables.RefMembers; }
            { ViewBag.Messages = StaticTables.Messages; }
            { ViewBag.Balances = StaticTables.MainBalances; }
            { ViewBag.Withdrawals = StaticTables.Withdrawals; }
            { ViewBag.IsWithdrawalError = isWithdrawalError; }
            { ViewBag.IsWithdrawal = isWithdrawal; }
            { ViewBag.BalWithdr = BalancesSorted; }
            { ViewBag.IsWelcome = isWelcome; }
            { ViewBag.CurrentUser = CurrentLocalUser; }
            { ViewBag.IsMessageSent = isMessageSent; }
            { ViewBag.IsBalanceLess = isBalanceIsLess; }
            return View();
        }

        public ActionResult Index()  // Главная (информационная) страница
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Withdrawals(WithdrawDto withdrawInfo)
        {
            isWithdrawal = isBalanceIsLess = false;
            CurrentLocalUser = GetCurrUser();
            var currBal = StaticTables.MainBalances.Where(f => f.UserId == withdrawInfo.UserId);
            var cntBal = 0;
            foreach (var bal in currBal)
            {
                cntBal += int.Parse(bal.Amount.Trim('+'));
            }

            if (withdrawInfo.Amount == null || int.Parse(withdrawInfo.Amount) < 5000)
            {
                isWithdrawalError = true;
                return RedirectToAction("mainpage");
            }
            else if (cntBal < int.Parse(withdrawInfo.Amount))
            {
                isBalanceIsLess = true;
                return RedirectToAction("mainpage");
            }
            db.Insert(new WithdrawDto
            {
                Amount = "-" + withdrawInfo.Amount,
                DateWithdraw = DateTime.Now,
                Message = "Новая заявка на вывод средств!",
                Status = "В ожидании..",
                NumberCard = withdrawInfo.NumberCard,
                UserId = CurrentLocalUser.UserId
            });

            cntBal = (cntBal - int.Parse(withdrawInfo.Amount));
            var currentBalance = StaticTables.MainBalances.FirstOrDefault(f => f.UserId == withdrawInfo.UserId);
            currentBalance.Amount = "+" + cntBal.ToString();
            currentBalance.Date = DateTime.Now;

            foreach (var mb in currBal)
            {
                db.DeleteMainBalance(mb);
            }
            db.Insert(currentBalance);

            isWithdrawal = true;

            return RedirectToAction("mainpage");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRegData(ApplicationUser userInfo)
        {
            if (userInfo != null)
            {
                CurrentLocalUser = UserManager.Users.FirstOrDefault(f => f.Email == CurrentUserEmail);
                // Save RefLink to Referal field in parallel:
                CurrentLocalUser.Referal = RefLink;
                CurrentLocalUser.Telegram = userInfo.Telegram;
                CurrentLocalUser.Country = userInfo.Country;
                CurrentLocalUser.CardNumber = userInfo.CardNumber;
                var res = await UserManager.UpdateAsync(CurrentLocalUser);
                isRegDataUpd = true;
                return RedirectToAction("mainpage");
            }

            return RedirectToAction("mainpage");
        }

        public ActionResult SendMessage(EmailData mailInfo)
        {
            //var recipient = UserManager.Users.FirstOrDefault(f => f.UserId == userInfo.UserId);
            isMessageSent = true;
            return RedirectToAction("mainpage");
        }

        public ActionResult CloseAlerts()
        {
            isWithdrawal = isWithdrawalError = isWelcome = isRegDataUpd = isBalanceIsLess = false;
            return RedirectToAction("mainpage");
        }

        #region Auxiliary methods:
        async Task FillRefLink(string link)
        {
            if (link != null)
            {
                CurrentLocalUser.Referal = RefLink;
                await UserManager.UpdateAsync(CurrentLocalUser);
            }
        }

        private Dictionary<DateTime, string> Separate2Tables()
        {
            var dict = new Dictionary<DateTime, string>();
            var currBal = StaticTables.MainBalances.Where(u => u.UserId == CurrentLocalUser.UserId);
            var currWith = StaticTables.Withdrawals.Where(u => u.UserId == CurrentLocalUser.UserId);
            foreach (var with in currWith)
            {
                dict.Add(with.DateWithdraw, with.Amount);
            }
            foreach (var bals in currBal)
            {
                dict.Add(bals.Date, bals.Amount);
            }
            return dict;
        }

        private async Task<string> LoadAllDataFromTables()
        {
            try
            {
                await CheckFillOutTbl(StaticTables.MainBalances);
                await CheckFillOutTbl(StaticTables.Messages);
                await CheckFillOutTbl(StaticTables.RefMembers);
                await CheckFillOutTbl(StaticTables.Withdrawals);
                await CheckFillOutTbl(StaticTables.Products);
                await CheckFillOutTbl(StaticTables.Orders);
                return "Loaded Successfully!";
            }
            catch (Exception ex) { return ex.Message; }
        }

        private async Task CheckFillOutTbl(IEnumerable<BLL.Interfaces.IModel> table)
        {
            //if (table == null || table.Count() == 0)
            //{
            switch (table.GetType().GetGenericArguments()[0].Name)
            {
                case nameof(MainBalanceDto):
                    StaticTables.MainBalances = await db.ReadMainBalancesAsync();
                    break;
                case nameof(MessageDto):
                    StaticTables.Messages = await db.ReadMessagesAsync();
                    break;
                case nameof(RefMemberDto):
                    StaticTables.RefMembers = await db.ReadRefMembersAsync();
                    break;
                case nameof(WithdrawDto):
                    StaticTables.Withdrawals = await db.ReadWithdrawalsAsync();
                    break;
                case nameof(OrderDto):
                    StaticTables.Orders = await db.ReadOrdersAsync();
                    break;
                case nameof(ProcessInfo):
                    StaticTables.Products = await db.ReadProductsAsync();
                    break;
            }
            // }
        }
        #endregion

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                CurrentUserEmail = filterContext.HttpContext.User.Identity.Name;
                CurrentLocalUser = UserManager.Users.FirstOrDefault(f => f.Email == CurrentUserEmail);
                RefLogic = new ReferalLogic(CurrentLocalUser, UserManager.Users);
            }
            else // When User Log off, or still doesn't enter 
            {
                CurrentUserEmail = null;
                CurrentLocalUser = null;
            }
        }
    }

    public class Filter
    {
        [Required(ErrorMessage = "Выберете с какой даты.")]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "Выберете по какую дату.")]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}
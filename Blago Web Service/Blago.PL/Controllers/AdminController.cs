namespace Blago.PL.Controllers
{
    using Microsoft.AspNet.Identity.Owin;
    using System.Collections.Generic;
    using Blago.BLL.Services;
    using Blago.PL.Models;
    using System.Web.Mvc;
    using System.Web;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;
    using Blago.BLL.DTO;

    enum MessageType
    {
        prostrocheno,
        notresponse,
        income
    }

    public class AdminController : Controller
    {
        public static List<ApplicationUser> AllUsers { get; private set; }
        public static ApplicationUser CurrentUser { get; private set; }
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager; 
        private readonly BlagoService db;
        private bool isMenuPart = false, isMsgRes = false;
        private bool isMsgDetail = false;

        #region Properties:
        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }
        #endregion

        public AdminController()
        {
            db = new BlagoService(Init.ConnectionStr);
        }

        public ActionResult admin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> admin(LoginViewModel admin)
        {
            if (!ModelState.IsValid) return View();
            else
            {
                ApplicationUser signedUser = UserManager.FindByEmail(admin.Email);

                if (signedUser == null) // if login and password doesn't exists
                {
                    ViewBag.Error = "Email или пароль не правильные...";
                    return View(admin);
                }

                SignInStatus result = await SignInManager.PasswordSignInAsync(signedUser.Email, admin.Password, admin.RememberMe, shouldLockout: false);
                if (result == SignInStatus.Success)
                {
                    if (GetAdmin(admin) != null)
                    {                     
                        return RedirectToAction(GetAdmin(admin).ToString());
                    }
                }
            }

            { ViewBag.IsMenuPart = isMenuPart; }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> _829528a_441d_484m_862i_22475963ffdn(string param, string msgRes, int? msgDetailId)
        {
            if (msgRes != null)
            {
                isMsgRes = true;
                ViewBag.MsgRes = msgRes;
            }
            else if (msgDetailId != null)
            {
                isMsgDetail = true;
                var msg = StaticTables.Messages.FirstOrDefault(f => f.Id == msgDetailId);
                ViewBag.MsgDetails = msg;
                ViewBag.Sender = AllUsers.FirstOrDefault(f => f.UserId == msg.SenderId);
            }
            ViewBag.Users = AllUsers;
            await CheckFillOutTbl(StaticTables.Messages);
            await CheckFillOutTbl(StaticTables.Withdrawals);
            await CheckFillOutTbl(StaticTables.MainBalances);
            if (param != null)
            { 
                var select = TypeOfPartial(param);
                if(param == select)
                {
                    ViewBag.PartialView = select;
                    isMenuPart = true;
                    await CheckFillOutTbl(StaticTables.RefMembers);
                    ViewBag.RefMembers = StaticTables.RefMembers;
                }
            }

            { ViewBag.MainBalances = StaticTables.MainBalances; }
            { ViewBag.IsMsgDetails = isMsgDetail; }
            { ViewBag.IsMsgRes = isMsgRes; }
            { ViewBag.Withdrawals = StaticTables.Withdrawals; }
            { ViewBag.Messages = StaticTables.Messages; }
            { ViewBag.IsMenuPart = isMenuPart; }
            { ViewBag.AdminName = $"{CurrentUser.FirstName} {CurrentUser.LastName}"; }
            return View(AllUsers);
        }

        [HttpPost]
        public ActionResult _829528a_441d_484m_862i_22475963ffdn(ApplicationUser param)
        {
            var button =
             Request.Params.Cast<string>().Where(p => p.StartsWith("btn")).Select(p => p.Substring("btn".Length)).First().Remove(0, 1);

            if (button != null)
            {
                switch (button)
                {
                    case "income":
                        ViewBag.PartialView = "MessagesPart";
                        isMenuPart = true;
                        break;
                    case "notresponse":

                        break;
                    case "prostrocheno":

                        break;
                    case "BalanceInfo":
                        ViewBag.PartialView = "BalancePart";
                        isMenuPart = true;
                        break;
                    case "WithdrawInfo":
                        ViewBag.PartialView = "WithdrawPart";
                        isMenuPart = true;
                        break;
                }
            }

            { ViewBag.MainBalances = StaticTables.MainBalances; }
            { ViewBag.IsMsgDetails = isMsgDetail; }
            { ViewBag.IsMsgRes = isMsgRes; }
            { ViewBag.Withdrawals = StaticTables.Withdrawals; }
            { ViewBag.Users = AllUsers; }
            { ViewBag.IsMenuPart = isMenuPart; }
            { ViewBag.Messages = StaticTables.Messages; }
            { ViewBag.IsMenuPart = isMenuPart; }
            return View(AllUsers);
        }

        [HttpPost]
        public ActionResult SendMessage(BLL.DTO.EmailEntity.EmailData mailInfo)
        {
            if (mailInfo.Title == null && mailInfo.Email == null)
            {
                string retMsg = string.Empty;
                int cntMsg = 0;
                foreach(var i in AllUsers)
                {
                    cntMsg++;
                    mailInfo.Title = mailInfo.Title;
                    mailInfo.Email = i.Email;
                    new EmailSender(mailInfo).SendMessage(mailInfo, null, i.Email);
                }
                return Json($"Писмо отправлено всем {cntMsg} Агентам успешно!");
            }
            mailInfo.SendingDate = System.DateTime.UtcNow;
            var res = new EmailSender(mailInfo).SendMessage(mailInfo, null, mailInfo.Email);
            isMsgRes = true;
            return RedirectToAction("_829528a_441d_484m_862i_22475963ffdn", new { msgRes=res});
                //Json(new EmailSender(mailInfo).SendMessage(mailInfo, null, mailInfo.Email));
        }

        #region Auxiliary methods:
        private string TypeOfPartial(string param)
        {
            switch (param)
            {
                case "UserInfoPart":
                    return "UserInfoPart";
                case "BalancePart":
                    return "BalancePart";
                case "RequestsPart":
                    return "RequestsPart";
                case "MessagesPart":
                    return "MessagesPart";
                default:return null;
            }
        }

        private async Task CheckFillOutTbl(IEnumerable<BLL.Interfaces.IModel> table)
        {
            if (table == null || table.Count() == 0)
            {
                switch (table.GetType().GetGenericArguments()[0].Name)
                {
                    case nameof(CategoryDto):
                        StaticTables.Categories = await db.ReadCategoriesAsync();
                        break;
                    case nameof(ProductDto):
                        StaticTables.Products = await db.ReadProductsAsync();
                        break;
                    case nameof(CartDto):
                        StaticTables.Carts = await db.ReadCartsAsync();
                        break;
                    case nameof(WithdrawDto):
                        StaticTables.Withdrawals = await db.ReadWithdrawalsAsync();
                        break;
                    case nameof(MessageDto):
                        StaticTables.Messages = await db.ReadMessagesAsync();
                        break;
                    case nameof(RefMemberDto):
                        StaticTables.RefMembers = await db.ReadRefMembersAsync();
                        break;
                    case nameof(MainBalanceDto):
                        StaticTables.MainBalances = await db.ReadMainBalancesAsync();
                        break;
                }
            }
        }

        private object GetAdmin(LoginViewModel model)
        {
            AllUsers = UserManager.Users.ToList();
            CurrentUser = AllUsers.FirstOrDefault(s => s.Email.Equals(model.Email));
            Role role = CurrentUser.Role.Equals(Role.Admin.ToString()) ? Role.Admin : Role.Unknown;
            switch (role)
            {
                case Role.Admin:
                    return "_829528a_441d_484m_862i_22475963ffdn";
                default:return null;
            }
        }
        #endregion
    }
}
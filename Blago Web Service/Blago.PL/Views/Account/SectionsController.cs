namespace Blago.PL.Views.Account
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Blago.BLL.DTO;
    using Blago.BLL.Services;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    public class SectionsController : Controller
    {
        private IEnumerable<MessageDto> ListOfMessages { get; set; }
        private string button = string.Empty, typeOfView = string.Empty;
        private static bool isMsgClicked = false;
        private readonly BlagoService db = null;
        private string CurrentUserEmail { get; set; }
        private Models.ApplicationUser CurrentLocalUser { get; set; }

        public SectionsController()
        {
            db = new BlagoService(Models.Init.ConnectionStr);
        }

        public ApplicationUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Motivation()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Questions()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Messages()
        {
            ViewBag.User = CurrentLocalUser;
            return View();
        }

        [HttpPost]
        public ActionResult Messages(object param)
        {
            try
            {
                button =
                   Request.Params.Cast<string>()
                   .Where(p => p.StartsWith("btn"))
                   .Select(p => p.Substring("btn".Length))
                   .First().Remove(0, 1);
                ViewBag.User = CurrentLocalUser;
            }
            catch { }
            finally
            {
                if (button != null)
                {
                    switch (button)
                    {
                        case "Income":
                            typeOfView = "Income";
                            ListOfMessages = db.ReadMessages().Where(u => u.RecipientId == CurrentLocalUser.UserId).ToList();
                            break;
                        case "Sent":
                            ListOfMessages= db.ReadMessages().Where(u => u.SenderId == CurrentLocalUser.UserId).ToList();
                            typeOfView = "Sent";
                            break;
                        case "NewMsg":
                            typeOfView = "NewMsg";
                            break;
                        default: break;

                    }
                    isMsgClicked = true;
                }
            }

            ViewBag.TypeView = typeOfView;
            ViewBag.Users = UserManager.Users.ToList();
            ViewBag.Messages = ListOfMessages; 
            ViewBag.IsMsgClick = isMsgClicked;
            return View();
        }

        #region The override method for checking authentication of a current User:
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                CurrentUserEmail = filterContext.HttpContext.User.Identity.Name;
                CurrentLocalUser = UserManager.Users.FirstOrDefault(f => f.Email == CurrentUserEmail);
            }
            else // When User Log off, or still doesn't enter 
            {
                CurrentUserEmail = null;
                CurrentLocalUser = null;
            }
        }
        #endregion
    }
}
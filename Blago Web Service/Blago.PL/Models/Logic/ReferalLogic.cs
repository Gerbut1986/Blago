namespace Blago.PL.Models.Logic
{
    using System.Linq;
    using Blago.BLL.DTO;
    using System.Collections.Generic;

    internal class ReferalLogic
    {
        #region Level of Referrals:
        static List<ReferalInfo> Level1InfoList { get; set; } = new List<ReferalInfo>();
        static List<ReferalInfo> Level2InfoList { get; set; } = new List<ReferalInfo>();
        static List<ReferalInfo> Level3InfoList { get; set; } = new List<ReferalInfo>();
        static List<ReferalInfo> Level4InfoList { get; set; } = new List<ReferalInfo>();
        static List<ReferalInfo> Level5InfoList { get; set; } = new List<ReferalInfo>();
        #endregion

        #region Fields:
        IEnumerable<ApplicationUser> allUsers { get; set; }
        private RefMemberDto FirstReferal { get; set; }
        #endregion

        private readonly ApplicationUser currentUser;

        public ReferalLogic(ApplicationUser currentUser, IEnumerable<ApplicationUser> allUsers = default)
        {
            this.currentUser = currentUser;
            this.allUsers = allUsers;
        }

        #region Get percent from each of a Person's Level ONLY if it do Buy the Product:
        public double GetPercentFrom1stReferal(bool isRefBuyProduct, int userId) // Owner gets 100% from 1st referal:
        {
            if (isRefBuyProduct)
            {
                FirstReferal = StaticTables.RefMembers.Where(u => u.InvitedBy == userId).OrderBy(d => d.DateRegister).FirstOrDefault();
                if (FirstReferal == null)//||  )
                    return 0;

                return 250 * 100 / 100; //StaticTables.Products.FirstOrDefault(f => f.Id == 1).Price;
            }
            else return 0;
        }

        public ReferalInfo[] GetPercents1Level(bool isRefBuyProduct) // The next all just 20%:
        {
            var refList = from rf in StaticTables.RefMembers where rf.InvitedBy == currentUser.UserId select rf;
            var perSum = 250 * 20 / 100;// StaticTables.Products.FirstOrDefault(f => f.Id == 1).Price;
            Level1InfoList = new List<ReferalInfo>();
            foreach (var all in refList)
            {
                var member = allUsers.FirstOrDefault(u => u.UserId == all.MemberId);
                var res = StaticTables.Orders.ToList().FirstOrDefault(o => o.UserId == member.UserId);
                if (res != null)
                {
                    Level1InfoList.Add(new ReferalInfo
                    {
                        AmountPercent = perSum,
                        Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                        // значения дати, установлю после того, как настрою механизм покупки товара..
                        DateBuyProduct = System.DateTime.Now,
                        LevelNumber = 1
                    });
                }
            }
            return Level1InfoList.ToArray();
        }

        public ReferalInfo[] GetPercents2Level(bool isRefBuyProduct, BLL.Services.BlagoService db = null)
        {
            var secondLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level1InfoList.Count; i++)
            {
                secondLevel.AddRange(StaticTables.RefMembers
                    .Where(f => f.InvitedBy == Level1InfoList[i].Referal.UserId).ToList());
            }

            var perSum = 250 * 10 / 100;// StaticTables.Products.FirstOrDefault(f => f.Id == 1).Price;
            Level2InfoList = new List<ReferalInfo>();
            foreach (var all in secondLevel)
            {
                if (StaticTables.Orders.FirstOrDefault(o => o.UserId == allUsers.FirstOrDefault(u => u.UserId == all.MemberId).UserId) != null)
                {
                    Level2InfoList.Add(new ReferalInfo
                    {
                        AmountPercent = perSum,
                        Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                        // значения дати, установлю после того, как настрою механизм покупки товара..
                        DateBuyProduct = System.DateTime.Now,
                        LevelNumber = 2
                    });
                }
            }
            return Level2InfoList.ToArray();
        }

        public ReferalInfo[] GetPercents3Level(bool isRefBuyProduct)
        {
            var thirdLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level2InfoList.Count; i++)
            {
                thirdLevel.AddRange(StaticTables.RefMembers
                     .Where(f => f.InvitedBy == Level2InfoList[i].Referal.UserId).ToList());
            }
            var perSum = 250 * 4 / 100;
            Level3InfoList = new List<ReferalInfo>();
            foreach (var all in thirdLevel)
            {
                if (StaticTables.Orders.FirstOrDefault(o => o.UserId == allUsers.FirstOrDefault(u => u.UserId == all.MemberId).UserId) != null)
                {
                    Level3InfoList.Add(new ReferalInfo
                    {
                        AmountPercent = perSum,
                        Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                        // значения дати, установлю после того, как настрою механизм покупки товара..
                        DateBuyProduct = System.DateTime.Now,
                        LevelNumber = 3
                    });
                }
            }
            return Level3InfoList.ToArray();
        }

        public ReferalInfo[] GetPercents4Level(bool isRefBuyProduct)
        {
            var fourthLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level3InfoList.Count; i++)
            {
                fourthLevel.AddRange(StaticTables.RefMembers
                     .Where(f => f.InvitedBy == Level3InfoList[i].Referal.UserId).ToList());
            }
            var perSum = 250 * 3 / 100;
            Level4InfoList = new List<ReferalInfo>();
            foreach (var all in fourthLevel)
            {
                if (StaticTables.Orders.FirstOrDefault(o => o.UserId == allUsers.FirstOrDefault(u => u.UserId == all.MemberId).UserId) != null)
                {
                    Level4InfoList.Add(new ReferalInfo
                    {
                        AmountPercent = perSum,
                        Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                        // значения дати, установлю после того, как настрою механизм покупки товара..
                        DateBuyProduct = System.DateTime.Now,
                        LevelNumber = 4
                    });
                }
            }
            return Level4InfoList.ToArray();
        }

        public ReferalInfo[] GetPercents5Level(bool isRefBuyProduct)
        {
            var fifthLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level4InfoList.Count; i++)
            {
                fifthLevel.AddRange(StaticTables.RefMembers
                     .Where(f => f.InvitedBy == Level4InfoList[i].Referal.UserId).ToList());
            }
            var perSum = 250 * 2 / 100;
            Level5InfoList = new List<ReferalInfo>();
            foreach (var all in fifthLevel)
            {
                if (StaticTables.Orders.FirstOrDefault(o => o.UserId == allUsers.FirstOrDefault(u => u.UserId == all.MemberId).UserId) != null)
                {
                    Level5InfoList.Add(new ReferalInfo
                    {
                        AmountPercent = perSum,
                        Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                        // значения дати, установлю после того, как настрою механизм покупки товара..
                        DateBuyProduct = System.DateTime.Now,
                        LevelNumber = 5
                    });
                }
            }
            return Level5InfoList.ToArray();
        }
        #endregion

        #region Get full referals Level quantity:
        public ReferalInfo[] Get1Level()
        {
            ReserReferalInfos();
            var refList = from rf in StaticTables.RefMembers where rf.InvitedBy == currentUser.UserId select rf;
            Level1InfoList = new List<ReferalInfo>();
            foreach (var all in refList)
            {
                Level1InfoList.Add(new ReferalInfo
                {
                    Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                    LevelNumber = 1
                });
            }
            return Level1InfoList.ToArray();
        }

        public ReferalInfo[] Get2Level(BLL.Services.BlagoService db = null)
        {
            var secondLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level1InfoList.Count; i++)
            {
                secondLevel.AddRange(StaticTables.RefMembers
                    .Where(f => f.InvitedBy == Level1InfoList[i].Referal.UserId).ToList());
            }

            Level2InfoList = new List<ReferalInfo>();
            foreach (var all in secondLevel)
            {
                Level2InfoList.Add(new ReferalInfo
                {
                    Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                    LevelNumber = 2
                });
            }
            return Level2InfoList.ToArray();
        }

        public ReferalInfo[] Get3Level()
        {
            var thirdLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level2InfoList.Count; i++)
            {
                thirdLevel.AddRange(StaticTables.RefMembers
                     .Where(f => f.InvitedBy == Level2InfoList[i].Referal.UserId).ToList());
            }

            Level3InfoList = new List<ReferalInfo>();
            foreach (var all in thirdLevel)
            {
                Level3InfoList.Add(new ReferalInfo
                {
                    Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                    LevelNumber = 3
                });
            }
            return Level3InfoList.ToArray();
        }

        public ReferalInfo[] Get4Level()
        {
            var fourthLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level3InfoList.Count; i++)
            {
                fourthLevel.AddRange(StaticTables.RefMembers
                     .Where(f => f.InvitedBy == Level3InfoList[i].Referal.UserId).ToList());
            }

            Level4InfoList = new List<ReferalInfo>();
            foreach (var all in fourthLevel)
            {
                Level4InfoList.Add(new ReferalInfo
                {
                    Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                    LevelNumber = 4
                });
            }
            return Level4InfoList.ToArray();
        }

        public ReferalInfo[] Get5Level()
        {
            var fifthLevel = new List<RefMemberDto>();
            for (var i = 0; i < Level4InfoList.Count; i++)
            {
                fifthLevel.AddRange(StaticTables.RefMembers
                     .Where(f => f.InvitedBy == Level4InfoList[i].Referal.UserId).ToList());
            }

            Level5InfoList = new List<ReferalInfo>();
            foreach (var all in fifthLevel)
            {
                Level5InfoList.Add(new ReferalInfo
                {
                    Referal = allUsers.FirstOrDefault(f => f.UserId == all.MemberId),
                    LevelNumber = 5
                });
            }
            return Level5InfoList.ToArray();
        }
        #endregion

        #region Reset All ReferalInfo's arrays:
        void ReserReferalInfos() => Level1InfoList = Level2InfoList = Level3InfoList = Level4InfoList = Level5InfoList = new List<ReferalInfo>();
        #endregion
    }

    public class ReferalInfo
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public int AmountPercent { get; set; }
        public ApplicationUser Referal { get; set; }
        public System.DateTime DateBuyProduct { get; set; }
    }
}
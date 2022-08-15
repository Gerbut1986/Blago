namespace Blago.DAL.Entities
{
    public class RefMember
    {
        public int Id { get; private set; }
        public int OwnerId { get; set; }
        public int MemberId { get; set; }
        public int RefNumber { get; set; }
        public int InvitedBy { get; set; }
        public System.DateTime DateRegister { get; set; }
    }
}

namespace Blago.BLL.DTO
{
    public class RefMemberDto : Interfaces.IModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int MemberId { get; set; }
        public int RefNumber { get; set; }
        public int InvitedBy { get; set; }
        public System.DateTime DateRegister { get; set; }
    }
}

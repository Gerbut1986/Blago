using System.ComponentModel.DataAnnotations;

namespace Blago.BLL.DTO
{
    public class WithdrawDto : Interfaces.IModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime DateWithdraw { get; set; }
        [Required(ErrorMessage = "Незаполненное поле")]
        public string NumberCard { get; set; }
        [Required(ErrorMessage = "Незаполненное поле")]
        public string Amount { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}

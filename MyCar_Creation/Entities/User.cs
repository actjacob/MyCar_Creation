using MyCar_Creation.Model;
using System.ComponentModel.DataAnnotations;

namespace MyCar_Creation.Entities
{

    public enum Roles
    {
        Admin=0,
        NormalUser =1,
    }
    public class User : BaseModel
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
  

        [Required(ErrorMessage = "Confirmation Password is required.")]



        public  string ConfirmPassword { get; set; }
        public string? Role { get; set; }
    }
}

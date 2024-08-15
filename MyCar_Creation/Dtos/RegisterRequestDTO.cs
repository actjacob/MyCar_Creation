using System.ComponentModel.DataAnnotations;

namespace MyCar_Creation.Dtos
{
    public class RegisterRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]

        public string ConfirmPassword { get; set; }
    }
}

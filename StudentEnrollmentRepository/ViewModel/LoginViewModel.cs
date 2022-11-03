using StudentEnrollmentRepository.ConstantValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$",
        ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase " +
        " Alphabet, 1 Number and 1 Special Character")]
        public string Password { set; get; }
        public int RoleId { set; get; }
        public string RoleName { set; get; }
        public LoginViewModel(string email, string password, int roleId, string roleName)
        {
            Email = email;
            Password = password;
            RoleId = roleId;
            RoleName = roleName;
        }
        public LoginViewModel() { }
    }
}

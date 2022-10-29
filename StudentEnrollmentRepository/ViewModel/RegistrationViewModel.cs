using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentEnrollmentRepository.ViewModel
{
    public class RegistrationViewModel
    { 
    public int UserID { set; get; }
    public string Username { set; get; }
     public string Email { set; get; }
    public string Password { set; get; }
    public string ConfirmPassword { set; get; }
    }
   
}

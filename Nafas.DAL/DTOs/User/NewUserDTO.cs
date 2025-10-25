using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafas.DAL.DTOs.User
{
    public class NewUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public float Weight { get; set; }
        public int Height {  get; set; }
        public int Age {  get; set; }
        public bool GenderIsMale { get; set; }
        public bool IsAdmin {  get; set; }
    }
}

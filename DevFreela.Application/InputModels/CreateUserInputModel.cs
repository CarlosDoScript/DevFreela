using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string fullName,string password, string email, DateTime birthDate)
        {
            FullName = fullName;
            Password = password;
            Email = email;
            BirthDate = birthDate;
        }

        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    class User
    {
        public int Id { get; set; }
        public string Login, Password, Email;

        public string login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public User() { }

        public User(string login, string email, string password)
        {
            this.Login = login;
            this.Email = email;
            this.Password = password;
        }
    }
}

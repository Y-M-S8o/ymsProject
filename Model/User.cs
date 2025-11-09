using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : People

    {
        private string username;
        private string email;
        private int goal;

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public int Goal { get => goal; set => goal = value; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity
{
    public class user
    {
        public int id;
        public string login;
        public string pass;
        public int type;

        public user()
        {
            this.id = -1;
            this.pass = "";
            this.type = -1;
        }

        public user(int id, string login, string pass, int type)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
            this.type = type;
        }

        public user(int id, string login, string pass)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
            this.type = -1;
        }

        public user(string login, string pass) {
            this.id = -1;
            this.login = login;
            this.pass = pass;
            this.type = -1;
        }

        public static bool operator ==(user c1, user c2)
        {
            if (c1.id != c2.id) return false;
            else if (c1.login != c2.login) return false;
            else if (c1.pass != c2.pass) return false;
            else return true;
        }

        public static bool operator !=(user c1, user c2)
        {
            /*if (c1.id == c2.id) return false;
            else if (c1.login == c2.login) return false;
            else if (c1.pass == c2.pass) return false;
            else return true;*/

            if (c1 == c2) return false;
            else return true;
        }
    }
}

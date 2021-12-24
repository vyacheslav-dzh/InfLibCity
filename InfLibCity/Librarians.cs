using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity
{
    class Librarian
    {
        int id;
        int userId;
        string firstName;
        string lastName;
        string middleName;

        public Librarian(int id, int userId, string fn, string ln, string mn)
        {
            this.id = id;
            this.userId = userId;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
        }

    }
}

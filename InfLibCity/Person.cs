using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity
{
    abstract class Person
    {
        public int id;
        public int userId;
        public string firstName;
        public string lastName;
        public string middleName;

        public Person()
        {

        }

        public Person(int id, int userId, string fn, string ln, string mn)
        {
            this.id = id;
            this.userId = userId;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
        }
    }

    class People : Person
    { 
        public People(int id, int userId, string fn, string ln, string mn)
            : base(id, userId, fn, ln, mn)
        {

        }
    }

    class Librarian : Person
    {
        public Librarian(int id, int userId, string fn, string ln, string mn)
            : base(id, userId, fn, ln, mn)
        {

        }

        public Librarian()
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = "";
            this.lastName = "";
            this.middleName = "";
        }
    }
}

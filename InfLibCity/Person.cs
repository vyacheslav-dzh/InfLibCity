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


        public People(string fn, string ln, string mn)
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = ln;

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

        public Librarian(string firstName, string lastName, string middleName) {
            this.id = -1;
            this.userId = -1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
        }
    }

    class SchoolBoy : Person
    {
        public string institution;
        public string group;

        public SchoolBoy(int id, int userId, string fn, string ln, string mn, string institution, string group)
            : base(id, userId, fn, ln, mn)
        {
            this.institution = institution;
            this.group = group;
        }
    }
    
    class Student : Person
    {
        public string institution;
        public string faculty;
        public string group;


        public Student(int id, int userId, string fn, string ln, string mn, string institution, string faculty, string group)
            : base(id, userId, fn, ln, mn)
        {
            this.institution = institution;
            this.faculty = faculty;
            this.group = group;
        }
    }

    class Teacher : Person
    {
        public string orgName;
        public string subject;

        public Teacher(int id, int userId, string fn, string ln, string mn, string orgName, string subject)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.subject = subject;
        }
    }

    class Scientist : Person
    {
        public string orgName;
        public string direction;

        public Scientist(int id, int userId, string fn, string ln, string mn, string orgName, string direction)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.direction = direction;
        }
    }

    class Worker : Person
    {
        public string orgName;
        public string post;

        public Worker(int id, int userId, string fn, string ln, string mn, string orgName, string post)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.post = post;
        }
    }

    class Other : Person
    {
        public string typeWork;

        public Other(int id, int userId, string fn, string ln, string mn, string typeWork)
        {
            this.typeWork = typeWork;
        }
    }
}

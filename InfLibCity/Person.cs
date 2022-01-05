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
        public int roomID;

        public Librarian(int id, int userId, string fn, string ln, string mn)
            : base(id, userId, fn, ln, mn)
        {
            this.roomID = -1;
        }

        public Librarian()
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = "";
            this.lastName = "";
            this.middleName = "";
            this.roomID = -1;
        }

        public Librarian(string firstName, string lastName, string middleName, int roomID) {
            this.id = -1;
            this.userId = -1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.roomID = roomID;
        }
    }

    class SchoolBoy : Person
    {
        public const int personType = 0;
        public string institution;
        public string group;

        public SchoolBoy(int id, int userId, string fn, string ln, string mn, string institution, string group)
            : base(id, userId, fn, ln, mn)
        {
            this.institution = institution;
            this.group = group;
        }

        public SchoolBoy(string fn, string ln, string mn, string institution, string group)
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
            this.institution = institution;
            this.group = group;
        }
    }
    
    class Student : Person
    {
        public const int personType = 1;
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

        public Student(string fn, string ln, string mn, string institution, string faculty, string group)
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
            this.institution = institution;
            this.faculty = faculty;
            this.group = group;
        }
    }

    class Teacher : Person
    {
        public const int personType = 2;
        public string orgName;
        public string subject;

        public Teacher(int id, int userId, string fn, string ln, string mn, string orgName, string subject)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.subject = subject;
        }


        public Teacher(string fn, string ln, string mn, string orgName, string subject)
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
            this.orgName = orgName;
            this.subject = subject;
        }
    }

    class Scientist : Person
    {
        public const int personType = 3;
        public string orgName;
        public string direction;

        public Scientist(int id, int userId, string fn, string ln, string mn, string orgName, string direction)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.direction = direction;
        }

        public Scientist(string fn, string ln, string mn, string orgName, string direction)
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
            this.orgName = orgName;
            this.direction = direction;
        }
    }

    class Worker : Person
    {
        public const int personType = 4;
        public string orgName;
        public string post;

        public Worker(int id, int userId, string fn, string ln, string mn, string orgName, string post)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.post = post;
        }


        public Worker(string fn, string ln, string mn, string orgName, string post)
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
            this.orgName = orgName;
            this.post = post;
        }
    }

    class Other : Person
    {
        public const int personType = 5;
        public string typeWork;

        public Other(int id, int userId, string fn, string ln, string mn, string typeWork)
            : base(id, userId, fn, ln, mn) 
        {
            this.typeWork = typeWork;
        }

        public Other(string fn, string ln, string mn, string typeWork) 
        {
            this.id = -1;
            this.userId = -1;
            this.firstName = fn;
            this.lastName = ln;
            this.middleName = mn;
            this.typeWork = typeWork;
        }
    }
}

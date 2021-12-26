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

    class SchoolBoy : Person
    {
        string institution;
        string group;

        public SchoolBoy(int id, int userId, string fn, string ln, string mn, string institution, string group)
            : base(id, userId, fn, ln, mn)
        {
            this.institution = institution;
            this.group = group;
        }
    }
    
    class Student : Person
    {
        string institution;
        string faculty;
        string group;


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
        string orgName;
        string subject;

        public Teacher(int id, int userId, string fn, string ln, string mn, string orgName, string subject)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.subject = subject;
        }
    }

    class Scientist : Person
    {
        string direction;

        public Scientist(int id, int userId, string fn, string ln, string mn, string direction)
            : base(id, userId, fn, ln, mn)
        {
            this.direction = direction;
        }
    }

    class Worker : Person
    {
        string orgName;
        string post;

        public Worker(int id, int userId, string fn, string ln, string mn, string orgName, string post)
            : base(id, userId, fn, ln, mn)
        {
            this.orgName = orgName;
            this.post = post;
        }
    }

    class Other : Person
    {
        string typeWork;

        public Other(int id, int userId, string fn, string ln, string mn, string typeWork
        {
            this.typeWork = typeWork;
        }
    }
}

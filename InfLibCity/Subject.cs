using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity
{
    public abstract class Subject
    {
        int id;
        string name;
        string publisher;
        int quantity;
        string dateOfWriting;
        int address;
        bool isReadOnly;

        public Subject(string name, string publisher, int quantity)
        {
            this.name = name;
            this.publisher = publisher;
            this.quantity = quantity;
        }

        public Subject(Subject subject)
        {
            this.name = subject.name;
            this.publisher = subject.publisher;
            this.quantity = subject.quantity;
        }
    }

    public class BookPoem : Subject
    {
        string genre;
        string author;
        bool isBook;

        public BookPoem(string name, string publisher, int quantity, string genre, string author, bool isBook = true)
            : base (name, publisher, quantity)
        {
            this.genre = genre;
            this.author = author;
            this.isBook = isBook;
        }

        public BookPoem(Subject subject, string genre, string author, bool isBook = true)
            : base(subject)
        {
            this.genre = genre;
            this.author = author;
            this.isBook = isBook;
        }

        public string getType()
        {
            if (isBook) return "Book";
            else return "Poem";
        }
    }

    public class Article
    {

    }


}

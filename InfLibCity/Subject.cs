using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity
{
    public class Subject
    {
        public int id { get; set; }
        public int shelf_id { get; set; }
        public int publisher_id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public bool isReadOnly { get; set; }
        public int quantity { get; set; }
        public int type { get; set; }
        public int yearWriteOff;
        public bool isWriteOff;
        public attributesClass attributes { get; set; }


        public class attributesClass
        {

            public List<int> author_id;
            public List<int> genre_id;
            public int discipline_id;
            public int type_id;

            public attributesClass(List<int> author_id = null, List<int> genre_id = null, int discipline_id = -1,  int type_id = -1)
            {

                this.author_id = author_id;
                this.genre_id = genre_id;
                this.discipline_id = discipline_id;
                this.type_id = type_id;
            }

            public attributesClass(attributesClass atr)
            {
                this.author_id = atr.author_id;
                this.genre_id = atr.genre_id;
                this.discipline_id = atr.discipline_id;
                this.type_id = atr.type_id;
            }
        }

        public Subject(int id, int shelf_id, int publisher_id, string name, int year, bool isReadOnly, int quantity, int type, int yearWriteOff, bool isWriteOff, attributesClass attributes)
        {
            this.id = id;
            this.shelf_id = shelf_id;
            this.publisher_id = publisher_id;
            this.name = name;
            this.year = year;
            this.isReadOnly = isReadOnly;
            this.quantity = quantity;
            this.type = type;
            this.attributes = attributes;
            this.yearWriteOff = yearWriteOff;
            this.isWriteOff = isWriteOff;
        }

        public Subject(Subject subject)
        {
            this.id = subject.id;
            this.shelf_id = subject.shelf_id;
            this.publisher_id = subject.publisher_id;
            this.name = subject.name;
            this.year = subject.year;
            this.isReadOnly = subject.isReadOnly;
            this.quantity = subject.quantity;
            this.type = subject.type;
            this.yearWriteOff = subject.yearWriteOff;
            this.isWriteOff = subject.isWriteOff;
            this.attributes = subject.attributes;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity {
    public class Library {

        public int id { get; set; }
        public string libraryName { get; set; }
        public string libraryAddress { get; set; }

        public Library() {
            this.id = -1;
            this.libraryName = "";
            this.libraryAddress = "";
        }
        
        public Library(int id, string name, string address) {
            this.id = id;
            this.libraryName = name;
            this.libraryAddress = address;
        }

        public Library(int id, string name) {
            this.id = id;
            this.libraryName = name;
            this.libraryAddress = "";
        }

    }

    public class Room {

        public int id { get; set; }
        public int libId { get; set; }
        public int number { get; set; }

        public Room() {
            this.id = -1;
            this.libId = -1;
            this.number = -1;
        }

        public Room(int id, int libId, int number) {
            this.id = id;
            this.libId = id;
            this.number = number;
        } 

        public Room(int id, int number) {
            this.id = id;
            this.libId = -1;
            this.number = number;
        }

    }
}

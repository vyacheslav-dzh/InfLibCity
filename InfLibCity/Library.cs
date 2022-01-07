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


    public class Shevilings {

        public int id { get; set; }
        public int roomId { get; set; }
        public int number { get; set; }


        public Shevilings() {
            this.id = -1;
            this.roomId = -1;
            this.number = -1;
        }

        public Shevilings(int id, int roomId, int number) {
            this.id = id;
            this.roomId = roomId;
            this.number = number;
        }


    }

    public class Shelves {

        public int id { get; set; }

        public int shId { get; set; }

        public int number { get; set; }

        public Shelves() {
            this.id = -1;
            this.shId = -1;
            this.number = -1;
        }

        public Shelves(int id, int shId, int number) {
            this.id = id;
            this.shId = shId;
            this.number = number;
        }
    }

    public class Address
    {
        Library lib;
        Room room;
        Shevilings shevling;
        Shelves shelf;

        public Address(Library lib, Room room, Shevilings shevling, Shelves shelf)
        {
            this.lib = lib;
            this.room = room;
            this.shevling = shevling;
            this.shelf = shelf;
        }

        public override string ToString()
        {
            return String.Format("{0}, зал {1}-{2}-{3}", lib.libraryName, room.number, shevling.number, shelf.number);
        }

    }
}

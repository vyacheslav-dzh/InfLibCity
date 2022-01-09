using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity {
    class Subscription {

        public int id;
        public int readerId;
        public int subjectId;
        public string startDate;
        public string finishDate;
        public bool isActive;
        public int libId;

        public Subscription() {
            this.id = -1;
            this.readerId = -1;
            this.subjectId = -1;
            this.startDate = "";
            this.finishDate = "";
            this.isActive = false;
            this.libId = -1;
        }


        public Subscription(int id, int readerId, int subjectId, string startDate, string finishDate, bool isActive) {
            this.id = id;
            this.readerId = readerId;
            this.subjectId = subjectId;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.isActive = isActive;
            this.libId = -1;
        }


        public Subscription(int id, int readerId, int subjectId, string startDate, string finishDate, bool isActive, int libId) {
            this.id = id;
            this.readerId = readerId;
            this.subjectId = subjectId;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.isActive = isActive;
            this.libId = libId;
        }

    }
}

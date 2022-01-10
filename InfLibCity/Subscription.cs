using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfLibCity {
    class Subscription {

        public int id;
        public int peopleId;
        public int subjectId;
        public string startDate;
        public string finishDate;
        public bool isActive;
        public int libId;

        public Subscription() {
            this.id = -1;
            this.peopleId = -1;
            this.subjectId = -1;
            this.startDate = "";
            this.finishDate = "";
            this.isActive = false;
            this.libId = -1;
        }


        public Subscription(int id, int peopleId, int subjectId, string startDate, string finishDate, bool isActive) {
            this.id = id;
            this.peopleId = peopleId;
            this.subjectId = subjectId;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.isActive = isActive;
            this.libId = -1;
        }

        public Subscription(int peopleId, int subjectId, string startDate, string finishDate)
        {
            this.id = -1;
            this.peopleId = peopleId;
            this.subjectId = subjectId;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.isActive = true;
            this.libId = -1;
        }


        public Subscription(int id, int peopleId, int subjectId, string startDate, string finishDate, bool isActive, int libId) {
            this.id = id;
            this.peopleId = peopleId;
            this.subjectId = subjectId;
            this.startDate = startDate;
            this.finishDate = finishDate;
            this.isActive = isActive;
            this.libId = libId;
        }


        public override string ToString()
        {
            Person person = DBManipulator.getPerson(peopleId);
            Subject subject = DBManipulator.getSubjectData(subjectId);
            return $"{person.firstName[0]}. {person.middleName[0]}. {person.lastName} получит {subject.name} " +
                $"на срок {(Convert.ToDateTime(finishDate) - Convert.ToDateTime(startDate)).Days} дней, " +
                $"с {Convert.ToDateTime(startDate).ToString("dd-MM-yyyy")} по {Convert.ToDateTime(finishDate).ToString("dd-MM-yyyy")}";
        }

    }
}

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
            int subjectType;

            Dictionary<string, int> dict;

            public attributesClass(int subjectType)
            {
                this.subjectType = subjectType;

                dict = createDict(subjectType);
            }

            private static Dictionary<string, int> createDict(int subjectType)
            {
                switch (subjectType)
                {
                    case 0: // Книга
                        return new Dictionary<string, int>()
                        {
                            {"author_id", -1 },
                            {"genre_id", -1 }
                        };

                    case 1: // Сборник стихов
                        return new Dictionary<string, int>()
                        {
                            {"author_id", -1 },
                            {"genre_id", -1 }
                        };

                    case 2: // Газета
                        return new Dictionary<string, int>()
                        {
                            {"type_id", -1 }
                        };

                    case 3: // Журнал
                        return new Dictionary<string, int>()
                        {
                            {"type_id", -1 }
                        };

                    case 4: // Реферат
                        return new Dictionary<string, int>()
                        {
                            {"dicipline_id", -1 }
                        };

                    case 5: // Сборник докладов
                        return new Dictionary<string, int>()
                        {
                            {"dicipline_id", -1 }
                        };

                    case 6: // Сборник тезисов
                        return new Dictionary<string, int>()
                        {
                            {"dicipline_id", -1 }
                        };

                    case 7: // Статья
                        return new Dictionary<string, int>()
                        {
                            {"type_id", -1 }
                        };

                    case 8: // Диссертация
                        return new Dictionary<string, int>()
                        {
                            {"type_id", -1 }
                        };
                    default:
                        throw new Exception("This type not exist");
                }
            }

            public attributesClass(attributesClass atr)
            {
                this.subjectType = atr.subjectType;
                this.dict.Clear();
                if (atr.dict.Count > 0)
                {
                    this.dict = atr.dict.ToDictionary(entry => entry.Key, entry => entry.Value);
                }
                else
                {
                    createDict(this.subjectType);
                }
            }

            public int this[string key]
            {
                get
                {
                    if (dict.ContainsKey(key)) return dict[key];
                    else throw new Exception(String.Format("{0} key not found", key));
                }
                set
                {
                    if (dict.ContainsKey(key)) dict[key] = value;
                    else throw new Exception(String.Format("{0} key not found", key));
                }
            }

            public string[] getKeys()
            {
                return dict.Keys.ToArray();
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
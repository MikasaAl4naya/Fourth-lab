using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    //Общий класс
    public class Movie
    {
        public static Random rnd = new Random();//Поле для рандомного заполнения
        public int Rating = 0;//Общее свойство для всех классов
        public string name;
        public virtual string GetInfo()//virtual нужен для того, чтобы можно было переопределить функцию
        {                              //в классах наследниках

            var str = String.Format("\n Рейтинг: {0}", this.Rating);
            return str;
        }
        public static string RandomName(int random)
        {
            string str = "";
            var rnd = new Random();
            {
                switch (random)
                {
                    case 0:
                        str = "Побег из Шоушенка";
                        break;
                    case 1:
                        str = "Властелин колец";
                        break;
                    case 2:
                        str = "Фанатик";
                        break;
                    case 3:
                        str = "Остаться в живых";
                        break;
                    case 4:
                        str = "Сверхъествественное";
                        break;
                    case 5:
                        str = "Теория большого взрыва";
                        break;
                    case 6:
                        str = "Поле чудес";
                        break;
                    case 7:
                        str = "Вечерний Ургант";
                        break;
                    case 8:
                        str = "ЧТО БЫЛО ДАЛЬШЕ";
                        break;
                }
            }
            return str;
        }
    }

    class Film : Movie
    {
        public enum Filmtype { art, documentary, scientific }
        public enum Filmname { Deadpool,Intochables, Ted }
        public Filmtype kinds = Filmtype.art;
        public Filmname Filmnames = Filmname.Deadpool;
        public int timing;
        public int awards;
        public override string GetInfo()
        {
            var str = "Фильм";
            str += base.GetInfo();
            str += String.Format("\n Название:{0}", this.name);
            str += String.Format("\n Тип фильма:{0}", this.kinds);
            str += String.Format("\n Xронометраж:{0}", this.timing);
            str += String.Format("\n Количество наград:{0}", this.awards);
            return str;
        }
            public static Film Generate()///создание экземпляра класса
            {
            return new Film
            {
                    Rating = rnd.Next() % 10,
                    timing = rnd.Next() % 300,
                    awards = rnd.Next() % 4,
                    name = RandomName(rnd.Next(0, 2))
            };
            }
    }

    class Serial:Movie
    {
        public int series=0;
        public int seasons=0;
        public override string GetInfo()
        {
            var str = "Сериал";
            str += base.GetInfo();
            str += String.Format("\n Название:{0}", this.name);
            str += String.Format("\n Кол-во серий:{0}", this.series);
            str += String.Format("\n Кол-во сезонов:{0}", this.seasons);
            return str;
        }
        public static Serial Generate()
        {
            return new Serial
            {
                Rating = rnd.Next() % 10,
                series = rnd.Next() % 23,
                seasons = rnd.Next() % 10,
                name = RandomName(rnd.Next(3, 5))
            };
        }
    }
    class TVprogramm:Movie
    {
        public int timing=0;
        public  int[] airtime=new int[2];
        public override string GetInfo()
        {
            var str = "Телепередача";
            str += base.GetInfo();
            str += String.Format("\n Название:{0}", this.name);
            str += String.Format("\n Продолжительность:{0}", this.timing);
            str += String.Format("\n Эфирное время:{0}", this.airtime[0]);
            str += String.Format(":{0}", this.airtime[1]);
            return str;
        }
        public static TVprogramm Generate()///создание экземпляра класса
        {
            return new TVprogramm
            {
                Rating = rnd.Next() % 10,
                timing = rnd.Next() % 90,
                airtime = new int[2] { rnd.Next() % 24, rnd.Next() % 60 },
                name=RandomName(rnd.Next(6,8))
            };
        }
        
        }

    }



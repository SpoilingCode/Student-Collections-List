using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Thirteenth
{
    class Student
    {
        static public int quantityObjects = 0;

        string name;
        string lastName;
        string patronymic;
        int day_birth;
        int month_birth;
        int year_birth;


        public Student()
        {

            name = "Unknown";
            lastName = "Unknown";
            patronymic = "Unknown";
            day_birth = 0;
            month_birth = 0;
            year_birth = 0;
            quantityObjects++;

        }


        public Student(string _lastName)
            : this()
        {

            if (_lastName != "") lastName = _lastName;
            else lastName = "Unknown";

        }

        public Student(string name, string patronymic, string lastName, int day_birth, int month_birth, int year_birth)
        {

            if (name != "")
            {

                this.name = name;

            }
            else name = "Unknown";

            if (lastName != "")
            {

                this.lastName = lastName;

            }
            else lastName = "Unknown";


            if (patronymic != "")
            {

                this.patronymic = patronymic;

            }
            else patronymic = "Unknown";

            if (day_birth >= 1 && day_birth <= 31)
            {

                this.day_birth = day_birth;

            }
            else throw new Exception("День рождения указан неверно.Значение должно быть в интервале [1, 31]");

            if (month_birth >= 1 && month_birth <= 12)
            {

                this.month_birth = month_birth;

            }
            else throw new Exception("Месяц рождения указан неверно.Значение должно быть в интервале [1, 12]");

            if (year_birth >= 1985 && year_birth <= 2015)
            {

                this.year_birth = year_birth;

            }
            else throw new Exception("Год рождения указан неверно.Значение должно быть в интервале [1985, 2015]");

            quantityObjects++;

        }


        public string Name
        {

            get { return name; }

            set
            {
                if (name == "Unknown")
                {

                    if (value == "")
                    {
                        name = "Unknown";
                    }
                    else name = value;

                }


            }

        }

        public string LastName
        {

            get { return lastName; }

            set
            {
                if (lastName == "Unknown")
                {

                    if (value == "")
                    {
                        lastName = "Unknown";
                    }
                    else lastName = value;

                }


            }

        }

        public string Patronymic
        {

            get { return patronymic; }

            set
            {
                if (patronymic == "Unknown")
                {

                    if (value == "")
                    {
                        patronymic = "Unknown";
                    }
                    else patronymic = value;

                }


            }

        }

        public int Day_birth
        {
            get { return day_birth; }

            set
            {

                if (value >= 1 && value <= 31)
                {
                    day_birth = value;
                }
                else throw new Exception("День рождения указан неверно.Значение должно быть в интервале [1, 31]");

            }

        }

        public int Month_birth
        {
            get { return month_birth; }

            set
            {

                if (value >= 1 && value <= 12)
                {
                    month_birth = value;
                }
                else throw new Exception("Месяц рождения указан неверно.Значение должно быть в интервале [1, 12]");

            }

        }

        public int Year_birth
        {
            get { return year_birth; }

            set
            {

                if (value >= 1985 && value <= 2015)
                {
                    year_birth = value;
                }
                else throw new Exception("Год рождения указан неверно.Значение должно быть в интервале [1985, 2015]");

            }

        }


        public void inputDataAboutStudents()
        {

            Console.WriteLine("Введите имя cтудента:");
            Name = Console.ReadLine();
            if (Name == "")
            {
                Console.WriteLine("Вы ничего не ввели.Повторите ввод.");
            }


            Console.WriteLine("Введите отчество студента:");
            Patronymic = Console.ReadLine();
            if (Patronymic == "")
            {
                Console.WriteLine("Вы ничего не ввели.Повторите ввод.");
            }


            Console.WriteLine("Введите фамилию студента:");
            LastName = Console.ReadLine();
            if (LastName == "")
            {
                Console.WriteLine("Вы ничего не ввели.Повторите ввод.");
            }


            Console.WriteLine("Введите день рождения студента:");
            Day_birth = int.Parse(Console.ReadLine());
            if (Day_birth < 1 || Day_birth > 31)
            {
                Console.WriteLine("День рождения указан неверно.Значение должно быть в интервале [1, 31]");
            }


            Console.WriteLine("Введите месяц рождения студента:");
            Month_birth = Convert.ToInt32(Console.ReadLine());
            if (Month_birth < 1 || Month_birth > 12)
            {
                Console.WriteLine("Месяц рождения указан неверно.Значение должно быть в интервале [1, 12]");
            }


            Console.WriteLine("Введите год рождения студента:");
            Year_birth = int.Parse(Console.ReadLine());
            if (Year_birth < 1985 || Year_birth > 2015)
            {
                Console.WriteLine("Год рождения указан неверно.Значение должно быть в интервале [1985, 2015]");
            }
        }

        public void outputDataAboutStudents()
        {

            Console.Write(" ФИО: {0} {1} {2}  Дата Рождения: {3}.{4}.{5}\n", lastName, name, patronymic, day_birth, month_birth, year_birth);
        }

        public void makeEmpty()
        {
            name = "Unknown";
            lastName = "Unknown";
            patronymic = "Unknown";
            day_birth = 0;
            month_birth = 0;
            year_birth = 0;
        }

        public bool isEmpty()
        {
            return name == "Unknown";
        }


        public static void findStudentsByYearBirth( List<Student> arrStudents,  int readYearBirth )
        {

            if (arrStudents.Count == 0) { throw new Exception("\nВ списке нет студентов"); }
            bool flag = false;

            Student stud = new Student();
            stud.Year_birth = readYearBirth;
            for (int i = 0; i < arrStudents.Count; i++)
            {
                if (arrStudents[i] == stud)
                {
                    arrStudents[i].outputDataAboutStudents();
                    flag = true;
                }
            }

            if (flag == false)
            {
                Console.WriteLine("В списке нет студентов с годом рождения:{0}", readYearBirth);
            }

        }

        public override bool Equals(object inputObj)
        {
            if (inputObj == null || GetType() != inputObj.GetType())
                return false;

            Student temp = (Student)inputObj;
            return (Year_birth == temp.Year_birth);
        }

        public override int GetHashCode()
        {
            return year_birth.GetHashCode();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }

        public class SortByName : IComparer<Student>
        {

            public int Compare(Student ob1, Student ob2)
            {
                Student firstStudent = (Student)ob1;
                Student secondStudent = (Student)ob2;
                return string.Compare(firstStudent.name, secondStudent.name);

            }
        }
        public class SortByPatronymic : IComparer<Student>
        {

            public int Compare(Student ob1, Student ob2)
            {
                Student firstStudent = (Student)ob1;
                Student secondStudent = (Student)ob2;
                return string.Compare(firstStudent.patronymic, secondStudent.patronymic);

            }

            
        }

        public class SortByLastName : IComparer<Student>
        {

            public int Compare(Student ob1, Student ob2)
            {
                Student firstStudent = (Student)ob1;
                Student secondStudent = (Student)ob2;

                return string.Compare(firstStudent.lastName, secondStudent.lastName);
            }
        }
        public class SortByFullDateBirth : IComparer<Student>
        {

            public int Compare(Student ob1, Student ob2)
            {
                Student firstStudent = (Student)ob1;
                Student secondStudent = (Student)ob2;

                if (firstStudent.year_birth > secondStudent.year_birth) return 1;
                if (firstStudent.year_birth < secondStudent.year_birth) return -1;

                if (firstStudent.month_birth > secondStudent.month_birth) return 1;
                if (firstStudent.month_birth < secondStudent.month_birth) return -1;

                if (firstStudent.day_birth > secondStudent.day_birth) return 1;
                if (firstStudent.day_birth < secondStudent.day_birth) return -1;
                return 0;
            }

           
        }

        public static int operator -(Student firstStudent, Student secondStudent)
        {
            DateTime dateBirthFirstStudent = new DateTime(firstStudent.Year_birth, firstStudent.Month_birth, firstStudent.Day_birth);
            DateTime dateBirthSecondStudent = new DateTime(secondStudent.Year_birth, secondStudent.Month_birth, secondStudent.Day_birth);

            TimeSpan timeSpan = dateBirthFirstStudent - dateBirthSecondStudent;

            return timeSpan.Days;
        }


    }
}

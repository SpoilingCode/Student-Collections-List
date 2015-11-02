using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Thirteenth
{
    class Program
    {
       static List <Student> students = new List<Student>();
       const int maxNumberStudents = 20;
       static int numberStudents = 0;
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {

                Console.WriteLine("\nВыберите действие:\n");
                Console.WriteLine("1 - Тестовое создание объектов класса Студент");
                Console.WriteLine("2 - Тестовое использование свойств класса Студент и метода ввода");
                Console.WriteLine("3 - Формирование нового списка студентов");
                Console.WriteLine("4 - Добавление данных о студенте");
                Console.WriteLine("5 - Вывод списка студентов на экран");
                Console.WriteLine("6 - Операция класса: Вычисление разницы в возрасте (в днях) для двух студентов");
                Console.WriteLine("7 - Поиск в массиве всех студентов заданного года рождения");
                Console.WriteLine("8 - Удаление студента с заданной фамилией из массива");
                Console.WriteLine("9 - Сортировка по полной дате рождения");
                Console.WriteLine("10 - Сортировка по полной ФИО");
                Console.WriteLine("11 - Записать массив студентов в файл");
                Console.WriteLine("0 - Выход");

                try
                {

                    
                    int choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {

                        case 0:
                            {
                                flag = false;
                                Console.WriteLine("Программа завершила работу.");
                                break;
                            }

                        case 1:
                            {

                                Console.WriteLine("Количество созданных объектов = {0}", Student.quantityObjects - 20);
                                Console.WriteLine("\nДемонстрируется работа трех конструкторов: ");

                                Student firstStudent = new Student();
                                firstStudent.outputDataAboutStudents();

                                Student secondStudent = new Student("Иван", "Николаевич", "Тополев", 10, 12, 1990);
                                secondStudent.outputDataAboutStudents();

                                Student thirdStudent = new Student("Максимов");
                                thirdStudent.outputDataAboutStudents();

                                Console.WriteLine("\nКоличество созданных объектов = {0}", Student.quantityObjects - 20);
                                break;

                            }

                        case 2:
                            {
                                Console.WriteLine(" Для демонстрации свойств класса и метода вывода создайте студента. ");

                                Student student = new Student();
                                student.inputDataAboutStudents();

                                Console.WriteLine("\nСоздан студент:");
                                Console.WriteLine("ФИО: {0} {1} {2}   Дата Рождения:{3}.{4}.{5}", student.LastName, student.Name, student.Patronymic,
                                                                                                  student.Day_birth, student.Month_birth, student.Year_birth);

                                student.Name = "Василий";
                                student.Patronymic = "Федорович";
                                student.LastName = "Астафьев";
                                student.Day_birth = 15;
                                student.Month_birth = 10;
                                student.Year_birth = 1994;

                                Console.WriteLine("\nДанные студента изменены:");
                                Console.WriteLine("ФИО: {0} {1} {2}   Дата Рождения:{3}.{4}.{5}", student.LastName, student.Name, student.Patronymic,
                                                                                                  student.Day_birth, student.Month_birth, student.Year_birth);
                                break;

                            }

                        case 3:
                            {
                                if (numberStudents == 0) new_array();
                                else Console.WriteLine("Список уже сформирован, Вы можете только добавить студента");
                                break;
                            }
                        case 4: addStudent(); break;
                        case 5: outputArrayStudents(); break;
                        case 6:
                            {

                                Student s1 = new Student();
                                s1.inputDataAboutStudents();
                                Console.WriteLine("\nСоздан студент: ");
                                s1.outputDataAboutStudents();

                                Student s2 = new Student();
                                s2.inputDataAboutStudents();
                                Console.WriteLine("\nСоздан студент: ");
                                s2.outputDataAboutStudents();

                                Console.WriteLine("Разница в возрасте двух студентов: {0} дн.", Math.Abs(s1 - s2));
                                break;

                            }
                        case 7:
                            {
                                Console.WriteLine("\nВведите год рождения студента, данные о котором Вы хотите найти:  ");
                                int readYearBirth = int.Parse(Console.ReadLine());
                                Student.findStudentsByYearBirth(students, readYearBirth);
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("Введите фамилию студента, которого хотите удалить: ");
                                string readSurname = Console.ReadLine();

                                removeStudentInArray(readSurname);
                                break;
                            }
                        case 9:
                            {

                                Console.WriteLine("Сортировка по полной дате рождения:");
                                
                                students.Sort(new Student.SortByFullDateBirth());

                                foreach (Student elem in students)
                                {
                                    if (!elem.isEmpty())
                                        elem.outputDataAboutStudents();
                                }
                                break;

                            }
                        case 10:
                            {
                                Console.WriteLine("Сортировка по ФИО:");
                                students.Sort(new Student.SortByName());
                                students.Sort(new Student.SortByPatronymic());
                                students.Sort(new Student.SortByLastName());

                               
                                foreach (Student elem in students)
                                {
                                    if (!elem.isEmpty())
                                        elem.outputDataAboutStudents();
                                }
                                break;
                            }
                        case 11:
                            {
                                writeToFileArrayStudents();
                                foreach (Student elem in students)
                                {
                                    if (!elem.isEmpty())
                                        elem.outputDataAboutStudents();
                                }
                                break;
                            }

                        default: Console.WriteLine("Ошибка ввода\n"); break;

                    }

                }
                catch (FileNotFoundException)
                {

                    Console.WriteLine("Файла с таким именем не существует");
                    Console.WriteLine("Для продолжения нажмите Enter");
                    Console.ReadKey();

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Exception:{0}\nFile:{1}\nLocation:{2}\n{3}", ex.Message, ex.Source, ex.TargetSite);
                    Console.WriteLine("Для продолжения нажмите Enter");
                    Console.ReadKey();

                }



            }
        }

    

        static void outputArrayStudents()
        {

            if (students.Count == 0) Console.WriteLine("Нет студентов в списке");

            else
            {

                for (int i = 0; i < students.Count; i++)
                {
                    if (!students[i].isEmpty())
                        students[i].outputDataAboutStudents();
                }

            }

        }

        static void addStudent()
        {

            if (numberStudents < maxNumberStudents)
            {
                Student st = students[numberStudents];
                st.inputDataAboutStudents();
                students.Add(st);
                numberStudents++;
            }
            else Console.WriteLine("Невозможно добавить студента.Массив заполнен.");

        }


        static void removeStudentInArray(string readSurname)
        {
            if (readSurname == "")
            {
                Console.WriteLine("Ничего не введено.Попробуйте ещё раз!");
            }
            else
            {

                int count = 0;
                for (int i = 0; i < students.Count; i++)
                {
                    count += (students[i].isEmpty() || students[i].LastName == readSurname ? 0 : 1);
                }

                
                Student[] arrStudents = new Student[count];
                for (int i = 0, j = 0; i < students.Count; i++)
                {
                    if (!students[i].isEmpty() && students[i].LastName != readSurname)
                    {
                        arrStudents[j] = new Student(
                        students[i].Name,
                        students[i].Patronymic,
                        students[i].LastName,
                        students[i].Day_birth,
                        students[i].Month_birth,
                        students[i].Year_birth
                        );
                        j++;
                    }
                    students[i].makeEmpty();
                }

                for (int i = 0; i < count; i++)
                {
                    students[i].Name = arrStudents[i].Name;
                    students[i].Patronymic = arrStudents[i].Patronymic;
                    students[i].LastName = arrStudents[i].LastName;
                    students[i].Day_birth = arrStudents[i].Day_birth;
                    students[i].Month_birth = arrStudents[i].Month_birth;
                    students[i].Year_birth = arrStudents[i].Year_birth;
                }

                for (int i = 0; i < count; i++)
                {
                    students[i].outputDataAboutStudents();
                }
            }
        }

        static void writeToFileArrayStudents()
        {
            if (students.Count == 0) Console.WriteLine("Массив студентов не сформирован");
            else
            {
                Console.WriteLine("Ввведите название нового файла:");
                string newFileName = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(newFileName))
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (!students[i].isEmpty())
                        {
                            writer.WriteLine("ФИО: {0} {1} {2} Дата рождения: {3}.{4}.{5}",
                                              students[i].LastName, students[i].Name, students[i].Patronymic,
                                              students[i].Day_birth, students[i].Month_birth, students[i].Year_birth);
                        }
                    }
                }
            }
        }

        static void formArrayStudentsFromFile()
        {
            Console.WriteLine("Введите имя файла");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName)) throw new FileNotFoundException();

            using (StreamReader reader = new StreamReader(fileName, Encoding.Default))
            {
                string line;
                int i = 0;
                string[] buf;
                 
                while ((line = reader.ReadLine()) != null)
                {
                    buf = line.Split(' ');
                    if (buf.Length == 6)
                    {
                        Student stud = students[i];
                       
                        stud.LastName = buf[0];
                        stud.Name = buf[1];
                        stud.Patronymic = buf[2];
                        stud.Day_birth = Convert.ToInt32(buf[3]);
                        stud.Month_birth = Convert.ToInt32(buf[4]);
                        stud.Year_birth = Convert.ToInt32(buf[5]);
                        students.Add(students[i]);
                        i++;
                    }
                }
            }
        }

        static void new_array()
        {

            Console.WriteLine("Будете вводить данные с клавиатуры?(y/n)");
            char readStr = char.Parse(Console.ReadLine());

            if (readStr == 'y' || readStr == 'Y')
            {

                Console.WriteLine("Введите количество студентов :" );
                string readNumber = Console.ReadLine();
                int quantityStudents = int.Parse(readNumber);

                if (!int.TryParse(readNumber, out quantityStudents))
                {
                    throw new Exception("Некорректный ввод.Введите число!");
                }

                else
                {
                    for (int i = 0; i < quantityStudents; i++)
                    {
                        addStudent();
                    }
                    Console.WriteLine("\nФормирование списка завершено.");
                }
            }

            else
            {
                Console.WriteLine("Сформировать массив студентов из файла?(y/n)");
                char readLine = char.Parse(Console.ReadLine());

                if (readLine == 'y' || readLine == 'Y')
                {
                    formArrayStudentsFromFile();
                    foreach (Student st in students)
                    {
                        if (!st.isEmpty())
                        {
                            st.outputDataAboutStudents();
                            
                        }
                    }
                }

                else
                {

                    Student[] arrayStudents = 
              {
                  new Student("Александр", "Петрович", "Ярмолаев", 13, 5, 1992),
                  new Student("Валерий" , "Михайлович", "Островский", 14, 10, 1996),
                  new Student("Дмитрий", "Александрович", "Колосов", 21, 5, 1996),
                  new Student("Валентин" , "Андреевич", "Ломов", 11, 1, 1993),
                  new Student("Леонид", "Федорович", "Мамонов", 3, 5, 1992),
                  new Student("Владимир" , "Константинович", "Носов", 27, 12, 1999),
                  new Student("Вадим" , "Максимович", "Щуров", 2, 4, 1999)
                  
              };

                    for (int i = 0; i < arrayStudents.Length; i++)
                    {
                        students.Add( arrayStudents[i] );
                        numberStudents++;
                    }

                    Console.WriteLine("\nСписок студентов сформирован из заданного массива ");
                }

            }

        }
    }
}

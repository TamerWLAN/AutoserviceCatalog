using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class FucnForInterface
    {
        static DateTime InitData()
        {
            //Проверок нет((((
            int year;
            int month;
            int day;
            Console.Write(" Введите год: ");
            year = int.Parse(Console.ReadLine());

            Console.Write(" Введите месяц: ");
            month = int.Parse(Console.ReadLine());

            Console.Write(" Введите день: ");
            day = int.Parse(Console.ReadLine());

            return new DateTime(year, month, day);
        }
        static void PrintCarInfo(db_TO.DAL.AutoParkDBStorage db, int carId)
        {
            var car = db.GetCarWithId(carId);
            DateTime tmp;

            Console.WriteLine("---------------------");
            Console.WriteLine(" Id: " + car.CarListId);
            Console.WriteLine(" Марка: " + db.GetMarkNameForCar(car));
            Console.WriteLine(" Модель: " + db.GetModelNameForCar(car));
            Console.WriteLine(" ВИН номер (рамы|кузова): " + car.VIN);
            Console.WriteLine(" Дата регистрации: " + car.DateOfRegistration.ToShortDateString());

            if (car.DateOfDeregistration != null)
            {
                tmp = (DateTime)car.DateOfDeregistration;
                Console.WriteLine(" Дата снятия с учета: " + tmp.Date.ToShortDateString());
            }
            else
                Console.WriteLine(" Дата снятия с учета: --");

            if (car.LastToDate != null)
            {
                tmp = (DateTime)car.LastToDate;
                Console.WriteLine(" Дата последнего ТО: " + tmp.Date.ToShortDateString());
            }
            else
                Console.WriteLine(" Дата последнего ТО: --");

            Console.WriteLine(" Пробег: " + car.CurrentTraveled);
            Console.WriteLine("---------------------");
        }
        public static void PrintAllCarsInfo(db_TO.DAL.AutoParkDBStorage db)
        {
            foreach (var elem in db.GetAllCars())
            {
                PrintCarInfo(db, elem.CarListId);
            }
        }
        public static void AddCar(db_TO.DAL.AutoParkDBStorage db)
        {
            int modelId;
            string cmd;

            if (db.GetAllModels().Count() == 0)
            {
                Console.WriteLine(" Справочник автомобилей пуст");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Выберите модель авто в соответствии со справочником: \n");
            Console.ResetColor();

            foreach (var elem in db.GetAllModels())
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(" Id: " + elem.ModelId);
                Console.WriteLine(" Mark: " + db.GetMarkNameForMarkId(elem.MarkId));
                Console.WriteLine(" Model: " + elem.ModelName);
                Console.WriteLine("---------------------");
            }

            Console.Write(" >");
            modelId = int.Parse(Console.ReadLine());

            if (db.ModelIdIsNotExsist(modelId))
            {
                Console.WriteLine(" Ошибка неверное значение, возврат в меню ");
                return;
            }

            CarList car = new CarList();
            car.ModelId = modelId;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Введите тип кузова: ");

            car.AutoType = Console.ReadLine();

            Console.Write(" Введите ВИН номер (рамы|кузова): ");
            car.VIN = Console.ReadLine();

            Console.WriteLine(" Введите дату регистрации авто");
            car.DateOfRegistration = InitData();

            Console.WriteLine(" Если авто не снято с учёта, нажмите 0. В противном случае любую другую клавишу ");
            cmd = Console.ReadLine();

            if (cmd != "0")
            {
                Console.WriteLine(" Введите дату снятия с учёта");
                car.DateOfRegistration = InitData();
            }

            Console.WriteLine(" Если авто не проходило ТО, нажмите 0. В противном случае любую другую клавишу ");
            cmd = Console.ReadLine();

            if (cmd != "0")
            {
                Console.WriteLine(" Введите дату последнего ТО");
                car.DateOfRegistration = InitData();
            }

            Console.Write(" Введите пробег авто: ");
            car.CurrentTraveled = int.Parse(Console.ReadLine());

            Console.ResetColor();

            db.AddNewCar(car);
            Console.WriteLine(" Авто успешно добавлено!\n Для возврата в основное меню нажмите любую клавишу");
            Console.ReadKey();
        }
        static void PrintMaintenanceInfo(db_TO.DAL.AutoParkDBStorage db, int mtncId)
        {
            var mtnc = db.GetMaintenanceWithId(mtncId);
            Console.WriteLine("=====================");
            Console.WriteLine("To Id: " + mtnc.MaintenanceId);

            Console.WriteLine(" CarListId: " + mtnc.CarListId);
            Console.WriteLine(" Информация об авто, проходившем ТО: ");
            PrintCarInfo(db, mtnc.CarListId);
            Console.WriteLine(" Дата ТО: " + mtnc.Date.ToShortDateString());
            Console.WriteLine(" Пробег при прохождении ТО: " + mtnc.Traveled);
            Console.WriteLine("=====================");
        }
        public static void PrintAllMaintenancesInfo(db_TO.DAL.AutoParkDBStorage db)
        {
            foreach (var elem in db.GetAllMtncs())
            {
                PrintMaintenanceInfo(db, elem.MaintenanceId);
            }
        }
        public static void AddMaintenace(db_TO.DAL.AutoParkDBStorage db)
        {
            int carId;
            Maintenance mtnc = new Maintenance();

            if (db.GetAllCars().Count() == 0)
            {
                Console.WriteLine(" Сначала добавьте хотя-бы одну машину");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Выберите авто у которого проводилось ТО в соответствии со справочником: \n");
            Console.ResetColor();

            PrintAllCarsInfo(db);

            Console.Write(" >");
            carId = int.Parse(Console.ReadLine());

            if (db.CarIdIsNotExsist(carId))
            {
                Console.WriteLine(" Ошибка неверное значение, возврат в меню ");
                return;
            }

            mtnc.CarListId = carId;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Введите дату ТО: ");

            mtnc.Date = InitData();
            //КИЛЛЕРФИЧА
            if (db.GetLastToDateForCarWithId(carId) == null || db.GetLastToDateForCarWithId(carId) < mtnc.Date)
            {
                db.SetNewLastToDateForCarWithId(carId, mtnc.Date);
            }

            Console.Write(" Введите пробег на котором проведено ТО: ");
            Console.ResetColor();

            mtnc.Traveled = int.Parse(Console.ReadLine());
            //КИЛЛЕРФИЧА
            if (db.GetTraveledForCarWithId(carId) < mtnc.Traveled)
            {
                db.SetNewTraveledForCarWithId(carId, mtnc.Traveled);
            }

            db.AddNewMtnc(mtnc);
            Console.WriteLine(" Запись про ТО успешно добавлена!\n Для возврата в основное меню нажмите любую клавишу");
            Console.ReadKey();
        }
        public static void AddWork(db_TO.DAL.AutoParkDBStorage db)
        {
            int workTypeId;
            int maintenanceId;
            int spPartId;
            int empId;

            Works work = new Works();

            if (db.GetAllWorkTypes().Count() == 0)
            {
                Console.WriteLine(" Справочник типов работ пуст");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Выберите тип работы в соответствии со справочником: \n");
            Console.ResetColor();

            foreach (var elem in db.GetAllWorkTypes())
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(" Id: " + elem.WorkTypeId);
                Console.WriteLine(" Наименование: " + elem.WorkTypeName);
                Console.WriteLine(" Нормированное время выполнения: " + elem.NormTime);
                Console.WriteLine("---------------------");
            }

            Console.Write(" >");
            workTypeId = int.Parse(Console.ReadLine());

            if (db.WorkTypeIdIsNotExsist(workTypeId))
            {
                Console.WriteLine(" Ошибка неверное значение, возврат в меню ");
                return;
            }

            if (db.GetAllMtncs().Count() == 0)
            {
                Console.WriteLine(" Сначала добавьте хотя-бы одно ТО");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Выберите в рамках какого ТО проводилась работа: \n");
            Console.ResetColor();

            PrintAllMaintenancesInfo(db);

            Console.Write(" >");
            maintenanceId = int.Parse(Console.ReadLine());

            if (db.MtncIdIsNotExsist(maintenanceId))
            {
                Console.WriteLine(" Ошибка неверное значение, возврат в меню ");
                return;
            }

            work.MaintenanceId = maintenanceId;
            work.WorkTypeId = workTypeId;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Введите фактическое время выполнения работы: ");
            work.FactTime = int.Parse(Console.ReadLine());

            Console.Write(" Введите стоимость выполнения работы: ");
            work.Cost = int.Parse(Console.ReadLine());

            Console.Write(" Введите количество потраченных запчастей: ");
            work.CountOfSparePart = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (db.GetAllEmployees().Count() == 0)
            {
                Console.WriteLine(" Справочник сотрудников пуст");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Выберите сотрудника в соответствии со справочником: \n");
            Console.ResetColor();

            foreach (var elem in db.GetAllEmployees())
            {
                Console.WriteLine("#####################");
                Console.WriteLine(" Id: " + elem.EmployeesId);
                Console.WriteLine(" Имя фамилия: " + elem.FirstName + " " + elem.LastName);
                Console.WriteLine(" Должность: " + elem.PostName);
                Console.WriteLine("#####################");
            }

            Console.Write(" >");
            empId = int.Parse(Console.ReadLine());

            if (db.EmployeeIdIsNotExsist(empId))
            {
                Console.WriteLine(" Ошибка неверное значение, возврат в меню ");
                return;
            }

            work.EmployeesId = empId;

            int i = 0;
            // НО РАБОТАЕТ
            if (db.GetAllSpareParts().Count() == 0)
            {
                Console.WriteLine(" Справочник запчастей пуст");
                return;
            }

            while (i < work.CountOfSparePart)
            {
                Console.WriteLine(" Выберите запчасть N " + (i + 1).ToString() + " из справочника: \n");
                foreach (var elem in db.GetAllSpareParts())
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine(" Id: " + elem.SparePartsId);
                    Console.WriteLine(" Наименование: " + elem.ParName);
                    Console.WriteLine(" Количество на складе: " + elem.Cur_Count);
                    Console.WriteLine("---------------------");
                }
                Console.Write(" >");

                spPartId = int.Parse(Console.ReadLine());

                if (db.SpPartIdIsNotExsist(spPartId))
                {
                    Console.WriteLine(" Ошибка неверное значение, повторите ");
                }
                else if (db.GetSparePartWithId(spPartId).Cur_Count == 0)
                {
                    Console.WriteLine(" Ошибка данная запчасть закончилась на складе, повторите ");
                }
                else
                {
                    i++;

                    //SpareParts sp = new SpareParts() { SparePartsId = spPartId, Cur_Count = part.Cur_Count };

                    work.SparePartses.Add(db.RemoveOneSpPartWithId(spPartId));
                }
            }

            db.AddNewWork(work);

            Console.WriteLine(" Запись про работу успешно добавлена!\n Для возврата в основное меню нажмите любую клавишу");
            Console.ReadKey();
        }
        public static void PrintAllWorksInfo(db_TO.DAL.AutoParkDBStorage db)
        {
            foreach (var elem in db.GetAllWorks())
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.WriteLine(" Id: " + elem.WorksId);
                Console.WriteLine(" Код Сотрудника: " + elem.EmployeesId);
                Console.WriteLine(" Код ТО: " + elem.MaintenanceId);
                Console.WriteLine(" Время выполнениея: " + elem.FactTime);
                Console.WriteLine(" Стоимость: " + elem.Cost);
                Console.WriteLine(" Количество затраченных запчастей: " + elem.CountOfSparePart);
                Console.WriteLine(" Код типа работы: " + elem.WorkTypeId);
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            }
        }
        static bool CheckModel(db_TO.DAL.AutoParkDBStorage db, int id)
        {
            bool check = false;
            foreach (var elem in db.GetAllCars())
            {
                if (elem.ModelId == id)
                    check = true;
            }
            return check;
        }
        public static void DeleteModel(db_TO.DAL.AutoParkDBStorage db)
        {
            int modelId;

            if (db.GetAllModels().Count() == 0)
            {
                Console.WriteLine(" Справочник автомобилей пуст");
                return;
            }

            Console.WriteLine(" Выберите марку для удаления");

            foreach (var elem in db.GetAllModels())
            {
                Console.WriteLine("-------------");
                Console.WriteLine(" Id " + elem.ModelId);
                Console.WriteLine(" Модель " + elem.ModelName);
                Console.WriteLine(" Марка Id" + elem.MarkId);
                Console.WriteLine("-------------");
            }

            Console.Write(" >");
            modelId = int.Parse(Console.ReadLine());

            if (db.ModelIdIsNotExsist(modelId))
            {
                Console.WriteLine(" Ошибка неверное значение, возврат в меню ");
                return;
            }

            if (CheckModel(db, modelId))
            {
                Console.WriteLine(" Ошибка ссылочной целостности, возврат в меню ");
                return;
            }

            db.DeleteModel(modelId);
            Console.WriteLine(" Успешно удалено ");
        }
    }
}

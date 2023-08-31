using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using db_TO.model;

namespace db_TO.DAL
{
    internal class AutoParkDBStorage //помог интернал
    {
        private readonly TOContext _context;

        public AutoParkDBStorage(TOContext context)
        {
            _context = context;
        }
        public IQueryable<CarList> GetAllCars()
        {
            return _context.CarListDb;
        }
            
        public CarList GetCarWithId(int carId)
        {
            return _context.CarListDb.Find(carId);
        }
        public string GetModelNameForCar(CarList car)
        {
            return _context.ModelDb.Find(car.ModelId).ModelName;
        }
        public string GetMarkNameForCar(CarList car)
        {
            return _context.MarkDb.Find(_context.ModelDb.Find(car.ModelId).MarkId).MarkName;
        }
        public void AddNewCar(CarList car)
        {
            _context.CarListDb.Add(car);
            _context.SaveChanges();
        }
        public IQueryable<Model> GetAllModels()
        {
            return _context.ModelDb;
        }

        public string GetMarkNameForMarkId(int markId)
        {
            return _context.MarkDb.Where(c => c.MarkId == markId).FirstOrDefault().MarkName;
        }

        public  Model GetModelWithId(int modelId)
        {
            return _context.ModelDb.Find(modelId);
        }

        public Maintenance GetMaintenanceWithId(int mtncId)
        {
            return _context.MaintenanceDb.Find(mtncId);
        }

        public IQueryable<Maintenance> GetAllMtncs()
        {
            return _context.MaintenanceDb;
        }

        public DateTime? GetLastToDateForCarWithId(int carId)
        {
            return _context.CarListDb.Find(carId).LastToDate;
        }
        public void SetNewLastToDateForCarWithId(int carId, DateTime newDate)
        {
            var car = _context.CarListDb.Where(c => c.CarListId == carId).FirstOrDefault();
            car.LastToDate = newDate;
            _context.SaveChanges();
        }

        public int GetTraveledForCarWithId(int carId)
        {
            return _context.CarListDb.Find(carId).CurrentTraveled;
        }

        public void SetNewTraveledForCarWithId(int carId, int newTraveled)
        {
            var car = _context.CarListDb.Where(c => c.CarListId == carId).FirstOrDefault();
            car.CurrentTraveled = newTraveled;
            _context.SaveChanges();
        }

        public void AddNewMtnc(Maintenance mtnc)
        {
            _context.MaintenanceDb.Add(mtnc);
            _context.SaveChanges();
        }

        public IQueryable<WorkType> GetAllWorkTypes()
        {
            return _context.WorkTypesDb;
        }
        public IQueryable<Employees> GetAllEmployees()
        {
            return _context.EmployeesDb;
        }
        public IQueryable<SpareParts> GetAllSpareParts()
        {
            return _context.SparePartsDb;
        }
        public WorkType GetWorkTypeWithId()
        {
            return null;
        }

        public bool ModelIdIsNotExsist(int modelId)
        {
            return _context.ModelDb.Find(modelId) == null;
        }

        public bool CarIdIsNotExsist(int carId)
        {
            return _context.CarListDb.Find(carId) == null;
        }

        public bool WorkTypeIdIsNotExsist(int workTypeId)
        {
            return _context.WorkTypesDb.Find(workTypeId) == null;
        }

        public bool MtncIdIsNotExsist(int mtncId)
        {
            return _context.MaintenanceDb.Find(mtncId) == null;
        }
        public bool EmployeeIdIsNotExsist(int empId)
        {
            return _context.EmployeesDb.Find(empId) == null;
        }

        public bool SpPartIdIsNotExsist(int spPartId)
        {
            return _context.SparePartsDb.Find(spPartId) == null;
        }

        public SpareParts GetSparePartWithId(int spPartId)
        {
            return _context.SparePartsDb.Find(spPartId);
        }
        public SpareParts RemoveOneSpPartWithId(int spPartId)
        {
            var part = _context.SparePartsDb.Find(spPartId);
            part.Cur_Count--;
            _context.SaveChanges(); ///мб не правильно работает
            return part;
        }
        public void AddNewWork(Works work)
        {
            _context.WorkDb.Add(work);
            _context.SaveChanges();
        }
        public void DeleteModel(int Id)
        {
            var Model = _context.ModelDb.Find(Id);
            _context.ModelDb.Remove(Model);
        }

        public IQueryable<Works> GetAllWorks()
        {
            return _context.WorkDb;
        }
    }
}

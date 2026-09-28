using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YalcinHotel_BLL.Abstract;
using YalcinHotel_DAL.Abstract;
using YalcinHotel_Entity;

namespace YalcinHotel_BLL.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        
        public EmployeeService(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Create(Employee entity)
        {
            _employeeDal.Create(entity);
        }

        public void Delete(Employee entity)
        {
            _employeeDal.Delete(entity);
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            return _employeeDal.GetAll(filter);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public Employee GetOne(Expression<Func<Employee, bool>> filter = null)
        {
            return _employeeDal.GetOne(filter);
        }

        public void Update(Employee entity)
        {
            _employeeDal.Update(entity);
        }
    }
}

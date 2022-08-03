using DemoApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        public EmployeeService(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeeCollectionName);

        }

        public List<Employee> Get()
        {
            List<Employee> employees;
            employees = _employees.Find(emp => true).ToList();
            return employees;
        }

        public Employee Get(string id) =>
            _employees.Find<Employee>(emp => emp.Id == id).FirstOrDefault();

        public Employee Create(Employee employee)
        {
            _employees.InsertOne(employee);
            return employee;
        }

        public void Update(string id, Employee employeeIn) =>
            _employees.ReplaceOne(book => book.Id == id, employeeIn);

        public void Remove(Employee employeeIn) =>
            _employees.DeleteOne(book => book.Id == employeeIn.Id);

        public void Remove(string id) =>
            _employees.DeleteOne(employee => employee.Id == id);

    }
}

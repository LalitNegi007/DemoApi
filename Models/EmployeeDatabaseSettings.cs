using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class EmployeeDatabaseSettings: IEmployeeDatabaseSettings
    {
        public string EmployeeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IEmployeeDatabaseSettings
    {
        public string EmployeeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

namespace new_testprojectADO.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
    }
}
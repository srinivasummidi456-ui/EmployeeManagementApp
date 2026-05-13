using Microsoft.Data.SqlClient;
using new_testprojectADO.Models;
using System.Data;

namespace new_testprojectADO.Services
{
    public class EmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")!;
        }

        // ===========================
        // Get Employees
        // ===========================

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection con =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand("sp_GetEmployees", con))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    con.Open();

                    SqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee emp = new Employee();

                        emp.EmpId =
                            Convert.ToInt32(reader["EmpId"]);

                        emp.EmpName =
                            reader["EmpName"].ToString() ?? "";

                        emp.Salary =
                            Convert.ToDecimal(reader["Salary"]);

                        emp.Address =
                            reader["Address"].ToString() ?? "";

                        emp.Department =
                            reader["Department"].ToString() ?? "";

                        employees.Add(emp);
                    }
                }
            }

            return employees;
        }

        // ===========================
        // Add Employee
        // ===========================

        public int AddEmployee(Employee employee)
        {
            int result = 0;

            using (SqlConnection con =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand("sp_AddEmployee", con))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@EmpName",
                        employee.EmpName ?? "");

                    cmd.Parameters.AddWithValue(
                        "@Salary",
                        employee.Salary);

                    cmd.Parameters.AddWithValue(
                        "@Address",
                        employee.Address ?? "");

                    cmd.Parameters.AddWithValue(
                        "@Department",
                        employee.Department ?? "");

                    con.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        public int DeleteEmployee(int empId)
        {
            int result = 0;

            using (SqlConnection con =
                   new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd =
                       new SqlCommand("sp_DeleteEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    con.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }
    }
}
using Domain.Entities;

namespace Domain.Services;

public interface IEmployeeService
{
    Task AddEmployeeAsync(string firstName, string lastName, decimal salaryPerHour);
    Task UpdateEmployeeAsync(int id, string firstName, string lastName, decimal salaryPerHour);
    Task DeleteEmployeeAsync(int id);
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
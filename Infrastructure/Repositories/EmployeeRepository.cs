using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.DataModels;
using JsonFlatFileDataStore;

namespace Infrastructure.Repositories;

public class EmployeeRepository(JsonDataContext context, IMapper mapper) : IEmployeeRepository
{
    private readonly IDocumentCollection<EmployeeDataModel> _employees = context.Store.GetCollection<EmployeeDataModel>();
    public Task<Employee> GetByIdAsync(int id)
    {
        var employeeDataModel = _employees.AsQueryable().FirstOrDefault(e => e.Id == id);
        var employee = mapper.Map<Employee>(employeeDataModel);
        return Task.FromResult(employee);
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        var employeesModels =  _employees.AsQueryable().ToList();
        var employees = employeesModels.Select(mapper.Map<Employee>);
        return Task.FromResult(employees);
    }

    public Task<int> AddAsync(Employee employee)
    {
        var employeeDataModel = mapper.Map<EmployeeDataModel>(employee);
        var isSuccess = _employees.InsertOne(employeeDataModel);
        return isSuccess ? Task.FromResult(employeeDataModel.Id) : Task.FromResult(-1);
    }

    public async Task<bool> UpdateAsync(Employee employee)
    {
        var employeeDataModel = mapper.Map<EmployeeDataModel>(employee);
        return await _employees.ReplaceOneAsync(e => e.Id == employeeDataModel.Id, employeeDataModel);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _employees.DeleteOneAsync(e => e.Id == 1);
    }
}
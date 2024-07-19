using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.DataModels;

namespace Infrastructure.Repositories;

public class EmployeeRepository(JsonDataContext context, IMapper mapper) : IEmployeeRepository
{
    public Task<Employee> GetByIdAsync(int id)
    {
        var employeeDataModel = context.Store.GetCollection<EmployeeDataModel>().AsQueryable().FirstOrDefault(e => e.Id == id);
        var employee = mapper.Map<Employee>(employeeDataModel);
        return Task.FromResult(employee);
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        var employeesModels =  context.Store.GetCollection<EmployeeDataModel>().AsQueryable().ToList();
        var employees = employeesModels.Select(mapper.Map<Employee>);
        return Task.FromResult(employees);
    }

    public Task<int> AddAsync(Employee employee)
    {
        var employeeDataModel = mapper.Map<EmployeeDataModel>(employee);
        var isSuccess = context.Store.GetCollection<EmployeeDataModel>().InsertOne(employeeDataModel);
        return isSuccess ? Task.FromResult(employeeDataModel.Id) : Task.FromResult<int>(-1);
    }

    public async Task<bool> UpdateAsync(Employee employee)
    {
        var employeeDataModel = mapper.Map<EmployeeDataModel>(employee);
        return await context.Store.GetCollection<EmployeeDataModel>().ReplaceOneAsync(e => e.Id == employeeDataModel.Id, employeeDataModel);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await context.Store.GetCollection<EmployeeDataModel>().DeleteOneAsync(e => e.Id == 1);
    }
}
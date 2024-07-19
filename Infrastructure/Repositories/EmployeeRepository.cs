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
        var employeeDataModel = context.store.GetCollection<EmployeeDataModel>().AsQueryable().FirstOrDefault(e => e.Id == id);
        var employee = mapper.Map<Employee>(employeeDataModel);
        return Task.FromResult(employee);
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        var employeesModels =  context.store.GetCollection<EmployeeDataModel>().AsQueryable().ToList();
        var employees = employeesModels.Select(e => mapper.Map<Employee>(e));
        return Task.FromResult(employees);
    }

    public Task<int> AddAsync(Employee employee)
    {
        var employeeDataModel = mapper.Map<EmployeeDataModel>(employee);
        var isSuccess = context.store.GetCollection<EmployeeDataModel>().InsertOne(employeeDataModel);
        return Task.FromResult(employeeDataModel.Id);
    }

    public async Task UpdateAsync(Employee employee)
    {
        var employeeDataModel = mapper.Map<EmployeeDataModel>(employee);
        var isSuccess = await context.store.GetCollection<EmployeeDataModel>().ReplaceOneAsync(e => e.Id == employeeDataModel.Id, employeeDataModel);
    }

    public async Task DeleteAsync(int id)
    {
        var isSuccess = await context.store.GetCollection<EmployeeDataModel>().DeleteOneAsync(e => e.Id == 1);
    }
}
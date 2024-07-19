using FluentValidation.Results;
using System;
using Application.DTOs;

namespace Presentation.Utilities
{
    public static class WriteLineHelper
    {
        public static void ShowErrors(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        public static void ShowResult(EmployeeResultDto result)
        {
            if (result.Success)
                Console.WriteLine($"Employee with ID: {result.Id} added successfully.");
            else
                Console.WriteLine($"{result.Message}");
        }

        public static void ShowResult(List<EmployeeDto> result)
        {
            throw new NotImplementedException();
        }

        public static void ShowResult(EmployeeDto result)
        {
            throw new NotImplementedException();
        }
    }
}
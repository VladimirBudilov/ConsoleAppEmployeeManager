using FluentValidation.Results;
using System;
using Application.DTOs;
using Newtonsoft.Json;

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

        public static void ShowResult(ResultDto result)
        {
            Console.WriteLine($"Employee {result.Id} {result.Message}");
        }

        public static void ShowResult(List<EmployeeDto> result)
        {
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        public static void ShowResult(EmployeeDto result)
        {
            Console.WriteLine(result == null ? "Employee not found." : JsonConvert.SerializeObject(result));
        }
    }
}
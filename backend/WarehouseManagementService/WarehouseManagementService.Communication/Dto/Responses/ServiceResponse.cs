using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagementService.Communication.Dto.Responses
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        private static ServiceResponse<T> Create(bool success, int statusCode, string? message = null, T? data = default, List<string>? errors = null)
        {
            return new ServiceResponse<T>
            {
                Success = success,
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Errors = errors
            };
        }

        public static ServiceResponse<T> Ok(T data) => Create(true, 200, data: data);

        public static ServiceResponse<T> BadRequest(string message) => Create(false, 400, message: message);

        public static ServiceResponse<T> ValidationError(List<string> errors) => Create(false, 400, errors: errors);

        public static ServiceResponse<T> Unauthorized(string message) => Create(false, 401, message: message);

        public static ServiceResponse<T> Error(string message) => Create(false, 500, message: message);
    }
}
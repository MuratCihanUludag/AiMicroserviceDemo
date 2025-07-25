using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace AiDemo.SharedLiblary.Result
{
    public class ServiceResult
    {
        [JsonIgnore] public HttpStatusCode StatusCode { get; set; }
        public ProblemDetails? Fail { get; set; }
        [JsonIgnore] public bool IsSuccess => Fail == null;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        //Static Factory Methods
        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult
            {
                StatusCode = HttpStatusCode.NoContent
            };
        }
        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                StatusCode = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = "The requested resource was not found.",
                }
            };
        }
        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                StatusCode = statusCode,
                Fail = problemDetails
            };
        }
        public static ServiceResult Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult
            {
                StatusCode = statusCode,
                Fail = new ProblemDetails
                {
                    Title = title,
                    Status = statusCode.GetHashCode(),
                }
            };
        }
        public static ServiceResult ErrorFromProblemDetails(Refit.ApiException apiException)
        {
            if (string.IsNullOrEmpty(apiException.Content))
            {
                return new ServiceResult
                {
                    StatusCode = apiException.StatusCode,
                    Fail = new ProblemDetails
                    {
                        Title = apiException.Message,
                        Detail = apiException.Content,
                    }
                };
            }
            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(apiException.Content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });
            return new ServiceResult()
            {
                Fail = problemDetails,
                StatusCode = apiException.StatusCode
            };
        }
        public static ServiceResult ErrorFromValidation(IDictionary<string, object?> errors)
        {
            return new ServiceResult()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails
                {
                    Title = "Validation Error",
                    Detail = "One or more validation errors occurred.",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                }
            };
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }
        //200
        public static ServiceResult<T> Success(T data)
        {
            return new ServiceResult<T>
            {
                StatusCode = HttpStatusCode.OK,
                Data = data
            };
        }
        //201
        public static ServiceResult<T> SuccessAsNoContent(T data, string url)
        {
            return new ServiceResult<T>
            {
                StatusCode = HttpStatusCode.NoContent,
                Data = data,
                UrlAsCreated = url
            };
        }
        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>()
            {
                Fail = problemDetails,
                StatusCode = statusCode,
            };
        }
        public new static ServiceResult<T> Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>()
            {
                StatusCode = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Status = statusCode.GetHashCode(),
                }
            };
        }
        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>()
            {
                StatusCode = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Detail = description,
                    Status = statusCode.GetHashCode(),
                }
            };
        }
        public new static ServiceResult<T> ErrorFromProblemDetails(Refit.ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>()
                {
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,
                        Detail = exception.Content,
                    },
                    StatusCode = (HttpStatusCode)exception.StatusCode,
                };
            }

            var problemDetails = JsonSerializer.Deserialize<Microsoft.AspNetCore.Mvc.ProblemDetails>(exception.Content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            });

            return new ServiceResult<T>()
            {
                Fail = problemDetails,
                StatusCode = (HttpStatusCode)exception.StatusCode,
            };
        }
        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string, object?> errors)
        {
            return new ServiceResult<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation Erorrs Occured",
                    Detail = "Please chek the errors property for more details",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode(),
                }
            };
        }
    }
}

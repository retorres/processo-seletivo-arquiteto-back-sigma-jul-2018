using System.Collections.Generic;

namespace GP.Api.AspNet.Models
{
    public class BaseModelResponse
    {
        /// <summary>
        /// Se houve sucesso na requisição
        /// </summary>
        public bool Success { get; }


        /// <summary>
        /// Mensagens de retorno da requisição
        /// </summary>
        public IEnumerable<string> Messages { get; }


        /// <summary>
        /// O Resultado caso tenha tido sucesso
        /// </summary>
        public object Result { get; }

        /// <summary>
        /// O Status code que a requisição teve
        /// </summary>
        public int StatusCode { get; }

        public BaseModelResponse(bool success, int statusCode, IEnumerable<string> messages, object result = null)
        {
            Success = statusCode < 300;
            StatusCode = statusCode;
            Messages = messages ?? new List<string>();
            Result = result;
        }

        public static BaseModelResponse Unauthorized(string message, object data = null)
        {
            return new BaseModelResponse(false, 401, new[] { message }, data);
        }

        public static BaseModelResponse Unauthorized(IEnumerable<string> messages, object data = null)
        {
            return new BaseModelResponse(false, 401, messages, data);
        }

        public static BaseModelResponse BadRequest(string message)
        {
            return new BaseModelResponse(false, 400, new[] { message });
        }

        public static BaseModelResponse BadRequest(IEnumerable<string> messages)
        {
            return new BaseModelResponse(false, 400, messages);
        }

        public static BaseModelResponse Forbidden(string message)
        {
            return new BaseModelResponse(false, 403, new[] { message });
        }

        public static BaseModelResponse Forbidden(IEnumerable<string> messages)
        {
            return new BaseModelResponse(false, 403, messages);
        }

        public static BaseModelResponse InternalServerError(string message)
        {
            return new BaseModelResponse(false, 500, new[] { message });
        }

        public static BaseModelResponse InternalServerError(IEnumerable<string> messages)
        {
            return new BaseModelResponse(false, 500, messages);
        }

    }
}

using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private IStringLocalizer _stringLocalizer1;

        public ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public ResponseHandler(IStringLocalizer stringLocalizer1)
        {
            _stringLocalizer1 = stringLocalizer1;
        }

        public ResponseInformation<T> Deleted<T>()
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.deleted]
            };
        }

        public ResponseInformation<T> Deleted<T>(string message)
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? _stringLocalizer[SharedResourcesKeys.deleted]
            };
        }
        public ResponseInformation<T> Success<T>(T entity, object Meta = null)
        {
            return new ResponseInformation<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.success],
                Meta = Meta
            };
        }
        public ResponseInformation<T> Unauthorized<T>()
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }

        public ResponseInformation<T> Unauthorized<T>(string msg)
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = msg
            };
        }

        public ResponseInformation<T> UnprocessableEntity<T>(string Message = null)
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = true,
                Message = Message == null ? "Unprocessable Entity" : Message
            };
        }
        public ResponseInformation<T> BadRequest<T>(string Message = null)
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public ResponseInformation<T> NotFound<T>(string message = null)
        {
            return new ResponseInformation<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _stringLocalizer[SharedResourcesKeys.NotFound] : message
            };
        }

        public ResponseInformation<T> Created<T>(T entity, object Meta = null)
        {
            return new ResponseInformation<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.created],
                Meta = Meta
            };
        }
    }
}

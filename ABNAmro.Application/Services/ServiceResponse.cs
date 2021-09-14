namespace ABNAmro.Application.Services
{
    public class ServiceResponse
    {
        protected ServiceResponse()
        { }

        public bool IsSuccessful { get; protected set; }

        public bool IsAuthenticated { get; protected set; } = true; // TODO: Remove this temp default

        public string Message { get; protected set; }

        public static ServiceResponse Success()
        {
            return new ServiceResponse
            {
                IsSuccessful = true,
                IsAuthenticated = true
            };
        }

        public static ServiceResponse Failure(string message)
        {
            return new ServiceResponse
            {
                IsSuccessful = false,
                IsAuthenticated = true,
                Message = message
            };
        }

        public static ServiceResponse NotAuthenticated()
        {
            return new ServiceResponse
            {
                IsSuccessful = true,
                IsAuthenticated = false
            };
        }
    }

    public class ServiceResponse<TDto> : ServiceResponse
    {
        protected ServiceResponse()
        { }

        public TDto Value { get; protected set; }

        public static ServiceResponse<TDto> Success(TDto responseValue)
        {
            return new ServiceResponse<TDto>
            {
                IsSuccessful = true,
                Value = responseValue
            };
        }

        public static new ServiceResponse<TDto> Failure(string message)
        {
            return new ServiceResponse<TDto>
            {
                IsSuccessful = false,
                Message = message
            };
        }
    }
}

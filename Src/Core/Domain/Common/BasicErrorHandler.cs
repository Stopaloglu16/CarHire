namespace Domain.Common
{
    public class BasicErrorHandler
    {
        //public BasicErrorHandler(T data, string errorMessage, string errorDeveloperMessage)
        //{
        //    ErrorMessage = errorMessage;
        //    ErrorDeveloperMessage = errorDeveloperMessage;
        //    Data = data;
        //}

        public BasicErrorHandler()
        {
        }

        public BasicErrorHandler(string? errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
        }

        public bool HasError { get; set; } = false;
        public string? ErrorMessage { get; set; }

    }
}

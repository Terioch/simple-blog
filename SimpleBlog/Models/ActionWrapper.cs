namespace SimpleBlog.Models
{
    public class ActionWrapper<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Payload { get; set; }

        public ActionWrapper<T> Success(string message, T payload)
        {
            return new ActionWrapper<T>
            {
                IsSuccess = true,
                Message = message,
                Payload = payload
            };
        }

        public ActionWrapper<T> Failed(string message, T payload)
        {
            return new ActionWrapper<T>
            {
                IsSuccess = false,
                Message = message,
                Payload = payload
            };
        }
    }

    public class ActionWrapper
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public ActionWrapper Success(string message) 
        {
            return new ActionWrapper
            {
                IsSuccess = true,
                Message = message
            };
        }

        public ActionWrapper Failed(string message)
        {
            return new ActionWrapper
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}

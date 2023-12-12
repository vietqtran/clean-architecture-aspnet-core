namespace Solution.MVC.Services.Base
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}

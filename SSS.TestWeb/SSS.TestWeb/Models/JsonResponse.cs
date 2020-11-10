namespace SSS.TestWeb.Models
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public dynamic data { get; set; }
        public int count { get; set; }
    }
}
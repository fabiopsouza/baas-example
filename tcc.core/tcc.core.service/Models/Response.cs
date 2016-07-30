namespace tcc.core.service.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Error { get; set; }

        public object Data { get; set; }

        public int Code { get; set; }
        
        public Response()
        {

        }

        public Response(bool isSuccess, string error, object data, int code)
        {
            IsSuccess = isSuccess;
            Error = error;
            Data = data;
            Code = code;
        }
    }
}

namespace LoginBackend.Application.Responses;

public class CustomResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public CustomResponse(bool success, string message, object data = null)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public static CustomResponse Error(string message)
    {
        return new CustomResponse(false, message);
    }

    public static CustomResponse SuccessResponse(object data)
    {
        return new CustomResponse(true, "Success", data);
    }
}

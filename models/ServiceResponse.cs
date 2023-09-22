namespace web_api.models
{
    public class ServiceResponse<T>
    {
         public T? data { get; set; } 
         public bool success { get; set; } = true;

         public String message { get; set; } = String.Empty;    
    }
}
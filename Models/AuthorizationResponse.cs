namespace PASVE.Models
{
    public class AuthorizationResponse<T>
    {
        public bool Authorized { get; set; }
        public string? Message { get; set; }
        public T? Response { get; set; }
    }
}

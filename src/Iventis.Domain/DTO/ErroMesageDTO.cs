namespace Iventis.Domain.DTO
{
    public class ErrorMessageDTO
    {
        public ErrorMessageDTO()
        {
            Success = true;
            ErrorMessages = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

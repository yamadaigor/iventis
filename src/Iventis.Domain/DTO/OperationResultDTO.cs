namespace Iventis.Domain.DTO
{
    public class OperationResultDTO
    {
        public OperationResultDTO()
        {
            Success = true;
            ErrorMessages = new List<string>();
        }
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }

        public void AddErrorMessage(string message)
        {
            if (Success)
                Success = false;

            ErrorMessages.Add(message);
        }
    }
}

namespace CRM.Models.DTO.Abstract
{
    public abstract class AbstractResponse<T>
    {
        public T Result { get; set; }
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

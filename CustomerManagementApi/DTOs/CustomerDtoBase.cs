namespace CustomerManagementApi.DTOs
{
    public abstract class CustomerDtoBase
    {
        public string Firstname { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}

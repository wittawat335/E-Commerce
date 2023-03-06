namespace E_CommerceAPI.Utilities
{
    public class ReponseApi<T>
    {
        public bool Status { get; set; }
        public string? StatusMessage { get; set; } = string.Empty;
        public T? Value { get; set; }
    }
}

namespace ChatApp.Repository
{
    public interface IMessageRepository
    {
        Task AddMessageAsync(string user, string message);
        //Task<List<Message>> GetMessagesAsync();
    }
}

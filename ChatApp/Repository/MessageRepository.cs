using ChatApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(string user, string message)
        {
            var msg = new Message { User = user, Content = message, Timestamp = DateTime.Now };
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _context.Messages.OrderByDescending(m => m.Timestamp).ToListAsync();
        }
    }

}

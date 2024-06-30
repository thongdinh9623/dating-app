using API.Helpers;
using System.Collections.Generic;

namespace API.Interfaces
{
    public interface IMessageRepository
    {
        void AddGroup(Group group);

        Task<Connection> GetConnection(string connectionId);

        void RemoveConnection(Connection connection);

        Task<Group> GetMessageGroup(string groupName);

        Task<Group> GetGroupForConnection(string connectionId);

        void AddMessage(Message message);

        Task<Message> GetMessage(int id);

        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);

        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);

        void DeleteMessage(Message message);

    }
}

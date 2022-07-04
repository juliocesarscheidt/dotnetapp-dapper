using Api.Domain.Entity;
using Api.Application.Dto;

namespace Api.Domain.Repository
{
    public interface IMessageRepository
    {
        void Dispose();

        List<Message> findAll(int page, int size);

        Message findOne(int id);

        int create(MessageDto dto);

        Message update(int id, MessageDto dto);

        void delete(int id);

        int count();
    }
}

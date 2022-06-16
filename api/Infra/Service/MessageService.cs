using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

using Api.Domain.Entity;
using Api.Domain.Repository;
using Api.Application.Dto;
using Api.Application.Service;

namespace Api.Infra.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository MessageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            MessageRepository = messageRepository;
        }

        public List<Message> FindAll()
        {
            List<Message> messages = MessageRepository.findAll();
            messages.ForEach(message => Console.WriteLine(message));

            return messages;
        }

        public Message FindOne(int id)
        {
            Message message = MessageRepository.findOne(id);
            Console.WriteLine(message);

            return message;
        }

        public int Create(MessageDto dto)
        {
            int id = MessageRepository.create(dto);
            Console.WriteLine($"value => {id}");

            return id;
        }

        public Message Update(int id, MessageDto dto)
        {
            Message message = MessageRepository.update(id, dto);
            Console.WriteLine(message);

            return message;
        }

        public void Delete(int id)
        {
            MessageRepository.delete(id);
        }

        public int Count()
        {
            int count = MessageRepository.count();
            Console.WriteLine(count);

            return count;
        }
    }
}

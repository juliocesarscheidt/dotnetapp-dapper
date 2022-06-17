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

        public List<Message> findAll(int page, int size)
        {
            List<Message> messages = MessageRepository.findAll(page, size);
            Console.WriteLine(messages);

            return messages;
        }

        public Message findOne(int id)
        {
            Message message = MessageRepository.findOne(id);
            Console.WriteLine(message);

            return message;
        }

        public int create(MessageDto dto)
        {
            int id = MessageRepository.create(dto);
            Console.WriteLine(id);

            return id;
        }

        public Message update(int id, MessageDto dto)
        {
            Message message = MessageRepository.update(id, dto);
            Console.WriteLine(message);

            return message;
        }

        public void delete(int id)
        {
            MessageRepository.delete(id);
        }

        public int count()
        {
            int counter = MessageRepository.count();
            Console.WriteLine(counter);

            return counter;
        }
    }
}

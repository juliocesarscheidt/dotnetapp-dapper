using Dapper;
using System.Data;
// using System.Collections;
using System.Collections.Generic;
using System.Linq; // for ToList()

using Api.Domain.Entity;
using Api.Application.Dto;

namespace Api.Application.Service
{
    public interface IMessageService
    {
        List<Message> FindAll();

        Message FindOne(int id);

        int Create(MessageDto dto);

        Message Update(int id, MessageDto dto);

        void Delete(int id);

        int Count();
    }
}

using Dapper;
using System.Data;
// using System.Collections;
using System.Collections.Generic;
using System.Linq; // for ToList()

using Api.Entity;
using Api.Dto;

namespace Api.Infra.Repository
{
    public interface IMessageRepository
    {
        void Dispose();

        List<Message> findAll();

        Message findOne(int id);

        int create(MessageDto dto);

        Message update(int id, MessageDto dto);

        void delete(int id);

        int count();
    }
}

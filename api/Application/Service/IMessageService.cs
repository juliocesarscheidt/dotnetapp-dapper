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
        List<Message> findAll(int page, int size);

        Message findOne(int id);

        int create(MessageDto dto);

        Message update(int id, MessageDto dto);

        void delete(int id);

        int count();
    }
}

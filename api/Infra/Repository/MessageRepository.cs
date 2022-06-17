using Dapper;
using System;
using System.Data;

using System.Collections.Generic;
using System.Linq; // for ToList()

using Api.Domain.Entity;
using Api.Application.Dto;
using Api.Domain.Repository;

namespace Api.Infra.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IDbConnection DbConnection;

        public MessageRepository(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public void Dispose()
        {
            DbConnection.Close();
        }

        public List<Message> findAll(int page, int size)
        {
            const string sql = @"SELECT
              id, user_id, content, created_at, updated_at, deleted_at
              FROM message
              WHERE deleted_at IS @deleted_at
              ORDER BY id DESC LIMIT @limit OFFSET @offset";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@deleted_at", null);
            parameters.Add("@offset", (page * size));
            parameters.Add("@limit", size);

            return DbConnection.Query<Message>(sql, parameters).ToList();
        }

        public Message findOne(int id)
        {
            const string sql = @"SELECT id, user_id, content, created_at, updated_at, deleted_at FROM message WHERE id = @id AND deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@deleted_at", null);

            return DbConnection.QueryFirstOrDefault<Message>(sql, parameters);
        }

        public int create(MessageDto dto)
        {
            const string sql = @"INSERT INTO message (user_id, content) VALUES (@user_id, @content)";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@user_id", dto.user_id);
            parameters.Add("@content", dto.content);

            DbConnection.Execute(sql, parameters);
            string sqlId = @"SELECT LAST_INSERT_ID();";

            int id = DbConnection.QueryFirstOrDefault<int>(sqlId);
            return id;
        }

        public Message update(int id, MessageDto dto)
        {
            const string sql = @"UPDATE message SET user_id = @user_id, content = @content, updated_at = NOW() WHERE id = @id AND deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@user_id", dto.user_id);
            parameters.Add("@content", dto.content);
            parameters.Add("@id", id);
            parameters.Add("@deleted_at", null);

            DbConnection.Execute(sql, parameters);
            return this.findOne(id);
        }

        public void delete(int id)
        {
            const string sql = @"UPDATE message SET deleted_at = NOW() WHERE id = @id AND deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@deleted_at", null);

            DbConnection.Execute(sql, parameters);
        }

        public int count()
        {
            const string sql = @"SELECT COUNT(id) as counter FROM message WHERE deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@deleted_at", null);

            int counter = DbConnection.QueryFirstOrDefault<int>(sql, parameters);
            return counter;
        }
    }
}

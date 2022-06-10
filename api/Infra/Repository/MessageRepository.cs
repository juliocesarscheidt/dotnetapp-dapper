using Dapper;
using System;
using System.Data;

using System.Collections.Generic;
using System.Linq; // for ToList()

using Api.Entity;
using Api.Dto;
using Api.Infra.Repository;

namespace Api.Repository
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

        public List<Message> findAll()
        {
            const string sql = @"SELECT id, user_id, content, created_at, updated_at, deleted_at FROM message WHERE deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@deleted_at", null);

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

            var result = DbConnection.Execute(sql, parameters);
            Console.WriteLine($"result {result}");

            string sqlLastId = @"SELECT LAST_INSERT_ID();";
            Console.WriteLine(sql);

            int lastId = DbConnection.QueryFirstOrDefault<int>(sqlLastId);
            Console.WriteLine($"lastId {lastId}");

            return lastId;
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

            var result = DbConnection.Execute(sql, parameters);
            Console.WriteLine($"result {result}");

            return this.findOne(id);
        }

        public void delete(int id)
        {
            const string sql = @"UPDATE message SET deleted_at = NOW() WHERE id = @id AND deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            parameters.Add("@deleted_at", null);

            var result = DbConnection.Execute(sql, parameters);
            Console.WriteLine($"result {result}");
        }

        public int count()
        {
            const string sql = @"SELECT COUNT(*) as row_count FROM message WHERE deleted_at IS @deleted_at";
            Console.WriteLine(sql);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@deleted_at", null);

            int result = DbConnection.QueryFirstOrDefault<int>(sql, parameters);

            Console.WriteLine($"result {result}");

            return result;
        }
    }
}

using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

using Api.Entity;
using Api.Dto;
using Api.Infra.Repository;

namespace Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository MessageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            MessageRepository = messageRepository;
        }

        // GET api/message
        [HttpGet]
        public ActionResult<HttpResponseDto> FindAll()
        {
            Response.Headers.Add("Content-type", "application/json");

            List<Message> messages = MessageRepository.findAll();
            messages.ForEach(message => Console.WriteLine(message));

            HttpResponseDto response = new HttpResponseDto()
                .setData(messages)
                .setStatusCode(200);

            return Ok(response);
        }

        // GET api/message/count
        [HttpGet("count")]
        public ActionResult<HttpResponseDto> Count()
        {
            Response.Headers.Add("Content-type", "application/json");

            int count = MessageRepository.count();
            Console.WriteLine(count);

            HttpResponseDto response = new HttpResponseDto()
                .setData(count)
                .setStatusCode(200);

            return Ok(response);
        }

        // GET api/message/1
        [HttpGet("{id}")]
        public ActionResult<HttpResponseDto> FindOne(int id)
        {
            Console.WriteLine($"value => {id}");
            Response.Headers.Add("Content-type", "application/json");

            Message message = MessageRepository.findOne(id);
            Console.WriteLine(message);

            if (message == null) {
                return NotFound();
            }

            HttpResponseDto response = new HttpResponseDto()
                .setData(message)
                .setStatusCode(200);

            return Ok(response);
        }

        // POST api/message
        [HttpPost]
        public ActionResult<HttpResponseDto> Create([FromBody] MessageDto dto)
        {
            Response.Headers.Add("Content-type", "application/json");

            int id = MessageRepository.create(dto);
            Console.WriteLine($"value => {id}");

            HttpResponseDto response = new HttpResponseDto()
                .setData(id)
                .setStatusCode(202);

            return Accepted(response);
        }

        // PUT api/message/1
        [HttpPut("{id}")]
        public ActionResult<HttpResponseDto> Update(int id, [FromBody] MessageDto dto)
        {
            Response.Headers.Add("Content-type", "application/json");

            Console.WriteLine($"value => {id}");

            Message message = MessageRepository.update(id, dto);
            Console.WriteLine(message);

            HttpResponseDto response = new HttpResponseDto()
                .setData(message)
                .setStatusCode(202);

            return Accepted(response);
        }

        // DELETE api/message/1
        [HttpDelete("{id}")]
        public ActionResult<HttpResponseDto> Delete(int id)
        {
            Response.Headers.Add("Content-type", "application/json");

            Console.WriteLine($"value => {id}");

            MessageRepository.delete(id);

            return NoContent();
        }
    }
}

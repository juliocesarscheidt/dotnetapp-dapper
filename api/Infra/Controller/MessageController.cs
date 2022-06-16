using System;
using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Api.Domain.Entity;
using Api.Application.Dto;
using Api.Application.Service;

namespace Api.Infra.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService MessageService;

        public MessageController(IMessageService messageService)
        {
            MessageService = messageService;
        }

        // GET api/message
        [HttpGet]
        public ActionResult<HttpResponseDto> FindAll()
        {
            Response.Headers.Add("Content-type", "application/json");

            List<Message> messages = MessageService.FindAll();
            messages.ForEach(message => Console.WriteLine(message));

            HttpResponseDto response = new HttpResponseDto()
                .setData(messages)
                .setStatusCode(200);

            return Ok(response);
        }

        // GET api/message/1
        [HttpGet("{id}")]
        public ActionResult<HttpResponseDto> FindOne(int id)
        {
            Console.WriteLine($"value => {id}");
            Response.Headers.Add("Content-type", "application/json");

            Message message = MessageService.FindOne(id);
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

            int id = MessageService.Create(dto);
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

            Message message = MessageService.Update(id, dto);
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

            MessageService.Delete(id);

            return NoContent();
        }

        // GET api/message/count
        [HttpGet("count")]
        public ActionResult<HttpResponseDto> Count()
        {
            Response.Headers.Add("Content-type", "application/json");

            int count = MessageService.Count();
            Console.WriteLine(count);

            HttpResponseDto response = new HttpResponseDto()
                .setData(count)
                .setStatusCode(200);

            return Ok(response);
        }
    }
}

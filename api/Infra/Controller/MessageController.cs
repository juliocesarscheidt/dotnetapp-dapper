using Microsoft.AspNetCore.Mvc;

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

        public MessageController(IMessageService _messageService)
        {
            MessageService = _messageService;
        }

        private ObjectResult throwInternalServerError(Exception e) {
            Console.WriteLine(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, e);
        }

        // GET api/message
        [HttpGet]
        public ActionResult<HttpResponseDto> findAll([FromQuery] int page = 0, [FromQuery] int size = 50)
        {
            Response.Headers.Add("Content-type", "application/json");
            try {
                List<Message> messages = MessageService.findAll(page, size);
                int counter = MessageService.count();

                HttpResponseDto response = new HttpResponseDto()
                    .setData(messages)
                    .setMetadata(new {page = page, size = size, total = counter})
                    .setStatusCode(StatusCodes.Status200OK);
                return Ok(response);

            } catch (Exception e) {
                return this.throwInternalServerError(e);
            }
        }

        // GET api/message/1
        [HttpGet("{id}")]
        public ActionResult<HttpResponseDto> findOne(int id)
        {
            Response.Headers.Add("Content-type", "application/json");
            try {
                Message message = MessageService.findOne(id);
                if (message == null) {
                    return NotFound();
                }
                HttpResponseDto response = new HttpResponseDto()
                    .setData(message)
                    .setStatusCode(StatusCodes.Status200OK);
                return Ok(response);

            } catch (Exception e) {
                return this.throwInternalServerError(e);
            }
        }

        // POST api/message
        [HttpPost]
        public ActionResult<HttpResponseDto> create([FromBody] MessageDto dto)
        {
            Response.Headers.Add("Content-type", "application/json");
            try {
                int id = MessageService.create(dto);
                HttpResponseDto response = new HttpResponseDto()
                    .setData(id)
                    .setStatusCode(StatusCodes.Status202Accepted);
                return Accepted(response);

            } catch (Exception e) {
                return this.throwInternalServerError(e);
            }
        }

        // PUT api/message/1
        [HttpPut("{id}")]
        public ActionResult<HttpResponseDto> update(int id, [FromBody] MessageDto dto)
        {
            Response.Headers.Add("Content-type", "application/json");
            try {
                Message message = MessageService.update(id, dto);
                HttpResponseDto response = new HttpResponseDto()
                    .setData(message)
                    .setStatusCode(StatusCodes.Status202Accepted);
                return Accepted(response);

            } catch (Exception e) {
                return this.throwInternalServerError(e);
            }
        }

        // DELETE api/message/1
        [HttpDelete("{id}")]
        public ActionResult<HttpResponseDto> delete(int id)
        {
            Response.Headers.Add("Content-type", "application/json");
            try {
                MessageService.delete(id);
                return NoContent();

            } catch (Exception e) {
                return this.throwInternalServerError(e);
            }
        }
    }
}

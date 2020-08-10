using Microsoft.AspNetCore.Mvc;
using MSAFORO255.Notification.DTO;
using MSAFORO255.Notification.Model;
using MSAFORO255.Notification.Repository;
using System.Linq;

namespace MSAFORO255.Notification.Controllers
{
    [Route("api/Notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMailRepository _mailRepository;

        public NotificationController(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        [HttpPost]
        public IActionResult GetNotification([FromBody] SendMailDto request)
        {
            SendMail mail = new SendMail()
            {
                SendDate = request.SendDate,
                AccountId = request.AccountId
            };
            _mailRepository.Add(mail);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult CreateNotification(int id)
        {
            var entity = _mailRepository.GetAll();
            var result = entity.Where(x => x.SendMailId.Equals(id));
            return Ok(result);
        }
    }
}

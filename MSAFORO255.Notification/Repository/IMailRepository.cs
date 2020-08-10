using MSAFORO255.Notification.Model;
using System.Collections;
using System.Collections.Generic;

namespace MSAFORO255.Notification.Repository
{
    public interface IMailRepository
    {
        bool Add(SendMail sendMail);
        IEnumerable<SendMail> GetAll();
    }
}

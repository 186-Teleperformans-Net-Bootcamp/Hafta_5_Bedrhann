using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Application.Interfaces.EventServices
{
    public interface ICreateUserEvent
    {
        public void SendEvent(string Username);
    }
}

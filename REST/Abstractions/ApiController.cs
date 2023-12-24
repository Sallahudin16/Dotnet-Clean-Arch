using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace REST.Abstractions
{
    public class ApiController : ControllerBase
    {
        protected ISender _Sender;

        public ApiController(ISender sender)
        {
            _Sender = sender;
        }
    }
}

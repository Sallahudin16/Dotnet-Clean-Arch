using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Abstractions
{
    public interface IApiRequest
    {
        public bool Validated();
        public bool ValidationErrors();
    }
}

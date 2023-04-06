using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Restaurant_Order.Domain.Integrations
{
    public interface ISaveFile
    {
        string Save(byte[] file, string fileExt);
    }
}

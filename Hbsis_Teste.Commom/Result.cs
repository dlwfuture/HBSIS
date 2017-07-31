using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hbsis_Teste.Commom
{
    public class Result<T>
    {
        public Result()
        {
            Return = System.Activator.CreateInstance<T>();
        }

        public bool Error { get; set; }

        public string Message { get; set; }
        public T Return { get; set; }
    }
}

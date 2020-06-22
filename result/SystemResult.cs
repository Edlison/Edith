using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edith.result
{
    class SystemResult
    {
        private String desc;
        private long code;

        public SystemResult(String desc, long code)
        {
            this.desc = desc;
            this.code = code;
        } 

        public long getCode()
        {
            return this.code;
        }

        public String getDesc()
        {
            return this.desc;
        }
    }
}

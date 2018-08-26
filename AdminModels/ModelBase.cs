using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels
{
    public class ModelBase
    {
        public virtual int Id { get; set; }

        public virtual DateTime _CreateDate { get; set; } = DateTime.Now;

        public virtual DateTime? _UpdateDate { get; set; }
    }
}

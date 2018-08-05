using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels
{
    public class ModelBase
    {
        public int Id { get; set; }

        public DateTime _CreateDate { get; set; } = DateTime.Now;

        public DateTime? _UpdateDate { get; set; }
    }
}

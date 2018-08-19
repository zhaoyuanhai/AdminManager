using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminDataEntity.Models
{
    public class ParameterModel
    {
        public int Id { get; set; }

        public int IsOutParam { get; set; }

        public string Name { get; set; }

        public short Length { get; set; }
    }
}

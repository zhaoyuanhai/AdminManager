using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminModels.Entities
{
    public class T_AuthorityType : ModelBase
    {
        /// <summary>
        /// 类型Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        /// <summary>
        /// 类型描述描述
        /// </summary>
        public string Description { get; set; }
    }
}
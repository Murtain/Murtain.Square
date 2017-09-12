using Murtain.AutoMapper;
using Murtain.Domain.Entities.Audited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Domain.Entities
{
    [Table("Sentence")]
    [AutoMap(typeof(SDK.Sentence.Sentence), typeof(SDK.Sentence.SentenceFavoriteAsyncRequest))]
    public class Sentence : AuditedEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(40)]
        public string FamousName { get; set; }
        /// <summary>
        /// 名言
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string FamousSaying { get; set; }
    }
}

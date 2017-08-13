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
    [Table("Focus")]
    [AutoMap(typeof(SDK.Domain.Focus))]
    public class Focus : AuditedEntity
    {
        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(40)]
        public string Content { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public Status Status { get; set; }
    }

    /// <summary>
    /// 任务状态
    /// </summary>
    public enum Status
    {
        Focus,
        Completed,
        Expired
    }
}

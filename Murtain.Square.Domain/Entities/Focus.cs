using Murtain.AutoMapper;
using Murtain.Domain.Entities.Audited;
using Murtain.Square.SDK.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Murtain.Square.Domain.Entities
{
    [Table("Focus")]
    [AutoMap(typeof(SDK.Domain.Focus))]
    public class Focus : AuditedEntity, IAutoMaping
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

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Domain.Entities.Focus, SDK.Domain.Focus>()
                .ForMember(x => x.key, opt => opt.MapFrom(m => m.Id.ToString()))
                ;
        }
    }

}

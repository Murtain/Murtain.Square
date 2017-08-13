using Murtain.Domain.Entities;
using Murtain.Domain.Entities.Audited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Domain
{

    public abstract class AuditedEntityBase : AuditedEntity
    {
        public override long Id { get; set; }
        public override DateTime? CreateTime { get; set; }
        [MaxLength(50)]
        public override string CreateUser { get; set; }
        [MaxLength(50)]
        public override string ChangeUser { get; set; }
        public override DateTime? ChangeTime { get; set; }
    }

    public abstract class PassivableEntityBase : AuditedEntityBase, IPassivable
    {
        public virtual bool IsActived { get; set; }
    }


    public abstract class SoftDeleteEntityBase : AuditedEntityBase, ISoftDelete
    {
        public virtual bool IsDeleted { get; set; }
    }

    public abstract class PassivableSoftDeleteEntityBase : AuditedEntityBase, IPassivable, ISoftDelete
    {
        public virtual bool IsActived { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}

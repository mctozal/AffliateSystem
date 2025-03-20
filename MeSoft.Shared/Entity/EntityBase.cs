using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeSoft.Shared.EntityBase
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public virtual int? CreatedByUserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloomia.Domain.Common;

namespace Bloomia.Domain.Entities.Admin
{
    public class ArticleEntity : BaseEntity
    {
        public int AdminId { get; set; }
        public AdminEntity Admin { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishedAt { get; set; }=DateTime.UtcNow;

    }
}

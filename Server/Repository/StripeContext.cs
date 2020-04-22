using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Tres.Stripes.Models;

namespace Tres.Stripes.Repository
{
    public class StripeContext : DBContextBase, IService
    {
        public virtual DbSet<Stripe> Stripe { get; set; }

        public StripeContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Tres.Stripes.Models;

namespace Tres.Stripes.Services
{
    public interface IStripeService 
    {
        Task<List<Stripe>> GetStripesAsync(int ModuleId);

        Task<Stripe> GetStripeAsync(int StripeId);

        Task<Stripe> AddStripeAsync(Stripe Stripe);

        Task<Stripe> UpdateStripeAsync(Stripe Stripe);

        Task DeleteStripeAsync(int StripeId);
    }
}

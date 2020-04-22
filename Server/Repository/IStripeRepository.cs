using System.Collections.Generic;
using Tres.Stripes.Models;

namespace Tres.Stripes.Repository
{
    public interface IStripeRepository
    {
        IEnumerable<Stripe> GetStripes(int ModuleId);
        Stripe GetStripe(int StripeId);
        Stripe AddStripe(Stripe Stripe);
        Stripe UpdateStripe(Stripe Stripe);
        void DeleteStripe(int StripeId);
    }
}

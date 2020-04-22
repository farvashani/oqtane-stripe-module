using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Tres.Stripes.Models;

namespace Tres.Stripes.Repository
{
    public class StripeRepository : IStripeRepository, IService
    {
        private readonly StripeContext _db;

        public StripeRepository(StripeContext context)
        {
            _db = context;
        }

        public IEnumerable<Stripe> GetStripes(int ModuleId)
        {
            return _db.Stripe.Where(item => item.ModuleId == ModuleId);
        }

        public Stripe GetStripe(int StripeId)
        {
            return _db.Stripe.Find(StripeId);
        }

        public Stripe AddStripe(Stripe Stripe)
        {
            _db.Stripe.Add(Stripe);
            _db.SaveChanges();
            return Stripe;
        }

        public Stripe UpdateStripe(Stripe Stripe)
        {
            _db.Entry(Stripe).State = EntityState.Modified;
            _db.SaveChanges();
            return Stripe;
        }

        public void DeleteStripe(int StripeId)
        {
            Stripe Stripe = _db.Stripe.Find(StripeId);
            _db.Stripe.Remove(Stripe);
            _db.SaveChanges();
        }
    }
}

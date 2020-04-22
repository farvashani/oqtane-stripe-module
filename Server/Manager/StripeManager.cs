using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Tres.Stripes.Models;
using Tres.Stripes.Repository;

namespace Tres.Stripes.Manager
{
    public class StripeManager : IPortable
    {
        private IStripeRepository _Stripes;

        public StripeManager(IStripeRepository Stripes)
        {
            _Stripes = Stripes;
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Stripe> Stripes = _Stripes.GetStripes(module.ModuleId).ToList();
            if (Stripes != null)
            {
                content = JsonSerializer.Serialize(Stripes);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Stripe> Stripes = null;
            if (!string.IsNullOrEmpty(content))
            {
                Stripes = JsonSerializer.Deserialize<List<Stripe>>(content);
            }
            if (Stripes != null)
            {
                foreach(Stripe Stripe in Stripes)
                {
                    Stripe _Stripe = new Stripe();
                    _Stripe.ModuleId = module.ModuleId;
                    _Stripe.Name = Stripe.Name;
                    _Stripes.AddStripe(_Stripe);
                }
            }
        }
    }
}
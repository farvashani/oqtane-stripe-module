using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Tres.Stripes.Models;

namespace Tres.Stripes.Services
{
    public class StripeService : ServiceBase, IStripeService, IService
    {
        private readonly NavigationManager _navigationManager;
        private readonly SiteState _siteState;

        public StripeService(HttpClient http, SiteState siteState, NavigationManager navigationManager) : base(http)
        {
            _siteState = siteState;
            _navigationManager = navigationManager;
        }

         private string Apiurl
        {
            get { return CreateApiUrl(_siteState.Alias, _navigationManager.Uri, "Stripe"); }
        }

        public async Task<List<Stripe>> GetStripesAsync(int ModuleId)
        {
            List<Stripe> Stripes = await GetJsonAsync<List<Stripe>>(Apiurl + "?moduleid=" + ModuleId.ToString());
            return Stripes.OrderBy(item => item.Name).ToList();
        }

        public async Task<Stripe> GetStripeAsync(int StripeId)
        {
            return await GetJsonAsync<Stripe>(Apiurl + "/" + StripeId.ToString());
        }

        public async Task<Stripe> AddStripeAsync(Stripe Stripe)
        {
            return await PostJsonAsync<Stripe>(Apiurl + "?entityid=" + Stripe.ModuleId, Stripe);
        }

        public async Task<Stripe> UpdateStripeAsync(Stripe Stripe)
        {
            return await PutJsonAsync<Stripe>(Apiurl + "/" + Stripe.StripeId + "?entityid=" + Stripe.ModuleId, Stripe);
        }

        public async Task DeleteStripeAsync(int StripeId)
        {
            await DeleteAsync(Apiurl + "/" + StripeId.ToString());
        }
    }
}

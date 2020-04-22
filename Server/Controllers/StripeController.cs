using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Tres.Stripes.Models;
using Tres.Stripes.Repository;


//Based off blog
//https://wellsb.com/csharp/aspnet/stripe-connect-express-and-blazor/
//https://wellsb.com/csharp/aspnet/stripe-net-create-stripe-webhooks-receiver/


namespace Tres.Stripes.Controllers
{
    [Route("{site}/api/[controller]")]
    public class StripeController : Controller
    {
        private readonly IStripeRepository _Stripes;
        private readonly ILogManager _logger;

        //Stripe settings. Need to be placed in a better location in production app.
        private string _ApiKey;
        private string _ClientId;
        private string _WebhookSigningKey;

        public StripeController(IStripeRepository Stripes, ILogManager logger)
        {
            _Stripes = Stripes;
            _logger = logger;

            _ApiKey = "ABC123";
            _ClientId = "XYZ789";
            _WebhookSigningKey = "whsec_xxxx";

        }

        //// GET: api/<controller>?moduleid=x
        //[HttpGet]
        //[Authorize(Roles = Constants.RegisteredRole)]
        //public IEnumerable<Stripe> Get(string moduleid)
        //{
        //    return _Stripes.GetStripes(int.Parse(moduleid));
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //[Authorize(Roles = Constants.RegisteredRole)]
        //public Stripe Get(int id)
        //{
        //    return _Stripes.GetStripe(id);
        //}

        //// POST api/<controller>
        //[HttpPost]
        //[Authorize(Roles = Constants.AdminRole)]
        //public Stripe Post([FromBody] Stripe Stripe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Stripe = _Stripes.AddStripe(Stripe);
        //        _logger.Log(LogLevel.Information, this, LogFunction.Create, "Stripe Added {Stripe}", Stripe);
        //    }
        //    return Stripe;
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //[Authorize(Roles = Constants.AdminRole)]
        //public Stripe Put(int id, [FromBody] Stripe Stripe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Stripe = _Stripes.UpdateStripe(Stripe);
        //        _logger.Log(LogLevel.Information, this, LogFunction.Update, "Stripe Updated {Stripe}", Stripe);
        //    }
        //    return Stripe;
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //[Authorize(Roles = Constants.AdminRole)]
        //public void Delete(int id)
        //{
        //    _Stripes.DeleteStripe(id);
        //    _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Stripe Deleted {StripeId}", id);
        //}
    }
}

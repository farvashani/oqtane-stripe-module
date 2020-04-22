using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Tres.Stripes.Models;
using Tres.Stripes.Repository;
using System.IO;


//Based off blog
//https://wellsb.com/csharp/aspnet/stripe-connect-express-and-blazor/
//https://wellsb.com/csharp/aspnet/stripe-net-create-stripe-webhooks-receiver/


namespace Tres.Stripes.Controllers
{
    [Route("{site}/api/[controller]")]
    public class StripeWebhookController : Controller
    {
        private readonly IStripeRepository _Stripes;
        private readonly ILogManager _logger;

        //Stripe settings. Need to be placed in a better location in production app.
        private string _ApiKey;
        private string _ClientId;
        private string _WebhookSigningKey;

        public StripeWebhookController(IStripeRepository Stripes, ILogManager logger)
        {
            _Stripes = Stripes;
            _logger = logger;

            _ApiKey = "ABC123";
            _ClientId = "XYZ789";
            _WebhookSigningKey = "whsec_xxxx";

        }

        
        [HttpPost]
        [Authorize(Roles = Constants.AllUsersRole)] //The webhook needs to be accessable
        public async Task<IActionResult> Index()
        {
            string json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], _webhookSecret);
                switch (stripeEvent.Type)
                {
                    case Events.CustomerSourceUpdated:
                        //make sure payment info is valid
                        break;
                    case Events.CustomerSourceExpiring:
                        //send reminder email to update payment method
                        break;
                    case Events.ChargeFailed:
                        //do something
                        break;
                }
                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}

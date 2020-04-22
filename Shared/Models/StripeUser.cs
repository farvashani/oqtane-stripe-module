using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Tres.Stripes.Models
{
    public class StripeUser
    {
        public int StripeUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

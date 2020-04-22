using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Tres.Stripes.Models
{
    [Table("Stripe")]
    public class Stripe : IAuditable
    {
        public int StripeId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string StripeConnectId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}

using Oqtane.Models;
using Oqtane.Modules;

namespace Tres.Stripes.Modules
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Stripe",
            Description = "Stripe",
            Version = "1.0.0",
            Dependencies = "Tres.Stripes.Module.Shared",
            ServerManagerType = "Tres.Stripes.Manager.StripeManager, Tres.Stripes.Module.Server"
        };
    }
}

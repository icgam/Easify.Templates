using System;

namespace Easify.Template.Core.Shared.Domain
{
    public class Sample
    {
        public Sample(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        
        public string Name { get; }
    }
}
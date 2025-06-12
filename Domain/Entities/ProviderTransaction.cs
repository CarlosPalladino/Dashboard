using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProviderTransaction
    {
        public Guid Id { get; private set; }
        public Guid ProviderId { get; private set; }
        public DateTime Date { get; private set; }
        public string Observation { get; private set; }

        private ProviderTransaction() { } // Para Entity Framework

        public ProviderTransaction(Guid id, Guid providerId, DateTime date, string observation)
        {
            Id = id;
            ProviderId = providerId;
            Date = date;
            Observation = observation;
        }
    }

}

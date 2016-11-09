using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Models.Resource
{
    public abstract class EmpireResources : IEmpire, IResources
    {

        private int quantity;
        protected EmpireResources(ResourceType typeOfResource, int quantity)
        {
            this.TypeOfResource = typeOfResource;
            this.Quantity = quantity;
        }

        public ResourceType TypeOfResource { get; }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Can't be a negative number!");
                }
                this.quantity = value;
            }
        }
    }
}

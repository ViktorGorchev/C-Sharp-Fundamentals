using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Contracts;
using ClashOfKings.Exceptions;

namespace ClashOfKings.Models
{
    class GreatHouse : House, IIsGreatHouse
    {

        private const string CityNotFoundErrorMessage = "Specified city does not exist or is not controlled by house {0}";
        private const string InsufficientUpgradeFundsErrorMessage = "House {0} has insufficient funds to upgrade {1}";
       private const int NeededControlledCities = 10;
        private const int MinControlledCities = 5;
        private decimal treasuryAmount;

        public GreatHouse(string name, decimal initialTreasuryAmount) 
            : base(name, initialTreasuryAmount)
        {
            this.TreasuryAmount = initialTreasuryAmount;
        }

        public bool IsGreatHouse { get; set; }

        public override decimal TreasuryAmount
        {
            get
            {
                return this.treasuryAmount;
            }

            set
            {
                if (value < 0 && IsGreatHouse == false)
                {
                    this.DeclareBankruptcy();
                    value = 0;
                }

                this.treasuryAmount = value;
            }
        }

        public override void UpgradeCity(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("city", CityNotFoundErrorMessage);
            }

            if (this.TreasuryAmount < city.UpgradeCost && IsGreatHouse == false)
            {
                throw new InsufficientFundsException(string.Format(InsufficientUpgradeFundsErrorMessage, this.Name, city.Name));
            }

            city.Upgrade();
            this.TreasuryAmount -= city.UpgradeCost;
        }

        public override void Update()
        {
            if (this.ControlledCities.Count() >= NeededControlledCities)
            {
                IsGreatHouse = true;
            }
            if (this.ControlledCities.Count() <= MinControlledCities && IsGreatHouse)
            {
                IsGreatHouse = false;
            }
            this.TreasuryAmount += this.ControlledCities.Sum(city => city.TaxBase);
        }

        public override string Print()
        {
            if (IsGreatHouse)
            {
               return string.Format("Great " + base.ToString()); 
            }
            return base.ToString();
        }

        private void DeclareBankruptcy()
        {
            foreach (var city in this.ControlledCities)
            {
                city.Downgrade();
            }
        }

        
    }
}

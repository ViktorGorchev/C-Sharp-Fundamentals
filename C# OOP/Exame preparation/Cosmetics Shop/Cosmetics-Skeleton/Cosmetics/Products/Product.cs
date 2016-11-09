using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product: IProduct
    {
        private const int MinProductNameLength = 3;
        private const int MaxProductNameLength = 10;
        private const int MinBrandNameLength = 2;
        private const int MaxBrandNameLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public string Brand
        {
            get { return this.brand; }
            set
            {
                ValidateBrandName(value);
                this.brand = value;
            }
        }

        public virtual decimal Price { get; private set; }
        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("- {0} - {1}:{2}", this.Brand, this.Name, Environment.NewLine);
            sb.AppendFormat("  * Price: ${0}{1}", this.Price, Environment.NewLine);
            sb.AppendFormat("  * For gender: {0}{1}", this.Gender, Environment.NewLine);

            return sb.ToString();
        }

        private static void ValidateName(string value)
        {
            string emptyValueMessage = string.Format(
               GlobalErrorMessages.StringCannotBeNullOrEmpty,
               "Product name");

            Validator.CheckIfStringIsNullOrEmpty(value, emptyValueMessage);

            string invalidValueLengthMessage = string.Format(
                GlobalErrorMessages.InvalidStringLength,
                "Product name",
                MinProductNameLength,
                MaxProductNameLength);

            Validator.CheckIfStringLengthIsValid(
                value,
                MaxProductNameLength,
                MinProductNameLength,
                invalidValueLengthMessage);
        }

        private void ValidateBrandName(string value)
        {
            string emptyValueMessage = string.Format(
                GlobalErrorMessages.StringCannotBeNullOrEmpty,
                "Product brand");

            Validator.CheckIfStringIsNullOrEmpty(value, emptyValueMessage);

            string invalidValueLength = string.Format(
                GlobalErrorMessages.InvalidStringLength,
                "Product brand",
                MinBrandNameLength,
                MaxBrandNameLength);

            Validator.CheckIfStringLengthIsValid(
                value,
                MaxBrandNameLength,
                MinBrandNameLength,
                invalidValueLength);
        }
    }
}

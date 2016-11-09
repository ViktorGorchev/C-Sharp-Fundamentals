using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientNameLength = 4;
        private const int MaxIngredientNameLength = 12;

        private readonly IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            StringBuilder sb = new StringBuilder(base.Print());

            sb.AppendFormat("  * Ingredients: {0}", this.Ingredients);

            return sb.ToString();
        }

        private static void ValidateIngredients(IList<string> ingredientsToCheck)
        {
            foreach (var ingredient in ingredientsToCheck)
            {
                Validator.CheckIfStringIsNullOrEmpty(ingredient, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Ingredient"));

                Validator.CheckIfStringLengthIsValid(
                    ingredient,
                    MaxIngredientNameLength,
                    MinIngredientNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", MinIngredientNameLength, MaxIngredientNameLength));
            }
        }

    }
}

namespace AnimalFarm
{
    class Chicken : Animal
    {
        public Chicken(string name, int age)
            : base(name, age)
        {
        }

        protected override Product ProduceProduct()
        {
            return new Product();
        }

        protected override double GetHumanAge()
        {
            return base.Age * 11;
        }
    }
}

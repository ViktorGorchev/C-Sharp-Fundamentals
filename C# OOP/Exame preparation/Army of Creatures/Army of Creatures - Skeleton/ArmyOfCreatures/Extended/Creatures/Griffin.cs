using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    class Griffin : Creature
    {
        
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5m;

        private const int DoubleDefenseWhenDefendingRunds = 5;
        private const int AddDefenseWhenSkipPoints = 3;

        public Griffin() 
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(DoubleDefenseWhenDefendingRunds));
            this.AddSpecialty(new AddDefenseWhenSkip(AddDefenseWhenSkipPoints));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}

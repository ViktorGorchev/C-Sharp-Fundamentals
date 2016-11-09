using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get { return this.rounds; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Rounds", "Must be from 1 to 10!");
                }
                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }
        
        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * 2;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }
    }
}

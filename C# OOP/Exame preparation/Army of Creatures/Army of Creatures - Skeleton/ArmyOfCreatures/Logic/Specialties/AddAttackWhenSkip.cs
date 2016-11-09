using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Logic.Specialties
{
    public class AddAttackWhenSkip : Specialty
    {
        private const int MinAttackToAdd = 1;
        private const int MaxAttackToAdd = 10;
        private int points;

        public AddAttackWhenSkip(int points)
        {
            this.Points = points;
        }

        public int Points
        {
            get { return this.points; }
            set
            {
                if (value < MinAttackToAdd || value > MaxAttackToAdd)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Must from 1 to 10!");
                }
                this.points = value;
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
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.Points;
            
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Points);
        }
    }
}

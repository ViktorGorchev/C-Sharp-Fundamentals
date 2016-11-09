using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Logic.Specialties
{
    public class DoubleAttackWhenAttacking : Specialty
    {
        private int doubleAttackRounds;

        public DoubleAttackWhenAttacking(int doubleAttackRounds)
        {
            this.DoubleAttackRounds = doubleAttackRounds;
        }

        public int DoubleAttackRounds
        {
            get { return this.doubleAttackRounds; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Must be more than 0!");
                }
                this.doubleAttackRounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.doubleAttackRounds <= 0)
            {
               return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.doubleAttackRounds--;
            
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

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.DoubleAttackRounds);
        }
    }
}

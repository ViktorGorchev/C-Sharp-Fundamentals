﻿using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing : Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18;

        private const int AttackPointsWhenSkip = 3;
        private const int DoubleAttackRounds = 4;
        private const int DoubleDamageRounds = 1;

        public CyclopsKing() 
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AttackPointsWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(DoubleAttackRounds));
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}

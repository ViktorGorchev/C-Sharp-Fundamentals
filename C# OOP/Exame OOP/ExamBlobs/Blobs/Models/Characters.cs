namespace Blobs.Models
{
    using System;
    using System.Text;

    using Blobs.Contracts;
    using Blobs.Enums;

    public abstract class Characters : ICharacters, IAttack, IBehavior
    {
        private AttackTypeEnum attack;

        private BehaviorTypeEnum behavior;

        private int damage;

        private int health;

        private string name;

        protected Characters(string name, int health, int damage, BehaviorTypeEnum behavior, AttackTypeEnum attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.Attack = attack;
            this.IsAlive = true;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null or empty space!");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Health can't be a negative number!");
                }

                this.health = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Damage can't be a negative number");
                }

                this.damage = value;
            }
        }

        public BehaviorTypeEnum Behavior { get; set; }

        public AttackTypeEnum Attack { get; set; }

        public bool IsAlive { get; set; }

        public abstract int ImplimentAttackType(ICharacters character);

        public abstract void ImplimentBehaviorType(ICharacters chracter);

        public override string ToString()
        {
            StringBuilder characterStatus = new StringBuilder();
            if (!this.IsAlive)
            {
                characterStatus.AppendFormat("Blob {0} KILLED", this.Name);
            }
            else
            {
                characterStatus.AppendFormat("Blob {0}: {1} HP, {2} Damage", this.Name, this.Health, this.Damage);
            }

            return characterStatus.ToString();
        }

        protected void CheckIfAlive(ICharacters character)
        {
            if (character.Health < 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
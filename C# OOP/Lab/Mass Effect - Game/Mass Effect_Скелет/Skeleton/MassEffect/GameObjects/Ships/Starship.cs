﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using MassEffect.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    abstract class Starship : IStarship
    {
        private List<Enhancement> enhancements;
        private string name;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private StarSystem location;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();

        }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Shields { get; set; }
        public int Damage { get; set; }
        public double Fuel { get; set; }
        public StarSystem Location { get; set; }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }
            
            this.enhancements.Add(enhancement);
            this.ApplyEnhancementEffects(enhancement);
        }

        private void ApplyEnhancementEffects(Enhancement enhancement)
        {
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
            this.Damage += enhancement.DamageBonus;
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));

                var enhancementsOutput = "N/A";
                if (this.enhancements.Any())
                {
                    enhancementsOutput = string.Join(
                        ", ", this.enhancements.Select(e => e.Name));
                }

                output.Append(string.Format("-Enhancements: {0}", enhancementsOutput));
            }

            return output.ToString();
        }

    }
}

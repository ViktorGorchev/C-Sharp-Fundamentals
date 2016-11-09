using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        protected void ValidateAlive(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
        }
        protected IStarship GetStarshipByName(string name)
        {
            return this.GameEngine.Starships
                .First(s => s.Name == name);
        }

        private void ProcessStarshipBattle(IStarship attackingShip, IStarship targetShip)
        {
            this.ValidateAlive(attackingShip);
            this.ValidateAlive(targetShip);

            var battleLocation = attackingShip.Location;
            if (targetShip.Location != battleLocation)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            var attack = attackingShip.ProduceAttack();
            targetShip.RespondToAttack(attack);
            Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, targetShip.Name);

            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }

            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }
    }
}

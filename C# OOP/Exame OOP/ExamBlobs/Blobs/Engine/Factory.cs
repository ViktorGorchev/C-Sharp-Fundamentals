using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;
using Blobs.Enums;
using Blobs.Models;

namespace Blobs.Engine
{
    public class Factory : IFactory
    {
        public ICharacters CharacterCharacter(string[] commandInfo)
        {
            //•	create < name > < health > < damage > < behavior > < attack >
            string name = commandInfo[0];
            int health = int.Parse(commandInfo[1]);
            int damage = int.Parse(commandInfo[2]);
            BehaviorTypeEnum behaviorType = GetBehavior(commandInfo[3]);
            AttackTypeEnum attackType = GetAttack(commandInfo[4]);

            var blob = new Blob(name, health, damage, behaviorType, attackType);
            return blob;
        }

        private BehaviorTypeEnum GetBehavior(string behavior)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior), "Behavior can't be null!");
            }
            else if (behavior == "Aggressive")
            {
                return BehaviorTypeEnum.Aggressive;
            }
            else if (behavior == "Inflated")
            {
                return BehaviorTypeEnum.Inflated;
            }
            else
            {
                throw new AggregateException("Invalid behavour type!");
            }
        }

        private AttackTypeEnum GetAttack(string attack)
        {
            if (attack == null)
            {
                throw new ArgumentNullException(nameof(attack), "Attack can't be null!");
            }
            else if (attack == "PutridFart")
            {
                return AttackTypeEnum.PutridFart;
            }
            else if (attack == "Blobplode")
            {
                return AttackTypeEnum.Blobplode;
            }
            else
            {
                throw new AggregateException("Invalid behavour type!");
            }
        }
    }
}

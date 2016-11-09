using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;
using Blobs.Enums;

namespace Blobs.Models
{
    public class Blob : Characters
    {
        
        public Blob(string name, int health, int damage, BehaviorTypeEnum behavior, AttackTypeEnum attack) 
            : base(name, health, damage, behavior, attack)
        {
            
        }

        public override void ImplimentBehaviorType(ICharacters chracter)
        {
            if (chracter.Behavior == BehaviorTypeEnum.Aggressive)
            {
                chracter.Damage *= 2;
            }
            else if (chracter.Behavior == BehaviorTypeEnum.Inflated)
            {
                chracter.Health += 50;
            }
            
        }

        public override int ImplimentAttackType(ICharacters character)
        {
            int attackDamage = 0;

            if (character.Attack == AttackTypeEnum.PutridFart)
            {
                attackDamage = character.Damage;
            }
            else if (character.Attack == AttackTypeEnum.Blobplode)
            {
                int checkHealth = character.Health - (character.Health / 2);
                if (checkHealth < 1)
                {
                    character.Health = 1;
                }
                else
                {
                    character.Health = character.Health - (character.Health / 2);
                }
                attackDamage = character.Damage * 2;
            }
            return attackDamage;
        }
    }
}

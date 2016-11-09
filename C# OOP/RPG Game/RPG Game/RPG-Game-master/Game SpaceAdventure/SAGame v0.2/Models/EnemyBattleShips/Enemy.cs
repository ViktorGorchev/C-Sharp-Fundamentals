using System;
using SAGame_v0._2.Interfaces;

namespace SAGame_v0._2.Models.EnemyBattleShips
{
    public abstract class Enemy : Characters
    {

        protected Enemy(string name, int damage, int shieldStatus, Position position) 
            : base(name, damage, shieldStatus, position)
        {
        }
    }
}

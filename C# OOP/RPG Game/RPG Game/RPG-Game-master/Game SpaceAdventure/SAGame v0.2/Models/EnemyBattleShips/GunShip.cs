namespace SAGame_v0._2.Models.EnemyBattleShips
{
    public class GunShip : Enemy
    {
        private const string DefaultGunShipName = "Gunship";
        private const int DefaultGunShipDamage = 60;
        private const int DefaultGunShipShieldStatus = 100;

        public GunShip(Position position) 
            : base(DefaultGunShipName, DefaultGunShipDamage, DefaultGunShipShieldStatus, position)
        {
        }

    }
}

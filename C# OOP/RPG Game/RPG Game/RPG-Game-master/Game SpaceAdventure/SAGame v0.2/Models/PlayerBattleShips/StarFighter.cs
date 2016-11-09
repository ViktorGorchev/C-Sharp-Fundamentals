namespace SAGame_v0._2.Models.PlayerBattleShips
{
    public class StarFighter : Player
    {
        private const string DefaultStartfighterName = "Starfighter";
        private const int DefaultStartfighterDamage = 75;
        private const int DefaultStartfighterShieldStatus = 140;
        private const int DefaultStartfighterMunitions = 100;
        private const int DefaultStartfighterEnergy = 100;

        public StarFighter()
            : base(DefaultStartfighterName,
                  DefaultStartfighterDamage,
                  DefaultStartfighterShieldStatus,
                  DefaultStartfighterMunitions,
                  DefaultStartfighterEnergy)
        {
        }

        public override void AutoRepair()
        {
            this.ShieldStatus = DefaultStartfighterShieldStatus;

        }


    }
}

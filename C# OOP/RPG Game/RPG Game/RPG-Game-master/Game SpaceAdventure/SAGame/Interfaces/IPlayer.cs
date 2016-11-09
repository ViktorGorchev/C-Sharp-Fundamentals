namespace SAGame.Interfaces
{
    public interface IPlayer : ICharacter, ICollect
    {
        int Munitions { get; set; }
    }
}

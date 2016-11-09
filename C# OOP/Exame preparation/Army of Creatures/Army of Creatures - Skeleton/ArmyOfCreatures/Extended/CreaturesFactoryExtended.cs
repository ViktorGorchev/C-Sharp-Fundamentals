using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended
{
    public class CreaturesFactoryExtended : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "Goblin":
                    return new Goblin();
                case "Griffin":
                    return new Griffin();
                case "WolfRaider":
                    return new WolfRaider();
                case "CyclopsKing":
                    return new CyclopsKing();
                default:
                    return base.CreateCreature(name);
            }
            

        }
    }
}

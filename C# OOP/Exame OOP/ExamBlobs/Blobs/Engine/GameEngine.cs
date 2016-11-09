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
    public class GameEngine : IEngine
    {
        private int turnsCount = 0;
        private readonly IReade reader;
        private readonly IRender render;
        private readonly IFactory factory;
        private readonly IDataBase dataBase;
        private readonly IBattleManager battleManager;

        public GameEngine(IReade reader, IRender renderer, IFactory factory, IDataBase dataBase, IBattleManager battleManager)
        {
            this.reader = reader;
            this.render = renderer;
            this.factory = factory;
            this.dataBase = dataBase;
            this.battleManager = battleManager;
        }

        

        public virtual void Run()
        {
            while (true)
            {
                var input = this.reader.Reade();
                var inputInfo = input.Split().ToArray();
                ExecuteCommand(inputInfo);
                this.battleManager.UpdateGameTurn();
            }
        }

        protected virtual void ExecuteCommand(string[] inputInfo)
        {
            var command = inputInfo[0].ToLower();
            var commandInfo = inputInfo.Skip(1).ToArray();
            switch (command)
            {
                case "create":
                    var character = factory.CharacterCharacter(commandInfo);
                    this.dataBase.AddCharacter(character);
                    break;
                case "attack":
                    var attacker = GetCharacter(commandInfo[0]);
                    var target = GetCharacter(commandInfo[1]);
                    this.battleManager.BattelCommand(attacker, target);
                    break;
                case "pass":
                    break;
                case "status":
                    PrintStatus();
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
            }
        }

        private ICharacters GetCharacter(string character)
        {
            if (string.IsNullOrEmpty(character))
            {
               throw new AccessViolationException("Character's name cat't be null or emrty!");
            }
            return this.dataBase.AllCharacters.FirstOrDefault(characterInList => characterInList.Name == character);
        }

        private void PrintStatus()
        {
            foreach (var character in dataBase.AllCharacters)
            {
                this.render.Render(character.ToString());
            }
        }
    }
}

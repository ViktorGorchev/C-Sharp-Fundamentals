using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SAGame.UI
{
    class Maps
    {
        Form gameForm;
        
        WorldMap worldMap;
        PlayerParty playerParty;
        PictureBox wordMapSpritePb;
        WorldMapMonster monster;
        //WorldMapMonster planetDesert;
        bool inCombat;

        public Maps(Form form)
        {
            gameForm = form;
            gameForm.Width = 2000;
            gameForm.Height = 2000;
            gameForm.BackgroundImage = new Bitmap("Space.jpg");

            worldMap = new WorldMap(gameForm);

            Bitmap bmp = new Bitmap("SpaceStation2.png");
            playerParty = new PlayerParty(new Point(100, 00), bmp, 1);

            wordMapSpritePb = new PictureBox();
            wordMapSpritePb.Width = gameForm.Width;
            wordMapSpritePb.Height = gameForm.Height;
            wordMapSpritePb.BackColor = Color.Transparent; ////////////
            wordMapSpritePb.Parent = gameForm;

            Bitmap bmpMonster = new Bitmap("Earth1.png");
            monster = new WorldMapMonster(new Point(100, 100), bmpMonster, 0);

            Draw();

        }

        public void HandeleKeyPress(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                playerParty.partySprite.Move(-1, 0);
            }

            if (e.KeyCode == Keys.Right)
            {
                playerParty.partySprite.Move(1, 0);
            }

            if (e.KeyCode == Keys.Up)
            {
                playerParty.partySprite.Move(0, -1);
            }

            if (e.KeyCode == Keys.Down)
            {
                playerParty.partySprite.Move(0, 1);
            }

            Draw();
        }

        void Draw()
        {
            Graphics device;
            Image img = new Bitmap(gameForm.Width, gameForm.Height);
            device = Graphics.FromImage(img);

            worldMap.DrawMap(device);
            playerParty.partySprite.Draw(device);

            monster.Draw(device);

            wordMapSpritePb.Image = img;
        }
    }

    class WorldMap
    {
        public Image mapImage;

        public WorldMap(Form form)
        {

        }

        public void DrawMap(Graphics device)
        {
            for (int x = 0; x < 27; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    Pen pen = new Pen(Color.Blue);     //change to Color.Transparent
                    device.DrawRectangle(pen, x * 50, y * 50, 50, 50);
                }

            }
        }
    }

    class WorldMapSprite
    {
        public Point location;
        public Image image;
        public int ID;

        public WorldMapSprite(Point location, Image image, int ID)
        {
            this.location = location;
            this.image = image;
            this.ID = ID;
        }

        public void Draw(Graphics device)
        {
            device.DrawImage(image, location);
        }

        public void Move(int x, int y)
        {
            location.X += x * 50;
            location.Y += y * 50;
        }
    }

    class WorldMapMonster : WorldMapSprite
    {
        public bool isStatic;
        public WorldMapMonster(Point location, Image image, int ID)
            : base(location, image, ID)
        {
            isStatic = true;
        }
        //Loot loot;
    }

    class PlayerParty
    {
        public WorldMapSprite partySprite;

        public PlayerParty(Point location, Image image, int ID)
        {
            partySprite = new WorldMapSprite(location, image, ID);
        }
    }
}




using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame.UI;

namespace SAGame.Models
{
    public abstract class Character
    {
        private Point location;
        private Image image;
        private int id;

        protected Character(Point location, Image image, int id)
        {
            this.Location = location;
            this.Image = image;
            this.Id = id;
        }

        public Point Location { get; set; }
        public Image Image { get; private set; }
        public int Id { get; private set; }

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
}

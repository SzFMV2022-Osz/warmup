namespace AutomatedCar.Models.NpcObjects
{
    using global::AutomatedCar.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PedastrianNpc : WorldObject, INpc
    {
        private int positionX;
        private int positionY;
        private int rotation;
        private int speed;
        public PedastrianNpc(int x, int y, string filename, int zindex = 1, bool collideable = false, WorldObjectType worldObjectType = WorldObjectType.Other) : base(x, y, filename, zindex, collideable, worldObjectType)
        {
            this.PositionX = x;
            this.PositionY = y;
            this.Rotation = rotation;
            this.speed = speed;
        }

        public int PositionX { get => positionX; set => this.positionX = value; }
        public int PositionY { get => positionY; set => this.positionY = value; }
        public int Rotation { get => rotation; set => this.rotation = value; }
        public int Speed { get => speed; set => this.speed = value; }

        public void Move()
        {
            NpcPedastrianMove();
        }

        private void NpcPedastrianMove()
        {
            // Implements the movement of the pedastrian.
        }

        public void Rotate()
        {
            // Sets the rotation of the pedastrian.
            // It has to be call in the NpcPedastrianMove method.
        }


    }
}

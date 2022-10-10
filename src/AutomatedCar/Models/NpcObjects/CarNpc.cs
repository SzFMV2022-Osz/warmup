namespace AutomatedCar.Models
{
    using global::AutomatedCar.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CarNpc : Car, INpc
    {
        private int positionX;
        private int positionY;
        private int rotation;
        private int speed;
        public CarNpc(int x, int y, string filename) : base(x, y, filename)
        {
            this.PositionX = x;
            this.PositionY = y;
            this.Rotation = rotation;
            this.speed = speed;
        }

        public int PositionX { get => positionX; set => this.positionX = value; }
        public int PositionY { get => positionY; set => this.positionY = value; }
        public int Rotation { get => rotation; set => this.rotation = value; }
        public int Speed { get => speed; set => this.speed= value; }

        public void Rotate()
        {
            // Sets the rotation of the car.
            // It has to be call in the NpcCarMove method.
        }
        public void Move()
        {
            NpcCarMove();
        }
        private void NpcCarMove()
        {
            // if ...
            Start();

            // else if ...
            Stop();

            // else
            MoveCar();
        }

        
        private void Start()
        {

        }
        private void Stop()
        {

        }
        

        private void MoveCar()
        {
            // This is the main implementation of the moving car.
        }
        private void ChangeSpeed()
        {
            // Implementation of the car changing speed.
        }
    }
}
        
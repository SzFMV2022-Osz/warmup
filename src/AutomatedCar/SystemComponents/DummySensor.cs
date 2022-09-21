using AutomatedCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedCar.SystemComponents
{
    internal class DummySensor : SystemComponent
    {
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
        }

        public override void Process()
        {
            WorldObject car = World.Instance.WorldObjects.Where(t => t is AutomatedCar.Models.AutomatedCar).FirstOrDefault();
            WorldObject circle = World.Instance.WorldObjects.Where(t => t is Circle).FirstOrDefault();

            int distanceX = Math.Abs(car.X - circle.X);
            int distanceY = Math.Abs(car.Y - circle.Y);

            this.virtualFunctionBus.DummyPacket.DistanceX = distanceX;
            this.virtualFunctionBus.DummyPacket.DistanceY = distanceY;
        }
    }
}

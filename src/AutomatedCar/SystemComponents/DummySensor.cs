namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        DummyPacket DummyPacket;
        AutomatedCar car;

        public DummySensor(VirtualFunctionBus virtualFunctionBus, AutomatedCar car) : base(virtualFunctionBus)
        {
            this.DummyPacket = new DummyPacket();
            this.car = car;
        }

        public override void Process()
        {
            Calculate(this.car);
        }

        private void Calculate(WorldObject currentCar)
        {
            this.DummyPacket.DistanceX = currentCar.X - getCircle().X;
            this.DummyPacket.DistanceY = currentCar.Y - getCircle().Y;
        }

        private Circle getCircle()
        {
            return (Circle)World.Instance.WorldObjects.FirstOrDefault(t => t is Circle);
        }
    }
}

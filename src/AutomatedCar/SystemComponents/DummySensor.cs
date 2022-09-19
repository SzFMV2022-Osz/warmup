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
        private DummyPacket dummyPacket;
        private AutomatedCar car;

        public DummySensor(VirtualFunctionBus virtualFunctionBus, AutomatedCar car) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.car = car;
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            this.CalculateDistanceFromTarget(this.GetFirstDummyCircle());
        }

        private Circle GetFirstDummyCircle()
        {
            return (Circle)World.Instance.WorldObjects.FirstOrDefault(t => t is Circle);
        }

        private void CalculateDistanceFromTarget(WorldObject target)
        {
            this.dummyPacket.DistanceX = target.X - this.car.X;
            this.dummyPacket.DistanceY = target.Y - this.car.Y;
        }
    }
}

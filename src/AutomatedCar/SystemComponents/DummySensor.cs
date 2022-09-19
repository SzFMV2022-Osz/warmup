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

        public DummySensor(VirtualFunctionBus virtualFunctionBus): base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            Circle testItem = (Circle)World.Instance.WorldObjects.FirstOrDefault(t => t is Circle);
            AutomatedCar car = World.Instance.ControlledCar;

            this.dummyPacket.DistanceX = Math.Abs(car.X - testItem.X);
            this.dummyPacket.DistanceY = Math.Abs(car.Y - testItem.Y);
        }
    }
}

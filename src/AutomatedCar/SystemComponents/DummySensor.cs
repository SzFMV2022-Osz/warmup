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
        VirtualFunctionBus bus;
        WorldObject car;

        public DummySensor(VirtualFunctionBus virtualFunctionBus, WorldObject car) : base(virtualFunctionBus)
        {
            bus = virtualFunctionBus;
            this.car = car;
        }

        public override void Process()
        {
            WorldObject worldObject = World.Instance.WorldObjects.First();
            DummyPacket newPacket = new DummyPacket()
            {
                DistanceX = Math.Abs(car.X - worldObject.X),
                DistanceY = Math.Abs(car.Y - worldObject.Y)
            };
            bus.DummyPacket = newPacket;
        }
    }
}

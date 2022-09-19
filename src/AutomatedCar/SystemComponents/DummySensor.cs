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
        DummyPacket dummyPacket;
        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            WorldObject worldObject = World.Instance.WorldObjects.First();
            AutomatedCar car = World.Instance.ControlledCar;
            dummyPacket.DistanceX = Math.Abs(car.X - worldObject.X);
            dummyPacket.DistanceY = Math.Abs(car.Y - worldObject.Y);
        }
    }
}

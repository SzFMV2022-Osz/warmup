namespace AutomatedCar.SystemComponents.Sensors
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
        private DummyPacket packet;

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.packet = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.packet;
        }

        public override void Process()
        {
            Circle circle = World.Instance.WorldObjects.Single(obj => obj is Circle) as Circle;
            AutomatedCar car = World.Instance.ControlledCar;

            this.packet.DistanceX = circle.X - car.X;
            this.packet.DistanceY = circle.Y - car.Y;
        }
    }
}

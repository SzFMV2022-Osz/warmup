namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        private DummyPacket DummyPacket { get; set; }

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.DummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.DummyPacket;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects.Where(o => o.GetType() == typeof(Circle)).FirstOrDefault();

            if (circle != null)
            {
                this.DummyPacket.DistanceX = World.Instance.ControlledCar.X - circle.X;
                this.DummyPacket.DistanceY = World.Instance.ControlledCar.Y - circle.Y;
            }

            Debug.WriteLine(virtualFunctionBus.InputPacket.PrevKey.ToString() + " - " + virtualFunctionBus.InputPacket.ActualKey.ToString());
        }
    }
}

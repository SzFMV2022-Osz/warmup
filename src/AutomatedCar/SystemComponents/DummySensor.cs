namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    /// <summary>
    /// Warmup task.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus vfb)
            : base(vfb)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circleElement = World.Instance.WorldObjects.Find(x => x is Circle);

            if (circleElement != null)
            {
                this.dummyPacket.DistanceX = World.Instance.WorldObjects.First(x => x is AutomatedCar).X - circleElement.X;
                this.dummyPacket.DistanceY = World.Instance.WorldObjects.First(x => x is AutomatedCar).Y - circleElement.Y;
            }
        }
    }
}

namespace AutomatedCar.Models
{
    using global::AutomatedCar.SystemComponents.Packets;
    using global::AutomatedCar.SystemComponents;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DummySensor :SystemComponents.SystemComponent
    {
        /*
         * 1. Process from VFB (override)
         * 2. Get Circle to World
         * 3. Calculated distance from Circle stay in DummySensor (private)
         * 4. Store distance to DummyPacket
        */

        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus vfb)
            : base(vfb)
        {
            dummyPacket = new DummyPacket();
            vfb.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            CalculateDistance();
        }

        private Circle GetCircle()
        {
            if (World.Instance.WorldObjects.FirstOrDefault() is Circle)
            {
                return World.Instance.WorldObjects.FirstOrDefault() as Circle;
            }
            return null;
        }

        private void CalculateDistance()
        {
            Circle circle = GetCircle();
            AutomatedCar car = World.Instance.ControlledCar;

            dummyPacket.DistanceX = (car.X - circle.X);
            dummyPacket.DistanceY = (car.Y - circle.Y);
        }
    }
}

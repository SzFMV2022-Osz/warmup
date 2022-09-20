namespace AutomatedCar.SystemComponents.Packets
{
    using System.Linq;
    using AutomatedCar.Models;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public DummyPacket DummyPacket { get => dummyPacket; set => dummyPacket = value; }

        public override void Process()
        {
            WorldObject dummyCircle = World.Instance.WorldObjects.Where(x => x is Circle).ToList().FirstOrDefault();

            if (dummyCircle != null)
            {
                var controlledCar = World.Instance.ControlledCar;
                this.dummyPacket.DistanceX = controlledCar.X - dummyCircle.X;
                this.dummyPacket.DistanceY = controlledCar.Y - dummyCircle.Y;
            }
        }
    }
}


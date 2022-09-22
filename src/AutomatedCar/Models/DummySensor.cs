namespace AutomatedCar.Models
{
    using global::AutomatedCar.SystemComponents;
    using global::AutomatedCar.SystemComponents.Packets;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override async void Process()
        {
            AutomatedCar automatedCar = World.Instance.ControlledCar;
            Circle circle = (Circle)World.Instance.WorldObjects.Where(x => (x is Circle))
                                                               .FirstOrDefault();

            dummyPacket.DistanceX = circle.X - automatedCar.X;
            dummyPacket.DistanceY = circle.Y - automatedCar.Y;
        }
    }
}

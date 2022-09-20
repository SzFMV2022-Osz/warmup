namespace AutomatedCar.Models
{
    using global::AutomatedCar.SystemComponents;
    using global::AutomatedCar.SystemComponents.Packets;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = dummyPacket;
        }

        public override void Process()
        {
            CalculateDistanceFromCircle();
        }

        private void CalculateDistanceFromCircle()
        {
            Circle circle = getCircle();
            AutomatedCar car = World.Instance.ControlledCar;
            dummyPacket.DistanceX = (circle.X - car.X);
            dummyPacket.DistanceY = (circle.Y - car.Y);
        }

        private Circle getCircle()
        {
            return (Circle)World.Instance.WorldObjects.FirstOrDefault();
        }
    }
}

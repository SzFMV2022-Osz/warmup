namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            int[] distances = this.CalculateDistances(this.GetAutomatedCar(), this.GetCircle());

            this.SaveDistancesToPacket(distances);
        }

        private void SaveDistancesToPacket(int[] distances)
        {
            this.dummyPacket.DistanceX = distances[0];
            this.dummyPacket.DistanceY = distances[1];
        }

        private Circle GetCircle()
        {
            return World.Instance.WorldObjects.Find(x => x is Circle) as Circle;
        }

        private AutomatedCar GetAutomatedCar()
        {
            return World.Instance.ControlledCar;
        }

        private int[] CalculateDistances(AutomatedCar automatedCar, Circle circle)
        {
            if (circle == null)
            {
                return null;
            }

            int distanceX = automatedCar.X - circle.X;
            int distanceY = automatedCar.Y - circle.Y;

            return new int[2] { distanceX, distanceY };
        }
    }
}

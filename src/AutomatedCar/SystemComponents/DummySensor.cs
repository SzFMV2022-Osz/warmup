namespace AutomatedCar.SystemComponents
{
    using System.Linq;
    using AutomatedCar.Models;
    using AutomatedCar.SystemComponents.Packets;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            var circle = World.Instance.WorldObjects.First();

            if (CheckObjectTypeIsCircle(circle))
            {
                var car = World.Instance.WorldObjects.First(c => c is AutomatedCar);

                this.dummyPacket.DistanceX = car.X - circle.X;
                this.dummyPacket.DistanceY = car.Y - circle.Y;
            }
        }

        private bool CheckObjectTypeIsCircle(object obj)
        {
            return obj != null ? obj is Circle : false;
        }
    }
}
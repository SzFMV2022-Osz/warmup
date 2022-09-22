namespace AutomatedCar.SystemComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
            var car = World.Instance.ControlledCar;
            var circle = this.GetCircle();

            var result = this.CalculateDistance(car, circle);

            this.StoreDistance(result.Item1, result.Item2);
        }

        private Circle GetCircle()
        {
            return (Circle)World.Instance.WorldObjects[0];
        }

        private Tuple<int, int> CalculateDistance(WorldObject obj1, WorldObject obj2)
        {
            double dX = obj1.X - obj2.X;
            double dY = obj1.Y - obj2.Y;

            return Tuple.Create((int)dX, (int)dY);
        }

        private void StoreDistance(int dx, int dy)
        {
            this.dummyPacket.DistanceX = dx;
            this.dummyPacket.DistanceY = dy;
        }
    }
}

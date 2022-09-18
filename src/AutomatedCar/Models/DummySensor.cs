namespace AutomatedCar.Models
{
    using global::AutomatedCar.SystemComponents;
    using global::AutomatedCar.SystemComponents.Packets;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
        }

        public override void Process()
        {
            Circle circle = this.GetCircle();
            double[] distances = CalculateDistanceFromCircle(circle);
            StoreDistance((int)distances[0], (int)distances[1]);
        }

        private Circle GetCircle()
        {
            return (Circle)World.Instance.WorldObjects.FirstOrDefault();
        }

        private double[] CalculateDistanceFromCircle(Circle circle)
        {
            AutomatedCar car = World.Instance.ControlledCar;
            double x = car.X - circle.X;
            double y = car.Y - circle.Y;
            double[] distances = new double[2];
            distances[0] = x;
            distances[1] = y;
            return distances;
        }

        public void StoreDistance(int x, int y)
        {
            this.dummyPacket.DistanceX = x;
            this.dummyPacket.DistanceY = y;
        }
    }
}

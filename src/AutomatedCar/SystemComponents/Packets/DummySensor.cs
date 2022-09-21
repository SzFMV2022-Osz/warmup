namespace AutomatedCar.SystemComponents.Packets
{
    using AutomatedCar.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        public DummyPacket DummyPacket
        {
            get { return dummyPacket; }
            set { dummyPacket = value; }
        }

        public DummySensor(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        public override void Process()
        {
            Circle circle = (Circle)World.Instance.WorldObjects.Where(x => x is Circle).ToList().FirstOrDefault();
            AutomatedCar automatedCar = (AutomatedCar)World.Instance.WorldObjects.Where(x => x is AutomatedCar).ToList().FirstOrDefault();

            this.dummyPacket.DistanceX = automatedCar.X - circle.X;
            this.dummyPacket.DistanceY = automatedCar.Y - circle.Y;


        }
    }
}

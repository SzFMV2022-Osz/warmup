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
    /// DummySensor implementation.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private DummyPacket dummyPacket;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">virtualFunctionBus parameter.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            virtualFunctionBus.DummyPacket = this.dummyPacket;
        }

        /// <summary>
        /// Process method.
        /// </summary>
        public override void Process()
        {
            var circle = World.Instance.WorldObjects.First();

            if (circle is Circle && circle != null)
            {
                var automatedCar = World.Instance.WorldObjects.First(x => x is AutomatedCar);
                this.dummyPacket.DistanceX = automatedCar.X - circle.X;
                this.dummyPacket.DistanceY = automatedCar.Y - circle.Y;
            }
        }
    }
}

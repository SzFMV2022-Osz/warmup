// <copyright file="DummySensor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AutomatedCar.SystemComponents.Packets.Dummy
{
    using System;
    using System.Linq;
    using AutomatedCar.Models;

    /// <summary>
    /// Sensor which calculates the distance between own and the circle's coordinates.
    /// </summary>
    public class DummySensor : SystemComponent
    {
        private readonly DummyPacket dummyPacket;

        private readonly Car car;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummySensor"/> class.
        /// </summary>
        /// <param name="virtualFunctionBus">Virtual function bus for events.</param>
        /// <param name="car">Instance of the car what contains the sensor.</param>
        public DummySensor(VirtualFunctionBus virtualFunctionBus, Car car)
            : base(virtualFunctionBus)
        {
            this.dummyPacket = new DummyPacket();
            this.virtualFunctionBus.DummyPacket = this.dummyPacket;
            this.car = car;
        }

        /// <inheritdoc/>
        public override void Process()
        {
            Circle circle = World.Instance.WorldObjects.Where(x => x is Circle).FirstOrDefault() as Circle;
            this.dummyPacket.DistanceX = Math.Abs(this.car.X - circle.X);
            this.dummyPacket.DistanceY = Math.Abs(this.car.Y - circle.Y);
        }
    }
}

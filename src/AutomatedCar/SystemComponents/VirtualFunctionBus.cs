namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.SystemComponents.Packets;
    using System.Collections.Generic;

    public class VirtualFunctionBus : GameBase
    {
        private List<SystemComponent> components = new List<SystemComponent>();

        // Right now we don't need the abstraction of an interface, we don't need to make the properties read-only.
        public DummyPacket DummyPacket { get; set; }

        public void RegisterComponent(SystemComponent component)
        {
            this.components.Add(component);
            this.DummyPacket = new DummyPacket();
        }

        protected override void Tick()
        {
            foreach (SystemComponent component in this.components)
            {
                component.Process();
            }
        }
    }
}
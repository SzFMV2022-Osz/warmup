namespace AutomatedCar.Models
{
    using SystemComponents.Packets;
    using Avalonia.Media;
    using SystemComponents;

    public class AutomatedCar : Car
    {
        private readonly DummySensor dummySensor;
        private VirtualFunctionBus virtualFunctionBus;

        public AutomatedCar(int x, int y, string filename)
            : base(x, y, filename)
        {
            this.virtualFunctionBus = new VirtualFunctionBus();
            this.dummySensor = new DummySensor(virtualFunctionBus);
            this.ZIndex = 10;
        }

        public VirtualFunctionBus VirtualFunctionBus { get => this.virtualFunctionBus; }

        public int Revolution { get; set; }

        public int Velocity { get; set; }

        public PolylineGeometry Geometry { get; set; }

        /// <summary>Starts the automated cor by starting the ticker in the Virtual Function Bus, that cyclically calls the system components.</summary>
        public void Start()
        {
            this.virtualFunctionBus.Start();
        }

        /// <summary>Stops the automated cor by stopping the ticker in the Virtual Function Bus, that cyclically calls the system components.</summary>
        public void Stop()
        {
            this.virtualFunctionBus.Stop();
        }
    }
}
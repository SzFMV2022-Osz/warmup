namespace AutomatedCar.SystemComponents
{
    using AutomatedCar.SystemComponents.Packets;
    using Avalonia.Input;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InputManager : SystemComponent
    {
        private InputPacket InputPacket { get; set; }

        public InputManager(VirtualFunctionBus virtualFunctionBus) : base(virtualFunctionBus)
        {
            this.InputPacket = new InputPacket();
            virtualFunctionBus.InputPacket = this.InputPacket;
        }


        public override void Process()
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                var key = Key.Up;
                InputPacket.PrevKey = InputPacket.ActualKey;
                InputPacket.ActualKey = key;
            } 
            else
            {
                InputPacket.Reset();
            }
           
        }
    }


    public class InputPacket
    {
        public Key ActualKey { get; set; }
        public Key PrevKey { get; set; }

        public InputPacket()
        {
            ActualKey = Key.None;
            PrevKey = Key.None;
        }

        public void Reset()
        {
            ActualKey = Key.None;
            PrevKey = Key.None;
        }
    }
}

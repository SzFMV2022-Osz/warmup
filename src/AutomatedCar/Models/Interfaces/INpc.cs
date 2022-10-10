namespace AutomatedCar.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface INpc
    {
        // implement Route class first
        int PositionX { get; set; }
        int PositionY { get; set; }
        int Rotation { get; set; }
        int Speed { get; set; }

        abstract void Move();
        abstract void Rotate();
    }
}

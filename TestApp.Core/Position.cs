using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Core
{
    [Flags]
    public enum Position
    {
        PointGuard = 0,
        ShootingGuard = 1,
        SmallForward = 2,
        Forward = 4,
        Center = 8
    }
}

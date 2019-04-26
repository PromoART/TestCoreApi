using System;

namespace TestApp.Core.Domain
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

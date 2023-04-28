using System.Collections.Generic;

public static class MovementHelper
{
    private static Dictionary<WheelMovementEnum, string> LeftMovementDirections = new Dictionary<WheelMovementEnum, string>
    {
        {
            WheelMovementEnum.Forward, "C"
        },
        {
            WheelMovementEnum.Backward, "F"
        },
        {
            WheelMovementEnum.Stop, "D"
        }
    };

    private static Dictionary<WheelMovementEnum, string> RightMovementDirections = new Dictionary<WheelMovementEnum, string>
    {
        {
            WheelMovementEnum.Forward, "A"
        },
        {
            WheelMovementEnum.Backward, "B"
        },
        {
            WheelMovementEnum.Stop, "E"
        },
    };

    public static string GetLeftDirectionString(WheelMovementEnum movement)
    {
        return LeftMovementDirections[movement];
    }
    
    public static string GetRightDirectionString(WheelMovementEnum movement)
    {
        return RightMovementDirections[movement];
    }
}

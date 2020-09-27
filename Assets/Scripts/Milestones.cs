using System.Collections;
using System.Collections.Generic;

public enum MilestoneType
{
    SPEED_UP,
    SPIKES,
    HEIGHT_INCREASE,
    SMALLER_PLATFORM,
    ENEMIES_FALL_PLATFORM
}

public class Milestones
{
    public Dictionary<MilestoneType, float>[] MilestoneList = new Dictionary<MilestoneType, float>[]
    {
        new Dictionary<MilestoneType, float>()
        {
            { MilestoneType.SPEED_UP, 1.05f },
            { MilestoneType.ENEMIES_FALL_PLATFORM, 0 }
        },
        new Dictionary<MilestoneType, float>()
        {
            { MilestoneType.SPEED_UP, 1.15f },
            { MilestoneType.HEIGHT_INCREASE, 1.25f }
        },
        new Dictionary<MilestoneType, float>()
        {
            { MilestoneType.SPIKES, 1.20f }
        },
        new Dictionary<MilestoneType, float>()
        {
            { MilestoneType.SPEED_UP, 1.05f },
            { MilestoneType.SMALLER_PLATFORM, 0 }
        }

    };


}



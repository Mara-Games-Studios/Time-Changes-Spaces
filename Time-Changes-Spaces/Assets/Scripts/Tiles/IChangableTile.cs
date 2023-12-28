using Player;
using TimeSpeed;

namespace Tiles
{
    public enum PassableState
    {
        Passable,
        NotPassable,
        Teleportable,
        NotTeleportable
    }

    internal interface IChangeableTile
    {
        public void SetState(TimeState state);
        public PassableState GetPassableState(Brain playerBrain);
        public void ApplyStanding(Brain playerBrain);
    }
}

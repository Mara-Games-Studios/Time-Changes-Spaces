using Player;
using TimeSpeed;

namespace Tiles
{
    public enum PassableState
    {
        Passable,
        NotPassable
    }

    internal interface IChangeableTile
    {
        public void SetState(TimeState state);
        public PassableState GetPassableState(Brain playerBrain);
        public void ApplyStanding(Brain playerBrain);
    }
}

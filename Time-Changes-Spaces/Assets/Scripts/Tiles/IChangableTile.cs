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
        public PassableState PassableState { get; }
        public PassableState GetFutureState(TimeState state);
        public void SetState(TimeState state);
    }
}

using Leopotam.Ecs;

namespace Components.Move
{
    internal interface IBlockMoveCondition
    {
        public bool CheckBlockMove(EcsEntity entity);
    }
}
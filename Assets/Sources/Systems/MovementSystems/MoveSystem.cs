using Entitas;
using UnityEngine;

namespace Systems.MovementSystems
{
    public class MoveSystem : IExecuteSystem, ICleanupSystem
    {
        private const float Speed = 4f;
        private readonly IGroup<GameEntity> _moveCompletes;
        private readonly IGroup<GameEntity> _moves;

        public MoveSystem(Contexts contexts)
        {
            _moves = contexts.game.GetGroup(GameMatcher.Move);
            _moveCompletes = contexts.game.GetGroup(GameMatcher.MoveComplete);
        }

        public void Cleanup()
        {
            foreach (var entity in _moveCompletes.GetEntities())
            {
                entity.isMoveComplete = false;
            }
        }

        public void Execute()
        {
            foreach (var entity in _moves.GetEntities())
            {
                var direction = entity.move.Target - entity.position.Value;
                var newPosition = entity.position.Value + direction.normalized * Speed * Time.deltaTime;
                entity.ReplacePosition(newPosition);

                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                entity.ReplaceDirection(angle);

                var dist = direction.magnitude;
                if (dist > 0.5f)
                {
                    continue;
                }

                entity.RemoveMove();
                entity.isMoveComplete = true;
            }
        }
    }
}
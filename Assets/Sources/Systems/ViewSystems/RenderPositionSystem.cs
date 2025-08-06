using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems.ViewSystems
{
    public class RenderPositionSystem : ReactiveSystem<GameEntity>
    {
        public RenderPositionSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GridIndex);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGridIndex && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.view.GameObject.transform.position = (Vector2)entity.gridIndex.Position;
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems.InputSystems
{
    public class CreateMoverSystem : ReactiveSystem<InputEntity>
    {
        private readonly GameContext _gameContext;

        public CreateMoverSystem(Contexts contexts) : base(contexts.input)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasMouseDown;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
            {
                var mover = _gameContext.CreateEntity();
                mover.isMover = true;
                mover.AddPosition(entity.mouseDown.Position);
                mover.AddDirection(Random.Range(0, 360));
                mover.AddSprite("Bee");
            }
        }
    }
}
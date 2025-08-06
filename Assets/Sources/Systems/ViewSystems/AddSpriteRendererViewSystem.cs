using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.Systems
{
    public class AddSpriteRendererViewSystem: ReactiveSystem<GameEntity>
    {
        private readonly Transform _viewContainer = new GameObject("Game Views").transform;
        private readonly GameContext _context;

        public AddSpriteRendererViewSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gameObject = new GameObject("Game View");
                gameObject.transform.SetParent(_viewContainer, false);
                entity.AddView(gameObject);
                gameObject.Link(entity);
            }
        }
    }
}
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Systems.ViewSystems
{
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        public RenderSpriteSystem(Contexts contexts) : base(contexts.game) { }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gameObject = entity.view.GameObject;
                var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                if (!spriteRenderer)
                {
                    spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
                }

                spriteRenderer.sprite = Resources.Load<Sprite>(entity.sprite.Name);
                entity.view.GameObject.transform.localScale = 0.75f * Vector3.one;
            }
        }
    }
}
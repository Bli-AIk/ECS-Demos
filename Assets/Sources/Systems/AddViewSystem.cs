using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// 识别拥有 SpriteComponent 但尚未分配关联 GameObject 的 Entities
    /// </summary>
    public class AddViewSystem :  ReactiveSystem<GameEntity>
    {
        private readonly Transform _viewContainer = new GameObject("Game Views").transform;
        private readonly GameContext _context;

        public AddViewSystem(Contexts contexts) : base(contexts.game)
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
                var obj = new GameObject("Game View");
                obj.transform.SetParent(_viewContainer, false);
                entity.AddView(obj);
                obj.Link(entity);
            }
        }
    }
}
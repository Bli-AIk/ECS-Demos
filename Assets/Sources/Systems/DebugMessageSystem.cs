using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class DebugMessageSystem : ReactiveSystem<GensoukyoEntity>
    {
        public DebugMessageSystem(Contexts contexts) : base(contexts.gensoukyo) { }
        
        protected override ICollector<GensoukyoEntity> GetTrigger(IContext<GensoukyoEntity> context)
        {
            //只关注带有 DebugMessageComponent 的实体
            return context.CreateCollector(GensoukyoMatcher.DebugMessage);
        }
        protected override bool Filter(GensoukyoEntity entity)
        {
            return entity.hasDebugMessage;
        }
        protected override void Execute(List<GensoukyoEntity> entities)
        {
            foreach (var e in entities)
            {
                Debug.Log(e.debugMessage.Message);
            }
        }
    }
}
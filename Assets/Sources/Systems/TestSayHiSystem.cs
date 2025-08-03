using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Systems
{
    public class TestSayHiSystem : ReactiveSystem<GensoukyoEntity>
    {
        public TestSayHiSystem(Contexts contexts) : base(contexts.gensoukyo) { }

        protected override ICollector<GensoukyoEntity> GetTrigger(IContext<GensoukyoEntity> context)
        {
            return context.CreateCollector(GensoukyoMatcher.TestSayHi);

        }
        protected override bool Filter(GensoukyoEntity entity)
        {
            return entity.hasTestSayHi;
        }
        protected override void Execute(List<GensoukyoEntity> entities)
        {
            foreach (var e in entities)
            {
                Debug.Log(e.testSayHi.TestText);
            }
        }
    }
}
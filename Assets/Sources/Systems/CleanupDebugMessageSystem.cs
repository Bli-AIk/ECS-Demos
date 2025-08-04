using Entitas;

namespace Systems
{
    public class CleanupDebugMessageSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _debugMessages;

        public CleanupDebugMessageSystem(Contexts contexts)
        {
            var context = contexts.game;
            _debugMessages = context.GetGroup(GameMatcher.DebugMessage);
        }

        public void Cleanup()
        {
            // group.GetEntities() always gives us an up to date list
            foreach (var e in _debugMessages.GetEntities())
            {
                e.Destroy();
            }
        }
    }
}
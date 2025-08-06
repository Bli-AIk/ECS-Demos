using Entitas;

namespace Sources.Systems
{
    public class GameInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _context;

        public GameInitializeSystem(Contexts contexts)
        {
            _context = contexts.game;
        }
        
        public void Initialize()
        {
            //var entity = _context.CreateEntity();
            //entity.isSnakeHead = true;
        }
    }
}
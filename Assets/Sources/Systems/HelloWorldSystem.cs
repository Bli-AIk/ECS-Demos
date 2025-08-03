using Entitas;

namespace Systems
{
    public class HelloWorldSystem : IInitializeSystem
    {
        private readonly GameContext _context;

        public HelloWorldSystem(Contexts contexts)
        {
            _context = contexts.game;
        }


        public void Initialize()
        {
            _context.CreateEntity().AddDebugMessage("hello world");
        }
    }
}
using Entitas;

namespace Systems
{
    public class HelloWorldSystem : IInitializeSystem
    {
        private readonly GensoukyoContext _context;

        public HelloWorldSystem(Contexts contexts)
        {
            _context = contexts.gensoukyo;
        }


        public void Initialize()
        {
            _context.CreateEntity().AddDebugMessage("hello world");
        }
    }
}
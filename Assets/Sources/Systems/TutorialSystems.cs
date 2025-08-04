using Entitas;

namespace Systems
{
    public class TutorialSystems : Feature
    {
        public TutorialSystems(Contexts contexts) : base ("Tutorial Systems")
        {
            Add(new HelloWorldSystem(contexts));
            Add(new LogMouseClickSystem(contexts));
            Add(new DebugMessageSystem(contexts));
            Add(new CleanupDebugMessageSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
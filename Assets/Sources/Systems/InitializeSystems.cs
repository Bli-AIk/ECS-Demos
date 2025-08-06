using Entitas;

namespace Sources.Systems
{
    public class InitializeSystems : Feature
    {
        public InitializeSystems(Contexts contexts) : base("Initialize Systems")
        {
            Add(new GameInitializeSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
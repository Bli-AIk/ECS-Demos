using Entitas;

namespace Sources.Systems.InputSystems
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts) : base("Input Systems")
        {
            Add(new SnakeInputSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
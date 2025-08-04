using Entitas;

namespace Systems.InputSystems
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts) : base("Input Systems")
        {
            Add(new EmitInputSystem(contexts));
            Add(new CreateMoverSystem(contexts));
            Add(new CommandMoveSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
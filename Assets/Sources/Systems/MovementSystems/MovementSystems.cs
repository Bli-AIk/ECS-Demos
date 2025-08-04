using Entitas;

namespace Systems.MovementSystems
{
    public class MovementSystems : Feature
    {
        public MovementSystems(Contexts contexts) : base("Movement Systems")
        {
            Add(new MoveSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
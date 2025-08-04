using Entitas;

namespace Systems.ViewSystems
{
    public class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts) : base("View Systems")
        {
            Add(new AddViewSystem(contexts));
            Add(new RenderSpriteSystem(contexts));
            Add(new RenderPositionSystem(contexts));
            Add(new RenderDirectionSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
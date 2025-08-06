using Entitas;

namespace Sources.Systems
{
    public class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts) : base("View Systems")
        {
            Add(new AddSpriteRendererViewSystem(contexts));
            Add(new RenderSpriteSystem(contexts));
            Add(new RenderPositionSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
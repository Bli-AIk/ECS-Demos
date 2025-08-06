using Entitas;
using Sources.Systems.InitializeSystems;
using Sources.Systems.InputSystems;
using Sources.Systems.LoopSystems;
using Sources.Systems.ViewSystems;

namespace Sources
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

    public class LoopSystems : Feature
    {
        public LoopSystems(Contexts contexts) : base("Loop Systems")
        {
            Add(new GameLoopSystem(contexts));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}
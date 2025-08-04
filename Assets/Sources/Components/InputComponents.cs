using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    public class InputComponents
    {
        [Input]
        [Unique]
        public class LeftMouseComponent : IComponent { }

        [Input]
        [Unique]
        public class RightMouseComponent : IComponent { }

        [Input]
        public class MouseDownComponent : IComponent
        {
            public Vector2 Position;
        }

        [Input]
        public class MousePositionComponent : IComponent
        {
            public Vector2 Position;
        }

        [Input]
        public class MouseUpComponent : IComponent
        {
            public Vector2 Position;
        }
    }
}
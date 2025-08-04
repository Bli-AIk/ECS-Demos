using Entitas;
using UnityEngine;

namespace Components
{
    public class GameComponents
    {
        [Game]
        public class PositionComponent : IComponent
        {
            public Vector2 Value;
        }

        [Game]
        public class DirectionComponent : IComponent
        {
            public float Value;
        }

        [Game]
        public class ViewComponent : IComponent
        {
            public GameObject GameObject;
        }

        [Game]
        public class SpriteComponent : IComponent
        {
            public string Name;
        }

        [Game]
        public class MoverComponent : IComponent { }

        [Game]
        public class MoveComponent : IComponent
        {
            public Vector2 Target;
        }

        [Game]
        public class MoveCompleteComponent : IComponent { }
    }
}
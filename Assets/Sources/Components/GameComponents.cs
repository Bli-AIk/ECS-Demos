using Entitas;
using UnityEngine;

namespace Components
{
    public class GameComponents
    {
        /// <summary>
        /// 位置的 Component
        /// </summary>
        [Game]
        public class PositionComponent : IComponent
        {
            public Vector2 Value;
        }

        /// <summary>
        /// 旋转角度的 Component
        /// </summary>
        [Game]
        public class DirectionComponent : IComponent
        {
            public float Value;
        }

        /// <summary>
        /// 视图物体的 Component
        /// </summary>
        [Game]
        public class ViewComponent : IComponent
        {
            public GameObject GameObject;
        }

        /// <summary>
        /// 视图使用的Sprite的 Component
        /// </summary>
        [Game]
        public class SpriteComponent : IComponent
        {
            public string Name;
        }
        /// <summary>
        /// Mover即移动属性
        /// </summary>
        [Game]
        public class MoverComponent : IComponent { }

        /// <summary>
        /// 移动的目的地
        /// </summary>
        [Game]
        public class MoveComponent : IComponent
        {
            public Vector2 Target;
        }
        /// <summary>
        /// 移动完成
        /// </summary>
        [Game]
        public class MoveCompleteComponent : IComponent { }
    }
}
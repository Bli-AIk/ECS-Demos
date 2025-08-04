using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
    public class InputComponents
    {
        /// <summary>
        /// 鼠标左键属性（唯一
        /// </summary>
        [Input]
        [Unique]
        public class LeftMouseComponent : IComponent { }
        /// <summary>
        /// 右键
        /// </summary>
        [Input]
        [Unique]
        public class RightMouseComponent : IComponent { }

        /// <summary>
        /// 按下
        /// </summary>
        [Input]
        public class MouseDownComponent : IComponent
        {
            public Vector2 Position;
        }

        /// <summary>
        /// 移动
        /// </summary>
        [Input]
        public class MousePositionComponent : IComponent
        {
            public Vector2 Position;
        }

        /// <summary>
        /// 抬起
        /// </summary>
        [Input]
        public class MouseUpComponent : IComponent
        {
            public Vector2 Position;
        }
    }
}
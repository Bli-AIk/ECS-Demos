using Entitas;
using UnityEngine;

namespace Sources.Components
{
    [Game]
    public class GridIndexComponent : IComponent
    {
        public int X;
        public int Y;
    }

    [Game]
    public class DirectionComponent : IComponent
    {
        public Direction Value;
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
    public class SnakeHeadComponent : IComponent { }

    [Game]
    public class SnakeBodyComponent : IComponent { }
}
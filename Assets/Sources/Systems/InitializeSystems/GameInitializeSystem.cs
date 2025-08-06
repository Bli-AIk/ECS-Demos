using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class GameInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _context;

        public GameInitializeSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Initialize()
        {
            InitializeTileObject(TileObjectType.SnakeHead, new Vector2Int(-1, 0), Direction.Left, "Square");
            InitializeTileObject(TileObjectType.SnakeBody, new Vector2Int(0, 0), Direction.Left, "Square");
            InitializeTileObject(TileObjectType.SnakeBody, new Vector2Int(1, 0), Direction.Left, "Square");
        }

        private void InitializeTileObject(TileObjectType tileObjectType,
            Vector2Int newPosition,
            Direction direction,
            string sprite)
        {
            var entity = _context.CreateEntity();
            entity.AddTileObject(tileObjectType);
            entity.AddGridIndex(newPosition);
            entity.AddDirection(direction);
            entity.AddSprite(sprite);
        }
    }
}
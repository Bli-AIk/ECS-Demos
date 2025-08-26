using Entitas;
using UnityEngine;

namespace Sources.Systems.InitializeSystems
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
            InitializeSnake(new Vector2Int(-1, 0), 3);
            InitializeFood();
        }

        private void InitializeSnake(Vector2Int startPoint, int length)
        {
            var snakeHead = InitializeTileObject(TileObjectType.SnakeHead,
                startPoint,
                "Square");
            snakeHead.AddDirection(Direction.Left);
            
            for (var i = 1; i < length; i++)
            {
                InitializeTileObject(TileObjectType.SnakeBody,
                    startPoint + new Vector2Int(i, 0),
                    "Square");
            }
        }

        private GameEntity InitializeTileObject(TileObjectType tileObjectType,
            Vector2Int position,
            string sprite)
        {
            var entity = _context.CreateEntity();
            entity.AddTileObject(tileObjectType);
            entity.AddGridIndex(position);
            entity.AddSprite(sprite);
            return entity;
        }

        private void InitializeFood()
        {
            InitializeTileObject(TileObjectType.Food,
                new Vector2Int(Random.Range(-5, 5), Random.Range(-5, 5)),
                "Circle");
        }
    }
}
using System;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Sources.Systems.LoopSystems
{
    public class GameLoopSystem : IExecuteSystem
    {
        private const float MaxTime = 0.5f;
        private readonly GameContext _context;
        private Vector2Int _lastPosition;
        private float _timer;

        public GameLoopSystem(Contexts contexts)
        {
            _context = contexts.game;
            _timer = MaxTime;
        }

        public void Execute()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _timer = MaxTime;
                GameLoop();
            }
        }

        private void GameLoop()
        {
            var tileObjects = _context
                .GetGroup(GameMatcher.AllOf(GameMatcher.TileObject))
                .GetEntities()
                .Where(entity =>entity.hasTileObject &&  entity.tileObject.Type is TileObjectType.SnakeHead or TileObjectType.SnakeBody);

            
            foreach (var tileObject in tileObjects)
            {
                switch (tileObject.tileObject.Type)
                {
                    case TileObjectType.SnakeHead:
                    {
                        MoveSnakeHead(tileObject);
                        HandleFoodConsumption(tileObject);
                        break;
                    }
                    case TileObjectType.SnakeBody:
                    {
                        MoveSnakeBody(tileObject);
                        break;
                    }
                    case TileObjectType.None:
                    case TileObjectType.Food:
                    case TileObjectType.Obstacle:
                    default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private void MoveSnakeHead(GameEntity snakeHead)
        {
            if (!snakeHead.hasDirection)
            {
                return;
            }

            var snakeHeadPosition = snakeHead.gridIndex.Position;
            var movePosition = snakeHead.direction.Value switch
            {
                Direction.Left => Vector2Int.left,
                Direction.Up => Vector2Int.up,
                Direction.Right => Vector2Int.right,
                Direction.Down => Vector2Int.down,
                _ => throw new ArgumentOutOfRangeException()
            };
            snakeHead.ReplaceGridIndex(snakeHeadPosition + movePosition);
            _lastPosition = snakeHeadPosition;
        }

        private void HandleFoodConsumption(GameEntity snakeHead)
        {
            var foods = _context
                .GetGroup(GameMatcher.AllOf(GameMatcher.TileObject))
                .GetEntities()
                .Where(entity => entity.hasTileObject && entity.tileObject.Type == TileObjectType.Food);

            foreach (var food in foods)
            {
                if (food.gridIndex.Position != snakeHead.gridIndex.Position)
                {
                    continue;
                }

                food.Destroy();

                var newBody = _context.CreateEntity();
                newBody.AddTileObject(TileObjectType.SnakeBody);
                newBody.AddGridIndex(_lastPosition);
            }
        }

        private void MoveSnakeBody(GameEntity snakeBody)
        {
            var newLastPosition = snakeBody.gridIndex.Position;
            snakeBody.ReplaceGridIndex(_lastPosition);
            _lastPosition = newLastPosition;
        }
    }
}
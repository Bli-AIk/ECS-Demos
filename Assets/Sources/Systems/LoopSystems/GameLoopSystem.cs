using System;
using Entitas;
using UnityEngine;

namespace Sources.Systems.LoopSystems
{
    public class GameLoopSystem : IExecuteSystem
    {
        private const float MaxTime = 1;
        private float _timer;
        private readonly GameContext _context;

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
                .GetGroup(GameMatcher.AllOf(GameMatcher.TileObject, GameMatcher.Direction))
                .GetEntities();

            foreach (var tileObject in tileObjects)
            {
                switch (tileObject.tileObject.Type)
                {
                    case TileObjectType.None:
                        break;
                    case TileObjectType.SnakeHead:
                        MoveSnakeHead(tileObject);
                        break;
                    case TileObjectType.SnakeBody:
                        break;
                    case TileObjectType.Food:
                        break;
                    case TileObjectType.Obstacle:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            
        }

        private static void MoveSnakeHead(GameEntity snakeHead)
        {
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
        }
    }
}
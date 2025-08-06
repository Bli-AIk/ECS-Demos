using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Sources.Systems.InputSystems
{
    public class SnakeInputSystem : IExecuteSystem
    {
        private static readonly Dictionary<KeyCode, Direction> KeyDirectionMap;
        private readonly GameContext _context;

        public SnakeInputSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        static SnakeInputSystem()
        {
            KeyDirectionMap = new Dictionary<KeyCode, Direction>
            {
                { KeyCode.UpArrow, Direction.Up },
                { KeyCode.W, Direction.Up },
                { KeyCode.DownArrow, Direction.Down },
                { KeyCode.S, Direction.Down },
                { KeyCode.LeftArrow, Direction.Left },
                { KeyCode.A, Direction.Left },
                { KeyCode.RightArrow, Direction.Right },
                { KeyCode.D, Direction.Right }
            };
        }

        public void Execute()
        {
            var tileObjectEntities = _context
                .GetGroup(GameMatcher.AllOf(GameMatcher.TileObject, GameMatcher.Direction))
                .GetEntities();

            MoveSnake(tileObjectEntities);
        }

        private static void MoveSnake(GameEntity[] tileObjectEntities)
        {
            var snakeHeadEntities = tileObjectEntities
                    .Where(entity => entity.tileObject.Type == TileObjectType.SnakeHead)
                    .ToArray();

            foreach (var pair in KeyDirectionMap.Where(pair => Input.GetKeyDown(pair.Key)))
            {
                foreach (var snakeHeadEntity in snakeHeadEntities)
                {
                    snakeHeadEntity.ReplaceDirection(pair.Value);
                }
                break;
            }
        }
    }
}
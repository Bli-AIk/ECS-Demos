using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class SnakeInputSystem : IExecuteSystem
    {
        private readonly GameContext _context;

        public SnakeInputSystem(Contexts contexts)
        {
            _context = contexts.game;
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
            var snakeHeadEntity = tileObjectEntities?.FirstOrDefault(entity => entity.tileObject.Type == TileObjectType.SnakeHead);
            if (snakeHeadEntity == null)
            {
                return;
            }

            var keyDirectionMap = new Dictionary<KeyCode, Direction>
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

            foreach (var pair in keyDirectionMap)
            {
                if (!Input.GetKeyDown(pair.Key))
                {
                    return;
                }

                snakeHeadEntity.ReplaceDirection(pair.Value);
                break;
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Sources.Systems
{
    public class InputSystem : IExecuteSystem
    {
        private readonly GameContext _context;

        public InputSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Execute()
        {
            var snakeHead = _context
                .GetGroup(GameMatcher.AllOf(GameMatcher.SnakeHead, GameMatcher.Direction))
                .GetSingleEntity();

            if (snakeHead == null)
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

                snakeHead.ReplaceDirection(pair.Value);
                break;
            }
        }
    }
}
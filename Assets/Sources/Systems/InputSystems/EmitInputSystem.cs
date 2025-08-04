using Entitas;
using UnityEngine;

namespace Systems.InputSystems
{
    public class EmitInputSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly InputContext _context;
        private InputEntity _leftMouseEntity;
        private InputEntity _rightMouseEntity;

        public EmitInputSystem(Contexts contexts)
        {
            _context = contexts.input;
        }

        public void Execute()
        {
            if (!Camera.main)
            {
                return;
            }

            // 鼠标位置
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            MouseLeftInput(mousePosition);

            MouseRightInput(mousePosition);
        }

        public void Initialize()
        {
            // 初始化保存鼠标按钮数据的唯一实体
            _context.isLeftMouse = true;
            _leftMouseEntity = _context.leftMouseEntity;

            _context.isRightMouse = true;
            _rightMouseEntity = _context.rightMouseEntity;
        }

        private void MouseLeftInput(Vector2 mousePosition)
        {
            MouseInput(_leftMouseEntity, 0, mousePosition);
        }

        private void MouseRightInput(Vector2 mousePosition)
        {
            MouseInput(_rightMouseEntity, 1, mousePosition);
        }

        private static void MouseInput(InputEntity entity, int button, Vector2 mousePosition)
        {
            if (Input.GetMouseButtonDown(button))
            {
                entity.ReplaceMouseDown(mousePosition);
            }

            if (Input.GetMouseButton(button))
            {
                entity.ReplaceMousePosition(mousePosition);
            }

            if (Input.GetMouseButtonUp(button))
            {
                entity.ReplaceMouseUp(mousePosition);
            }
        }
    }
}
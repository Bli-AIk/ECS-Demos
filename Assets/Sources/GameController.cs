using Systems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Entitas.Systems _systems;

    private void Start()
    {
        // 获取对上下文的引用
        var contexts = Contexts.sharedInstance;

        // 通过创建特性（Feature）来构建系统集合
        _systems = new Feature("Systems")
            .Add(new TutorialSystems(contexts));

        // 对所有实现了 IInitializeSystem 接口的系统调用 Initialize()
        _systems.Initialize();
    }

    private void Update()
    {
        // 对所有实现了 IExecuteSystem 接口的系统和
        // 在上一帧被触发的 ReactiveSystem 调用 Execute()
        _systems.Execute();
        // 对所有实现了 ICleanupSystem 接口的系统调用 Cleanup()
        _systems.Cleanup();
    }
}
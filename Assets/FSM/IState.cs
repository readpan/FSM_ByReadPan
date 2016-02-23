public interface IState
{
    /// <summary>
    /// 获取这个状态机的状态
    /// </summary>
    /// <returns></returns>
    uint GetStateID();

    void OnEnter();

    void OnExit();

    void OnUpdate();

    void OnFixedUpdate();

    void OnLateUpdate();
}

public interface IState
{
    /// <summary>
    /// 获取这个状态机的状态
    /// </summary>
    /// <returns></returns>
    StateType GetStateID();
    /// <summary>
    /// 进入状态
    /// </summary>
    /// <param name="machine">状态机</param>
    /// <param name="preState">上一个状态</param>
    /// <param name="parameter1">传参1，无用添加null</param>
    /// <param name="parameter2">传参2，无用添加null</param>
    void OnEnter(StateMachine machine, IState preState, object parameter1, object parameter2);

    /// <summary>
    /// 退出状态
    /// </summary>
    /// <param name="nextState">下一个要进入的状态</param>
    /// <param name="parameter1">参数1，无用添加null</param>
    /// <param name="parameter2">参数2，无用添加null</param>
    void OnExit(IState nextState, object parameter1, object parameter2);

    void OnUpdate();

    void OnFixedUpdate();

    void OnLateUpdate();
}

using UnityEngine;
using System.Collections.Generic;

public class StateMachine
{

    public Dictionary<uint, IState> mStateDic = null;
    private IState mCurrentState = null;
    public IState CurrentState
    {
        get
        {
            return mCurrentState;
        }
    }
    public uint CurrentID
    {
        get
        {
            return mCurrentState == null ? 0 : mCurrentState.GetStateID();
        }
    }
    public StateMachine()
    {
        mStateDic = new Dictionary<uint, IState>();

    }

    /// <summary>
    /// 注册新状态
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool RegisteState(IState state)
    {
        //如果状态为空,返回false
        if (state == null)
        {
            return false;
        }
        //如果状态存在也返回false
        if (mStateDic.ContainsKey(state.GetStateID()))
        {
            return false;
        }
        mStateDic.Add(state.GetStateID(), state);
        return true;
    }

    /// <summary>
    /// 移除状态
    /// </summary>
    /// <param name="stateID">状态ID</param>
    /// <returns>是否移除成功</returns>
    public bool RemoveState(uint stateID)
    {
        if (mCurrentState != null)
        {
            if (mCurrentState.GetStateID() == stateID)
            {
                return false;
            }
        }
        if (!mStateDic.ContainsKey(stateID))
        {
            return false;
        }
        mStateDic.Remove(stateID);
        return true;
    }

    /// <summary>
    /// 获取状态
    /// </summary>
    /// <param name="stateID">状态id</param>
    /// <returns>状态</returns>
    public IState GetState(uint stateID)
    {
        IState state = null;
        mStateDic.TryGetValue(stateID, out state);
        return state;
    }

    /// <summary>
    /// 停止状态
    /// </summary>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public void StopState(object param1, object param2)
    {
        if (mCurrentState != null)
        {
            mCurrentState.OnExit(null, param1, param2);
            mCurrentState = null;
        }
    }

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="stateID">要切换的状态</param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    /// <returns>是否切换成功</returns>
    public bool SwitchState(uint stateID, object param1, object param2)
    {
        IState newState = null;
        IState oldState = mCurrentState;
        mStateDic.TryGetValue(stateID, out newState);
        //如果stateID无对应值，返回false
        if (newState == null)
        {
            return false;
        }
        //
        if (mCurrentState != null && mCurrentState.GetStateID() == stateID)
        {
            return false;
        }

        if (mCurrentState != null)
        {
            mCurrentState.OnExit(newState, param1, param2);
        }
        mCurrentState = newState;
        if (onSwitchState != null)
        {
            onSwitchState(oldState, mCurrentState, param1, param2);
        }
        newState.OnEnter(this, oldState, param1, param2);
        return true;
    }
    /// <summary>
    /// 切换状态回调
    /// </summary>
    /// <param name="from">当前状态</param>
    /// <param name="to">预切换状态</param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public delegate void OnSwitchState(IState from, IState to, object param1, object param2);
    public OnSwitchState onSwitchState = null;

    /// <summary>
    /// 判断当前状态是否为此状态
    /// </summary>
    /// <param name="stateID">此状态</param>
    /// <returns></returns>
    public bool IsInState(uint stateID)
    {
        return mCurrentState == null ? false : mCurrentState.GetStateID() == stateID;
    }

    void OnUpdate()
    {
        if(mCurrentState !=null)
        {
            mCurrentState.OnUpdate();
        }
    }

    void OnFixedUpdate()
    {
        if (mCurrentState != null)
        {
            mCurrentState.OnFixedUpdate();
        }
    }

    void OnLateUpdate()
    {
        if (mCurrentState != null)
        {
            mCurrentState.OnLateUpdate();
        }
    }

}

using UnityEngine;
using System.Collections;
using System;

public class BaseState : IState
{
    public BaseObject mBaseObject = null;
    public BaseState(BaseObject baseObject)
    {
        mBaseObject = baseObject;
    }

    public virtual StateType GetStateID()
    {
        return StateType.NoneState;
    }
    public virtual void OnEnter(StateMachine machine, IState preState, object parameter1, object parameter2)
    {
        Debug.Log("Enter " + GetStateID());
    }
    public virtual void OnExit(IState nextState, object parameter1, object parameter2)
    {
        Debug.Log("Exit " + GetStateID());
    }
    public virtual void OnFixedUpdate() { }
    public virtual void OnLateUpdate() { }
    public virtual void OnUpdate() { }
}

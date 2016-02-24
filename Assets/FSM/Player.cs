using UnityEngine;
using System.Collections;

public class Player : BaseObject
{
    public override void Awake()
    {
        base.Awake();
        stateMachine.RegisteState(new State1(this));
        stateMachine.RegisteState(new State2(this));
        stateMachine.SwitchState(StateType.State1, null, null);
    }

    public void OnGUI()
    {
        if (GUILayout.Button("State1"))
        {
            stateMachine.onSwitchState += onSwitchStateCallBack;
            stateMachine.SwitchState(StateType.State1, null, null);
        }
        if (GUILayout.Button("State2"))
        {
            stateMachine.SwitchState(StateType.State2, null, null);
        }
    }

    void onSwitchStateCallBack(IState from, IState to, object param1, object param2)
    {
        Debug.Log("Call Back function has ran.");
    }
}

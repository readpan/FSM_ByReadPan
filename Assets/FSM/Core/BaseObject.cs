using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour
{
    [HideInInspector]
    public StateMachine stateMachine = new StateMachine();

    public virtual void Awake() { }

    protected virtual void Start() { }

    protected virtual void Update()
    {
        stateMachine.OnUpdate();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.OnFixedUpdate();
    }

    protected virtual void LateUpdate()
    {
        stateMachine.OnLateUpdate();
    }
}

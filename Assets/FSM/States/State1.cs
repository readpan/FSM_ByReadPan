using UnityEngine;
using System.Collections;
using System;

public class State1 : BaseState
{
    public State1(Player player) : base(player)
    {

    }
    public override StateType GetStateID()
    {
        return StateType.State1;
    }
}

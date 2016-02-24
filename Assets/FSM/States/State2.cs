using UnityEngine;
using System.Collections;

public class State2 : BaseState
{

    public State2(Player player):base(player)
    {

    }
    public override StateType GetStateID()
    {
        return StateType.State2;
    }
}

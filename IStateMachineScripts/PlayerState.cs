using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerParameters Params;

    public PlayerState(PlayerParameters param) => Params = param;

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}

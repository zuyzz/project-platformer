using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IState {
    protected Player player;
    public void Init(Player player){
        this.player = player;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
    public abstract void OnExit();
    public abstract bool Condition();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : IState {

    public UnityEvent onEnterState;
    public UnityEvent onExitState;

    public virtual void OnEnter(){
        onEnterState?.Invoke();
    }
    public virtual void OnExit(){
        onExitState?.Invoke();
    }
    public virtual void OnUpdate(){}
    public virtual void OnFixedUpdate(){}

    public abstract bool ValidateEnter();
    public abstract bool ValidateExit();
}

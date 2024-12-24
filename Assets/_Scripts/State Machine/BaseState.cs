using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : IState {
    protected Entity entity;
    public void Init(Entity entity) {
        this.entity = entity;
    }

    [SerializeField] protected AnimationClip animationClip;

    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
    public abstract void OnExit();

    public abstract bool IsAvailable();
}

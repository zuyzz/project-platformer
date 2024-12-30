using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State {

    [Header("Components")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected Rigidbody2D rigidbody;
    [SerializeField] protected Transform transform;

    [Header("Properties")]
    [SerializeField] protected AnimationClip animationClip;

    public override void OnEnter(){
        base.OnEnter();
    }
    public override void OnUpdate(){
        base.OnUpdate();
    }
    public override void OnFixedUpdate(){
        base.OnFixedUpdate();
    }
    public override void OnExit(){
        base.OnExit();
    }
}

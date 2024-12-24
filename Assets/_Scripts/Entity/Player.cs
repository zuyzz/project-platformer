using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
    [SerializeField] StateMachine stateMachine;

    protected override void Awake(){
        base.Awake();
        stateMachine = GetComponentInChildren<StateMachine>();
        stateMachine.Init(this);
    }
}

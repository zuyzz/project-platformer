using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {
    [SerializeField] StateMachine stateMachine;

    [SerializeField] float _moveSpeed;
    public float moveSpeed { get => _moveSpeed; }
    [SerializeField] float _jumpForce;
    public float jumpForce { get => _jumpForce; }

    protected override void Awake(){
        base.Awake();
        stateMachine = GetComponentInChildren<StateMachine>();
        stateMachine.Init(new PlayerStateFactory(),this);
    }

    private void Start(){
    }
}

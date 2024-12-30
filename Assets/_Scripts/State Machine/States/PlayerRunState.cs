using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddTypeMenu("Player/Run")]
[System.Serializable]
public class PlayerRunState : PlayerBaseState {

    [Header("Properties")]
    [SerializeField] float speed;

    public override void OnEnter(){
        animator.Play(animationClip.name);
    }

    public override void OnUpdate(){
        if (InputManager.Instance.x > 0){
            transform.localScale = new Vector3(1,1,1);
        } else {
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    public override void OnFixedUpdate(){
        rigidbody.velocityX = InputManager.Instance.x * speed;
    }

    public override bool ValidateEnter(){
        return Physics2D.Raycast(transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && InputManager.Instance.x != 0;
    }

    public override bool ValidateExit() 
    => true;
}

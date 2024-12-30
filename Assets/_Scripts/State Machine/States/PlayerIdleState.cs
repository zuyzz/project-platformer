using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddTypeMenu("Player/Idle")]
[System.Serializable]
public class PlayerIdleState : PlayerBaseState {

    public override void OnEnter(){
        animator.Play(animationClip.name);
    }

    public override void OnFixedUpdate(){
        rigidbody.velocityX = 0;
    }

    public override bool ValidateEnter(){
        return Physics2D.Raycast(transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && InputManager.Instance.x == 0;
    }

    public override bool ValidateExit() 
    => true;
}

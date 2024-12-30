using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddTypeMenu("Player/Fall")]
[System.Serializable]
public class PlayerFallState : PlayerBaseState {

    [Header("Properties")]
    [SerializeField] float gravity;

    public override void OnEnter(){
        animator.Play(animationClip.name);
        rigidbody.gravityScale = gravity;
    }

    public override bool ValidateEnter(){
        return !Physics2D.Raycast(transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && rigidbody.velocityY <= 0;
    }

    public override bool ValidateExit() 
    => true;
}

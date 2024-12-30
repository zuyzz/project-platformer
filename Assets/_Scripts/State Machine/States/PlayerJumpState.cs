using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddTypeMenu("Player/Jump")]
[System.Serializable]
public class PlayerJumpState : PlayerBaseState {

    [Header("Properties")]
    [SerializeField] float force;
    [SerializeField] float gravity;

    public override void OnEnter(){
        animator.Play(animationClip.name);
        rigidbody.AddForceY(force, ForceMode2D.Impulse);
        rigidbody.gravityScale = gravity;
    }

    public override bool ValidateEnter(){
        return Physics2D.Raycast(transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && InputManager.Instance.jump;
    }

    public override bool ValidateExit() 
    => true;
}

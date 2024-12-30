using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[AddTypeMenu("Player/Dash")]
[System.Serializable]
public class PlayerDashState : PlayerBaseState {

    [Header("Properties")]
    [SerializeField] float distance;
    [SerializeField] float duration;

    private bool isDashing = false;

    public override void OnEnter(){
        animator.Play(animationClip.name);
        rigidbody.gravityScale = 0;
        rigidbody.velocityY = 0;
        rigidbody.DOMoveX(transform.position.x+InputManager.Instance.x*distance,duration)
        .OnStart(
            () => isDashing = true
        )
        .OnComplete(
            () => isDashing = false
        );
    }

    public override bool ValidateEnter(){
        return InputManager.Instance.dash;
    }

    public override bool ValidateExit() 
    => !isDashing;
}

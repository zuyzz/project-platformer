using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : BaseState {
    public override void OnEnter(){
        player.ani.CrossFade(Animator.StringToHash("jump"),0);
        player.rb.AddForceY(player.jumpForce, ForceMode2D.Impulse);
    }

    public override void OnUpdate(){
        
    }

    public override void OnFixedUpdate(){
        
    }

    public override void OnExit(){
        
    }

    public override bool Condition(){
        return InputManager.Instance.jump
        && Physics2D.Raycast(player.transform.position,Vector2.down,1);
    }
}

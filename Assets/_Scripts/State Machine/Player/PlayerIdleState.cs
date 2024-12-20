using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState {
    public override void OnEnter(){
        player.ani.CrossFade(Animator.StringToHash("idle"),0);
    }

    public override void OnUpdate(){
        
    }

    public override void OnFixedUpdate(){
        player.rb.velocityX = 0;
    }

    public override void OnExit(){
        
    }

    public override bool Condition(){
        return InputManager.Instance.x == 0
        && player.rb.velocityY == 0;
    }
}

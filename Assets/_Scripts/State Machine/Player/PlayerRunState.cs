using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : BaseState {
    public override void OnEnter(){
        player.ani.CrossFade(Animator.StringToHash("run"),0);
    }

    public override void OnUpdate(){
        if (InputManager.Instance.x > 0){
            player.transform.localScale = new Vector3(1,1,1);
        } else {
            player.transform.localScale = new Vector3(-1,1,1);
        }
    }

    public override void OnFixedUpdate(){
        player.rb.velocityX = InputManager.Instance.x * player.moveSpeed;
    }

    public override void OnExit(){
        
    }

    public override bool Condition(){
        return InputManager.Instance.x != 0
        && player.rb.velocityY == 0;
    }
}

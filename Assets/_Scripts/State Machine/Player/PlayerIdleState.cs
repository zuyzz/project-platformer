using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerIdleState : BaseState {

    public override void OnEnter(){
        entity.ani.Play(animationClip.name);
    }

    public override void OnUpdate(){
        
    }

    public override void OnFixedUpdate(){
        entity.rb.velocityX = 0;
    }

    public override void OnExit(){
        
    }

    public override bool IsAvailable(){
        return Physics2D.Raycast(entity.transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && InputManager.Instance.x == 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerFallState : BaseState {

    [Header("Properties")]
    [SerializeField] float gravity;

    public override void OnEnter(){
        entity.ani.Play(animationClip.name);
        entity.rb.gravityScale = gravity;
    }

    public override void OnUpdate(){
        
    }

    public override void OnFixedUpdate(){
        
    }

    public override void OnExit(){
        
    }

    public override bool IsAvailable(){
        return !Physics2D.Raycast(entity.transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && entity.rb.velocityY < 0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRunState : BaseState {

    [Header("Properties")]
    [SerializeField] float speed;

    public override void OnEnter(){
        entity.ani.Play(animationClip.name);
    }

    public override void OnUpdate(){
        if (InputManager.Instance.x > 0){
            entity.transform.localScale = new Vector3(1,1,1);
        } else {
            entity.transform.localScale = new Vector3(-1,1,1);
        }
    }

    public override void OnFixedUpdate(){
        entity.rb.velocityX = InputManager.Instance.x * speed;
    }

    public override void OnExit(){
        
    }

    public override bool IsAvailable(){
        return Physics2D.Raycast(entity.transform.position,Vector2.down,1,LayerMask.GetMask("Ground"))
        && InputManager.Instance.x != 0;
    }
}

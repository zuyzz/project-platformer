using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerStateMachine.EState> {

    public enum EState {
        None        = 0,
        Idle        = 1<<1,
        Run         = 1<<2,
        Jump        = 1<<3,
        Fall        = 1<<4,
        Dash        = 1<<5,
        All         = ~None
    }

    public override void SetTransition(){

        AddTransition(EState.Idle, EState.Run);
        AddTransition(EState.Idle, EState.Jump);

        AddTransition(EState.Run, EState.Idle);
        AddTransition(EState.Run, EState.Jump);

        AddTransition(EState.Jump, EState.Fall);

        AddTransition(EState.Fall, EState.Idle);
        AddTransition(EState.Fall, EState.Run);
        
    }
}

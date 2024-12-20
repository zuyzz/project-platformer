using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    private IState current;
    private BaseStateFactory factory;

    public void Init(BaseStateFactory factory, Player player){
        this.factory = factory;
        factory.Init(player);
    }

    private void Start(){
        current = factory.@default;
    }

    private void Update(){
        CheckStateTransition();
        current.OnUpdate();
    }

    private void FixedUpdate(){
        current.OnFixedUpdate();
    }

    public void ChangeState(IState newState){
        if (current == newState) return;
        current.OnExit();
        current = newState;
        current.OnEnter();
    }

    public void CheckStateTransition(){
        foreach (var state in factory.GetNeighborStates(current)){
            if (state.Condition()){
                ChangeState(state);
            }
        }
    }
}

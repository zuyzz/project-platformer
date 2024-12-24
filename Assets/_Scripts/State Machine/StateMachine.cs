using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    [System.Serializable]
    public class StateNode {
        [SerializeReference, SubclassSelector]
        public BaseState state;
        public string from;
        public string[] to;

        public void Init(Entity entity){
            state.Init(entity);
        }
    }

    protected IState currentState;
    
    [SerializeField] protected List<StateNode> stateNodes = new();

    public void Init(Entity entity){
        stateNodes.ForEach((node) => node.Init(entity));
    }

    private void Start(){
        // foreach (var node in stateNodes){
        //     if (node.state.IsAvailable()){
        //         currentState = node.state;
        //         break;
        //     }
        // }
        currentState = stateNodes[0].state;
    }

    private void Update(){
        CheckStateTransition();
        currentState.OnUpdate();
    }

    private void FixedUpdate(){
        currentState.OnFixedUpdate();
    }

    public void SwitchState(IState newState){
        if (currentState == newState) return;
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }

    public void CheckStateTransition(){
        var currentNode = GetState(currentState);
        foreach (var state in GetNeighborStateNode(currentNode.from)){
            if (state.IsAvailable()){
                SwitchState(state);
            }
        }
    }

    private BaseState GetStateNode(string name){
        return stateNodes.Find(x => x.from.Equals(name)).state;
    }
    private StateNode GetState(IState state){
        return stateNodes.Find(x => x.state.Equals(state));
    }

    private BaseState[] GetNeighborStateNode(string name){
        List<BaseState> states = new();
        var currentNode = stateNodes.Find(x => x.from.Equals(name));
        foreach (var neighborStateName in currentNode.to){
            states.Add(GetStateNode(neighborStateName));
        }
        return states.ToArray();
    }
}

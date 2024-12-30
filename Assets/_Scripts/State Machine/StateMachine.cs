using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<StateID> : MonoBehaviour {
    protected IState currentState;

    [SerializeField]
    protected List<StateNode<StateID>> anyNodes = new();

    [SerializeField]
    protected List<StateNode<StateID>> stateNodes = new();

    protected Dictionary<StateID,List<StateID>> transitions = new();

    private void Awake(){
        SetTransition();
    }

    private void Start(){
        stateNodes.ForEach((node) => {
            if (node.state.ValidateEnter()){
                currentState = node.state;
                return;
            }
        });
    }

    private void Update(){
        CheckTransition();
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

    public void AddTransition(StateID from, StateID to){
        if (from == null || to == null) return;
        if (transitions.ContainsKey(from)){
            transitions[from].Add(to);
        } else {
            transitions.Add(from, new List<StateID>(){to});
        }
    }

    public void RemoveTransition(StateID from, StateID to){
        if (from == null || to == null) return;
        if (transitions.ContainsKey(from)){
            transitions.Remove(from);
        }
    }

    private void CheckTransition(){
        if (!currentState.ValidateExit()) return;
        anyNodes.ForEach((node) => {
            if (node.state.ValidateEnter()){
                Debug.Log(node.state);
                SwitchState(node.state);
                return;
            }
        });
        stateNodes.ForEach((node) => {
            foreach (var toID in transitions[GetStateNode(currentState).id]){
                if (node.id.Equals(toID) && node.state.ValidateEnter()){
                    Debug.Log(node.state);
                    SwitchState(node.state);
                    return;
                }
            }
        });
    }

    private IState GetState(StateID id){
        return stateNodes.Find(x => x.id.Equals(id)).state;
    }

    private StateNode<StateID> GetStateNode(IState state){
        return stateNodes.Find(x => x.state.Equals(state));
    }

    public abstract void SetTransition();
}

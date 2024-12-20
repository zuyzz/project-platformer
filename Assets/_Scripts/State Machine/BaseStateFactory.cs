using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateFactory {
    public IState @default;
    protected Dictionary<string,BaseState> states = new();
    protected Dictionary<IState,IState[]> stateTransition = new();

    public virtual void Init(Player player){
        foreach (var state in states){
            state.Value.Init(player);
        }
    }

    public void AddState(string name,BaseState state){
        states.Add(name,state);
    }

    public void AddTransition(IState from, params IState[] to){
        // if (!states.Contains(from as BaseState)) return;
        if (stateTransition.ContainsKey(from)){
            stateTransition[from] = to;
        } else {
            stateTransition.Add(from, to);
        }
    }

    public IState[] GetNeighborStates(IState from){
        return stateTransition[from];
    }
}

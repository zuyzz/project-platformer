using UnityEngine;

[System.Serializable]
public class StateNode<StateID> {
    public StateID id;

    [SerializeReference, SubclassSelector]
    public IState state;
}

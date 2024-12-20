using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Entity : MonoBehaviour {
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator ani;

    protected virtual void Awake(){
        rb = GetComponentInChildren<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
    }
}

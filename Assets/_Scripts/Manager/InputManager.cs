using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    [SerializeField] private Vector2 _mousePos;
    public Vector2 mousePos { get => _mousePos; }
    
    public float x;
    public bool jump;
    public bool dash;

    [SerializeField] Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(nameof(InputManager) + "service has been active");
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)){
            jump = true;
        }
        else jump = false;
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            dash = true;
        }
        else dash = false;
        // if (Input.GetKeyDown(KeyCode.J)){
        //     var projectile = Instantiate(projectilePRF,player.transform.position,Quaternion.identity);
        //     projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(player.transform.localScale.x*projectile.speed,0);
        // }
    }

    void FixedUpdate(){
        
    }
}

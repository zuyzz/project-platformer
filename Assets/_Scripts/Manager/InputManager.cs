using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    [SerializeField] private Vector2 _mousePos;
    public Vector2 mousePos { get => _mousePos; }

    [SerializeField] Player player;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] Animator playerANI;

    [SerializeField] Projectile projectilePRF;

    int idleHash;
    int runHash;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponentInChildren<Rigidbody2D>();
        playerANI = player.GetComponentInChildren<Animator>();
        Debug.Log(nameof(InputManager) + "service has been active");
        idleHash = Animator.StringToHash("idle");
        runHash = Animator.StringToHash("run");
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var x = Input.GetAxisRaw("Horizontal");
        playerRB.velocityX = x * player.moveSpeed;
        if (playerRB.velocityX == 0){
            playerANI.CrossFade(idleHash,0);
        } else {
            playerANI.CrossFade(runHash,0);
            player.transform.localScale = new Vector3(x,1,1);
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            playerRB.velocityY = player.jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.J)){
            var projectile = Instantiate(projectilePRF,player.transform.position,Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(player.transform.localScale.x*projectile.speed,0);
        }
    }

    void FixedUpdate(){
        
    }
}

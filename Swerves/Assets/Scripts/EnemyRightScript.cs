using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRightScript : MonoBehaviour
{
    public AudioSource exploSound;
    float hit = 0;
    Animator animator;
    
    public float levelSpeed;
    void Awake(){
        exploSound = GameObject.Find("Quad").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        levelSpeed = GameManagerScript.manager.levelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveRegular();
        if(SpawnScript.spawner.isEnable == false )
            Destroy(gameObject, 1f);
        if(GameManagerScript.manager.lives != 0 && GameObject.FindWithTag("Player").GetComponent<Move>().canMove == false){
            Destroy(gameObject);
        }
        if(transform.position.x <= -18f || transform.position.x >= 18f){
            SpawnScript.spawner.SpawnLeft();
            
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player" && hit ==0){
            GameManagerScript.manager.DecLives();
            CameraShake.shaker.shake = true;
            animator.SetTrigger("explosion");
            hit++;
            exploSound.Play();
            
        }
    }

    

    void MoveRegular(){
        if(Move.mover.xInput > 0){
            transform.Translate(((-10.1f - levelSpeed) - (Move.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
        else if(Move.mover.xInput == 0){
             transform.Translate(((-5.8f - levelSpeed) - (Move.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
        else{
            transform.Translate(((-5.8f - levelSpeed) - (Move.mover.xInput * 3f)) * Time.deltaTime, 0, 0);///dassdasdasd
        }
    }

    
}

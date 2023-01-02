using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftScript : MonoBehaviour
{
    
    float hit = 0;
    Animator animator;
    public float levelSpeed;

    void Awake(){
        animator = GetComponent<Animator>();
        
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        
        animator  = GetComponent<Animator>();
        levelSpeed = GameManagerScript.manager.levelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveRegular();
        
        if(SpawnScript.spawner.isEnable == false )
            Destroy(gameObject, 1f);
        if(GameManagerScript.manager.lives != 0 && GameObject.FindWithTag("Player").GetComponent<Move>().canMove == false)//only deleted instantly when lives = 0 and player canMove = false;
            Destroy(gameObject);
        if(transform.position.x >= 18f || transform.position.x <= -18f){
            SpawnScript.spawner.SpawnRight();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player" && hit ==0){
            GameManagerScript.manager.DecLives();
            CameraShake.shaker.shake = true;
            animator.SetTrigger("explosion");
            hit++;
            GameObject.Find("explodeManager").GetComponent<Explosion>().Explode();
            transform.GetChild(0).gameObject.SetActive(false);
            
        }
    }

    

    void MoveRegular(){
        if(Move.mover.xInput > 0){
            transform.Translate(((5.8f + levelSpeed) - (Move.mover.xInput * 3f)) * Time.deltaTime, 0, 0);
        }
        else if(Move.mover.xInput == 0){
            transform.Translate(((5.8f + levelSpeed) - (Move.mover.xInput * 0.5f)) * Time.deltaTime, 0, 0);
        }
        else{
            transform.Translate(((10.1f + levelSpeed) - (Move.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveRegular();
        
        if(SpawnScript.spawner.isEnable == false )
            Destroy(gameObject);
        if(transform.position.x <= -18f || transform.position.x >= 18f){
            SpawnScript.spawner.SpawnLeft();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            GameManagerScript.manager.DecLives();
            CameraShake.shaker.shake = true;
        }
    }

    void MoveRegular(){
        if(Move.mover.xInput > 0){
            transform.Translate((-11.1f - (Move.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
        else if(Move.mover.xInput == 0){
             transform.Translate((-6.8f - (Move.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
        else{
            transform.Translate((-6.8f - (Move.mover.xInput * 3f)) * Time.deltaTime, 0, 0);///dassdasdasd
        }
    }

    
}

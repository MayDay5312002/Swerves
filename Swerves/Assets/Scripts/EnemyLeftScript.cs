using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveRegular();
        
        if(transform.position.x >= 18f || transform.position.x <= -18f){
            SpawnScript.spawner.SpawnRight();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){

        }
    }

    void MoveRegular(){
        if(Move.mover.xInput > 0){
            transform.Translate(0.028f - (Move.mover.xInput * 0.02f), 0, 0);
        }
        else if(Move.mover.xInput == 0){
            transform.Translate(0.018f - (Move.mover.xInput * 0.005f), 0, 0);
        }
        else{
            transform.Translate(0.021f - (Move.mover.xInput * 0.0055f), 0, 0);
        }
    }

}

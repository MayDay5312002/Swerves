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
            transform.Translate((6.8f - (Move.mover.xInput * 3f)) * Time.deltaTime, 0, 0);
        }
        else if(Move.mover.xInput == 0){
            transform.Translate((6.8f - (Move.mover.xInput * 0.5f)) * Time.deltaTime, 0, 0);
        }
        else{
            transform.Translate((11.1f - (Move.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
    }

}

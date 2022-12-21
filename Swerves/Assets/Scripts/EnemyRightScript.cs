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
        if(Move.mover.xInput >= 0){
            transform.Translate(-0.03f - (Move.mover.xInput * 0.02f), 0, 0);
        }
        if(Move.mover.xInput < 0){
            transform.Translate(-0.03f - (Move.mover.xInput * 0.042f), 0, 0);
        }
        if(transform.position.x <= -15f || transform.position.x >= 15f){
            SpawnScript.spawner.SpawnLeft();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){

        }
    }
}

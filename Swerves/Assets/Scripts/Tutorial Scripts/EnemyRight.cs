using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : MonoBehaviour
{
    Animator animator;

    public GameObject timePanel;

    float speedLevel;

    int hit = 0;

    void Awake(){
        animator = GetComponent<Animator>();
        speedLevel = TimerScript.timer.speedLevel;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRegular();
        if(transform.position.x >= 18f || transform.position.x <= -18f){
            EnemySpawner.spawner.SpawnLeft();
            Destroy(gameObject);
        }
        speedLevel = TimerScript.timer.speedLevel;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(hit == 0){
            hit++;
            animator.SetTrigger("explosion");
            GameObject.Find("explodeManager").GetComponent<Explosion>().Explode();
            transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Canvas").gameObject.transform.Find("Timer Minus").GetComponent<TimerScript>().time = 30;
        }
    }
    void MoveRegular(){
        if(MoveTutorial.mover.xInput > 0){
            transform.Translate(((-10.1f - speedLevel) - (MoveTutorial.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
        else if(MoveTutorial.mover.xInput == 0){
             transform.Translate(((-5.8f - speedLevel) - (MoveTutorial.mover.xInput * 0.55f)) * Time.deltaTime, 0, 0);
        }
        else{
            transform.Translate(((-5.8f - speedLevel) - (MoveTutorial.mover.xInput * 3f)) * Time.deltaTime, 0, 0);
        }
    }

    
}

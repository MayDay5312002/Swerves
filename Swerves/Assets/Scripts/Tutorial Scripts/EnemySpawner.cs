using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner spawner;
    public GameObject leftEnemy;
    public GameObject rightEnemy;


    void Awake(){
        if(spawner == null)
            spawner = this;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        if(Random.Range(0, 2) == 0){
            Invoke("SpawnLeft", 2f);
        }
        else
            Invoke("SpawnRight", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLeft(){
        
        Instantiate(leftEnemy, new Vector3(-15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
    }
    public void SpawnRight(){
        
        Instantiate(rightEnemy, new Vector3(15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
    }

    public void CancelInvoker(){
        CancelInvoke("SpawnLeft");
        CancelInvoke("SpawnRight");
    }
}

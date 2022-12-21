using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static SpawnScript spawner;
    [SerializeField]GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable(){
        if(Random.Range(0f, 2f) == 0){
            Invoke("SpawnLeft", 2f);
        }
        else
            Invoke("SpawnRight", 2f);
    }

    void Awake(){
        if(spawner == null){
            spawner = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnLeft(){
        Instantiate(enemies[0], new Vector3(-15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
    }
    public void SpawnRight(){
        Instantiate(enemies[1], new Vector3(15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
    }
}

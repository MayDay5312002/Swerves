using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static SpawnScript spawner;
    public bool isEnable;
    [SerializeField]GameObject[] enemies;
    

    void Awake(){
        if(spawner == null){
            spawner = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable(){
        isEnable = true;
        
<<<<<<< HEAD
        if(Random.Range(0, 2) == 0){
            Invoke("SpawnLeftCheck", 2f);
=======
        if(!GameObject.FindWithTag("Enemies")){
            if(Random.Range(0, 6) % 2 == 0){
                Invoke("SpawnLeftCheck", 2f);
            }
            else
                Invoke("SpawnRightCheck", 2f);
>>>>>>> af170b3bfd5843ffba8a4ddf5a5eae55cc4d7d1a
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnLeftCheck(){
         if(GameObject.FindWithTag("Enemies") == false)
            Instantiate(enemies[0], new Vector3(-15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
        
        
    }
    public void SpawnRightCheck(){
         if(GameObject.FindWithTag("Enemies") == false)
            Instantiate(enemies[1], new Vector3(15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
        
        
    }

    public void SpawnLeft(){
        
        Instantiate(enemies[0], new Vector3(-15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
        
        
    }
    public void SpawnRight(){
        
        Instantiate(enemies[1], new Vector3(15f, Random.Range(-2.61f, 5.2f), 0), Quaternion.identity);
        
        
    }

    void OnDisable(){
        isEnable = false;
    }
    public void CancelInvokes(){
        CancelInvoke("SpawnRightCheck");
        CancelInvoke("SpawnLeftCheck");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake shaker;
     public bool shake = false;
    public float shakeRange;
    public float shakeTime;
    Vector3 originalPos;

    void Awake(){
        originalPos = transform.position;
        if(shaker == null){
            shaker = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(shake){
            StartCoroutine("Shakes");
         }
    }

    IEnumerator Shakes(){
        float elapsedTime = 0;
        while(elapsedTime < shakeTime){
            Vector3 pos = originalPos + Random.insideUnitSphere * shakeRange;
            pos.z = originalPos.z;
            transform.position = pos;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
        shake = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTutorial : MonoBehaviour
{
    public GameObject[] tutObj;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Transition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transition(){
        int i = 0;
        while(i < tutObj.Length ){
            tutObj[i].SetActive(true);
            if(!(i == 2 || i == 4 || i == 0 || i == 3 || i == 5))
                yield return new WaitForSeconds(8f);
            else if(i == 0 || i == 3)
                yield return new WaitForSeconds(6f);
            else if(i == tutObj.Length - 1)
                yield return new WaitForSeconds(3f);
            else if(i == 2)
                yield return new WaitForSeconds(12f);
            else
                yield return new WaitForSeconds(17f);
            if(i != tutObj.Length - 1)
                tutObj[i].SetActive(false);
            i++;
        }
        yield return new WaitForSeconds(1f);
        timer.SetActive(true);


        
    }
}

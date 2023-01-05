using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static TimerScript timer;
    public int startTime = 30;
    public int time;
    public Text text;
    public float speedLevel = 1f;
    public GameObject swerve10;

    public GameObject practiceTutorial;

    void Awake(){
        if(timer == null)
            timer = this;
        time = startTime;
        text.text = time.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartTime");
    }

    // Update is called once per frame
    void Update()
    {
        if(time == 0){
            Destroy(GameObject.FindWithTag("Enemies"));
            time = 0;
            swerve10.SetActive(false);
            MenuTutorial.menuer.menuState = true;
            MenuTutorial.menuer.menu.SetActive(true);
            practiceTutorial.SetActive(false);
            gameObject.SetActive(false);

        }
        if((time == 10 || time == 20)){
            speedLevel += 1f * Time.deltaTime;
        }   
        if(time >= 25){
            speedLevel = 1f;
        }
    }

    IEnumerator StartTime(){
        while(time > 0){
            yield return new WaitForSeconds(1f);
            time--;
            text.text = time.ToString();
        }
    }
}

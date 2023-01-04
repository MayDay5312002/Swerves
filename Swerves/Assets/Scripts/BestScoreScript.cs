using System;
using System.IO;
using UnityEngine;
//This is used in Game Manager Script
[System.Serializable]
public class BestScoreScript
{
    public static bool BestScoreWrite(){
        StreamWriter writer = null;
        try{
            int temp = int.Parse(BestScoreRead());
            if(temp < GameManagerScript.manager.time){
                writer = new StreamWriter("erocs.txt", false);
                writer.WriteLine(GameManagerScript.manager.time.ToString());
                writer.Close();
                return true;
            }
            return false;
        }
        catch(Exception e){
            Debug.Log(e.StackTrace.ToString());
            return false;
        }
        
    }

    public static string BestScoreRead(){
        string scoreData;
        StreamReader reader = null;
        try{
            
            if(File.Exists("erocs.txt")){
                reader = new StreamReader("erocs.txt");
                scoreData = reader.ReadLine();
                int temp = int.Parse(scoreData);
                reader.Close();
                return scoreData;
                
            }
            else{
                return "0";
                
            }
            
        }
        catch(Exception e){
            Debug.Log(e.Message);
            return "ERROR";
            
        }
        
    }

    public static bool CheckFileExist(){
        return File.Exists("erocs.txt");
    }

    

}
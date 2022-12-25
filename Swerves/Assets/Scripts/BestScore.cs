using System;
using System.IO;
using UnityEngine;

public class BestScore
{
    public static void BestScoreWrite(){
        StreamWriter writer = null;
        try{
        writer = new StreamWriter("erocs.txt", false);
        writer.WriteLine(GameManagerScript.manager.time.ToString());
        }
        catch(Exception e){
            Debug.Log(e.Message);
        }
        finally{
            writer.Close();
        }

    }

    public static string BestScoreRead(){
        string scoreData;
        StreamReader reader = null;
        try{
            
            if(File.Exists("erocs.txt")){
                reader = new StreamReader("erocs.txt");
                scoreData = reader.ReadLine();
                return scoreData;
                reader.Close();
            }
            else{
                return "0";
                reader.Close();
            }
            
        }
        catch(Exception e){
            Debug.Log(e.Message);
            return "ERROR";
            
        }
        
    }

}

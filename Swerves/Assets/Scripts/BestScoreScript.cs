using System;
using System.IO;
using UnityEngine;
//This is used in Game Manager Script
[System.Serializable]
public class BestScoreScript
{
    public static bool BestScoreWrite(){
        StreamWriter writer = null;
        StreamWriter writerEnc = null;
        try{
            int temp = int.Parse(BestScoreRead());
            if(temp < GameManagerScript.manager.time){
                writer = new StreamWriter("erocs.txt", false);
                writer.WriteLine(GameManagerScript.manager.time.ToString());
                writer.Close();
                writerEnc = new StreamWriter(@"Assets/nakuha/escor.txt", false);//In Unity Editor: @"Assets/nakuha/escor.txt";
                writerEnc.WriteLine(GameManagerScript.manager.time.ToString());       //When build@"Swerve_Data/Managed/escor.txt"
                writerEnc.Close();//
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
                reader.Close();
                int temp = int.Parse(scoreData);
                int byPass = int.Parse(EncryptionBypass());//
                if(temp == byPass)//
                    return scoreData;//
                else//
                    return "0";
                
            }
            else{
                return "0";
                
            }
            
        }
        catch(Exception e){
            Debug.Log(e.Message);
            File.Delete("erocs.txt");
            File.Delete(@"Assets/nakuha/escor.txt");//In Unity Editor: @"Assets/nakuha/escor.txt";
            return "0";                                   //When build@"Swerve_Data/Managed/escor.txt"
            
        }
        
    }

    public static bool CheckFileExist(){
        return File.Exists("erocs.txt");
    }

    public static string EncryptionBypass(){
        try{
            StreamReader reader = new StreamReader(@"Assets/nakuha/escor.txt");//In Unity Editor: @"Assets/nakuha/escor.txt";
            string temp = reader.ReadLine();                                         //When build@"Swerve_Data/Managed/escor.txt"
            reader.Close();
            return temp;
        }
        catch(Exception e){
            Debug.Log(e.Message);
            return "0";
        }
          
    }

    

    

}
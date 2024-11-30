using UnityEngine;
using System.IO;
using UnityEditor.ProjectWindowCallback;

public class FileReader : MonoBehaviour
{
    //public string file_path;
    public DialogManager dialogManager;

    //public int entryNumber;

    bool endedCurrentFile = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Lee la línea lineNumber del archivo en file_path
    public string readTextFile(string file_path, int entryNumber)
    {
        if (!File.Exists(file_path)) 
        {
            Debug.LogError("Archivo no encontrado: " + file_path);
            return "";
        }
        Debug.Log("Ended Current File: " + endedCurrentFile);
        if(endedCurrentFile) return "";
        
        StreamReader inp_stm = new StreamReader(file_path);
        string inp_ln = "";
        for(int i = 0; i < entryNumber; i++)
        {
            Debug.Log("loop:"+i);
            if (!inp_stm.EndOfStream)
            {
                inp_ln = inp_stm.ReadLine();
                Debug.Log("read line: "+inp_ln);
            }else{
                endedCurrentFile = true;
                inp_ln = "";
            }
        }

        inp_stm.Close();
        return inp_ln;
    }

    
}

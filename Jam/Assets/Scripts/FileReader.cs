using UnityEngine;
using System.IO;
using System.Collections;

public class FileReader : MonoBehaviour
{
    public string file_path;
    public DialogManager dialogManager;

    public int entryNumber;

    public float textSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entryNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Lee la siguiente línea de texto del .txt miembro
    [ContextMenu("readTextFile")]
    public void readTextFile()
    {
        StreamReader inp_stm = new StreamReader(file_path);
        string inp_ln;
        for(int i = 1; i < entryNumber; i++)
        {
            inp_ln = inp_stm.ReadLine();
        }

        if (!inp_stm.EndOfStream)
        {
            inp_ln = inp_stm.ReadLine();
            StartCoroutine(writeToDialog(inp_ln));
        }

        inp_stm.Close();

        entryNumber++;
    }

    // Escribe la cadena de texto en el diálogo caracter a caracter
    IEnumerator writeToDialog(string input)
    {
        string txt = "";
        foreach(char c in input)
        {
            txt += c;
            dialogManager.showDialog(txt);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

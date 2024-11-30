using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    public FileReader fileReader;
    public int currentEntryNumber;
    public int currentScene;
    public float textSpeed;
    public List<string> filePaths;
    public bool writing = false, finishedWriting = false;

    private void Start()
    {
        currentScene = 0;
        currentEntryNumber = 1;
        writing = false;
        finishedWriting = false;
    }

    
    public void showDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogText.text = text; 
    }

    private string getTextFromFile(string file_path, int entryNumber)
    {
        return fileReader.readTextFile(file_path,entryNumber);
    }

    public void nextEntry()
    {
        string file = System.IO.Path.GetFullPath(filePaths[currentScene]);
        Debug.Log("Reading text from file: " + file);
        string text = getTextFromFile(file, currentEntryNumber);
        Debug.Log("Got text: " + text);
        IEnumerator writeToDialogRoutine  = writeToDialog(text);
        if(!writing)
        {
            Debug.Log("Will start writing...");
            StartCoroutine(writeToDialogRoutine);
            finishedWriting = false;
            writing = true;
        }else
        {
            StopAllCoroutines();
            showDialog(text);
            finishedWritingCurrentEntry();
        }
    }

    // Escribe la cadena de texto en el diálogo caracter a caracter
    IEnumerator writeToDialog(string input)
    {
        writing = true;
        string txt = "";
        Debug.Log("Input is " + input);
        foreach(char c in input)
        {
            txt += c;
            showDialog(txt);
            yield return new WaitForSeconds(textSpeed);
        }
        finishedWritingCurrentEntry();
    }

    private void finishedWritingCurrentEntry()
    {
        writing = false;
        finishedWriting = true;
        currentEntryNumber++;
    }
}
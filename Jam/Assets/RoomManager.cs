using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public DialogManager DialogManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DialogManager.deactivate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        Debug.Log("Will load next Scene");
        if (DialogManager.deactivated)
            SceneManager.LoadScene(3);
    }
}

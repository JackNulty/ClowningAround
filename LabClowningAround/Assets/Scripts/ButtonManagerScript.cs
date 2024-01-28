using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    public Button play;
    public Button LevelSelect;
    public Button Quit;

    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Button>();
        LevelSelect = GetComponent<Button>();   
        Quit = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayPress()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitPress()
    {
        Application.Quit();
    }
    public void ONlevelSelectPress()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
GameObject[] g;
    public AudioSource cSound;
    void Start()
    {
        Time.timeScale = 1;
        g = GameObject.FindGameObjectsWithTag("pauseMenu");
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            hideAndshow();
        }
    }

    public void hideAndshow()
    {
        if (Time.timeScale == 1)
        {
            Debug.Log("Pause!");
            Time.timeScale = 0;
            show();
        }
        else if (Time.timeScale == 0)
        {
            Debug.Log("UnPause!");
            Time.timeScale = 1;
            hide();
        }
    }

    public void hide()
    {        
        cSound.PlayOneShot(cSound.clip);  
        foreach (GameObject o in g)
        {
            o.SetActive(false);
        }
    }
    public void show()
    {
        cSound.PlayOneShot(cSound.clip);
        foreach (GameObject o in g)
        {
            o.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit is clicked");
#if UNITY_EDITOR  
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#if UNITY_STANDALONE
        Application.Quit();
#endif
    }
}

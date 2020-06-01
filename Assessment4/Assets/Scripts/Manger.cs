using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manger : MonoBehaviour
{
    private Transform player;
    //public AudioSource ms1;
    //public AudioSource ms2;
    //private int dotNum;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;   
        //display current scene info 
        Debug.Log(MsgReceiver.passInfo);   
    }
    public void LoadFirstLevel()
    {
        DontDestroyOnLoad(this);
        StartCoroutine(ChangeScene());
        //SceneManager.LoadSceneAsync(1);
        //to level 1
    }

    private IEnumerator ChangeScene()
    {
        float waitTime = 1.0f;
        //float waitTime = ms1.clip.length;
        //ms1.PlayOneShot(ms1.clip);

        //not chaging scene yet
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(1);
        sceneLoading.allowSceneActivation = false;

        yield return new WaitForSeconds(waitTime);
        //after playing the sound

        sceneLoading.allowSceneActivation = true;

    }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Debug.Log("StartMenu");
            //GameObject.FindWithTag("QuitButton").GetComponent<Button>().onClick.AddListener(QuitGame);
            //player = GameObject.FindWithTag("Player").transform;
        }
    }
    private IEnumerator QuitScene()
    {
        //float waitTime = ms2.clip.length;
        float waitTime = 1.0f;
        //ms2.PlayOneShot(ms2.clip);

        yield return new WaitForSeconds(waitTime);   
    }
    public void QuitGame()
    {
        //StartCoroutine(QuitScene());
        Debug.Log("Quit is clicked");
#if UNITY_EDITOR  
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#if UNITY_STANDALONE
        Application.Quit();
#endif
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

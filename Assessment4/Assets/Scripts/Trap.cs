using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.name == "MalePlayer")
        {
            MsgReceiver.currentLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(5);
        }

    
    }
}

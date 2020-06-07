using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator mAnimator;
    private bool openDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GameObject.FindGameObjectWithTag("door").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator.GetBool("isOpen"))
        {
           openDoor = true;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && openDoor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

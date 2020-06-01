using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapTrigger : MonoBehaviour
{
    private Animator m_Animator;
    private Animation m_Animation;
    void Start()
    {
        m_Animator = GameObject.FindGameObjectWithTag("fireTrap").GetComponent<Animator>();
        m_Animation = GameObject.FindGameObjectWithTag("fireTrap").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "box")
        {
            //m_Animator.GetComponent<Animator>().enabled = false;
            //m_Animator.GetComponent<Animator>().enabled = true;
            m_Animation.Rewind();
            m_Animator.enabled = false;
            Destroy(gameObject);     
        }

        if (c.name == "MalePlayer")
        {

            SceneManager.LoadSceneAsync(3);
        }

    
    }
}

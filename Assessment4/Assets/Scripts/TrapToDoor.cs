using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapToDoor : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GameObject.FindGameObjectWithTag("door").GetComponent<Animator>();
        mAnimator.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("box"))
        {
            mAnimator.SetBool("isOpen", true);
        }
    }

}

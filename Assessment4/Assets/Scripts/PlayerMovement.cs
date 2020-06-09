using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    Vector2 dest = Vector2.zero;
    Collider2D cor2D;
    private Rigidbody2D r;
    void Start()
    {
        dest = transform.position;
        cor2D = GetComponent<Collider2D>();
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if ((Vector2)transform.position == dest)
        {
    
            if (Input.GetKey(KeyCode.UpArrow) && validMove(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && validMove(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && validMove(Vector2.down))
                dest = (Vector2)transform.position + Vector2.down;
            if (Input.GetKey(KeyCode.LeftArrow) && validMove(Vector2.left))
                dest = (Vector2)transform.position + Vector2.left;
        }
    }

bool validMove(Vector2 dir)
    {
        
        Vector2 pos = transform.position;           
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        
        // if (hit.collider != null && hit.collider != cor2D)
        // {
        //     //AudioSource s = GameObject.FindGameObjectWithTag("collideEffect").GetComponent<AudioSource>();
        //     //s.PlayOneShot(s.clip);
            
        //     Debug.Log(hit.collider);
        //    /* if (hit.collider == GameObject.FindGameObjectWithTag("Coin").GetComponent<BoxCollider2D>())
        //     {
        //         Debug.Log("Destory");
        //         Destroy(hit.collider.gameObject);
        //         return true;
        //     }*/
        //     return false;
            
        // }
        // else        
        return true;
    }

}

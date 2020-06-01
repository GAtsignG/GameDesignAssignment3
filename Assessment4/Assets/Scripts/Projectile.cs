using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public GameObject explosion;
   //public Rigidbody projectile;
   public Transform playerPosition;
   
   public float speed = -4;
   [SerializeField]
   private GameObject[] myPrefabs;  //store projectiles to generate
   int randIndex;
   int tempTimer; 

   private int timer;
   private Vector3 newP;
   private GameObject tempO;

   private GameObject[] projectiles;
   void Start()
   {
       timer = 0;
       tempTimer = 0;
      projectiles = myPrefabs;
      tempO = new GameObject();
   }

   void Update()
    {
        
        timer = (int)Time.time;
        //every 2 second
        if ((timer - tempTimer == 2)){
          //Debug.Log("fire block!");
          tempTimer = timer;        
          newP = new Vector3((playerPosition.position.x + 10f), Random.Range(-7f, 7f)
          , 0);
          var temp =  Instantiate(myPrefabs[Random.Range(0, myPrefabs.Length)],
           newP, Quaternion.identity);
          //tempO.GetComponent<AIMovement>().enabled = true;
          //tempO.GetComponent<PorjectileStop>().enabled = false;
          //tempO.GetComponent<ProjectileDestoryed>().enabled = true;
          Destroy(temp, 5);
          //Debug.Log(tempO.transform.position);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
            //p.velocity = transform.forward * speed;
        }
    }

   void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "MalePlayer")
        {
            //Destroy(c.gameObject);
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(gameObject);
            //SceneManager.LoadSceneAsync(2);
        }

    }
   void generateP()
   {

   }
}

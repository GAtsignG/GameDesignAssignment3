using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Physical : MonoBehaviour
{
    private const float MIN_MOVE_DISTANCE = 0.001f;

    private new Collider2D collider2D;
    private new Rigidbody2D rigidbody2D;
    private ContactFilter2D contactFilter2D;
    private readonly List<RaycastHit2D> raycastHit2DList = new List<RaycastHit2D>();
    private readonly List<RaycastHit2D> tangentRaycastHit2DList = new List<RaycastHit2D>();

public bool grounded = true;
public float jumpPower;
public float jumpHeight = 5f; 
public static bool isJumping = false; 
    private int x_dir = 0;
    private int y_dir = 0;
    public LayerMask layerMask;
    [HideInInspector]
    public Vector2 velocity;


    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (rigidbody2D == null)
            rigidbody2D = gameObject.AddComponent<Rigidbody2D>();

        rigidbody2D.hideFlags = HideFlags.NotEditable;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.simulated = true;
        rigidbody2D.useFullKinematicContacts = false;
        rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigidbody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
        rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody2D.gravityScale = 0;

        contactFilter2D = new ContactFilter2D
        {
            useLayerMask = true,
            useTriggers = false,
            layerMask = layerMask
        };
    }

    private void OnValidate()
    {
        contactFilter2D.layerMask = layerMask;
    }

	private void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown ("space") || Input.GetMouseButtonDown (0)&&grounded==true) {
			GetComponent<Rigidbody2D>().AddForce(transform.up*jumpPower);
			grounded=false;
            //jump
		}
    }

    private void FixedUpdate()
    {
        Movement(velocity * Time.deltaTime * 5f);
    }

    private void Movement(Vector2 deltaPosition)
    {
        // delta x and delta y.
        float dx = Input.GetAxisRaw("Horizontal");
        float dy = Input.GetAxisRaw("Vertical");
        
        float nx = dx + transform.position.x;
        float ny = dy + transform.position.y;
        // 判断下个位置是不是盒子。
        if (isBox(nx, ny))
        {
            // 得到玩家的下下个位置。
            // Next next position.
            float nnx = nx + dx;
            float nny = ny + dy;

            // 判断下下个位置是不是墙或者盒子。
            //if (isBox(nnx, nny) || isWall(nnx, nny)) return;

            // 把盒子移到下个位置。
            GameObject box = getBox(nx, ny);
            box.transform.position = new Vector3(nnx, nny);
            

            // 更新盒子在Map里面的结构。
            //myMap.getPosBoxMap().Remove(myMap.TwoDToOneD(nx, ny));
            //myMap.getPosBoxMap().Add(myMap.TwoDToOneD(nnx, nny), box);
        }

        if (deltaPosition == Vector2.zero)
            return;

        Vector2 updateDeltaPosition = Vector2.zero;

        float distance = deltaPosition.magnitude;
        Vector2 direction = deltaPosition.normalized;

        if (distance <= MIN_MOVE_DISTANCE)
            distance = MIN_MOVE_DISTANCE;

        rigidbody2D.Cast(direction, contactFilter2D, raycastHit2DList, distance);

        Vector2 finalDirection = direction;
        float finalDistance = distance;


        foreach (var hit in raycastHit2DList)
        {
            float moveDistance = hit.distance;

            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.white);
            Debug.DrawLine(hit.point, hit.point + direction, Color.yellow);

            float projection = Vector2.Dot(hit.normal, direction);

            if (projection >= 0)
            {
                moveDistance = distance;
            }
            else
            {
                Vector2 tangentDirection = new Vector2(hit.normal.y, -hit.normal.x);

                float tangentDot = Vector2.Dot(tangentDirection, direction);

                if (tangentDot < 0)
                {
                    tangentDirection = -tangentDirection;
                    tangentDot = -tangentDot;
                }

                float tangentDistance = tangentDot * distance;

                if (tangentDot != 0)
                {
                    rigidbody2D.Cast(tangentDirection, contactFilter2D, tangentRaycastHit2DList, tangentDistance);

                    foreach (var tangentHit in tangentRaycastHit2DList)
                    {
                        Debug.DrawLine(tangentHit.point, tangentHit.point + tangentDirection, Color.magenta);

                        if (Vector2.Dot(tangentHit.normal, tangentDirection) >= 0)
                            continue;

                        if (tangentHit.distance < tangentDistance)
                            tangentDistance = tangentHit.distance;
                    }

                    updateDeltaPosition += tangentDirection * tangentDistance;
                }
            }

            if (moveDistance < finalDistance)
            {
                finalDistance = moveDistance;
            }
        }

        updateDeltaPosition += finalDirection * finalDistance;
        rigidbody2D.position += updateDeltaPosition;
    }
    bool isBox(float x, float y)
    {      
        if(x == GameObject.FindGameObjectWithTag("box").transform.position.x &&
        y == GameObject.FindGameObjectWithTag("box").transform.position.y )
        {
         Debug.Log("Box: " + GameObject.FindGameObjectWithTag("box").transform.position);
          return true;
        }

        else
        return false;     
       
    }

    GameObject getBox(float x, float y)
    {
       
        return GameObject.FindGameObjectWithTag("box");
    }


private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.collider.tag == "Ground")
    {
       isJumping = false;
    }

    if (collision.collider.tag == "box")
    {
       Vector3 dir = new Vector3(velocity.x, velocity.y);
       collision.collider.transform.position = collision.collider.transform.position + dir;
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.collider.tag == "Ground")
    {
        isJumping = true;
    }
}
}

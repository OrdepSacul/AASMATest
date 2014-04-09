using UnityEngine;
using System.Collections;

public class Reactive : MonoBehaviour
{



    //private ResourceSpawner resScript = GameObject.Find("ResourceSpawner").GetComponent<ResourceSpawner>();
    public int moveSpeed = 2;
    public float wanderRadius = 2.0f;

    private enum Status {Wander, PickResource, PickBomb, Fight};

    private GameObject selectedTarget;
    private Vector3 moveToward, currentPosition, moveDirection;
    private Status currentStatus;


    // Use this for initialization
    void Start()
    {
        currentPosition = transform.position;
        currentStatus = Status.Wander;
        moveToward = GetRandomDestination(wanderRadius);
        moveDirection = moveToward - currentPosition;
        moveDirection.Normalize();
    }


    //only works on non-trigger colliders
    void OnCollisionEnter2D(Collision2D other)
    {

        //Debug.Log("Collision!");
        if (other.collider.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameObject.Find("ResourceSpawner").GetComponent<ResourceSpawner>().RegisterPickup(this.tag);
        }
        else if (other.collider.tag == "Bomb")
        {
            //pick it up
        }
        else if (other.collider.tag == "Blue" && this.tag == "Blue")
        {
            //assist
        }
        else if (other.collider.tag == "Red" && this.tag == "Blue")
        {
            //fight
        }
        else if (other.collider.tag == "Wall")
        {
            Debug.Log("HIT A WALL!");
            if (currentStatus == Status.Wander)
            {
                moveToward = GetRandomDestination(wanderRadius);
                moveDirection = moveToward - currentPosition;
                moveDirection.Normalize();
            }
        }

    }


    //only works on trigger colliders
    void OnTriggerEnter2D(Collider2D other)
    {
        //check tag and act accordingly
        if (other.collider2D.tag == "Coin")
        {
            //Debug.Log("Saw a coin!!");
        }
        else if (other.collider2D.tag == "Blue" && this.tag == "Blue")
        {
            //Debug.Log("BROOOO!!");
        }
        else if (other.collider2D.tag == "Red" && this.tag == "Blue")
        {
            //Debug.Log("ENEMYY!!!");
        }
        else if (other.collider2D.tag == "CaptureA")
        {
            //Debug.Log("Capture point A!!!");
        }
        else if (other.collider2D.tag == "CaptureB")
        {
            //Debug.Log("Capture point B!!!");
        }
        else if (other.collider2D.tag == "Bomb")
        {
            //Debug.Log("Bomb!!!");
        }
    }

    Vector3 GetRandomDestination(float radius) {

        var randX = (Random.value * 2.0f - 1) * radius;
        var randY = (Random.value * 2.0f - 1) * radius;

        Debug.Log((randX + currentPosition.x) + " - " + (randY + currentPosition.y));
        return new Vector3(randX + currentPosition.x, randY + currentPosition.y, 0.0f);

    }


    // Update is called once per frame
    void Update()
    {

        if (currentStatus == Status.Wander)
        {

            currentPosition = transform.position;

            var distance = moveToward - currentPosition;
            //Debug.Log(distance.magnitude);

            if (distance.magnitude < 0.2f)
            {
                moveToward = GetRandomDestination(wanderRadius);
                moveDirection = moveToward - currentPosition;
                moveDirection.Normalize();
            }

            Vector3 target = moveDirection * moveSpeed + currentPosition;
            transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);

        }

        


    }
}

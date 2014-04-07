using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {


    private Vector3 moveDirection;

    private int moveSpeed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //this.gameObject.transform.Rotate(new Vector3(0,0,1), 30.0f*Time.deltaTime, Space.Self);


        // 1
        Vector3 currentPosition = transform.position;
        // 2
        if (Input.GetButton("Fire1"))
        {
            // 3
            Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 4
            moveDirection = moveToward - currentPosition;
            moveDirection.z = 0;
            moveDirection.Normalize();
        }




        Vector3 target = moveDirection * moveSpeed + currentPosition;
        transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //This makes us move 5 meter per second.
    //Making variables public makes us see them in the inspector! Really cool.
    public float speed = 5.0f;
    public float horizontalInput;

	// Use this for initialization
	void Start () {
        Debug.Log("Enter Player Start Function");
        Debug.Log("Player is " + name);
        Debug.Log("x pos: " + transform.position.x);

        transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Updating Values for Player");

        // This is going to return a negative value for left key
        // 0 if we do nothing.
        // This is going to return a positive value for a right key
        float horizontalInput = Input.GetAxis("Horizontal"); //x
        float verticalInput = Input.GetAxis("Vertical");

        // Move our object using translate. (Vector is x,y,z) our speed multiplies 
        // 5 commutatively. This is why we move right and left.
        // transform.Translate(Vector3.right * Time.deltaTime * speed);//Delta time smooths out the frame.
        // The Foil method an operation that tells us to move right or left depending on the Vector
        // value!

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        Debug.Log(horizontalInput);

        //upper bounds
        if(transform.position.y > 0) {
            //Since we just want to change y we keep x
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        //lower bounds
        if(transform.position.y < -4.2f) {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //left bounds
        if(transform.position.x < -8.0f) {
            transform.position = new Vector3(-8.0f, transform.position.y, 0);
        }
        //right bounds
        if(transform.position.x > 8.0) {
            transform.position = new Vector3(8.0f, transform.position.x, 0);
        }


	}
}

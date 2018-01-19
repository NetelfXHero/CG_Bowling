using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float DistanceBehind = 5;
    public float DistanceUp = 5;
    public GameController gameController;

	// Use this for initialization
	void Start () {
        var position = this.transform.GetChild(0).transform.position;
        position.y = DistanceUp;
        position.z = DistanceBehind;
        this.transform.GetChild(0).transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
        //start at the position of the bowling ball
        var position = gameController.ball.transform.position;
        this.transform.position = position; //move camera rig
        //make sure camera looks at ball
        this.transform.GetChild(0).LookAt(gameController.ball.transform);

        if (Input.GetMouseButton(1))
        {
            // FREE LOOK with mouse!
            Cursor.lockState = CursorLockMode.Locked;
            var horizontal = Input.GetAxis("Mouse X");
            var rotation = this.transform.eulerAngles; //get current rotation of rig
            Debug.Log(horizontal);
            rotation.y += horizontal;                  //modify with mouse input
            this.transform.eulerAngles = rotation;     //set rotation of rig to modified rotation 

        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject BowlingPrefab;
    public Aimer aimer;
    public Camera cam;
    public float aimDistance;
    public float maxPower;
    public float jumpForce;
    public float startedMove;

    public bool IsMoving { get; private set; }

    // Use this for initialization fffffffffffffffffffffffffffffffffffffffff
	void Start () {
        cam = FindObjectOfType<Camera>();
        startedMove = float.MaxValue;

        aimer.gameObject.SetActive(true);
        aimer.transform.position = new Vector3(0, 0.2f, 0);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Raycast collided with: " + hit.collider.name);
            Transform objectHit = hit.transform;

            // aimer position = ball position + normalized vector between ball and click
            var distance = hit.point - transform.position;
            distance.Normalize(); // make sure lenght is 1
            distance *= aimDistance;
            var targetPos = transform.position + distance;
            aimer.transform.position = new Vector3(targetPos.x, aimer.transform.position.y, targetPos.z);
        }
        
        if (IsMoving 
            && GetComponent<Rigidbody>().velocity.magnitude < 0.2f
            && Time.time - startedMove > 1)
        {
            var ball = Instantiate(BowlingPrefab, transform.position, Quaternion.identity);
            var gc = GameObject.FindObjectOfType<GameController>();
            gc.ball = ball.GetComponent<Ball>();
            Destroy(gameObject); //delete from scene!
        }
    }

    public void Throw(float power)
    {
        if (IsMoving) return; //don't do anything if we're already moving!!!
        aimer.gameObject.SetActive(false);
        var direction = aimer.transform.position - transform.position;
        direction.Normalize();
        direction *= power * maxPower;
        GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        IsMoving = true;
        startedMove = Time.time; //Time.time is seconds since game launch
    }

    public void Jump()
    {
        if (IsMoving)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
        }
    }
    //Hei
}

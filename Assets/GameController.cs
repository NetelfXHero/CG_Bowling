using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // takk Kenneth!

public class GameController : MonoBehaviour {

    public GameObject pins;
    public Ball ball;
    public float chargeSeconds = 5;
    public string loadLevel;

    private float pressedTime;

    void Start()
    {
        SceneManager.LoadScene(loadLevel, LoadSceneMode.Additive);
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(pins, Vector3.zero, Quaternion.identity);
        }
        
        // når vi presser mus så starter vi en timer
        if (Input.GetMouseButtonDown(0))
        {
            pressedTime = Time.time;
        }
        if (Input.GetMouseButton(0) && pressedTime > 0)
        {
            var color = Color.Lerp(Color.yellow, Color.red, (Time.time - pressedTime) / chargeSeconds);
            ball.aimer.SetAimColor(color);
        }
        if (Input.GetMouseButtonUp(0))
        {
            ball.aimer.SetAimColor(Color.yellow);
            float power = (Time.time - pressedTime) / chargeSeconds;
            if (power > 1)
            {
                Debug.Log("Dun Goofed!!");
            } else
            {
                ball.Throw(power);
            }
            pressedTime = -1; // acts as a flag for color morph
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.Jump();
        }
        if (Input.GetKeyDown(KeyCode.T)) ball.Throw(1); //DEBUG CODE
        // tiden mellom X sekunder bestemmer fargen mellom gul og rød
    }
}

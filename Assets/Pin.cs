using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public AudioClip hitSound;
    public AudioSource audioSource;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        // check to see if we collided with the Ball
        if (other.GetComponent<Ball>() != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}

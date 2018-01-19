using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSpawn : MonoBehaviour {

    public string objectName;
    public GameObject prefabToSpawn;
    
	void Start () {
        var spawnedObject = GameObject.Find(objectName);

        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity); //TODO: rotation?
        } else
        {
            spawnedObject.transform.position = this.transform.position;
        }
        // Med denne koden så kan du rotere spawnen til Bowling Pinnen.
        spawnedObject.transform.rotation = this.transform.rotation;
        var gc = GameObject.FindObjectOfType<GameController>();

        // hvis vi lager en bowlingball, sørg for at gamecontroller vet om den!
        var ball = spawnedObject.GetComponent<Ball>();
        if (ball != null)
        {
            gc.ball = ball; // pek gamecontroller til vår nye bowlingball!
        }

        //Destroy(gameObject); // fjern kuben fra scenen, ser ikke særlig pen ut
    }
}

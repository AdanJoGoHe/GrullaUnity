using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public GameObject player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var rot = transform.rotation;
        rot.y = 180;
        this.transform.position = new Vector3(player.transform.position.x,2.3f , this.transform.position.z);

    }
}

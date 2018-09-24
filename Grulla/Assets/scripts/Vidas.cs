using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour {
    SpriteRenderer spriteR;
    public GameObject vida;
    int vidaNumero = 1;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            var vidaTemp = Instantiate(vida,  new Vector3(i-4, 1, 0), Quaternion.identity);
            vidaTemp.name = ("vida" + i);
        }
            
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

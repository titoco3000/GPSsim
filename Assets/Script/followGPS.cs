using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followGPS : MonoBehaviour {

    public GameObject followed;
    public Vector2 addendo;
    private Vector2 posicao;

    // Use this for initialization
    void Update () {
        posicao = Camera.main.WorldToScreenPoint(followed.transform.position);
        posicao += addendo;
        transform.position = posicao;
    }
	
	// Update is called once per frame
	
}

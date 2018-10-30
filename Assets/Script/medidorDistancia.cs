using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medidorDistancia : MonoBehaviour {

    [SerializeField]
    public Transform Emitter;

    public float distanciaDoGPS = 0f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider);
        distanciaDoGPS = Vector2.Distance(collider.transform.position, Emitter.position);
        
    }

}

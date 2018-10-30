using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manterObj : MonoBehaviour {

    public float distancia_A;
    public float distancia_B;
    public float distancia_C;

    public Vector3 posicao;
    // Use this for initialization
    private static GameObject obj;
    void Awake()
    {
        DontDestroyOnLoad(this.transform);

        if (obj == null)
        {
            obj = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
            //DestroyObject(this.transform);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

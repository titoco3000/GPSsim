using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{

    [SerializeField]
    public Camera video;

    public GameObject colocado;
    private bool actionDone = false;
    public GameObject fundo;
    public gameManager gameManager;
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !actionDone)
        {
            Debug.Log(Input.mousePosition);
            Vector3 p = Input.mousePosition;
            p.z = 2;
            Vector3 pos = Camera.main.ScreenToWorldPoint(p);
            colocado.transform.position = pos;
            gameManager.radarPos = pos;
            actionDone = true;
            fundo.SetActive(false);
            
        }
    }
    void retornarFundo()
    {
        fundo.SetActive(true);
    }
}


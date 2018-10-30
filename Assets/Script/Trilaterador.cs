using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trilaterador : MonoBehaviour {


    public GameObject satelite_A;
    public float distancia_A = 999999;

    public GameObject satelite_B;
    public float distancia_B = 999999;

    public GameObject satelite_C;
    public float distancia_C = 999999;

    public Vector2 resposta;

    private bool trilaterado;
    //public 

    // Use this for initialization
    void Start()
    {
        distancia_A = 999999;
        distancia_B = 999999;
        distancia_C = 999999;
        


    }

    void Update()
    {
        if(distancia_A != 999999 && distancia_B != 999999 && distancia_C != 999999 && !trilaterado)
        {
            trilaterado = true;
            trilaterar(satelite_A.transform.position, distancia_A, satelite_B.transform.position, distancia_B, satelite_C.transform.position, distancia_C);
        }
    }
    void trilaterar(Vector2 posA, float distanciaA,  Vector2 posB, float distanciaB, Vector2 posC, float distanciaC)
    {
        
        Debug.Log("Trilaterando...");
        Debug.Log("{"+((-2 * posA.x) + (2 * posB.x)) + " *x +(" + ((-2 * posA.y) + (2 * posB.y)) + " *y ) =" + (Mathf.Pow(distanciaA, 2) - Mathf.Pow(distanciaB, 2) - Mathf.Pow(posA.x, 2) + Mathf.Pow(posB.x, 2) - Mathf.Pow(posA.y, 2) + Mathf.Pow(posB.y, 2)) 
            + "\n" +
            "{" + ((-2 * posB.x) + (2 * posC.x)) + " *x +( " + ((-2 * posB.y) + (2 * posC.y)) + " *y ) =" + (Mathf.Pow(distanciaB, 2) - Mathf.Pow(distanciaC, 2) - Mathf.Pow(posB.x, 2) + Mathf.Pow(posC.x, 2) - Mathf.Pow(posB.y, 2) + Mathf.Pow(posC.y, 2))

            );
        float numDeXDaPrimeira = (-2 * posA.x) + (2 * posB.x);
        float numDeYDaPrimeira = (-2 * posA.y) + (2 * posB.y);
        float resultadoDaPrimeira = Mathf.Pow(distanciaA, 2) - Mathf.Pow(distanciaB, 2) - Mathf.Pow(posA.x, 2) + Mathf.Pow(posB.x, 2) - Mathf.Pow(posA.y, 2) + Mathf.Pow(posB.y, 2);

        float numDeXDaSegunda = (-2 * posB.x) + (2 * posC.x);
        float numDeYDaSegunda = (-2 * posB.y) + (2 * posC.y);
        float resultadoDaSegunda = Mathf.Pow(distanciaB, 2) - Mathf.Pow(distanciaC, 2) - Mathf.Pow(posB.x, 2) + Mathf.Pow(posC.x, 2) - Mathf.Pow(posB.y, 2) + Mathf.Pow(posC.y, 2);

        float y = (resultadoDaSegunda - ((numDeXDaSegunda * resultadoDaPrimeira) / numDeXDaPrimeira)) / (numDeYDaSegunda - ((numDeXDaSegunda * numDeYDaPrimeira) / numDeXDaPrimeira));
        float x = (resultadoDaPrimeira - (numDeYDaPrimeira * y)) / numDeXDaPrimeira;
        resposta = new Vector2(x, y);
        Debug.Log("y= " + y + "\n X= "+ x );
    }

    void Sistema2x2(string equation)
    {

    }


}

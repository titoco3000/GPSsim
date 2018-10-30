using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour
{
    public gameManager gameManager;
    private int gameSpeed;

    public float maxSize;
    private float growFactor;
    public float emmiterSpeed;

    public float waitTime;

    public Transform bolaGrande;
    public Transform bolaPequena;

    private Vector3 bolaGrande_originalScale;
    private Vector3 bolaPequena_originalScale;

    //private Renderer render;

    public bool jaEmitiu = false;

    void Start()
    {
        

        bolaGrande_originalScale = bolaGrande.localScale;
        bolaPequena_originalScale = bolaPequena.localScale;
        //render = bolaGrande.GetComponent<Renderer>();
    }
    void Update()
    {

            
    }
    public void Iniciar(float time)
    {
        bolaGrande.GetComponent<CircleCollider2D>().enabled = true;
        Invoke("Emitir", time);
    }
    void Emitir()
    {
        if (!jaEmitiu)
        {

            Debug.Log(transform.name + " iniciando...");
            StartCoroutine(Scale());
            jaEmitiu = true;
        }
    }

    IEnumerator Scale()
    {
        float timer = 0;


        growFactor = emmiterSpeed *(gameManager.gameSpeed/ 100);
        // we scale all axis, so they will have the same value, 
        // so we can work with a float instead of comparing vectors
        bolaGrande.localScale = bolaGrande_originalScale;
        bolaPequena.localScale = bolaPequena_originalScale;
        while (maxSize > bolaGrande.localScale.x)
        {
            timer += Time.deltaTime;
            bolaGrande.localScale += new Vector3(1, 1, 0) * Time.deltaTime * emmiterSpeed * (gameManager.gameSpeed / 100);
            bolaPequena.localScale += new Vector3(1, 1, 0) * Time.deltaTime * emmiterSpeed * (gameManager.gameSpeed / 100);
            //growFactor *= 1.005f;
            yield return null;
        }
        // reset the timer

        yield return new WaitForSeconds(0);

        timer = 0;
        if (1 < bolaGrande.localScale.x)
        {
            timer += Time.deltaTime;
            growFactor = emmiterSpeed;
            bolaGrande.localScale = new Vector3(0.00768f, 0.00768f, bolaGrande.localScale.z);
            bolaPequena.localScale = new Vector3(1, 1, -1);
            yield return null;
        }

        timer = 0;
        yield return new WaitForSeconds(0);

    }
    
}

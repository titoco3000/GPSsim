 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aro_emmiter : MonoBehaviour {
    public Transform aro;
    public Transform colliders;
    public float Raio;
    public float emmiterSpeed;
    public level2Manager level2M;

    private bool jaAcabou;
	// Use this for initialization
	void Start () {
        //StartCoroutine(Scale());
	}

    public void Emitir(float dist)
    {

        Raio = dist;
        StartCoroutine(Scale());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Scale()
    {
        Debug.Log("scale"+ Raio);
        float timer = 0;


        // we scale all axis, so they will have the same value, 
        // so we can work with a float instead of comparing vectors
        //aro.localScale = bolaGrande_originalScale;
        //olaPequena.localScale = bolaPequena_originalScale;
        while (Raio > aro.localScale.x)
        {
            timer += Time.deltaTime;
            aro.localScale += new Vector3(1, 1, 0) * Time.deltaTime * emmiterSpeed ;
            //colliders.localScale += new Vector3(1, 1, 0) * Time.deltaTime * emmiterSpeed;
            //bolaPequena.localScale += new Vector3(1, 1, 0) * Time.deltaTime * emmiterSpeed * (gameManager.gameSpeed / 100);
            //growFactor *= 1.005f;
            yield return null;
        }
        if (!jaAcabou)
        {
            level2M.arosProntos++;
            jaAcabou = true;
        }
        // reset the timer

        yield return new WaitForSeconds(0);

        /*timer = 0;
        if (1 < bolaGrande.localScale.x)
        {
            timer += Time.deltaTime;
            growFactor = emmiterSpeed;
            bolaGrande.localScale = new Vector3(0.00768f, 0.00768f, bolaGrande.localScale.z);
            bolaPequena.localScale = new Vector3(1, 1, -1);
            yield return null;
        }
        */
        timer = 0;
        yield return new WaitForSeconds(0);

    }

}

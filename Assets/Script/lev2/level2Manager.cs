using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2Manager : MonoBehaviour {

    private aro_emmiter emmiter1;
    private aro_emmiter emmiter2;
    private aro_emmiter emmiter3;
    public float waitTime = 2;
    public float addendo = 0.3f;
    public bool iniciarDestaque = false;
    public int arosProntos = 0;

    private bool destaqueColocado = false;


    // Use this for initialization
    void Start () {
        emmiter1 = GameObject.Find("Radar1").GetComponent<aro_emmiter>();
        emmiter2 = GameObject.Find("Radar2").GetComponent<aro_emmiter>();
        emmiter3 = GameObject.Find("Radar3").GetComponent<aro_emmiter>();

        emmiter1.Emitir(GameObject.Find("ObjConstante").GetComponent<manterObj>().distancia_A+addendo);
        Invoke("Emitir2", waitTime);
        Invoke("Emitir3", waitTime *2 );




    }
    void Update()
    {
        if(arosProntos >= 3 && !destaqueColocado)
        {
            Invoke("InstanciarSeta", 1.5f);

        }
        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(0);

    }
    void InstanciarSeta()
    {
        GameObject destaque = Instantiate(Resources.Load("pontoConectado") as GameObject);
        destaque.transform.position = GameObject.Find("ObjConstante").GetComponent<manterObj>().posicao;
    }
    void Emitir2()
    {
        Debug.Log("iniciando emissao 2");
        emmiter2.Emitir(GameObject.Find("ObjConstante").GetComponent<manterObj>().distancia_B+addendo);
    }
    void Emitir3()
    {
        emmiter3.Emitir(GameObject.Find("ObjConstante").GetComponent<manterObj>().distancia_C+addendo);
    }

}

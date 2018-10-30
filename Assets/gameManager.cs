using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public Trilaterador trilaterador;
    private manterObj manterOBJ;
    public GameObject PainelResposta;
    public Animator mostrarPainel;
    public GameObject fundo;

    public int gameSpeed = 100;
    private int vezesApertadas = 0;
    public float waitime;


    private GameObject radar1;
    private GameObject radar2;
    private GameObject radar3;

    public Vector3 radarPos;

    // Use this for initialization
    void Start () {
        radar1 = GameObject.Find("Radar1");
        radar2 = GameObject.Find("Radar2");
        radar3 = GameObject.Find("Radar3");
        manterOBJ = GameObject.Find("ObjConstante").GetComponent<manterObj>();
    }
	
	// Update is called once per frame
	void Update () {
        
        manterOBJ.distancia_A = trilaterador.distancia_A;
        manterOBJ.distancia_B = trilaterador.distancia_B;
        manterOBJ.distancia_C = trilaterador.distancia_C;
        if(trilaterador.distancia_A != 999999 && trilaterador.distancia_B != 999999 && trilaterador.distancia_C != 999999)
        {
            manterOBJ.posicao = radarPos;
            PainelResposta.GetComponentInChildren<Text>().text = "X = " + Mathf.Round( trilaterador.resposta.x) + " \n \n " +"Y = " + Mathf.Round(trilaterador.resposta.y);
            mostrarPainel.Play("mostrarResposta");
            fundo.SetActive(true);
            fundo.GetComponent<indicatorLines>().coord = new Vector2(Mathf.Round(trilaterador.resposta.x), Mathf.Round(trilaterador.resposta.y));
        }

        if (Input.GetKeyDown("r"))
            SceneManager.LoadScene(0);


        if (Input.GetMouseButtonDown(0))
        {
            vezesApertadas++;
            if (vezesApertadas == 1)
            {
        
                radar1.GetComponent<Emmiter>().Iniciar(0);
                radar2.GetComponent<Emmiter>().Iniciar(waitime / (gameSpeed/100));
                radar3.GetComponent<Emmiter>().Iniciar(waitime *2 / (gameSpeed/100));

            }
            else if (vezesApertadas == 2)
            {
                if(trilaterador.distancia_A == 999999 || trilaterador.distancia_B == 999999 || trilaterador.distancia_C == 999999)
                {
                    gameSpeed = 1000;
                    radar2.GetComponent<Emmiter>().Iniciar(waitime / (gameSpeed / 100));
                    radar3.GetComponent<Emmiter>().Iniciar(waitime * 2 / (gameSpeed / 100));
                }
                    


            }
            else if (vezesApertadas >= 3 && trilaterador.distancia_A != 999999 && trilaterador.distancia_B != 999999 && trilaterador.distancia_C != 999999)
            {

                SceneManager.LoadScene(1);
            }



        }

    }
}

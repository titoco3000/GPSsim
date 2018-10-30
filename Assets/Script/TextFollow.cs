using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TextFollow : MonoBehaviour
{
    private gameManager gameManager;

    public GameObject followed;
    private AudioSource audioSRC;
    public Vector2 addendo;
    public Text Paragrafo;
    private Vector2 posicao;
    private medidorDistancia MD;
    private bool emitiu = false;
    private string textoAtual = "";
    public Trilaterador trila;
    public string nomeDesteRadar;

    // Update is called once per frame
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();

        posicao = Camera.main.WorldToScreenPoint(followed.transform.position);
        posicao += addendo;
        transform.position = posicao;

        MD = followed.GetComponent<medidorDistancia>();
        audioSRC = GetComponent<AudioSource>();
    }
    void Update()
    {
        if( MD.distanciaDoGPS != 0 && !emitiu )
        {
            emitiu = true;
            StartCoroutine(MostrarTexto(MD.distanciaDoGPS.ToString()));
        }

    }
    IEnumerator MostrarTexto( string texto)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            audioSRC.Play();
            textoAtual += texto[i];
            Paragrafo.text = textoAtual;
            
            yield return new WaitForSeconds(0.2f / (gameManager.gameSpeed / 100));
        }
        yield return new WaitForSeconds(1f);
        if (nomeDesteRadar == "A") { trila.distancia_A = MD.distanciaDoGPS; }
        else if(nomeDesteRadar == "B") { trila.distancia_B = MD.distanciaDoGPS; }
        else if (nomeDesteRadar == "C") { trila.distancia_C = MD.distanciaDoGPS; }
        
        yield return null;
    }
}

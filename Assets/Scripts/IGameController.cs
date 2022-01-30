using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IGameController : MonoBehaviour
{
    public Text TextVerduras;
    public Text TextVidas;
    public GameObject winText;
    public GameObject loseText;
    public GameObject continuar;
    public GameObject exit;

    private bool boolVerduras;

    private int count;
    private int countVida;

    void Start()
    {
        count = 0; 
        countVida = 3;
        SetCountText();
        SetCountVidaText();
        winText.SetActive(false);
        loseText.SetActive(false);
        exit.SetActive(false);
        continuar.SetActive(false);
        boolVerduras = false;
    }

    public void Punto()
    {
        count++;
        SetCountText();
    }

    public void SetCountText()
    {
        TextVerduras.text = ("Verduras: " + count.ToString() + " / 10");

        if (count >= 10)
        {
            winText.SetActive(true);
            Time.timeScale = 0;

            continuar.SetActive(true);

            boolVerduras = true;
        }
    }
    public void SetCountVidaText()
    {
        TextVidas.text = ("Vidas: " + countVida.ToString());

        if (countVida <= 0)
        {
            loseText.SetActive(true);
            Time.timeScale = 0;

            exit.SetActive(true);
        }
    }

    public void Descontar()
    {
        countVida--;
        SetCountVidaText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerto : MonoBehaviour
{
    public PlayerControl playerControl;

    void Start()
    {
        playerControl.OnDeath += CambiarAPantallaMuerte;
    }
   
    void CambiarAPantallaMuerte()
    {
        Debug.Log("Cambiando a la pantalla de muerte");
        SceneManager.LoadScene("Muerto");
    }
}

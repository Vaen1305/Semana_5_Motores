using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerControl : MonoBehaviour
{

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Nivel 1");
    }
    public void EscenaInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PLAYER"))
        {
            SceneManager.LoadScene("Nivel 2");
        }
        if (other.gameObject.CompareTag("Player 2"))
        {
            SceneManager.LoadScene("Final");
        }
    }
}

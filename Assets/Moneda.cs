using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class Puntaje : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;
    public PlayerControl playerControl;
    private int puntaje = 0;
    public Action<int> OnCoinCollected;

    private void Awake()
    {
        OnCoinCollected += IncrementarPuntaje;
    }

    private void IncrementarPuntaje(int puntos)
    {
        puntaje += puntos;
        ActualizarPuntaje();
    }

    private void ActualizarPuntaje()
    {
        textoPuntaje.text = "Puntaje: " + puntaje;
    }
}


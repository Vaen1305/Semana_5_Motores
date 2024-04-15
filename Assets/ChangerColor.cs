using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorChanger : MonoBehaviour
{
    private SpriteRenderer characterSprite;
    void Awake()
    {
        characterSprite = GetComponent<SpriteRenderer>();
    }

    public void ChangerColor(Color newColor)
    {
        characterSprite.color = newColor;
    }
}

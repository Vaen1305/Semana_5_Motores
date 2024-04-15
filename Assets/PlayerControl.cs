using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using System.Collections.Concurrent;


public class PlayerControl : MonoBehaviour
{
    public Slider BarraVida;
    public int vida = 10;
    public int color;
    private int speed = 5;
    private int jumpForce = 5;
    private float moveInput;
    private bool salto = true;
    private bool isGroun;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Rigidbody2D _compRigidbody;
    private SpriteRenderer _compSpriteRenderer;
    public int extraJumpValue;
    public Puntaje puntajeScrip;

    public int extraJumps;
    public Action<int> OnLifeUpdated;
    public Action OnDeath;



    private void Start()
    {
        OnLifeUpdated += ActualizarVida;
    }


    void Awake()
    {
        extraJumps = extraJumpValue;
        _compRigidbody = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isGroun == true)
        {
            extraJumps = extraJumpValue;
        }
        /*if (isGroun || extraJumps >0)
        {
            _compRigidbody.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }*/
    }
    void FixedUpdate()
    {
        isGroun = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
         
        //moveInput = Input.GetAxis("Horizontal");
        _compRigidbody.velocity = new Vector2(moveInput * speed, _compRigidbody.velocity.y);

        if (salto == false && moveInput > 0)
        {
            Salto();
        }
        else if (salto == true && moveInput < 0)
        {
            Salto();
        }
    }
    
    public void OnMovement(InputAction.CallbackContext contex)
    {
        moveInput = contex.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            Debug.Log("Pressed");
            if (isGroun || extraJumps > 0)
            {
                _compRigidbody.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            
        }
    }
    public void ChangerColorRed(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            gameObject.GetComponent<SpriteRenderer>();
            _compSpriteRenderer.color = Color.red;
            color = 1;
        }
    
    }
    public void ChangerColorBlue(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            gameObject.GetComponent<SpriteRenderer>();
            _compSpriteRenderer.color = Color.blue;
            color = 2;
        }

    }
    public void ChangerColorWhite(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            gameObject.GetComponent<SpriteRenderer>();
            _compSpriteRenderer.color = Color.white;
            color = 3;
        }

    }
    public void ChangerColorGreen(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            gameObject.GetComponent<SpriteRenderer>();
            _compSpriteRenderer.color = Color.green;
            color = 4;
        }

    }
    public void ChangerColoYellow(InputAction.CallbackContext contex)
    {
        if (contex.performed)
        {
            gameObject.GetComponent<SpriteRenderer>();
            _compSpriteRenderer.color = Color.yellow;
            color = 5;
        }

    }
    public void ChangeColorToRed()
    {
        _compSpriteRenderer.color = Color.red;
        color = 1;
    }
    public void ChangeColorToBlue()
    {
        _compSpriteRenderer.color = Color.blue;
        color = 2;
    }
    public void ChangeColorToWhite()
    {
        _compSpriteRenderer.color = Color.white;
        color = 3;
    }
    public void ChangeColorToGreen()
    {
        _compSpriteRenderer.color = Color.green;
        color = 4;
    }
    public void ChangeColorToYellow()
    { 
        _compSpriteRenderer.color = Color.yellow;
        color = 5;
    }
    void Salto()
    {
        salto = !salto;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void ActualizarVida(int cantidad)
    {

        vida += cantidad;
        BarraVida.value = vida;

        if (vida <= 0)
        {
            Debug.Log("Invocando evento OnDeath");
            OnDeath?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Rojo")
        {
            if (color == 1)
            {

            }
            else
            {
                OnLifeUpdated?.Invoke(-1);
                BarraVida.value = vida;
                CinemaChineCamara.Instance.Movicamara(5f, .1f);
            }
        }
        if (collision.tag == "Azul")
        {
            if (color == 2)
            {

            }
            else
            {
                OnLifeUpdated?.Invoke(-1);
                BarraVida.value = vida;
                CinemaChineCamara.Instance.Movicamara(5f, .1f);

            }
        }
        if (collision.tag == "Blanco")
        {
            if (color == 3)
            {

            }
            else
            {
                OnLifeUpdated?.Invoke(-1);
                BarraVida.value = vida;
                CinemaChineCamara.Instance.Movicamara(5f, .1f);

            }
        }
        if (collision.tag == "Amarillo")
        {
            if (color == 5)
            {

            }
            else
            {
                OnLifeUpdated?.Invoke(-1);
                BarraVida.value = vida;
                CinemaChineCamara.Instance.Movicamara(5f, .1f);

            }
        }
        if (collision.tag == "Verde")
        {
            if (color == 4)
            {

            }
            else
            {
                OnLifeUpdated?.Invoke(-1);
                BarraVida.value = vida;
                CinemaChineCamara.Instance.Movicamara(5f, .1f);
            }
        }
        if (collision.tag == "Moneda")
        {
            puntajeScrip.OnCoinCollected(10); 
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Vida")
        {
            OnLifeUpdated?.Invoke(1);
            Destroy(collision.gameObject);
        }
    }
}
 
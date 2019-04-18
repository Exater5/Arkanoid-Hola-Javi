﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceBarra : MonoBehaviour {
    GameObject jugador;
    public float magnitud = 0.2f;
    SpriteRenderer sr;
    public float duracion = 10f;
    int contadorColisiones = 0;
    public static bool reducido = false;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ++contadorColisiones;
            jugador = col.gameObject;
            if(contadorColisiones == 1 && reducido == false)
            {
                col.gameObject.transform.localScale -= new Vector3(magnitud, 0, 0);
                Invoke("Crece", duracion);
                sr.enabled = false;
                Movimiento.bordeDerecho = Movimiento.bordeDerecho + 0.7f;
                Movimiento.bordeIzquierdo = Movimiento.bordeIzquierdo - 0.7f;
                reducido = true;
            }
 
        }
    }


    void Crece()
    {
        jugador.transform.localScale += new Vector3(magnitud, 0, 0);
        Movimiento.bordeDerecho = Movimiento.bordeDerecho - 0.7f;
        Movimiento.bordeIzquierdo = Movimiento.bordeIzquierdo + 0.7f;
        Destroy(gameObject);
        reducido = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackAttack : MonoBehaviour
{
    [SerializeField] Rigidbody shellPrefab; // referencia al prefab de la bala, es mas optimo coger solo el Rigidbody
    [SerializeField] Transform posShell; // referecia al gameobject vacío que representa la posición de salida de la bala
    [SerializeField] float launchForce;
    [SerializeField] AudioSource audioSource; // hace referencia al componente AudioSource que lleva el objeto posShell

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Lauch();
    }

    void Lauch()
    {
        Rigidbody cloneShellPrefab = Instantiate(shellPrefab, posShell.position, posShell.rotation);
        audioSource.Play();
        cloneShellPrefab.velocity = posShell.forward * launchForce;
    }
}

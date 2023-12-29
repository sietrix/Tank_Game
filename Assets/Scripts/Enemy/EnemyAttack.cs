using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Rigidbody shellEnemyPrefab; // referencia al prefab de la bala, es mas optimo coger solo el Rigidbody
    [SerializeField] Transform posShell; // referecia al gameobject vacío que representa la posición de salida de la bala
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float launchForce;
    // Factor para controlar la fuerza de lanzamiento en función de la distancia
    [SerializeField] float factorLauchForce;

    float timer;

    Ray ray;
    RaycastHit hit;
    float distance;

    void Start()
    {
        
    }

    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward; // eje Z local al objeto del script


        timer += Time.deltaTime;
        
        if(Physics.Raycast(ray, out hit))
        {   // si el Raycast detecta el collider del Player ...
            if (hit.collider.CompareTag("Player") && timer >= timeBetweenAttacks)
            {
                timer = 0;
                // se saca la distancia que hay desde el tanque player hasta el player
                distance = hit.distance; 
                Lauch();
            }
        }
    }

    void Lauch()
    {
        float lauchForceFinal = launchForce * distance * factorLauchForce;
        Rigidbody cloneShellPrefab = Instantiate(shellEnemyPrefab, posShell.position, posShell.rotation);
        cloneShellPrefab.velocity = posShell.forward * lauchForceFinal;
    }
}

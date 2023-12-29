using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionShell; // referencia al sistema de partículas que tiene la bala como hijo
    public int damageShell;

    AudioSource audioSource;
    Renderer rend;
    Collider coll;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        coll = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // desabilitamos el collider y el render para
        // que no siga colisionando y desaparezca
        coll.enabled = false;
        rend.enabled = false;

        explosionShell.Play();
        audioSource.Play();
        Destroy(gameObject, 0.5f);

    }
}

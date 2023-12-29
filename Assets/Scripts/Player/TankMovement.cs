using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] AudioClip idleClip;
    [SerializeField] AudioClip drivingClip;

    float horizontal;
    float vertical;

    Rigidbody rb;
    AudioSource audioSource;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        InputPlayer();
        AudioEngine();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Move()
    {
        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void Turn()
    {
        // Cálculo de grados que quiero girar el tanque
        float turn = horizontal * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * turnRotation);
    }

    void AudioEngine()
    {
        if(vertical !=0 || horizontal != 0)
        {
            if(audioSource.clip != drivingClip)
            {
                audioSource.clip = drivingClip;
                audioSource.Play();
            }
        }
        else // el tanque está parado
        {
            if (audioSource.clip != idleClip)
            {
                audioSource.clip = idleClip;
                audioSource.Play();
            }
        }
    }


}

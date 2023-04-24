using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject shootingPoint;
    [SerializeField]
    private float bulletSpeed = 800f;

    // component for the gun sound
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void ProcessShoot()
    {
        Debug.Log("Shoot");
        // add scattering effect to the bullet
        Quaternion randomRotation = Quaternion.Euler(Random.Range(-15f, 15f), Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        Vector3 randomDirection = transform.TransformDirection(Vector3.forward) + randomRotation * Vector3.right * Random.Range(-0.0f, 0.05f) + randomRotation * Vector3.up * Random.Range(-0.05f, 0.05f);
        GameObject bullets = Instantiate(bullet, shootingPoint.transform.position, transform.rotation * randomRotation);
        Debug.Log("DATA IS " + bullets.transform.rotation);
        bullets.GetComponent<Rigidbody>().AddForce(randomDirection.normalized * bulletSpeed);
        source.Play();
        Destroy(bullets, 2);

    }

}

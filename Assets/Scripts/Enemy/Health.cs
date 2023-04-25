using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author: Feifei
public class Health : MonoBehaviour
{
    // one shoot will result in 1 damage
    public int health = 3;
    public Vector3 RespawnPosition;
    private GameController gameController;

    // add player hurt sound
    private AudioSource source;
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 0.2f;
    private Vector3 originalPosition;
    private float shakeTimer = 0f;
    //public RawImage bloodEffect;  // Assign in the Inspector

    void Start()
    {
        //bloodEffect.enabled = false;
        gameController = FindObjectOfType<GameController>();
        source = GetComponent<AudioSource>();
        originalPosition = Camera.main.transform.localPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("HIT target!");
            health--;
            if (health <= 0)
            {
                Debug.Log("RUN win condition!");
                gameController.CheckWinCondition();
                health = 3;
                Respawn();
                //Destroy(gameObject);
            }
        }


        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT PLAYER");
            source.Play();
            ShakeCamera();
            gameController.hurtPlayer();
           
        }
    }
    public void Respawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-48, 27), 0.5f, Random.Range(-13, 17));
        transform.position = spawnPosition;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            Camera.main.transform.localPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            Camera.main.transform.localPosition = originalPosition;
        }
    }
    public void ShakeCamera()
    {
        shakeTimer = shakeDuration;
    }
/*    public void ShowBloodEffect()
    {
        bloodEffect.enabled = true;
        Invoke("HideBloodEffect", 0.2f);  // Hide blood effect after 0.2 seconds
    }*/
}

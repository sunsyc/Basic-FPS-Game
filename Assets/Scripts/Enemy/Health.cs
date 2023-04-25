using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    // one shoot will result in 1 damage
    public int health = 3;
    public Vector3 RespawnPosition;
    private GameController gameController;

    // add player hurt sound
    private AudioSource source;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        source = GetComponent<AudioSource>();
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
                gameController.hurtPlayer();
           
        }
    }
    public void Respawn()
    {
        transform.position = RespawnPosition;
    }


}

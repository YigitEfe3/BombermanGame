using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Spawn_Manager _spawnManager;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player1")
        {
            Player1 player1 = other.transform.GetComponent<Player1>();

            if (player1 != null)
            {
                player1.GainOneLife();
                _spawnManager.powerupObtained();
            }
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player2")
        {
            Player2 player2 = other.transform.GetComponent<Player2>();

            if (player2 != null)
            {
                player2.GainOneLife();
                _spawnManager.powerupObtained();
            }
            Destroy(this.gameObject);
        }
    }
}

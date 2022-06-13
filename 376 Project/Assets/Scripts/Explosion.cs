using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player2")
        {
            Player2 player2 = other.transform.GetComponent<Player2>();

            if (player2 != null)
                player2.Damage();
        }

        if (other.tag == "Player1")
        {
            Player1 player1 = other.transform.GetComponent<Player1>();

            if (player1 != null)
                player1.Damage();
        }
    }
}

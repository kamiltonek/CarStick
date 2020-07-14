using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Car" && collision.gameObject.tag != "Player")
        {
            GameInfo.Instance.endGame(false);
        }      
    }
}

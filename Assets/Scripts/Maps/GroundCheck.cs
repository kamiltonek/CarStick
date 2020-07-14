using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool backTire;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "road")
        {
            if (backTire)
            {
                GameInfo.Instance.BackIsGrounded = true;
            }
            else
            {
                GameInfo.Instance.FrontIsGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "road")
        {
            if (backTire)
            {
                GameInfo.Instance.BackIsGrounded = false;
            }
            else
            {
                GameInfo.Instance.FrontIsGrounded = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Dead":
                GameManager.instance.GameEnd();
                break;
            case "Color_Bouncer":
                GameManager.instance.UpdateScore(10, 1);
                break;
            case "Bucket_Bouncer":
                GameManager.instance.UpdateScore(5, 1);
                break;
            case "Point":
                GameManager.instance.UpdateScore(10, 1);
                break;
            case "Thimble_Points":
                GameManager.instance.UpdateScore(20, 1);
                break;
            case "Wall":
                GameManager.instance.UpdateScore(5, 0);
                break;
            case "Flipper":
                GameManager.instance.multiplier = 1;
                break;

            default:
                break;

        }

    }
}

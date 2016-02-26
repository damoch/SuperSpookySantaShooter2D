using UnityEngine;
using System.Collections;

public class FailControler : MonoBehaviour {

void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Player.GameOver();
        }
        else
            Destroy(col.gameObject);
    }
}

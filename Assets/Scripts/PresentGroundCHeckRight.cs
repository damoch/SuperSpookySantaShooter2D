using UnityEngine;
using System.Collections;

public class PresentGroundCHeckRight : MonoBehaviour {

    public PresentRight PR;
    int counter;
    // Use this for initialization
    void Start()
    {
        PR.IsGrounded = true;
        counter = 0;
    }

    void OnTriggerEnter2D(Collider2D col)//entering trigger - player is on ground
    {
        if (col.tag == "Platform")
        {
            PR.IsGrounded = true;

          
        }
        if (col.tag == "SantaHead") Player.GameOver();
    }
    void OnTriggerExit2D()
    {
        counter++;
        if (counter < 2)
        {
            PR.IsGrounded = false;
           
        }
        else
            PR.IsGrounded = true;



    }
}

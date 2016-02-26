using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {
  
    void Start()
    {
        
    }
void OnTriggerEnter2D(Collider2D col)//entering trigger - player is on ground
    {
        switch (col.tag)
        {
            case "Platform":
                Player.isGrounded = true;
                break;
            case "Present":
                Player.isOnPresent = true;
                break;
        }

        
       
          
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Platform":
                Player.isGrounded = false;
                break;
            case "Present":
                Player.isOnPresent = false;
                break;
        }


    }
}

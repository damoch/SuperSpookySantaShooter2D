using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
    public GameObject Bullet;
    float time = 0.10f;
    public Quaternion rotation;

    // Use this for initialization
    void Start () {
        rotation = new Quaternion(0f, 0f, 0f, 0f);
        InvokeRepeating("Shoot", time, time);
        Debug.Log(Bullet.transform.rotation.z);
	}
	
	// Update is called once per frame
	void Shoot () {
      
     Instantiate(Bullet, transform.position, rotation);  
        
       
	
	}
}

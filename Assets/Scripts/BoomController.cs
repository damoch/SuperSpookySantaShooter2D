using UnityEngine;
using System.Collections;

public class BoomController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DestroyThis");
	}
	
	// Update is called once per frame
IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}

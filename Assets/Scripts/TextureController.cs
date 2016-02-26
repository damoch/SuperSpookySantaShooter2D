using UnityEngine;
using System.Collections;

public class TextureController : MonoBehaviour {
    public Sprite[] Textures;
    void Start () {
        GetComponent<SpriteRenderer>().sprite = Textures[Random.Range(0, 4)];
	}
	

}

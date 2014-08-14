using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {

	private PlayerCode playercode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//other = playercode;
			other.GetComponent<PlayerCode>().asdf += 1;
			print ("player touched powerup");
			//other. + 1;
			Destroy(gameObject);
		}
	}
}

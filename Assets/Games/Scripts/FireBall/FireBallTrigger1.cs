using UnityEngine;
using System.Collections;

public class FireBallTrigger1 : MonoBehaviour {

	public float damage;
	public float speed;
	public float timeDestroy = 1f;
	public GameObject Player;

	void Start()
	{
		Destroy(gameObject, timeDestroy);
		
		Player = Player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update()
	{
		transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}


	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Player"))
		{
			
			print("Player");
		}

		if (col.CompareTag("Enemy"))
		{
			col.GetComponent<enemy2>().Damage(Player.GetComponent<PlayerStats>().Damage2);
			
			print("Enemy");
		}

		if (col.CompareTag("Enemy3"))
		{
			col.GetComponent<metalon>().Damage(Player.GetComponent<PlayerStats>().Damage2);
			
			print("Enemy");
		}
	}


}

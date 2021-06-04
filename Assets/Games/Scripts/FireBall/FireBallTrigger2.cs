using UnityEngine;
using System.Collections;

public class FireBallTrigger2 : MonoBehaviour {

	public float damage;
	public float speed;
	public GameObject Player;
	public float timeDestroy = 1f;

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
			col.GetComponent<PlayerStats>().curLife -= damage;
			Destroy(gameObject);
			print("Player");
		}

		if (col.CompareTag("Enemy"))
		{
			col.GetComponent<enemy2>().Damage(Player.GetComponent<PlayerStats>().Damage3);
			Destroy(gameObject);
			print("Enemy");
		}


		if (col.CompareTag("Enemy3"))
		{
			col.GetComponent<metalon>().Damage(Player.GetComponent<PlayerStats>().Damage3);
			Destroy(gameObject);
			print("Enemy");
		}
	}


}

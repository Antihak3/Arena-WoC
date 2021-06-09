using UnityEngine;
using System.Collections;

public class FireBallTrigger : MonoBehaviour {

	public float damage;
	public float speed;
	public float time;
	public GameObject Player;
	public soundMeneger sm;
	void Start()
	{
		Destroy(gameObject, time);
		
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
			sm.PlaySound(5);
		}

		if (col.CompareTag("Enemy"))
		{
			col.GetComponent<enemy2>().Damage(Player.GetComponent<PlayerStats>().Damage1);
			Destroy(gameObject);
			print("Enemy");
		}


		if (col.CompareTag("Enemy3"))
		{
			col.GetComponent<metalon>().Damage(Player.GetComponent<PlayerStats>().Damage1);
			Destroy(gameObject);
			print("Enemy3");
		}
	}

}

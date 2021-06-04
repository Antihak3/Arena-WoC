using UnityEngine;
using System.Collections;

public class FireBallTrigger3 : MonoBehaviour {

	public float damage;
	public GameObject Player;
	public float timeDestroy = 4f;

	void Start()
	{
		Destroy(gameObject, timeDestroy);
		
		Player = Player = GameObject.FindGameObjectWithTag("Player");
	}
	

    private void OnTriggerEnter(Collider col)
    {
       if(col.CompareTag("Enemy"))
        {
			col.GetComponent<enemy2>().Damage(Player.GetComponent<PlayerStats>().Damage4);
			Destroy(gameObject);
			print("Enemy");
		}


		if (col.CompareTag("Enemy3"))
		{
			col.GetComponent<metalon>().Damage(Player.GetComponent<PlayerStats>().Damage4);
			Destroy(gameObject);
			print("Enemy");
		}
	}


}

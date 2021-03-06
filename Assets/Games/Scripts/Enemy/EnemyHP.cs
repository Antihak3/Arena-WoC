using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyHP : MonoBehaviour {

	public float maxHP = 100;
	public float curHP = 100;
	public Text EnemyHpText;

	public GameObject Enemy;
	public Vector3 offset;
	public GameObject Player;
	public GameObject spawn;
	private float expPlayer = 250;
	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		spawn = GameObject.FindGameObjectWithTag("spawn");
	}
	
	// Update is called once per frame
	void Update () 
	{

            GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(Enemy.transform.position + offset);

		EnemyHpText.text = curHP.ToString();

		if (curHP <= 0)
		{
			Player.GetComponent<PlayerController>().curTarget = null;
			Enemy.GetComponent<Animator>().SetBool("died", true);
			StartCoroutine(Died());
		}
	}

	IEnumerator Died()
    {
		yield return new WaitForSeconds(1.5f);
		Spawn();
		StopCoroutine(Died());
	}

	public void Spawn()
    {
		Player.GetComponent<PlayerStats>().curExp += 250 + (Player.GetComponent<PlayerStats>().level * 20);
		Player.GetComponent<PlayerStats>().stars += 1;
		Destroy(gameObject);
	}
}

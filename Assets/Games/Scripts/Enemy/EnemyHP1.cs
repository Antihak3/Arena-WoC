using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyHP1 : MonoBehaviour {


	public float maxHP;
	public float curHP;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
        maxHP = GetComponentInParent<EnemyHP>().maxHP;
		curHP = GetComponentInParent<EnemyHP>().curHP;


		GetComponent<Image>().fillAmount = curHP / maxHP;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnPl : MonoBehaviour
{
	public GameObject Player;
	public GameObject fireball;
	public GameObject[] metalon;


	private void Start()
    {
		if (PlayerPrefs.HasKey("damage1"))
		{
			Player.GetComponent<PlayerStats>().Damage1 = PlayerPrefs.GetFloat("damage1");
		}
		else
		{
			Player.GetComponent<PlayerStats>().Damage1 = 12;
		}

		if (PlayerPrefs.HasKey("damage2"))
		{
			Player.GetComponent<PlayerStats>().Damage2 = PlayerPrefs.GetFloat("damage2");
		}
		else
		{
			Player.GetComponent<PlayerStats>().Damage2 = 20;
		}

		if (PlayerPrefs.HasKey("damage3"))
		{
			Player.GetComponent<PlayerStats>().Damage3 = PlayerPrefs.GetFloat("damage3");
		}
		else
		{
			Player.GetComponent<PlayerStats>().Damage3 = 30;
		}

		if (PlayerPrefs.HasKey("damage4"))
		{
			Player.GetComponent<PlayerStats>().Damage4 = PlayerPrefs.GetFloat("damage4");
		}
		else
		{
			Player.GetComponent<PlayerStats>().Damage4 = 50;
		}


		//Enemy
		if (PlayerPrefs.HasKey("damageG1"))
		{
			metalon[0].GetComponent<metalon>().DamageG = PlayerPrefs.GetFloat("damageG1");
		}
		else
		{
			metalon[0].GetComponent<metalon>().DamageG = 10;
		}

		if (PlayerPrefs.HasKey("damageG1"))
		{
			metalon[1].GetComponent<metalon>().DamageG = PlayerPrefs.GetFloat("damageG1");
		}
		else
		{
			metalon[1].GetComponent<metalon>().DamageG = 10;
		}

		if (PlayerPrefs.HasKey("damageG1"))
		{
			metalon[2].GetComponent<metalon>().DamageG = PlayerPrefs.GetFloat("damageG1");
		}
		else
		{
			metalon[2].GetComponent<metalon>().DamageG = 10;
		}

		if (PlayerPrefs.HasKey("damageG1"))
		{
			metalon[3].GetComponent<metalon>().DamageG = PlayerPrefs.GetFloat("damageG1");
		}
		else
		{
			metalon[3].GetComponent<metalon>().DamageG = 10;
		}

		if (PlayerPrefs.HasKey("damageG1"))
		{
			metalon[4].GetComponent<metalon>().DamageG = PlayerPrefs.GetFloat("damageG1");
		}
		else
		{
			metalon[4].GetComponent<metalon>().DamageG = 10;
		}

		if (PlayerPrefs.HasKey("damageG1"))
		{
			fireball.GetComponent<FireBallTrigger>().damage = PlayerPrefs.GetFloat("damageG1");
		}
		else
		{
			fireball.GetComponent<FireBallTrigger>().damage = 10;
		}

		//EnemyHP
		if (PlayerPrefs.HasKey("HPG1"))
		{
			metalon[0].GetComponent<metalon>().maxHP = PlayerPrefs.GetFloat("HPG1");
		}
		else
		{
			metalon[0].GetComponent<metalon>().maxHP = 70;
		}
		if (PlayerPrefs.HasKey("HPG1"))
		{
			metalon[1].GetComponent<metalon>().maxHP = PlayerPrefs.GetFloat("HPG1");
		}
		else
		{
			metalon[1].GetComponent<metalon>().maxHP = 40;
		}
		if (PlayerPrefs.HasKey("HPG1"))
		{
			metalon[2].GetComponent<metalon>().maxHP = PlayerPrefs.GetFloat("HPG1");
		}
		else
		{
			metalon[2].GetComponent<metalon>().maxHP = 25;
		}
		if (PlayerPrefs.HasKey("HPG1"))
		{
			metalon[3].GetComponent<metalon>().maxHP = PlayerPrefs.GetFloat("HPG1");
		}
		else
		{
			metalon[3].GetComponent<metalon>().maxHP = 30;
		}
		if (PlayerPrefs.HasKey("HPG1"))
		{
			metalon[4].GetComponent<metalon>().maxHP = PlayerPrefs.GetFloat("HPG1");
		}
		else
		{
			metalon[4].GetComponent<metalon>().maxHP = 50;
		}
		if (PlayerPrefs.HasKey("HPG1"))
		{
			metalon[5].GetComponent<enemy2>().maxHP = PlayerPrefs.GetFloat("HPG1");
		}
		else
		{
			metalon[5].GetComponent<enemy2>().maxHP = 50;
		}

	}

    private void Update()
    {
       
	}

	public void dag()
    {
		Player.GetComponent<PlayerStats>().Damage1 *= 1.2f;
		Player.GetComponent<PlayerStats>().Damage2 *= 1.2f;
		Player.GetComponent<PlayerStats>().Damage3 *= 1.1f;
		Player.GetComponent<PlayerStats>().Damage4 *= 1.1f;


		metalon[0].GetComponent<metalon>().DamageG += 5;
		metalon[1].GetComponent<metalon>().DamageG += 5;
		metalon[2].GetComponent<metalon>().DamageG += 5;
		metalon[3].GetComponent<metalon>().DamageG += 5;
		metalon[4].GetComponent<metalon>().DamageG += 5;
		fireball.GetComponent<FireBallTrigger>().damage += 5;

		metalon[0].GetComponent<metalon>().maxHP += 10;
		metalon[1].GetComponent<metalon>().maxHP += 5;
		metalon[2].GetComponent<metalon>().maxHP += 5;
		metalon[3].GetComponent<metalon>().maxHP += 15;
		metalon[4].GetComponent<metalon>().maxHP += 15;
		metalon[5].GetComponent<enemy2>().maxHP += 10;

		PlayerPrefs.SetFloat("damage1", Player.GetComponent<PlayerStats>().Damage1);
		PlayerPrefs.SetFloat("damage2", Player.GetComponent<PlayerStats>().Damage2);
		PlayerPrefs.SetFloat("damage3", Player.GetComponent<PlayerStats>().Damage3);
		PlayerPrefs.SetFloat("damage4", Player.GetComponent<PlayerStats>().Damage4);

		PlayerPrefs.SetFloat("damageG1", metalon[0].GetComponent<metalon>().DamageG);

		PlayerPrefs.SetFloat("HPG1", metalon[0].GetComponent<metalon>().maxHP);
	}

}

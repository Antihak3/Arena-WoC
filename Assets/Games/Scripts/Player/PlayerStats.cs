using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour {

	public float maxLife = 100;
	public float curLife = 100;
	public int level = 1;
	public float nextLevelExp = 1000;
	public float curExp = 0;
	public float Energy = 1f;
	public Image UIenergy;

	public Text curLifeText;
	public Text Level_Text;
	public Image EXP_Slider;
	public Image HP_Slider;
	Animator anim;

	public int stars = 0;
	public Text stars_Text;

	public float Damage1 = 15;
	public float Damage2 = 20;
	public float Damage3 = 30;
	public float Damage4 = 60;


	public float levelDamage = 1.2f;



	public GameObject fireball;
	public GameObject[] metalon;

	void Start ()
	{
		anim = GetComponent<Animator>();

		metalon[0].GetComponent<metalon>().DamageG = 10;
		metalon[1].GetComponent<metalon>().DamageG = 10;
		metalon[2].GetComponent<metalon>().DamageG = 10;
		metalon[3].GetComponent<metalon>().DamageG = 10;
		metalon[4].GetComponent<metalon>().DamageG = 10;

		fireball.GetComponent<FireBallTrigger>().damage = 10;
	}
	

	void Update () 
	{
        if (curLife < 0)
        {
			anim.SetBool("diedPl", true);
			curLife = 0;
        }

		if (curLife > 0 && curLife < maxLife)
		{
			curLife += Time.deltaTime * 1.5f;
		}


		if (Energy < 1f)
        {
			Energy += Time.deltaTime / 5f;
        }

     UIenergy.fillAmount = Energy;


	HP_Slider.fillAmount = (curLife/maxLife);
	EXP_Slider.fillAmount = (curExp/nextLevelExp);
	curLifeText.text = curLife.ToString();
	Level_Text.text = level.ToString();
	stars_Text.text = stars.ToString();

	if(curExp>= nextLevelExp)
	    {
		level++;
		maxLife += 50;
		curExp = 0;
		nextLevelExp += 500;
	        Damage1 *= levelDamage;
			Damage2 *= levelDamage;
			Damage3 *= levelDamage;
			Damage4 *= levelDamage;



			metalon[0].GetComponent<metalon>().DamageG += 10;
			metalon[1].GetComponent<metalon>().DamageG += 10;
			metalon[2].GetComponent<metalon>().DamageG += 10;
			metalon[3].GetComponent<metalon>().DamageG += 10;
			metalon[4].GetComponent<metalon>().DamageG += 10;


			fireball.GetComponent<FireBallTrigger>().damage += 10;
		}

	}
}

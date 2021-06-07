using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStatsGorod : MonoBehaviour {

	public float maxLife = 100;
	public float curLife;
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

	public int coins = 0;
	public Text coins_Text;

	public float Damage1 = 15;
	public float Damage2 = 20;
	public float Damage3 = 30;
	public float Damage4 = 60;


	public float levelDamage = 1.2f;



	

	void Start ()
	{
		anim = GetComponent<Animator>();

		if (PlayerPrefs.HasKey("lvl"))
		{
			level = PlayerPrefs.GetInt("lvl");
		}
		else
		{
			level = 1;
		}

		if (PlayerPrefs.HasKey("stars"))
		{
			stars = PlayerPrefs.GetInt("stars");
		}
		else
		{
			stars = 0;
		}

		if (PlayerPrefs.HasKey("HP"))
		{
			maxLife = PlayerPrefs.GetFloat("HP");
		}
		else
		{
			maxLife = 100;
		}

		if (PlayerPrefs.HasKey("EXP"))
		{
			curExp = PlayerPrefs.GetFloat("EXP");
		}
		else
		{
			curExp = 0;
		}

		if (PlayerPrefs.HasKey("nextLvl"))
		{
			nextLevelExp = PlayerPrefs.GetFloat("nextLvl");
		}
		else
		{
			nextLevelExp = 1000;
		}


		curLife = maxLife;

	}
	

	void Update () 
	{
		if (PlayerPrefs.HasKey("coins"))
		{
			coins = PlayerPrefs.GetInt("coins");
		}
        else
        {
			coins = 0;
        }

		

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
	stars_Text.text = stars.ToString();
	Level_Text.text = level.ToString();
	coins_Text.text = coins.ToString();

		if (curExp>= nextLevelExp)
	    {
		level++;
		maxLife += 50;
		curExp = 0;
		nextLevelExp += 500;
		curLife = maxLife;


	        Damage1 *= levelDamage;
			Damage2 *= levelDamage;
			Damage3 *= levelDamage;
			Damage4 *= levelDamage;



			
		}

	}

	
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour {

	public float maxLife = 100;
	public float curLife;
	public int level;
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

	public GameObject damageEnPl;
	public GameObject FXLevelUp;

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
	coins_Text.text = coins.ToString();

		if (curExp >= nextLevelExp)
		{
			level++;

			GameObject p = Instantiate(FXLevelUp, transform.position, transform.rotation) as GameObject;

			p.GetComponentInChildren<ParticleSystem>().Play();

			Destroy(p, p.GetComponentInChildren<ParticleSystem>().duration);

			maxLife += 50;
			curExp -= 500 * level;
			nextLevelExp += 500;
			curLife = maxLife;
			damageEnPl.GetComponent<DamageEnPl>().dag();

		}

	}

	IEnumerator timerApp()
    {
		yield return new WaitForSeconds(1);

    }

	
	public int GetCoins()
	{
		return coins;
	}

	public int GetLevel()
	{
		return level;
	}

	public int Getstars()
	{
		return stars;
	}

	public float GetHP()
	{
		return maxLife;
	}

	public float GetCurHp()
	{
		return curLife;
	}

	public float GetEXP()
	{
		return curExp;
	}

	public float GetNextLvlEXP()
	{
		return nextLevelExp;
	}
}

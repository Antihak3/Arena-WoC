using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
   public bool Stage = true;
    public GameObject[] Enemy;

    public float Round = 100;
    public Text Round_Text;

    public GameObject TP;

    private void Start()
    {
        
    }

    private void Update()
    {
       


        Round_Text.text = ((int)Round / 60).ToString() + ":" + ((int)Round - ((int)Round / 60) * 60).ToString();

        

        if (Round > 0)
        {
            Round -= Time.deltaTime;
        }
        else
        {
            TP.SetActive(true);
        }

        if (Round > 0)
        { if(Stage)
         {  StartCoroutine(SPawn1());} }   
        }

    public void SpawnEnemy()
    {
        GameObject fb = Instantiate( Enemy[Random.Range(0, Enemy.Length)], new Vector3(Random.Range(125, 159),11.3f, Random.Range(414, 438)) , transform.rotation) as GameObject;
    }

    IEnumerator SPawn1()
    {
        
        Stage = false;
        SpawnEnemy();
        yield return new WaitForSeconds(2f);
        Stage = true;
    }
}

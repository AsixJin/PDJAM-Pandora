using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

    public List<GameObject> EnemyList = new List<GameObject>();
    public int ListPos = -1;

    public GameObject Undead;
    public GameObject BHead;
    public GameObject Sting;

    public float level = 0.01f;
    public int tier = 1;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Spawn(int num)
    {
        if(num == 1)
        {
            EnemyList.Add((GameObject)Instantiate(Undead, Positioner(), Quaternion.identity));           
        }
        else if(num == 2)
        {
            EnemyList.Add(Instantiate(BHead));
        }
        else if(num == 3)
        {
            EnemyList.Add(Instantiate(Sting));
        }
    }

    public Vector3 Positioner()
    {
        return new Vector3(Random.Range(7, 9), 0, 0);
    }
}

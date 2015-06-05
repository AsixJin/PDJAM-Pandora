using UnityEngine;
using System.Collections;

public class Stinger : MonoBehaviour {

    //Stinger Body
    public Rigidbody2D rbody;
    public Animator anim;
    public GameObject needle;
    private GameObject player;
    //Positioning Variables
    private Vector2 needle_Pos;
    private Vector3 player_Pos;
    public Vector3 target_Pos;
    //Stinger variables
    private GameObject holstered;
    public float Timer;
    private float speed;
    public bool armed = false;
    public int HP = 50;
    //Debug Variables
    public float dist;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Epimetheus");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Positions
        dist = Vector3.Distance(target_Pos, transform.position);
        player_Pos = player.transform.position;
        target_Pos = new Vector3(player_Pos.x + 5.5f, player_Pos.y - 0.71f,0);
        needle_Pos = new Vector2(this.transform.position.x + 0.05f, this.transform.position.y + 0.65f);
        transform.position = Vector3.MoveTowards(transform.position, target_Pos, 2 * Time.deltaTime);

        if(holstered != null)
        {
            //transform.position = Vector3.MoveTowards(transform.position, target_Pos, 2 * Time.deltaTime);

            if (transform.position == target_Pos)
            {
                FireNeedle();
            }

            if (armed)
            {
                holstered.transform.position = needle_Pos;
            }
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position,target_Pos, 2 * Time.deltaTime);

            Timer += Time.deltaTime;
            if (Timer >= 2f)
            {
                Timer = 0;
                ReadyNeedle();
            }    
        }

        if (transform.position == target_Pos)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }


        //Motherfucker you die after you have no HP.....
        if (HP == 0)
        {
            Destroy(this.gameObject);
        }

	}

    //Deals Damage
    public void takeDamage(int Health)
    {
       if(Health == 5)
       {

       }
       else
       {
           HP = HP - Health;
       }
    }

    //Creates Needle
    void ReadyNeedle()
    {
        holstered = (GameObject)Instantiate(needle, needle_Pos, Quaternion.identity);
        armed = true;
               
    }

    void FireNeedle()
    {
        armed = false;
        holstered.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.1f, 0));
        holstered = null;
    }
}

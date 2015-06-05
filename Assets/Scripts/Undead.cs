using UnityEngine;
using System.Collections;

public class Undead : MonoBehaviour {

    //UnDead Body Parts
    public Rigidbody2D rbody;      //public Animator anim;
    private GameObject player;
    private Vector3 player_Pos;
    public float speed;
    public float dist;
    public int HP = 100;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Epimetheus");
        speed = Random.Range(0.3f, 0.41f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        dist = Vector3.Distance(player_Pos, transform.position);
        player_Pos = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, player_Pos, speed * Time.deltaTime);

        //Bruh you are so fucking through if your Health reaches zero!!!
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void takeDamage(int Health)
    {
        HP = HP - Health;
    }
}

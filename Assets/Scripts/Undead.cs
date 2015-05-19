using UnityEngine;
using System.Collections;

public class Undead : MonoBehaviour {

    //UnDead Body Parts
    public Rigidbody2D rbody;      //public Animator anim;
    private GameObject player;
    private Vector3 player_Pos;
    public float speed;
    public float dist;

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
	}
}

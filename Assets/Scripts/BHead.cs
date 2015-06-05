using UnityEngine;
using System.Collections;

public class BHead : MonoBehaviour {

    //UnDead Body Parts
    //public Rigidbody2D rbody;      //public Animator anim;
    private GameObject player;
    private Vector3 player_Pos;
    public float speed;
    private int steps;
    public float Timer;
    public int HP = 20;
    //public float dist;

    //Cooridinates
    private readonly float x_Start = -1.2f;
    private readonly float x_End = 4.8f;
    private readonly float y_Start = -4.1f;
    private readonly float y_End = 4.1f;


	// Use this for initialization
	void Start () 
    {
        Teleport();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer += Time.deltaTime;
        if(Timer >= 3)
        {
            Teleport();
            Timer = 0;
        }

        if(HP == 0)
        {
            Destroy(this.gameObject);
        }
	}

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(x_Start, x_End), Random.Range(y_Start, y_End));
    }

    private void Teleport()
    {
        transform.position = RandomPos();
    }

    public void takeDamage(int Health)
    {
        HP = HP - Health;
    }
}

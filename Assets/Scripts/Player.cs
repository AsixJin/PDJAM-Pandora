using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Player body parts and ammo
    public GameObject hand;
    public GameObject arrow;
    public Rigidbody2D rbody;
    public Animator anim;
    private GameObject holstered;
    private Vector3 Sarrow_pos;
    private Vector3 Earrow_pos;
    private Vector2 pullback;
    //Player Controls
    private float VAsix;
    private float HAsix;
    private string VInput = "Vertical";
    private string HInput = "Horizontal";
    private string Drawback = "Fire1";
    //Player Variable
    private readonly float hand_end = 0.4f;
    private readonly float hand_start = 0.2f;
    private float Timer;
    public float hand_pos = 0.2f;
    private float arrow_draw;
    public bool isFiring = false;
    public float power = 0.4f;
    public float speed = 5;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer += Time.deltaTime;
        //Positions for hands and arrows
        hand.transform.position = new Vector2(this.transform.position.x - hand_pos, this.transform.position.y - 0.4f);
        Sarrow_pos = new Vector3(this.transform.position.x + 0.55f, this.transform.position.y - 0.35f);
        pullback = new Vector2(Sarrow_pos.x + arrow_draw, this.transform.position.y - 0.35f);
        Earrow_pos = new Vector3(this.transform.position.x + 0.35f, this.transform.position.y - 0.35f);

        //Movement
        VAsix = Input.GetAxisRaw(VInput);
        HAsix = Input.GetAxisRaw(HInput);
        rbody.velocity = new Vector2(HAsix * speed, VAsix * speed);

        //Prevents Player from going off screen or in play area
        if(transform.position.y >= 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if(transform.position.y <= -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if(transform.position.x <= -4.82f)
        {
            transform.position = new Vector3(-4.82f, transform.position.y, 0);
        }
        else if (transform.position.x >= -3)
        {
            transform.position = new Vector3(-3, transform.position.y, 0);
        }

        //Plays walk animation
        if(HAsix != 0 || VAsix != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //Makes sure arrow drawsback with hand
        if(holstered != null && hand_pos < hand_end)
        {
            holstered.transform.position = pullback;      
        }
        else if(holstered != null && hand_pos >= hand_end)
        {
            holstered.transform.position = Earrow_pos;
        }       

        //Firing of arrow
        if(Input.GetButton(Drawback) && Timer >= 0.5f)
        {
            ReadyArrow();
            
            //Draws hand and arrow back as far as it'll got
            if(hand_pos < hand_end)
            {
                hand_pos += 0.005f;
                arrow_draw -= 0.005f;   
            }
            else
            {
                power = 0.10f;
            }
        }

        //When button is release
        if(Input.GetButtonUp(Drawback))
        {
            if(hand_pos >= 0.25f)
            {
                FireArrow();
            }
            else
            {
                Destroy(holstered);
                arrow_draw = 0;
                power = 0.04f;
                hand_pos = hand_start;
                isFiring = false;
                Timer = 0;
            }       
        }

	}

    //Method for readying arrow
    void ReadyArrow()
    {
        //Creates one arrow
        if (!isFiring)
        {
            holstered = (GameObject)Instantiate(arrow, Sarrow_pos, Quaternion.identity);
            isFiring = true;
        }
    }

    //Method for releasing arrow (in method in case needed elsewhere)
    void FireArrow()
    {
        try
        {
            holstered.GetComponent<Rigidbody2D>().AddForce(new Vector2(power, 0));
            holstered = null;
            arrow_draw = 0;
            power = 0.04f;
            hand_pos = hand_start;
            isFiring = false;
            Timer = 0;
        }
        catch
        {

        }
        
    }
}

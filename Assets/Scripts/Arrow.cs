using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public Rigidbody2D rBody;
    private bool fullPower = false;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	     if(transform.position.x >= 8.20f)
         {
             Destroy(this.gameObject);
         }
	}

    public void setPower()
    {
        fullPower = true;
    }

    private int Damage()
    {
        if(fullPower)
        {
            return 10; 
        }
        else
        {
            return 5;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Sting")
        {
            col.GetComponent<Stinger>().takeDamage(Damage());
            Destroy(this.gameObject);
        }
        else if(col.transform.tag == "BHead")
        {
            col.GetComponent<BHead>().takeDamage(Damage());
            Destroy(this.gameObject);
        }
        else if(col.transform.tag == "Zom")
        {
            col.GetComponent<Undead>().takeDamage(Damage());
            //Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.transform.tag == "Zom")
        {
            if(fullPower)
            {
                col.GetComponent<Undead>().takeDamage(1);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

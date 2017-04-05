using System.Collections;
using UnityEngine;

public class toss : MonoBehaviour
{

    private new Rigidbody rigidbody;
    public int speed;

	void Start ()
    {
        if(GetComponent<Rigidbody>() != null)
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        //Give the grenade an initial velocity to add 'realistic' throwing physics in the direction the player faces 
       rigidbody.velocity = transform.forward * speed * Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(rigidbody == null)
        {
            return;
        }
	}
    //Checks tags of the Grenade surrounding and acts in the appropriate way
    private void OnCollisionEnter(Collision collision)
    {
        //Destroys on wall or Ground contact after a small countdown
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(destroy());
        }
        //Destroys a target dummy on impact to replicate a real grenade as well as destroying itself
        if (collision.gameObject.CompareTag("Head") || collision.gameObject.CompareTag("Body")
            || collision.gameObject.CompareTag("Leg") || collision.gameObject.CompareTag("Legs"))
        {
            Destroy(collision.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
    //Adds small destroy timer to add realism
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

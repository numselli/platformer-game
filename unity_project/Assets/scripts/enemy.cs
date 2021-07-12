using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    public float speed = 1f;
    public float walkingdistance = 5f;
    public bool goright = true;
    public Vector3 startpos;
    public bool shouldbemoving = true;
	void Start () 
    {
        startpos = transform.position;
	}
		void Update ()
    {
        if (shouldbemoving == true)
        {
            if (goright == true)
            {
                if (transform.position.x < startpos.x + walkingdistance)
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
                else
                {
                    goright = false;
                }
            }
            if (goright == false)
            {
                if (transform.position.x > startpos.x - walkingdistance)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
                else
                {
                    goright = true;
                }
            }
        }
    }
}
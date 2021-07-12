using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    public GameObject checkpoint;
    public Slider progress;
    public float distancetoend;
    public float current_pos_x;
    public float maxval;
    public GameObject Flag;
    public int myBlubb;

    public AudioClip impact;
    public AudioClip Coin;
    public AudioClip winsound;

    public Text leveltxt;
    AudioSource audio;

    public int Platforms;

    public int speed = 9;
    public float jumpforce = 9f;
    public bool canjump = false;
    Animator ouranamitor;
    public GameObject win;
    public int coins = 0;
    public float health = 5;
    public bool stuned = false;
    public Text scoretext;
    public Text healthtext;
    public int Level = 1;
    public GameObject L;
    public bool canrespown = true;
    public GameObject respownbtn;

    void Start()
    {
        Application.runInBackground = true;
        ouranamitor = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    public void Updateval()
    {
        maxval = Flag.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x;
        maxval = Mathf.Abs(maxval);
        progress.maxValue = maxval;
    }

    public void respown()
    {
        if(coins >= 3)
        {
            transform.position = checkpoint.transform.transform.position;
            health = 5;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            coins = coins - 3;
            PlayerPrefs.SetInt("coins", FindObjectOfType<player>().coins);
            L.SetActive(false);
            FindObjectOfType<Canvas>().GetComponent<manager>().canrespown = false;
            FindObjectOfType<Canvas>().GetComponent<manager>().off();

        }
    }
    void Update()
    {
        distancetoend = Flag.GetComponent<Transform>().position.x - GetComponent<Transform>().position.x;
        myBlubb = (int) distancetoend;
        distancetoend = Mathf.Abs(distancetoend);
        progress.value = distancetoend;

        leveltxt.text = "Level: " + Level.ToString();
        scoretext.text = "Coins: " + coins.ToString();
        healthtext.text = "Health: " + health.ToString();

        // if (canrespown = false)
        // {
        //     respownbtn.SetActive(false);
        // }
        if (transform.position.y < -10)
        {
            //audioSource.PlayOneShot(impact);
            KB(transform.position); 
            health -= .9F;
        }
        if (health <= 0)
        {
            PlayerPrefs.SetInt("platfoms", FindObjectOfType<player>().Platforms);
            L.SetActive(true);
            health = 0;
            // Destroy(gameObject);
        }
        if (stuned == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
            if (canjump == true)
                {
                    //ouranamitor.SetBool("jump", true);
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                ouranamitor.SetBool("walk back", true);
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                ouranamitor.SetBool("walk forword", true);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            //on releace
            if (Input.GetKeyUp(KeyCode.A))
            {
                ouranamitor.SetBool("walk back", false);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                ouranamitor.SetBool("walk forword", false);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            stuned = false;
            canjump = true;
            ouranamitor.SetBool("jump", false);
            Platforms++;
        }
        if (collision.gameObject.tag == "spike")
        {
            KB(collision.transform.position);
            health--;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canjump = false;
            ouranamitor.SetBool("jump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            Destroy(checkpoint.gameObject);
            checkpoint = collision.gameObject;
        }
        if (collision.gameObject.tag == "coin")
        {
            audio.PlayOneShot(Coin);
            coins++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "flag")
        {
            audio.PlayOneShot(winsound);
            win.SetActive(true);
        }
        if (collision.gameObject.tag == "enemystopmable")
        {
            bounce();
            collision.GetComponent<Animator>().SetBool("Die", true);
            collision.GetComponent<enemy>().shouldbemoving = false;
            StartCoroutine(WaitDestroy(collision.gameObject));
        }
    }

    void bounce() 
    {
        float yvol = GetComponent<Rigidbody2D>().velocity.y;
        yvol = -yvol;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, yvol * 2), ForceMode2D.Impulse);
    }
    IEnumerator WaitDestroy(GameObject thingtodestroy)
    {
        yield return new WaitForSeconds(1f);
        Destroy(thingtodestroy);
    }
    void KB(Vector3 thingwehit) 
    {
        stuned = true;
        float xpower = 15f;
        float ypower = 18f;
        audio.PlayOneShot(impact);

        if (transform.position.x - thingwehit.x > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2 (xpower,ypower),ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-xpower, ypower), ForceMode2D.Impulse);
        }
    }
}
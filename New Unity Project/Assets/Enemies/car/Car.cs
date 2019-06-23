using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    // Continous means the car will go between wavepoints forever
    // dont change right and left sprites
    //direction is the initial direction the car should be facing
    public bool continous;
    
    public Sprite right;
    public Sprite left;
    public GameObject[] waypoints;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public string direction;
    public  int health;
    CapsuleCollider2D cd;
    Animator animator;
    SpriteRenderer sr;
    List<Waypoint> scripts;
    public float speed;
    Vector2 location;
    void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>() as Animator;
        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);
        cd = this.gameObject.GetComponent<CapsuleCollider2D>() as CapsuleCollider2D;

  
        if (direction == "right")
        {
            Debug.Log("went to the right");

            sr.flipX = false;
            cd.offset = new Vector2(-1.7f, -1.2f);
        }
        else if(direction == "left")
        {
            Debug.Log("went to the left");
            sr.flipX=true;
            cd.offset = new Vector2(0f, -1.2f);
        }
            
        location = gameObject.transform.position;

        scripts = new List<Waypoint>();
        waypoints = new GameObject[2];
        waypoints[0] = waypoint1;
        waypoints[1] = waypoint2;
   
        
        foreach (GameObject child in waypoints) {
            if (child.gameObject.CompareTag("invisible waypoint"))
            {
                
                scripts.Add(child.GetComponent<Waypoint>() as Waypoint);
            }
            else {
                Debug.Log("one or more of your waypoints do not have the tag invisible waypoint");
            }
         

        }

        
    }

    // Update is called once per frame
    void Update()
    {
       goToNextWavepoint(this.speed);
    }

    public void goToNextWavepoint(float speed) {
        Vector2 carpos = this.transform.position;
        animator.SetBool("TurnRight", false);
        animator.SetBool("TurnLeft", false);
        if (direction == "right")
        {

            sr.flipX = false;
            cd.offset = new Vector2(-1.7f, -1.2f);
        }
        else
        {
            sr.flipX = true;
            sr.flipX = true;
            cd.offset = new Vector2(0f, -1.2f);
        }
        if (continous)
        {
            int sum = 0;
            foreach (Waypoint w in scripts)
            {
                if (w.completed)
                {
                    sum++;
                }


            }
            if (sum == scripts.Count) {
                foreach (Waypoint w in scripts)
                {
                    w.completed = false;


                }
            }
        }
        foreach (Waypoint w in scripts) {

            if (!w.completed) {
                if (w.GetX()-0.2 > carpos.x)
                {
                    gameObject.transform.position = new Vector2(carpos.x + speed * Time.deltaTime, carpos.y);
                    break;
                }
                else if (w.GetX()+0.2 < carpos.x)
                {
                    gameObject.transform.position = new Vector2(carpos.x - speed * Time.deltaTime, carpos.y);
                    break;
                }
                else {
                    if (w.rotate) {
                        if (direction == "right")
                        {
                            animator.SetBool("TurnLeft",true);
                            sr.flipX = false;
                            cd.offset = new Vector2(0f, -1.2f);
                            direction = "left";
                        }
                        else {
                            animator.SetBool("TurnRight", true);
                            sr.flipX = true;
                            cd.offset = new Vector2(-1.7f, -1.2f);
                            direction = "right";
                        } 

                    }

                    if (w.destroy)
                    { Destroy(gameObject); }
                   
                    w.completed = true;

                }




            }

        }

    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Bullet")
        {

            health--;
            if (health <= 0)
            {
                //do some sound and
                Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.tag == "player") {
            //do something to the main character

        }



    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

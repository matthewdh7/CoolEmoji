using UnityEngine;

public class Boss: MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] waypoints;
    private bool moving;
   int stage;
    public float Speed;
    public float gravity;
    Vector2 destiny;
    Animator animate;
    SpriteRenderer sr;
    GameObject player;
    public Sprite BlackHole;
    Rigidbody2D rd;
    CircleCollider2D cd;
    public GameObject sunproj;
    public GameObject explosion;
   
    float waitTimeActual=10;
   public float waitTime;
    public int health;
    int initialHealth;
    int projectileStore;
    void Start()
    {
        if (health == 0)
        {
            health = 20;
        }
        initialHealth = health;

        waitTime = waitTimeActual*Time.deltaTime;
        stage = 2;
        projectileStore = 5;
        cd = gameObject.GetComponent<CircleCollider2D>();
        rd = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animate = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        moving = false;
        waypoints = GameObject.FindGameObjectsWithTag("SunWavePoint");
        foreach (GameObject g in waypoints) {
        g.SetActive(false);
        }
        destiny = chooseRandomWayPoint();
        Debug.Log(destiny.x+ "is found");

    }

    // Update is called once per frame
    void Update()
    {
        if (health > initialHealth/2) { stage = 1; }
        else if(health > 0 && health <= initialHealth/2)
        {

            stage = 2;
        }
        else if (health <= 0 )
        {
            Instantiate(explosion,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (stage == 1)
        {
            if (waitTime <= 0)
            {


                animate.SetBool("blackHolestage", false);
                if (moving)
                {

                    goToWaypoint(destiny, this.Speed);
                    if ((gameObject.transform.position.x > destiny.x - 0.5 && gameObject.transform.position.x < destiny.x + 0.5) && (gameObject.transform.position.y > destiny.y - 0.5 && gameObject.transform.position.y < destiny.y + 0.5))
                    {
                        moving = false;
                        destiny = chooseRandomWayPoint();


                    }
                }
                else
                {
                    ///fire missile then
                    GameObject o = Instantiate(sunproj, transform.position, Quaternion.identity) as GameObject;
                    o.GetComponent<SunRay>().direction = chooseRandomWayPoint();
                    moving = true;
                    waitTime = waitTimeActual;

                }
            }
            else { waitTime--; }

        }
        else if (stage == 2)
        {
            waitTimeActual = 20;
            sr.sprite = BlackHole;
            rd.useFullKinematicContacts = false;
            Vector2 o = new Vector2(-0.8600278f, 0);

            cd.offset = o;
            cd.radius = 3.6f;
            animate.SetBool("blackHolestage", true);
            if (waitTime <= 0)
            {
                if (moving)
                {


                    goToWaypoint(destiny, this.Speed);
                    if ((gameObject.transform.position.x > destiny.x - 0.5 && gameObject.transform.position.x < destiny.x + 0.5) && (gameObject.transform.position.y > destiny.y - 0.5 && gameObject.transform.position.y < destiny.y + 0.5))
                    {
                        if (gameObject.transform.localScale.x < 0.55f && gameObject.transform.localScale.y < 0.56f)
                        {

                            Shrink(0.5f);


                        }
                        else
                        {
                            moving = false;
                            waitTime = waitTimeActual;
                            destiny = chooseRandomWayPoint();

                        }
                    }
                }
                else
                {
                    ///fire missile then
                    ///
                    

                    if (gameObject.transform.localScale.x > 0.010f && gameObject.transform.localScale.y > 0.015f)
                    {
                        Shrink(-0.5f);

                    }
                    else
                    {
                        
                        moving = true;


                    }


                }



            }
            else { waitTime--; }


        }
    }

    public Vector2 chooseRandomWayPoint()
    {

        return waypoints[Random.Range(0, waypoints.Length)].transform.position;

    }

   

    void goToWaypoint(Vector2 target,float speed) {
        gameObject.transform.position=Vector2.MoveTowards(gameObject.transform.position,target,speed*Time.deltaTime);

    }

    void Shrink(float ShrinkSpeed) {
        gameObject.transform.localScale += new Vector3(ShrinkSpeed * Time.deltaTime, ShrinkSpeed * Time.deltaTime,0);
        cd.radius += ShrinkSpeed * Time.deltaTime;
        Vector2 forceDirection = player.transform.position - gameObject.transform.position;

        // apply force on target towards me
        player.GetComponent<Rigidbody2D>().AddForce(-forceDirection.normalized * 1/forceDirection.magnitude*gravity  * Time.fixedDeltaTime);
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Gabe add it here

        }else if (col.gameObject.CompareTag("Bullet"))
        {
            health--;

        }
        else if (col.gameObject.CompareTag("bossprojectile")) {

            
        }
        

    }

}

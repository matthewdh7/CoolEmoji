using UnityEngine;

public class SunRay : MonoBehaviour
{

    public Vector2 direction;
    public float speed;
    private float initializedtime;
    Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();


        speed = 10;
        initializedtime = Time.timeSinceLevelLoad;


    }

    // Update is called once per frame
    void Update()
    {
        rd.velocity = direction * speed * Time.deltaTime;
        if (Time.timeSinceLevelLoad > initializedtime + 4)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && HealthAmount.hurt == false)
        {
            HealthAmount.takenDamage = 0.05f;


            Destroy(gameObject);

        }
        else if (col.gameObject.CompareTag("Boss"))
        {

            //Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {

            Destroy(gameObject);
        }

    }

    void setDirection(Vector2 received)
    {

        this.direction = received;
    }

}

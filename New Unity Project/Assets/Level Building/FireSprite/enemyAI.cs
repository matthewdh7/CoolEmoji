using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    Vector3 bottomLeft;
    Vector3 topRight;
    Vector3 nextPos;
    bool newPos = false;
    public float moveSpeed;
    int horizontalDir= 1;
    int verticalDir = 1;
    int count = 0;
    public Transform fireballPrefab;
    GameObject yeti;
    public int health = 5;
    public int fireRate = 8;
    int fireCount;
    public int fireDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        yeti = GameObject.Find("Yeti");
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), yeti.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), yeti.GetComponent<CircleCollider2D>());
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        bottomLeft = transform.GetChild(0).position;
        topRight = transform.GetChild(1).position;
        nextPos = randPos();
        if (transform.position.x > nextPos.x) {
            horizontalDir = -1;
        }
        else {
            horizontalDir = 1;
        }
        if (transform.position.y > nextPos.y) {
            verticalDir = -1;
        }
        else {
            verticalDir = 1;
        }
        Debug.DrawLine(transform.position, nextPos, Color.red, 5f);
        Debug.Log(horizontalDir);
        Debug.Log(verticalDir);
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCount >= fireRate && Vector3.Distance(transform.position, yeti.transform.position) <= fireDistance)
        {
            firePunIntended();
            fireCount = 0;
        }
        if (count >= moveSpeed) {
        nextPos = randPos();
        Debug.DrawLine(transform.position, nextPos, Color.red, 5f);
        if (transform.position.x > nextPos.x) {
            horizontalDir = -1;
        }
        else {
            horizontalDir = 1;
        }
        if (transform.position.y > nextPos.y) {
            verticalDir = -1;
        }
        else {
            verticalDir = 1;
        }
        count = 0;
            fireCount++;
    }

    Vector2 move = new Vector2(Mathf.Abs(transform.position.x - nextPos.x) / moveSpeed * horizontalDir, Mathf.Abs(transform.position.y - nextPos.y) / moveSpeed * verticalDir);
    transform.Translate(move);
        count++;


    }
    Vector3 randPos() {
        return (new Vector3(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y), Random.Range(bottomLeft.z, topRight.z)));
    }
    void firePunIntended() {
        Vector3 yetiPos = yeti.transform.position;
        Vector3 firePos = transform.position;
        yetiPos = yetiPos - firePos;
        Instantiate(fireballPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(yetiPos.y, yetiPos.x) * Mathf.Rad2Deg)));
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Bullet") {
            health -= 1;
            Debug.Log("Oof");
            if(health <= 0) {
                Destroy(this.gameObject);
            }
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    float timeToFire = 0;
    public Transform BulletTrailPrefab;
    public Transform BulletAmmoPrefab;
    Transform firePoint;
    public int bulletMagazine = 4;
    int bulletCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if(firePoint == null) {
            Debug.LogError("No Firepoint? What!");

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate == 0) {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        }
        else {
            if(Input.GetButton("Fire1") && Time.time > timeToFire){
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void Shoot() {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); // Gets the location of the firepoint as a vector
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        Effect();
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
        if(hit.collider != null) {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }
    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
        if(bulletCount >= bulletMagazine) {
            Instantiate(BulletAmmoPrefab, transform.GetChild(1).position, Quaternion.Inverse(transform.GetChild(1).rotation));
            bulletCount = 0;
        }
        bulletCount++;
        
    }
}

using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject target;
    public Transform cannon;

    public GameObject bullet;

    public int range;

    public float fireRate;
    float fireTimer;

    private void Start()
    {
        fireTimer = 0.0f;
    }

    private void Update()
    {
        if (target.activeSelf)
        {
            cannon.transform.LookAt(target.transform.position);

            if (Vector3.Distance(target.transform.position, transform.position) <= range)
            {
                if (fireTimer >= fireRate)
                {
                    fireTimer = 0.0f;

                    Homing homing = Instantiate(bullet, cannon.position, cannon.rotation).GetComponent<Homing>();
                    homing.SetTarget(target.gameObject);
                }
                fireTimer += Time.deltaTime;

                return;
            }
            fireTimer = 0.0f;
        }
    }

}

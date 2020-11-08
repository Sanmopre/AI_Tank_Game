using UnityEngine;

public class Homing : MonoBehaviour
{
    public int speed;
    public GameObject explosion;

    float gravity = -20.0f;
    float distance;

    Vector3 target;

    Vector3 pos;
    Vector3 vel;

    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        Vector3 toTarget = (target - pos);
        toTarget.y = 0.0f;
        distance = toTarget.magnitude;

        vel = toTarget.normalized * speed;
        float vox = (new Vector2(vel.x, vel.z)).magnitude;

        vel.y = -gravity * distance / (2 * vox);
    }

    // Update is called once per frame
    void Update()
    {
        vel.y += gravity * Time.deltaTime;

        pos.x += vel.x * Time.deltaTime;
        pos.y += vel.y * Time.deltaTime;
        pos.z += vel.z * Time.deltaTime;

        transform.forward = vel;

        if (pos.y <= 0.0f)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (pos.x - 4 < enemy.transform.position.x && enemy.transform.position.x < pos.x + 4)
                if (pos.z - 4 < enemy.transform.position.z && enemy.transform.position.z < pos.z + 4)
                    enemy.GetComponent<TankStats>().Damage();
            Destroy(gameObject, 0.0f);
        }

        transform.position = pos;
    }

    public void SetTarget(GameObject tar)
    {
        enemy = tar;

        int x = Random.Range(-5, 5);
        int z = Random.Range(-5, 5);
        target = tar.transform.position + tar.transform.forward.normalized * 2;
        target += new Vector3(x, 0, z);
    }
}

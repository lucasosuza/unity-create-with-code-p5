using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float MIN_SPEED = 12.0f;
    private const float MAX_SPEED = 16.0f;
    private const int MAX_TORQUE = 10;
    private const int SPAWM_RANGE_X = 4;
    private const int SPAWM_RANGE_Y = -6;
    private Rigidbody targetRigidbody;

    private GameController gameController;

    public int pointValue = 5;

    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Game Manager").GetComponent<GameController>();

        targetRigidbody = GetComponent<Rigidbody>();
        targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameController.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private static Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-SPAWM_RANGE_X, SPAWM_RANGE_X), SPAWM_RANGE_Y);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MIN_SPEED, MAX_SPEED);
    }

    float RandomTorque()
    {
        return Random.Range(-MAX_TORQUE, MAX_TORQUE);
    }
}

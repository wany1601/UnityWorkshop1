using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float angularSpeed;

    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    public float timeToLive;


    // Start is called before the first frame update
    void Start()
    {
        // TODO: Obtain relevant information from GameSettings
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Setup inputs to move the player left, right, forward and backwards
        // TODO: Press a specific button to spawn a shield
        // TODO: Deduct the number of shields available (consider writing this code in another component)

        // Read from input manager
        // (We will use the New Input System later)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Translate towrds input direction
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = Vector3.ClampMagnitude(direction, 1f);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            // Rotate towards the direction vector
            Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, angularSpeed * Time.deltaTime);
        }

        // Press a specific button to spawn a shield
        if (Input.GetKeyDown(KeyCode.Space) && prefabToSpawn != null && spawnPoint != null && GameSettings.ShieldsAvailable != 0)
        {
            // Spawn the prefab on the spawn point
            GameObject obj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Destroy after some time
            if (timeToLive > 0)
            {
                Destroy(obj, 5f);
            }
            GameSettings.ShieldsAvailable--;
        }

        // Deduct the number of shields available
    }
}

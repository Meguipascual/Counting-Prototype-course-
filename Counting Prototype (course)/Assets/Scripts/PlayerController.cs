using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20;
    private int ballUsed = 0;
    [SerializeField] private float rightOffset = -24f;
    [SerializeField] private float leftOffset = 20.5f;
    [SerializeField] private Text ballsLeftText;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        ballsLeftText.text = "Balls : " + ObjectPooler.SharedInstance.amountToPool;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (gameObject.transform.position.z > leftOffset)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, leftOffset);
        }
        else if (gameObject.transform.position.z < rightOffset)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, rightOffset);
        }
        else
        {
            gameObject.transform.position += (Vector3.forward * speed * Time.deltaTime * horizontalInput);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            var numberOfBalls = ObjectPooler.SharedInstance.amountToPool;

            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
                ballUsed++;
            }
            ballsLeftText.text = "Balls : " + (numberOfBalls - ballUsed);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControlle : MonoBehaviour
{

    
    public float lifeTime = 10;
    //public float rotationSpeed = 60;
    public float speed = 0.05f;
    public GameObject platform;

    Vector2 direction = new Vector2();

    /// <summary>
    /// Start this instance. Get Called by Unity when this GameObject enters the scene
    /// </summary>
    void Start()
    {
        direction = new Vector2(0, -1);
        // normalize direction so it does not impact the travel speed
        direction.Normalize();
    }

    /// <summary>
    /// Moves the asteroid downwards using speed and rotates it using rotationSpeed.
	/// Also kills the object after lifeTime expires. Update is called each frame by Unity.
    /// </summary>
	void Update()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        //transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward); // not sure if needed

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

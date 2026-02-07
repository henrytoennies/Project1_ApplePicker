using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    public GameObject bombPrefab;

    // Speed at which the Apple Tree moves
    static public float speed = 10f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the Apple tree will change directions
    static public float chanceToChangeDirections = 0.01f;

    //rate at which apples will be instantiated
    static public float secondsBetweenAppleDrops = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke( "DropApple", 2f);
    }

    void DropApple()
    {
        Vector3 pos = transform.position;
        pos.x += 18;
        pos.y += 8;
        pos.z += 17;
        if (Random.value > 0.1) {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = pos;
        } else
        {
            GameObject bomb = Instantiate<GameObject>(bombPrefab);
            bomb.transform.position = pos;
        }
        
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the Apple Tree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the Apple tree will change directions
    public float chanceToChangeDirections = 0.1f;

    //rate at which apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;
    
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
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = pos;
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

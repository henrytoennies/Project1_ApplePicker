using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public static float bottomY = -20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            if (this.tag == "Apple") {
                Destroy(this.gameObject);
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                apScript.AppleDestroyed();
            } else if (this.tag == "Bomb")
            {
                Destroy(this.gameObject);
            }
        }
    }
}

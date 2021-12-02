using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 0.05f;

    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 hasPackageColor = new Color32(0, 195, 35, 255);

    SpriteRenderer spriteRenderer; 

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision!");    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // if the thing we trigger is the package, print "package picked up" to the console
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
        }

        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        
    }
}

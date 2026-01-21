using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageUpgrades : MonoBehaviour
{
    public Canvas shopCanvas;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shopCanvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            shopCanvas.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            shopCanvas.enabled = false;
        }
    }
    public void BuyUpgrade()
    {
        if (player.GetComponent<colletables>() != null)
        {
            if (player.GetComponent<colletables>().cash >= 5)
            {
                player.GetComponent<PlatformerMovement>().UpgradeSpeed();
                player.GetComponent<colletables>().cash -= 5;
            }
            else
            {
                //Sound for something if you dont have the money for it.
            }
        }
    }
}
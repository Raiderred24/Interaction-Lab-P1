using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    public SpikeGen spikeGen;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * spikeGen.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("nextLine"))
        {
            spikeGen.GenerateNextSpikeWithRandom();
        }

        if (collision.gameObject.CompareTag("finish"))
        {
            Destroy(this.gameObject);
        }
    }
}

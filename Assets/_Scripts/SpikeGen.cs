using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGen : MonoBehaviour
{

    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeWithRandom()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randomWait);
    }

    public void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGen = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}

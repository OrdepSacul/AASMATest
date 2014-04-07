using UnityEngine;
using System.Collections;

public class ResourceSpawner : MonoBehaviour {

    public int MaxResources;
    public Transform agent;

    // Use this for initialization
    void Start()
    {

        var randX = 0.0f;
        var randY = 0.0f;

        for (int i = 0; i < MaxResources; i++)
        {
            randX = (Random.value*2.0f - 1) * 9;
            randY = (Random.value * 2.0f - 1) * 9;
            Instantiate(agent, new Vector3(randX, randY, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

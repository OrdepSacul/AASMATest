using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Transform agent;

    public int NumAgents = 5;

	// Use this for initialization
	void Start () {


        for (int i = 0; i < NumAgents; i++)
            Instantiate(agent, new Vector3(9f + i , -9f , 0), Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
	
	}



}

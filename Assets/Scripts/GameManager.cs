using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject[] attackablePrafabs;
 
    public int platfromSpawnCount;

    //public Transform lastEndPoint;
    public Vector3 lastEndPoint;
    public void SpawnPlatforms()
    {
        for (int i = 0; i < platfromSpawnCount; i++)
        {
          GameObject platform = GameObject.Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)] );
            Platforms platformScript = platform.GetComponent<Platforms>();

            platform.transform.position = lastEndPoint;

            int x = Random.Range(0, 10);
            
                if (x >= 7)
                {
                    GameObject tree = GameObject.Instantiate(attackablePrafabs[Random.Range(0, attackablePrafabs.Length)]);
                tree.transform.position = lastEndPoint + new Vector3(0, 2.08f, 0);
                }

                
            



            lastEndPoint = platformScript.ReturnEndPoint();


           
        }
    }



    private void Awake()
    {


    }




    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatforms();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}

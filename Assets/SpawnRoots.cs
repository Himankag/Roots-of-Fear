using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoots : MonoBehaviour
{
    public int minZ;
    public int maxZ;
    public int rangeX;
    public float waitingTime = 0.5f;
    public GameObject rootPrefab;
    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnARoot());
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
    }
    
    IEnumerator SpawnARoot(){
        while (true){
        int zRand = Random.Range((int)currentPos.z + minZ, (int)currentPos.z + maxZ);
        int xRand = Random.Range((int)currentPos.x - rangeX, (int)currentPos.x + rangeX);
        Vector3 randomSpawnVector = new Vector3(xRand,3.53f,zRand);
        Instantiate(rootPrefab,randomSpawnVector,Quaternion.Euler(11.8f,0,-180));
        yield return new WaitForSeconds(waitingTime);
        }
    }
}

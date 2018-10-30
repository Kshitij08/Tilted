using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour {

    public GameObject stack;
    public GameObject platform;
    public int stackLength = 7;
    private float[] stackArray;
    public GameObject[] blockArray;
    public float stopTime;
    public float stopPause = 30;

    private void Awake()
    {
        stackArray = new float[stackLength];
        blockArray = new GameObject[stackLength];
        float f = 0;
        for (int i = 1; i < stackLength + 1; i++)
        {
            
            stackArray[i-1] = f;
            f = f - 0.5f;
        }
        stopTime = stopPause;
       
       


    }

    // Use this for initialization
    void Start () {
        for (int j = 0; j < stackLength; j++)
        {
            GameObject stackClone = Instantiate(stack, new Vector3(0, stackArray[j], 0), transform.rotation);
            blockArray[j] = stackClone;
        }
        GameObject initializedPlane = Instantiate(platform, new Vector3(0, 0.35f, 0), transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        float t = Time.timeSinceLevelLoad;
        if (t<1) Physics.gravity = new Vector3(0, -9.8f, 0);
        else
        Physics.gravity  = new Vector3(0, -9.8f * Mathf.Log(t,10f) , 0);
// Physics.gravity *= new Vector3(0,0,0);
        stopTime = stopTime - Time.deltaTime;
       // Debug.Log(stopTime);
        if (stopTime < 0)
        {
            StartCoroutine(BlockDestroyer());
            stopTime = stopPause;
        }

    }

    public IEnumerator BlockDestroyer()
    {
        int count = blockArray[0].transform.childCount;
        if (count == 4)
        {
            int n = Random.Range(2, 4);
            int c = Random.Range(0,4);
            /*if(c == 0)
            {
                Destroy(blockArray[0].transform.GetChild(blockArray[0].transform.childCount - 1).gameObject);
                Destroy(blockArray[0].transform.GetChild(blockArray[0].transform.childCount - 1).gameObject);
            }
            else if(c == 1) {
                Destroy(blockArray[0].transform.GetChild(0).gameObject);
            }*/
            
            Destroy(blockArray[0].transform.GetChild(c).gameObject);
            Destroy(blockArray[0].transform.GetChild((c+1)%4).gameObject);
            if (n==3) Destroy(blockArray[0].transform.GetChild((c + 2) % 4).gameObject);

        }
        else
        {
            Destroy(blockArray[0]);
            Debug.Log("Started");
            
            for (int i = 0; i < stackLength - 1; i++)
            {
                blockArray[i] = blockArray[i + 1];
            }
            GameObject stackClone = Instantiate(stack, new Vector3(0, blockArray[5].transform.position.y - 0.5f, 0), transform.rotation);
            blockArray[6] = stackClone;
        }
        
        
        //yield return new WaitForSecondsRealtime(2);
        yield return null;

    }

}

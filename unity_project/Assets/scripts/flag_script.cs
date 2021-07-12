using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class flag_script : MonoBehaviour
{
    public GameObject[] _objects;
    public Dictionary<float, GameObject> distDic = new Dictionary<float, GameObject>();
    public Transform objecttransfom;
    //public GameObject ui;
    public GameObject objToTP;
    public Transform tpLoc;
    public GameObject coin; 
    public GameObject checkpoint;
    // Use this for initialization
    void Start()
    {
        // Populate array for testing purpose - use your array of objects
        _objects = GameObject.FindGameObjectsWithTag("ground");
        foreach (GameObject obj in _objects)
        {
            float dist = Vector3.Distance(gameObject.transform.position, obj.transform.position);
            distDic.Add(dist, obj);
        }
        List<float> distances = distDic.Keys.ToList();
        distances.Sort();
        GameObject furthestObj = distDic[distances[distances.Count - 1]];
        objecttransfom = furthestObj.GetComponent<Transform>();
        tpLoc = objecttransfom;
        objToTP.transform.position = tpLoc.transform.position + new Vector3(0, 1.3f, 0);
        GameObject.FindWithTag("Player").GetComponent<player>().Updateval();
        int i = 0;
        foreach(GameObject o in _objects) 
        {
            i++;
            if (i == 2)
            {
                if (Random.Range(1,4) == 2)
                {
                    Instantiate(coin, o.transform.position + new Vector3 (0, 1, 0) , Quaternion.identity);
                }
                if (Random.Range(1,3) == 2)
                {
                    Instantiate(checkpoint, o.transform.position + new Vector3 (0, 1, 0) , Quaternion.identity);
                }
                // Instantiate(coin, o.transform.position + new Vector3 (0, 1, 0) , Quaternion.identity);
                // Instantiate(checkpoint, o.transform.position + new Vector3 (0, 1, 0) , Quaternion.identity);
                i = 0;
            }
            
            // if (i == 2)
            // {
            //     Instantiate(checkpoint, o.transform.position + new Vector3 (0, 1, 0) , Quaternion.identity);
            //     i = 0;
            // }
        }
    }
    void Update()
    {
        objToTP.transform.position = tpLoc.transform.position + new Vector3 (0,1.3f,0);
    }
}
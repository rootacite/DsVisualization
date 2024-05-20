using UnityEngine;

public class Connection : MonoBehaviour
{
    public LineRenderer line;
    public GameObject obj1, obj2;
    Vector3[] c = new Vector3[2];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line.positionCount = 2;
        line.SetPositions(c);
    }

    // Update is called once per frame
    void Update()
    {
        if(!obj1 || !obj2)return;
        
        c[0] = obj1.transform.position;
        c[1] = obj2.transform.position;
        line.SetPositions(c);
    }
}

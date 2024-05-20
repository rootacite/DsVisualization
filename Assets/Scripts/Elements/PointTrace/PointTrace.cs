using UnityEngine;

public class PointTrace : MonoBehaviour
{
    void Update()
    {
        var p = Input.mousePosition;
        var wp = Camera.main.ScreenToWorldPoint(p);
        transform.position = new Vector3(wp.x, wp.y, transform.position.z);
    }
}

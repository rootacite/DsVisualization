using UnityEngine;

public class Dragable : MonoBehaviour
{
    GameObject PointTrace;
    Collider2D col;

    Vector3 relPos;
    bool draging = false;
    void Awake()
    {
        PointTrace = GameObject.Find("PointTrace");
        col = GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(PointTrace.transform.position, Vector2.zero);
            if(hit.collider == col && hit.collider != null) {
                relPos = transform.position - PointTrace.transform.position;
                draging = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            draging = false;
        }

        if(draging)
        {
            transform.position = PointTrace.transform.position + relPos;
        }
    }
}

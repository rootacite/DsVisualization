using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    MouseNotify mouseNotify;
    GameObject PointTrace;
    PrefabStore prefabStore; 

    bool status = true;
    GameObject cont;
    Vector3 originPos, mousePos;

    private void _drawTree(TreeNode root, GameObject parent, Dictionary<TreeNode, GameObject> objs)
    {
        if(parent == null)
        {
            var node = Instantiate(prefabStore.Node);
            var nodeController = node.GetComponent<Node>();
            nodeController.SetContent(root.val);
            nodeController.SubNode = root;
            objs.Add(root, node);

            if(root.children != null)
                foreach(var i in root.children)
                {
                    _drawTree(i, node, objs);
                }
        }
        else
        {
            var node = Instantiate(prefabStore.Node);
            var nodeController = node.GetComponent<Node>();
            nodeController.SetContent(root.val);
            nodeController.SubNode = root;
            objs.Add(root, node);

            var ctn = Instantiate(prefabStore.Connection);
            var ctnController = ctn.GetComponent<Connection>();
            ctnController.obj1 = parent;
            ctnController.obj2 = node;

            if(root.children != null)
                foreach(var i in root.children)
                {
                    _drawTree(i, node, objs);
                }
        }
    }

    public void DrawTree(TreeNode head)
    {
        Dictionary<TreeNode, GameObject> nodeDic = new();
        _drawTree(head, null, nodeDic);

        Queue<TreeNode> qt = new();
        qt.Enqueue(head);

        float ly = 0f;

        do
        {
            int cc = qt.Count;
            float sx = - (cc - 1f) / 2f;
            sx *= 1.5f;

            for(int i=0;i<cc;i++)
            {
                var n = qt.Dequeue();
                if(n.children != null)
                    foreach(var m in n.children) qt.Enqueue(m);

                nodeDic[n].transform.localPosition = new Vector3(sx, ly, 0);
                sx += 1.5f;
            }
            ly -= 1.5f;
        }while(qt.Count != 0);
    }

    void Awake()
    {
        mouseNotify = GameObject.Find("MouseNotify").GetComponent<MouseNotify>();
        PointTrace = GameObject.Find("PointTrace");
        prefabStore = GameObject.Find("PrefabStore").GetComponent<PrefabStore>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* mouseNotify.Clicked += (t, b) => {
            if(t == 0 && b == 0)
            {
                if(status)  // Mouse first clicked
                {
                    var obj = new GameObject();
                    obj.transform.position = PointTrace.transform.position;
                    cont = Instantiate(prefabStore.Connection);
                    cont.GetComponent<Connection>().obj1 = obj;
                    cont.GetComponent<Connection>().obj2 = PointTrace;
                    obj.transform.parent = cont.transform;

                    status = false;
                }
                else
                {
                    var obj = new GameObject();
                    obj.transform.position = PointTrace.transform.position;
                    cont.GetComponent<Connection>().obj2 = obj;
                    obj.transform.parent = cont.transform;
                    
                    status = true;
                }
            }
            return true;
        };*/

        mouseNotify.Wheeled += (d) => {
           Camera.main.orthographicSize += -2.0f * d;
        };

        mouseNotify.Clicked += (t, b) => {
            if(t==0&&b==2)
            {
                var node = Instantiate(prefabStore.Node);
                var nodeController = node.GetComponent<Node>();
                if(nodeController == null) Debug.Log("Alert");
                nodeController.SetContent('Z');
            }
            return true;
        };

        TreeNode h = new();
        h.val = 'A';
        h.children = new TreeNode[2];

        h.children[0] = new(){ val = 'B' };
        h.children[1] = new(){ val = 'C' };

        h.children[0].children = new TreeNode[2];
        h.children[0].children[0] = new() {val = 'D'};
        h.children[0].children[1] = new() {val = 'E'};

        h.children[1].children = new TreeNode[3];
        h.children[1].children[0] = new() {val = 'F'};
        h.children[1].children[1] = new() {val = 'G'};
        h.children[1].children[2] = new() {val = 'H'};

        DrawTree(h);
    }
 
    // Update is called once per frame
    void Update()
    {
        // Right button for moving vision
        if(Input.GetMouseButtonDown(1)){
            mousePos = PointTrace.transform.position - Camera.main.gameObject.transform.position;
            originPos = Camera.main.gameObject.transform.position;
        }
        if(Input.GetMouseButton(1))
        {
            var nmp = PointTrace.transform.position - Camera.main.gameObject.transform.position;
            var dp = mousePos - nmp;

            Camera.main.gameObject.transform.position = originPos + dp;
        }
    }
}

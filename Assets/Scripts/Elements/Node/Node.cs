using TMPro;
using UnityEngine;

public class Node : MonoBehaviour
{
    public TextMeshPro TMP;
    public TreeNode SubNode;
    public void SetContent(char c)
    {
        TMP.text = c.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

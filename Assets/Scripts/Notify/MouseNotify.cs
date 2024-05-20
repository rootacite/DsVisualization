using UnityEngine;

public delegate bool MouseClickProc(int type, int button);
public delegate void MouseWheelProc(float delta);

public class MouseNotify : MonoBehaviour
{
    public event MouseClickProc Clicked;
    public event MouseWheelProc Wheeled;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Clicked?.Invoke(0, 0);
        if(Input.GetMouseButtonDown(1))
            Clicked?.Invoke(0, 1);
        if(Input.GetMouseButtonDown(2))
            Clicked?.Invoke(0, 2);

        if(Input.GetMouseButtonUp(0))
            Clicked?.Invoke(1, 0);
        if(Input.GetMouseButtonUp(1))
            Clicked?.Invoke(1, 1);
        if(Input.GetMouseButtonUp(2))
            Clicked?.Invoke(1, 2);

        var axis = Input.GetAxis("Mouse ScrollWheel");
        if(axis != 0)
        {
            Wheeled?.Invoke(axis);
        }
    }
}

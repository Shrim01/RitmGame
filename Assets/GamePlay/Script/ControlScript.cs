using UnityEngine;

public class ControlScript : MonoBehaviour
{
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        var position = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        var rotation = Mathf.Atan(position.y / position.x) * 180 / Mathf.PI;
        if (position.x < 0)
            rotation += 180;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
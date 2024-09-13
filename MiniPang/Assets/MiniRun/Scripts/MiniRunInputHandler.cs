using UnityEngine;

public class MiniRunInputHandler : MonoBehaviour
{
    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}

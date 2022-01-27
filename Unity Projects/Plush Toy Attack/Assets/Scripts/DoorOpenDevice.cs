using UnityEngine;
using System.Collections;
public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] private Vector3 dPos;
    private bool _open;
    public Animator animator;
    public void Activate()
    {
        if (!_open)
        {
            _open = true;
            animator.SetBool("character_nearby", true);
        }
    }
    public void Deactivate()
    {
        if (_open)
        {
            _open = false;
            this.animator.SetBool("character_nearby", false);
        }
    }
}
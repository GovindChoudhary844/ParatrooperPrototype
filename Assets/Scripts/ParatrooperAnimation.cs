using UnityEngine;

public class ParatrooperAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void StartWalking(bool walk)
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        anim.SetBool("IsWalking", walk);
    }
}
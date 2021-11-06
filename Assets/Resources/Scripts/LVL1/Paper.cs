using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private Animator _animator;
    public GameObject paper;
    private bool fly;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        fly = false;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "paper")
        {
            Destroy(paper);
            _animator.SetBool(("_isFly"), true);
            Invoke("Fly", 0.3f);
        }
        if (other.tag == "Ground" && fly == true )
        {
            _animator.SetBool(("_isFly"), false);
            _animator.Play("spig");
           fly = false;
        }
    }

    void Fly()
    {
        fly = true;
    }
}

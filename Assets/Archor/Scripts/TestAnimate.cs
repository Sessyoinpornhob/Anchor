using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestAnimate : MonoBehaviour
{
    public GameObject cube;
    private Rigidbody _rb;

    private float yy;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = cube.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("KeyDownZ");
            transform.DOLocalMoveY(300f, 0.1f, true);

            _rb.position = new Vector3(10f,0f,0) * 5000f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputTest : MonoBehaviour
{
    public GameObject target;

    private EventSystem _inputField;
    // Start is called before the first frame update
    void Start()
    {
        _inputField = this.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputField.SetSelectedGameObject(target);
    }
}

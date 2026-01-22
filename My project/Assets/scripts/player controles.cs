using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroles : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float Speed;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        transform.Translate(moveDirection * Speed * Time.deltaTime);

    }
}
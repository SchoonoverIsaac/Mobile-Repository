using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turn : MonoBehaviour
{
    Rigidbody2D rb;
    public float left = 5f;
    public float right = 5f;
    [SerializeField] private InputActionReference moveActionToUse;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
        float movex = Input.GetAxis("Horizontal");
        Vector2 vector21 = moveActionToUse.action.ReadValue<Vector2>();
        Vector2 vector2 = vector21;
        Vector2 moveDirection = vector2;

    }
    public void rightturn ()
    {
        Debug.Log("right called");
        Vector3 rot = GetComponent<Transform>().rotation.eulerAngles;
        rot.z -= 90;
        GetComponent<Transform>().rotation = Quaternion.Euler(rot);
       
    }
    public void leftturn()
    {
        Debug.Log("left called");
      
    }
}

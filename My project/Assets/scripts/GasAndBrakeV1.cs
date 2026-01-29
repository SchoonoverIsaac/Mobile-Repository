using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GasAndBrake : MonoBehaviour
{
    Rigidbody2D rb;
    public float Gas = 5f;
    public float Brake = 5f;
    [SerializeField] private InputActionReference moveActionToUse;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // when gas button is pressed move forword//
        float movex = Input.GetAxis("Vertical");
        Vector2 vector21 = moveActionToUse.action.ReadValue<Vector2>();
        Vector2 vector2 = vector21;
        Vector2 moveDirection = vector2;
       
        
           //when break is pressed slow down//

        
    }
    public void GasPedal()
    {
        Debug.Log("gas called");
        rb.AddForce(new Vector2(0, 100 * Gas));
    }
    public void Brakepedal()
    {
        Debug.Log("Brake called");
        rb.AddForce(new Vector2(0, -100 * Gas));
        if (rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(0,0);
        }
    }
}

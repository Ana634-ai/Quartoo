using UnityEngine;
using UnityEngine.InputSystem; // <- usa o novo sistema

public class MoverCilindro : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movX = 0f;
        float movZ = 0f;

        // Controlo com teclado usando o novo Input System
        var teclado = Keyboard.current;
        if (teclado != null)
        {
            if (teclado.wKey.isPressed || teclado.upArrowKey.isPressed)
                movZ = 1f;
            if (teclado.sKey.isPressed || teclado.downArrowKey.isPressed)
                movZ = -1f;
            if (teclado.aKey.isPressed || teclado.leftArrowKey.isPressed)
                movX = -1f;
            if (teclado.dKey.isPressed || teclado.rightArrowKey.isPressed)
                movX = 1f;
        }

        Vector3 movimento = new Vector3(movX, 0, movZ).normalized * velocidade;
        rb.linearVelocity = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z);
    }

    void OnCollisionEnter(Collision colisao)
    {
        Debug.Log("Colidiu com objeto de TAG: " + colisao.gameObject.tag);
    }
}
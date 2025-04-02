using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float waterSurfaceY = 1.5f; // Верхний уровень воды
    public float floatForce = 12f;     // Сила всплытия
    public float waterDrag = 5f;       // Сопротивление в воде

    private Rigidbody rb;
    private float objectHeight;        // Высота объекта

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectHeight = transform.localScale.y; // Высота = масштаб по Y
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // Глубина погружения (0 = не погружён, 1 = полностью)
            float submersion = Mathf.Clamp01((waterSurfaceY - transform.position.y) / objectHeight);
            rb.AddForce(Vector3.up * floatForce * submersion, ForceMode.Force);
            rb.linearDamping = waterDrag;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            rb.linearDamping = 0f; // Нет сопротивления в воздухе
        }
    }
}
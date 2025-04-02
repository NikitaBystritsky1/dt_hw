using UnityEngine;

public class WaterWaveAnimation : MonoBehaviour
{
    public float scrollSpeedX = 0.1f; // Скорость по X
    public float scrollSpeedY = 0.1f; // Скорость по Y
    private Material waterMat;
    private Vector2 offset;

    void Start()
    {
        // Получаем материал из рендерера
        waterMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Смещаем текстуру с течением времени
        offset.x += Time.deltaTime * scrollSpeedX;
        offset.y += Time.deltaTime * scrollSpeedY;
        
        // Применяем смещение к основной текстуре и нормал-карте
        waterMat.SetTextureOffset("_BaseMap", offset);
        waterMat.SetTextureOffset("_BumpMap", offset);
    }
}
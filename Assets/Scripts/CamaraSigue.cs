using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 5f;
    public Vector3 offset = new Vector3(0, 0, -10);
    
    void LateUpdate()
  {
        if (objetivo == null)
        {
            objetivo = GameObject.Find("Cuerpo")?.transform;
            if (objetivo == null) return;
        }
        
        Vector3 destino = objetivo.position + offset;
        transform.position = Vector3.Lerp(transform.position, destino, suavizado * Time.deltaTime);
    }
}
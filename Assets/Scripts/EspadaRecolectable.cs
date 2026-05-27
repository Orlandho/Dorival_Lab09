using UnityEngine;

public class EspadaRecolectable : MonoBehaviour
{
    public Color nuevoColor = new Color(1f, 0.2f, 0.2f);
    public float nuevoAncho = 0.2f;
    public float nuevoLargo = 0.9f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Cuerpo")
        {
            EquipamientoController equip = other.GetComponent<EquipamientoController>();
            
            if (equip != null)
            {
                equip.ReemplazarEspada(this);
                Destroy(gameObject);
            }
        }
    }
}
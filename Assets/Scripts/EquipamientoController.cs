using UnityEngine;
public class EquipamientoController : MonoBehaviour
{
[Header("ACCESORIOS")]
public GameObject sombrero;
public GameObject lentes;
public GameObject espada;
[Header("PARTÍCULAS")]
public ParticleSystem efectoParticulas;
private Rigidbody2D rb;
private Vector2 movimiento;
private bool tieneSombrero = true;
private bool tieneLentes = true;
private bool tieneEspada = true;
void Start()
{
rb = GetComponent<Rigidbody2D>();
}
void Update()
{
// Movimiento
float x = Input.GetAxisRaw("Horizontal");
float y = Input.GetAxisRaw("Vertical");
movimiento = new Vector2(x, y).normalized;
// Teclas
if (Input.GetKeyDown(KeyCode.Alpha1))
{
tieneSombrero = !tieneSombrero;
if (sombrero != null) sombrero.SetActive(tieneSombrero);
ActivarEfecto();
}
if (Input.GetKeyDown(KeyCode.Alpha2))
{
tieneLentes = !tieneLentes;
if (lentes != null) lentes.SetActive(tieneLentes);
ActivarEfecto();
}
if (Input.GetKeyDown(KeyCode.Alpha3))
{
tieneEspada = !tieneEspada;
if (espada != null) espada.SetActive(tieneEspada);
ActivarEfecto();
}
}
void FixedUpdate()
{
if (rb != null)
rb.linearVelocity = movimiento * 5f;
}
void ActivarEfecto()
{
if (efectoParticulas != null)
{
efectoParticulas.Stop(true,
ParticleSystemStopBehavior.StopEmittingAndClear);
efectoParticulas.Play();
}
}
public void ReemplazarEspada(EspadaRecolectable nuevaEspada)
    {
    if (espada == null) return;
    
    SpriteRenderer sr = espada.GetComponent<SpriteRenderer>();
    if (sr != null)
    {
        sr.color = nuevaEspada.nuevoColor;
	        espada.transform.localScale = new Vector3(nuevaEspada.nuevoAncho, nuevaEspada.nuevoLargo, 1);
        Debug.Log("¡Espada Roja obtenida!");
        ActivarEfecto();
    }
    }
}
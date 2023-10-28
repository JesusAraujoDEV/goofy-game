using UnityEngine;
using UnityEngine.SceneManagement;

public class PlumasManager : MonoBehaviour
{   
    public static PlumasManager Instance { get; private set; }

    public int PlumasTotalesWhiteDuck { get { return plumasTotalesWhiteDuck; } }
    private int plumasTotalesWhiteDuck;

    public int PlumasTotalesBlackDuck { get { return plumasTotalesBlackDuck; } }
    private int plumasTotalesBlackDuck;
    public string TagPlayer { get { return tagPlayer;} }
    private string tagPlayer;
    private int vidas = 3;
    public HUD hud;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPlumas(int plumasASumar, string tag)
    {
        if (tag == "WhiteDuck")
        {
            plumasTotalesWhiteDuck += plumasASumar;
            hud.ActualizarPlumas(plumasTotalesWhiteDuck);
        }
        else if (tag == "BlackDuck")
        {
            plumasTotalesBlackDuck += plumasASumar;
            hud.ActualizarPlumas(plumasTotalesBlackDuck);
        }
        tagPlayer = tag;
        Debug.Log(plumasTotalesWhiteDuck);
        Debug.Log(plumasTotalesBlackDuck);
    }

    public void PerderVidas()
    {
        vidas--;
        hud.DesactivarVidas(vidas);
    }
}

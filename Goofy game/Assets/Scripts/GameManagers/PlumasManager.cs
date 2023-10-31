using UnityEngine;
using UnityEngine.SceneManagement;

public class PlumasManager : MonoBehaviour
{   
    public GameObject[] players;
    public static PlumasManager Instance { get; private set; }

    public int PlumasTotalesWhiteDuck { get { return plumasTotalesWhiteDuck; } }
    private int plumasTotalesWhiteDuck;

    public int PlumasTotalesBlackDuck { get { return plumasTotalesBlackDuck; } }
    private int plumasTotalesBlackDuck;
    public string TagPlayer { get { return tagPlayer;} }
    private string tagPlayer;
    private int vidasWhite = 3;
    private int vidasBlack = 3;
    public HUD hud;
    public MenuPausa menuPausa;
    public bool loTieneWhite;    
    public bool loTieneBlack;
    public GameObject babyWhite;
    public GameObject babyBlack;

    private void Awake()
    {
        Time.timeScale = 1f;
        if(Instance == null){
            Instance = this;
        }
        else{
            Debug.Log("Hay otro GameManager!!");
        }
        string scene = SceneManager.GetActiveScene().name;
        int aliveCount = 0;
        if (scene == "Granja" || scene == "Nieve" || scene == "Playa"){
            aliveCount = 0;

            foreach (GameObject player in players)
            {
                if (player.activeSelf) {
                    aliveCount++;
                }
            }

            if (aliveCount <= 0) {
                menuPausa.StatusWinner();
                //Invoke(nameof(NewRound), 3f);
            }
        }
        else{
            aliveCount = 0;

            foreach (GameObject player in players)
            {
                if (player.activeSelf) {
                    aliveCount++;
                }
            }

            if (aliveCount <= 1) {
                menuPausa.StatusWinner();
                //Invoke(nameof(NewRound), 3f);
            }
        }
    }
    public void ReiniciarVidas()
    {
        vidasWhite = 2;
        vidasBlack = 2;
    }


    public void SumarPlumas(int plumasASumar, string tag)
    {
        if (tag == "WhiteDuck")
        {
            plumasTotalesWhiteDuck += plumasASumar;
            hud.ActualizarPlumasWhite(plumasTotalesWhiteDuck);
        }
        else if (tag == "BlackDuck")
        {
            plumasTotalesBlackDuck += plumasASumar;
            hud.ActualizarPlumasBlack(plumasTotalesBlackDuck);
        }
        tagPlayer = tag;
        Debug.Log(plumasTotalesWhiteDuck);
        Debug.Log(plumasTotalesBlackDuck);
    }

    public void PerderVidas(string tag)
    {   
        if (tag == "WhiteDuck"){
            vidasWhite--;
            hud.DesactivarVidas(vidasWhite);
            
        }
        else if(tag == "BlackDuck"){
            vidasBlack--;
            hud.DesactivarVidasBlack(vidasBlack);
        }
    }

    public void ObtenerBaby(string tag){
        Debug.Log(tag);
        if (tag == "WhiteDuck"){
            hud.ActivarBabies(1,"WhiteDuck");
            loTieneWhite = true; 
        }
        else if(tag == "BlackDuck"){
            hud.ActivarBabies(0,"BlackDuck");
            loTieneBlack = true;
        }
    }
    public void DesobtenerBaby(string tag){
        Debug.Log(tag);
        if (tag == "WhiteDuck"){
            hud.DesactivarBabies(1,"WhiteDuck");
            loTieneWhite = false; 
        }
        else if(tag == "BlackDuck"){
            hud.DesactivarBabies(0,"BlackDuck");
            loTieneBlack = false;
        }
    }
    public void SuperActivacionWhite(){
        babyWhite.SetActive(true);
    }
    public void SuperActivacionBlack(){
        babyBlack.SetActive(true);
    }
}

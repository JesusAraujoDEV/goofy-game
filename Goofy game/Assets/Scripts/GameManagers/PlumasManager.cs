using UnityEngine;
using UnityEngine.SceneManagement;

public class PlumasManager : MonoBehaviour
{   
    public int PlumasTotalesWhiteDuck { get { return plumasTotalesWhiteDuck;} }
    private int plumasTotalesWhiteDuck;
    public int PlumasTotalesBlackDuck { get { return plumasTotalesBlackDuck;} }
    private int plumasTotalesBlackDuck;
    public string TagPlayer { get { return tagPlayer;} }
    private string tagPlayer;
    public void SumarPlumas(int plumasASumar, string tag){
        if (tag == "WhiteDuck"){
            plumasTotalesWhiteDuck += plumasASumar;
        }
        else if(tag == "BlackDuck"){
            plumasTotalesBlackDuck += plumasASumar;
        }
        tagPlayer = tag;
        Debug.Log(plumasTotalesWhiteDuck);
        Debug.Log(plumasTotalesBlackDuck);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
public class MapSettings
{
    public int Ncicles;
    public int MapWidth;
    public int MapHeight;
    public int AmountCells;
    public int AmountCleanWalls;
    public int XmoduleChest;
    public int YmoduleChest;
    public int XmodulePlayer;
    public int YmodulePlayer;
    public int AmountFlower;
    public int XmoduleFlower;
    public int AmountEnemy;
    public int XmoduleEnemy;
    public int YmoduleEnemy;
}

public class FunctionMenu : MonoBehaviour
{

    public static string JsonConfig;
    public GameObject SetMenuObj;
    public GameObject PanelButtonMain;
    public GameObject PanelButtonSetMenu;

    public InputField Nclicles, MapWidth, MapHeight, amountCells, amountCleanWalls;
    public InputField XModuleChest, YModuleChest, XModulePlayer, YModulePlayer;
    public InputField AmountFlower, XModuleFlower, AmountEnemy, XModuleEnemy, YModuleEnemy;

    // Start is called before the first frame update
    void Start()
    {
        PanelButtonMain.SetActive(true);
        SetMenuObj.SetActive(false);
        PanelButtonSetMenu.SetActive(false);
    }

    public void LoadGame()
    {
        Confirm();
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSetMenu()
    {
        SetMenuObj.SetActive(true);
        PanelButtonSetMenu.SetActive(true);
        PanelButtonMain.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseSetMenu()
    {
        SetMenuObj.SetActive(false);
        PanelButtonSetMenu.SetActive(false);
        PanelButtonMain.SetActive(true);
    }

    public void Confirm()
    {
        MapSettings save = new MapSettings();
        //Map setting
        save.Ncicles = int.Parse(Nclicles.text);
        save.MapWidth = int.Parse(MapWidth.text);
        save.MapHeight = int.Parse(MapHeight.text);
        save.AmountCells = int.Parse(amountCells.text);
        save.AmountCleanWalls = int.Parse(amountCleanWalls.text);

        //OBJ's Settings 1
        save.XmoduleChest = int.Parse(XModuleChest.text);
        save.YmoduleChest = int.Parse(YModuleChest.text);
        save.XmodulePlayer = int.Parse(XModulePlayer.text);
        save.YmodulePlayer = int.Parse(YModulePlayer.text);

        //OBJ's Settings 2
        save.AmountFlower = int.Parse(AmountFlower.text);
        save.XmoduleFlower = int.Parse(XModuleFlower.text);
        save.AmountEnemy = int.Parse(AmountEnemy.text);
        save.XmoduleEnemy = int.Parse(XModuleEnemy.text);
        save.YmoduleEnemy = int.Parse(YModuleEnemy.text);


        JsonConfig = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + JsonConfig);
    }
}

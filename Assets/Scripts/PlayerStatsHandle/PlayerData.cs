using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    // Character Stats
    public CharacterStat Strength;
    public CharacterStat Stamina;
    public CharacterStat Money;

    // PropFull
    private Vector3 _position = Vector3.zero;
    public Vector3 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    //Ctor
    public PlayerData(PlayerMovement player)
    {
        //_position = player.transform.position;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    

    private void Start()
    {
        Strength.BaseValue = 10;
        Stamina.BaseValue = 1000;
        Money.BaseValue = 100;

        DateTimeSystem.GameClockInstance.MinuteLoopEvent += HandleReduceStaminaOverTime;
    }
    private void FixedUpdate()
    {
        
    }

    public void HandleReduceStaminaOverTime(object sender, System.EventArgs e)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != Constant.Scene.Hospital && currentScene.name != Constant.Scene.Home)
        { // Only reduce stamina out of Hospital

            //Stamina.AddModifier(new StatModifier(-1, StatModType.Flat));

            if (Stamina.Value == 0)
            {
                Debug.Log("Out of stamina -> Move player to hospital");
                MovePlayerToHospital();
            }
        }
    }

    private void MovePlayerToHospital()
    {
        Scene sceneToLoad = SceneManager.GetSceneByName(Constant.Scene.Hospital);
        SceneManager.LoadScene(Constant.Scene.Hospital);
        SceneManager.MoveGameObjectToScene(this.gameObject, sceneToLoad);
    }
}

using System;

[Serializable]
public class PlayerModel
{
    public float Stamina { get; set; }
    public float Strength { get; set; }

    public PlayerModel()
    {

    }

    public PlayerModel(float Stamina, float Strength)
    {
        this.Strength = Strength;
        this.Stamina = Stamina;
    }
}
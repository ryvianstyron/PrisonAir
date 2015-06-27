using System;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
	private int TotalObjectives;
	private int CurrentTotalObjectives = 0;

	private static int TotalScore;
	public void SetTotalObjectives(int Total)
	{
		TotalObjectives = Total;
	}
	public void UpdateTotalObjectives()
	{
		CurrentTotalObjectives++;
	}
	public int GetTotalScore()
	{
		return TotalScore;
	}
	public float GetCompletion()
	{
		return (CurrentTotalObjectives/ TotalObjectives)* 100;
	}
     public static void Calculate(Enums.PrisonObjectType Type, Enums.Limb Limb)
    {
        float Percentage = 0;
        float ObstacleScore = 0;
        switch (Limb)
        {
            default:
                Debug.LogError("Score.cs: CalculateScore() Limb not found");
                break;

            case Enums.Limb.BN_L_Elbow:
            case Enums.Limb.BN_R_Elbow:
                Percentage = 0.70f;
                break;

            case Enums.Limb.BN_L_Foot:
            case Enums.Limb.BN_R_Foot:
                Percentage = 0.55f;
                break;

            case Enums.Limb.BN_L_Hand:
            case Enums.Limb.BN_R_Hand:
                Percentage = 0.55f;
                break;

            case Enums.Limb.BN_L_Hip:
            case Enums.Limb.BN_R_Hip:
                Percentage = 0.85f;
                break;

            case Enums.Limb.BN_L_Knee:
            case Enums.Limb.BN_R_Knee:
                Percentage = 0.70f;
                break;

            case Enums.Limb.BN_L_Shoulder:
            case Enums.Limb.BN_R_Shoulder:
                Percentage = 0.85f;
                break;

            case Enums.Limb.BN_M_Head:
                Percentage = 0.70f;
                break;
            case Enums.Limb.BN_M_Neck:
                Percentage = 0.85f;
                break;

            case Enums.Limb.BN_M_Pelvis:
            case Enums.Limb.BN_M_Torso:
                Percentage = 1.0f;
                break;
        }
        switch (Type)
        {
            case Enums.PrisonObjectType.Alarm:
                ObstacleScore = 100;
                break;
            case Enums.PrisonObjectType.Bars:
                    ObstacleScore = 200;
                    break;
            case Enums.PrisonObjectType.Bench:
                    ObstacleScore = 300;
                    break;
            case Enums.PrisonObjectType.Blimp:
                    ObstacleScore = 400;
                    break;
            case Enums.PrisonObjectType.BowlingPin:
                    ObstacleScore = 500;
                    break;
            case Enums.PrisonObjectType.Cabinet:
                    ObstacleScore = 600;
                    break;
            case Enums.PrisonObjectType.SecurityCamera:
                    ObstacleScore = 700;
                    break;
            case Enums.PrisonObjectType.CellBed:
                    ObstacleScore = 800;
                    break;
            case Enums.PrisonObjectType.Chair:
                    ObstacleScore = 900;
                    break;
            case Enums.PrisonObjectType.Computer:
                    ObstacleScore = 1000;
                    break;
            case Enums.PrisonObjectType.Counter:
                    ObstacleScore = 1100;
                    break;
            case Enums.PrisonObjectType.Desk:
                    ObstacleScore = 1200;
                    break;
            case Enums.PrisonObjectType.Detergent:
                    ObstacleScore = 1300;
                    break;
            case Enums.PrisonObjectType.FilingCabinet:
                    ObstacleScore = 1400;
                    break;
            case Enums.PrisonObjectType.FirstAid:
                    ObstacleScore = 1500;
                    break;
            case Enums.PrisonObjectType.Freezer:
                    ObstacleScore = 1600;
                    break;
            case Enums.PrisonObjectType.Fridge:
                    ObstacleScore = 1700;
                    break;
            case Enums.PrisonObjectType.Garbage:
                    ObstacleScore = 1800;
                    break;
            case Enums.PrisonObjectType.GarbageBin:
                    ObstacleScore = 1900;
                    break;
            case Enums.PrisonObjectType.Lamp:
                    ObstacleScore = 2000;
                    break;
            case Enums.PrisonObjectType.LaundryBasket:
                    ObstacleScore = 2100;
                    break;
            case Enums.PrisonObjectType.Locker:
                    ObstacleScore = 2200;
                    break;
            case Enums.PrisonObjectType.MetalDetector:
                    ObstacleScore = 2300;
                    break;
            case Enums.PrisonObjectType.Oven:
                    ObstacleScore = 2400;
                    break;
            case Enums.PrisonObjectType.PictureFrame:
                    ObstacleScore = 2500;
                    break;
            case Enums.PrisonObjectType.PoliceCar:
                    ObstacleScore = 2600;
                    break;
            case Enums.PrisonObjectType.Poster:
                    ObstacleScore = 2700;
                    break;
            case Enums.PrisonObjectType.PrisonTower:
                    ObstacleScore = 2800;
                    break;
            case Enums.PrisonObjectType.Radio:
                    ObstacleScore = 2900;
                    break;
            case Enums.PrisonObjectType.RollerBed:
                    ObstacleScore = 3000;
                    break;
            case Enums.PrisonObjectType.Shower:
                    ObstacleScore = 3100;
                    break;
            case Enums.PrisonObjectType.SinkTub:
                    ObstacleScore = 3200;
                    break;
            case Enums.PrisonObjectType.Stall:
                    ObstacleScore = 3300;
                    break;
            case Enums.PrisonObjectType.Stool:
                    ObstacleScore = 3400;
                    break;
            case Enums.PrisonObjectType.Table:
                    ObstacleScore = 3500;
                    break;
            case Enums.PrisonObjectType.Toilet:
                    ObstacleScore = 3600;
                    break;
            case Enums.PrisonObjectType.TubeLight:
                    ObstacleScore = 3700;
                    break;
            case Enums.PrisonObjectType.TV:
                    ObstacleScore = 3800;
                    break;
            case Enums.PrisonObjectType.UHaulTruck:
                    ObstacleScore = 3900;
                    break;
            case Enums.PrisonObjectType.VendingMachine:
                    ObstacleScore = 4000;
                    break;
            case Enums.PrisonObjectType.WashingMachine:
                    ObstacleScore = 4100;
                    break;
        }
        TotalScore += (int) (ObstacleScore * Percentage);
    }
    public void Update()
     {
         GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE: " + TotalScore;
         if (GameManager.LevelOverScreen.IsVisible())
         {
             GameObject.Find("Score").GetComponent<Text>().text = "SCORE: " + TotalScore; 
         } 
     }
}

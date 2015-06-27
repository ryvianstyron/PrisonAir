using UnityEngine;
using System.Collections;

public class Criminal : MonoBehaviour 
{
	public int NumberOfObstaclesHit = 0;
    public int CriminalType;

	public float floorHeight;
	public bool isHit = true;

	private GameObject frontWall;

	private const int HIT_MAX = 1;

	private int bowlingPinHitCount = 0;
	private int spikesHitCount = 0;
	private int fireRingHitCount = 0;
	private int towerHitCount = 0;
	private int spotlightHitCount = 0;
	private int toiletHitCount = 0;
    private int megaBowlingPinHitCount = 0;
    private int ropeSoapHitCount = 0;
    private int prisonBarsHitCount = 0;
    private int washingMachineHitCount = 0;
    private int benchPressBarHitCount = 0;
    private int prisonAlarmHitCount = 0;
	private int explosiveBarrelHitCount = 0;
	private int boltHitCount = 0;
	private int prisonBedHitCount = 0;
	private int cardboardHitCount = 0;

	private bool hitTerrain = false;
	private bool hitFrontWall = false;
	private bool hitOtherWall = false;
	private bool hitPrisonFloor = false;
	private bool hitBarbedWire = false;
	private bool startCameraResetTimer = false;

	private Camera prisonerCamera;
	private Camera catapultCamera;
	
	private float HighestHeightAchieved = 0;
	private float cameraTime = 5.0f;

	private Cop CopSetUp;
	private CameraMovement cameraMovement;
	private UI ui;

    void Start()
    {
		CopSetUp = GameObject.Find ("Cop").GetComponent<Cop>();
		floorHeight = GameObject.Find("PrisonFloorLowest").transform.position.y;
		catapultCamera = GameObject.Find("Camera").GetComponent<Camera>();
		prisonerCamera = GameObject.Find("PrisonerCam").GetComponent<Camera>();
		cameraMovement = GameObject.Find("PrisonerCam").GetComponent<CameraMovement>();
		prisonerCamera.transform.position = new Vector3(49.676f,21.877f,-130.41f);
		frontWall = GameObject.Find("TrackerWall");
		ui = GameObject.Find ("CatapultAnimWithoutCircle").GetComponent<UI>();

		HighestHeightAchieved = Mathf.Abs (transform.position.y - floorHeight);

		ui.resetBarAndCanFire = false;
		catapultCamera.enabled = false;
		prisonerCamera.enabled = true;

    }
    public void SetCriminalType(int CriminalType)
    {
        this.CriminalType = CriminalType;
    }
    public int GetCriminalType()
    {
        return CriminalType;
    }
	void OnTriggerEnter(Collider Collider)
	{
		if(Collider.gameObject.tag.Contains ("Water"))
		{

		}
	}
    void Update()
    {
		GameObject Prisoner = transform.parent.gameObject;
		Component [] Limbs = Prisoner.GetComponentsInChildren(typeof(Rigidbody));
		/*foreach(Rigidbody RGB in Limbs)
		{
			//LimbCollider LimbCollider = RGB.GetComponent<LimbCollider>();
			if(LimbCollider.HasLimbCollided())
			{
				    startCameraResetTimer = true;
					//PrisonObstacle PrisonObstacle = (PrisonObstacle)GameObject.FindGameObjectWithTag(LimbCollider.GetTagOfObjectHit()).GetComponent<PrisonObstacle>();
					//Debug.Log ("Criminal.cs ->Limb: " + LimbCollider.GetLimbName() + " collided with: " + PrisonObstacle.GetObstacleTag());
					
					// For all past wall objects
					bool ApplyScore = false;
					if(PrisonObstacle.GetObstacleTag().Contains("BowlingPin"))
					{	
						bowlingPinHitCount++;
						if(bowlingPinHitCount <= HIT_MAX)
						{
							//Debug.Log ("Bowling Pin Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("PrisonBed"))
					{	
						prisonBedHitCount++;
						if(prisonBedHitCount <= HIT_MAX)
						{
							Debug.Log ("PrisonBed Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Cardboard"))
					{	
					    cardboardHitCount++;
						if(cardboardHitCount <= HIT_MAX)
						{
							Debug.Log ("Cardboard Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Spikes"))
					{
						spikesHitCount++;
						if(spikesHitCount <= HIT_MAX)
						{
							Debug.Log ("Spikes Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("FireRing"))
					{
						fireRingHitCount++;
						if(fireRingHitCount <= HIT_MAX)
						{
							Debug.Log ("Fire Ring Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Blimp"))
					{
						Debug.Log ("Blimp Hit!");
						PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
						ApplyScore = true;
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Bolt"))
					{
						boltHitCount++;
						if(boltHitCount <= HIT_MAX)
						{
							Debug.Log ("Bolt Ring Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Tower"))
					{
						towerHitCount++;
						if(towerHitCount <= HIT_MAX)
						{
							Debug.Log ("Tower Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Spotlight"))
					{
						spotlightHitCount++;
						if(spotlightHitCount <= HIT_MAX)
						{
							Debug.Log ("Spotlight Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("ExplosiveBarrel"))
					{
						explosiveBarrelHitCount++;
						if(explosiveBarrelHitCount <= HIT_MAX)
						{
							Debug.Log ("ExplosiveBarrel Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("Toilet"))
					{
						toiletHitCount++;
						if(toiletHitCount <= HIT_MAX)
						{
							Debug.Log ("Toilet Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if(PrisonObstacle.GetObstacleTag().Contains("BarbedWire"))
					{
						if (!hitBarbedWire)
						{
							Debug.Log("Barbed wire Hit!");
							PrisonObstacle.SetHitBarbedWireAtHeight(transform.position.y);
							hitOtherWall = true;
							ApplyScore = true;
						}
						else if(hitBarbedWire)
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("MegaBowlingPin"))
					{
						if (megaBowlingPinHitCount <= HIT_MAX)
						{
							Debug.Log("MegaBowlingPin Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("RopeSoap"))
					{
						if (ropeSoapHitCount <= HIT_MAX)
						{
							Debug.Log("RopeSoap Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("PrisonBars"))
					{
						if (prisonBarsHitCount <= HIT_MAX)
						{
							Debug.Log("PrisonBars Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("WashingMachine"))
					{
						if (washingMachineHitCount <= HIT_MAX)
						{
							Debug.Log("WashingMachine Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("BenchPressBar"))
					{
						if (benchPressBarHitCount <= HIT_MAX)
						{
							Debug.Log("BenchPressBar Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("PrisonAlarm"))
					{
						prisonAlarmHitCount++;
						if (prisonAlarmHitCount <= HIT_MAX)
						{
							Debug.Log("PrisonAlarm Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							ApplyScore = true;
						}
						else
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("Wall"))
					{
						if (!hitOtherWall)
						{
							Debug.Log("Other Wall Hit!");
							PrisonObstacle.SetHitWallAtHeight(transform.position.y);
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							hitOtherWall = true;
							ApplyScore = true;
						}
						else if(hitOtherWall)
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("FrontWall"))
					{
						if (!hitFrontWall)
						{
							Debug.Log("Front Wall Hit!");
							hitFrontWall = true;
							ApplyScore = true;
						}
						else if(hitFrontWall)
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("PrisonFloor"))
					{
						if (!hitPrisonFloor)
						{
							Debug.Log("Prison Floor Hit!");
							PrisonObstacle.SetHighestHeightAchievedInArc(HighestHeightAchieved);
							PrisonObstacle.SetPrisonerDistancePastWall(transform.position.z);
							hitPrisonFloor = true;
							ApplyScore = true;
						}
						else if(hitPrisonFloor)
						{
							ApplyScore = false;
						}
					}
					else if (PrisonObstacle.GetObstacleTag().Contains("Terrain"))
					{
						if (transform.position.x < frontWall.transform.position.x || transform.position.x > frontWall.transform.position.x)
						{
							if (!hitTerrain)
							{
								Debug.Log("Terrain Hit!");
								hitTerrain = true;
								ApplyScore = true;
							}
							else if(hitTerrain)
							{
								ApplyScore = false;
							}
						}
					}
					if(ApplyScore)
					{
						PrisonObstacle.CalculateArcScore();
						NumberOfObstaclesHit++;
						switch(NumberOfObstaclesHit)
						{
							case 1: 
								ui.Hit1.enabled = true;
								ui.Hit1Text.text = PrisonObstacle.GetObstacleTag();
								break;
							case 2:
								ui.Hit2.enabled = true;
								ui.Hit2Text.text = PrisonObstacle.GetObstacleTag();
								break;
							case 3:
								ui.Hit3.enabled = true;
								ui.Hit3Text.text = PrisonObstacle.GetObstacleTag();
								break;
							case 4:
								ui.Hit4.enabled = true;
								ui.Hit4Text.text = PrisonObstacle.GetObstacleTag();
								break;
							default:
								Debug.Log ("Something went wrong");
								break;
						}
						if(NumberOfObstaclesHit > 4)
						{
							NumberOfObstaclesHit = 0;
							ui.Hit1Text.text = "";
							ui.Hit2Text.text = "";
							ui.Hit3Text.text = "";
							ui.Hit4Text.text = "";
							
							ui.Hit1.enabled = false;
							ui.Hit2.enabled = false;
							ui.Hit3.enabled = false;
							ui.Hit4.enabled = false;
						}
						LimbCollider.SetHasCollided(false);
					}
				}
		}*/
		if(startCameraResetTimer)
		{
			cameraTime -= Time.deltaTime;
		}
		if(cameraTime <= 0)
		{
			prisonerCamera.enabled = false;
			catapultCamera.enabled = true;
			startCameraResetTimer = false;
			cameraTime = 5.0f;
			ui.resetBarAndCanFire = true;
			ui.VelocityFiller.fillAmount = 0.0f;
			ui.PowerFiller.fillAmount = 0.0f;
			ui.PlayPowerBarFill = true;
			ui.PlayVelocityBarFill = true;
			ui.SpacePressedCount = 0;
			if(!(CopSetUp.GetNextPrisonerName().Contains("oup")))
			{
				ui.nextPrisonerInlist.text = CopSetUp.GetNextPrisonerName();
			}
			else 
			{
				Application.LoadLevel("ScoreScreen");
			}
			ui.Hit1Text.text = "";
			ui.Hit2Text.text = "";
			ui.Hit3Text.text = "";
			ui.Hit4Text.text = "";
			
			ui.Hit1.enabled = false;
			ui.Hit2.enabled = false;
			ui.Hit3.enabled = false;
			ui.Hit4.enabled = false;
			cameraMovement.prisonerT = null;
			prisonerCamera.transform.position = new Vector3(49.676f,21.877f,-130.41f);
			this.enabled = false;
		}
		if(Mathf.Abs (transform.position.y - floorHeight) > HighestHeightAchieved)
        {
			HighestHeightAchieved = Mathf.Abs (transform.position.y - floorHeight);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Proyecto26;

public class MilleniumItemManager : MonoBehaviour {
	private TileManager tileManager;
	public static int itemindex;

	[SerializeField]
	private int count;

	private List<MilleniumPuzzle> items = new List<MilleniumPuzzle>();
	private float[] itemLats;
	private float[] itemLons;
	private bool[] spawnedItem;


	private float previousLat, previousLon;


	void Start () {
	

		var music = PlayerPrefs.GetString("Music", "Default value");


	   if (music.Equals("yes"))
	   {
			if(!DiscoveryMusic.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
			{
				DiscoveryMusic.Instance.gameObject.GetComponent<AudioSource>().Play();
			}
			
			ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
			
	   } 


		itemLats = new float[count];
		itemLons = new float[count];
		spawnedItem = new bool[count];

		tileManager = GameObject.FindGameObjectWithTag ("TileManager").GetComponent<TileManager> ();
		itemPositions();
	}


	

	void Update () {
		SpawnItems();


		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

			if (Physics.Raycast (ray, out hit, 100f)) {
				if (hit.transform.tag.Substring(0,2) == "MI") {

				    itemindex = Int32.Parse(hit.transform.tag.Substring(2));

					MilleniumPuzzle item = hit.transform.GetComponent<MilleniumPuzzle> ();
					Destroy(item);
					FlipCard(item.milleniumType);
				}
			}
		}
	}

	void FlipCard(MilleniumItemType type) {
		string t = type.ToString ();
		SceneManager.LoadScene (2);
	}

	public void SpawnItems() {

		for(int i = 0; i < count; i++)
		{

			if (googleSignIn.locationdata[i] == false && spawnedItem[i] == false)
			{
				if(tileManager.getLat - itemLats[i] < 0.003f && tileManager.getLat - itemLats[i] > -0.003f && tileManager.getLon - itemLons[i] < 0.00103f && tileManager.getLon - itemLons[i] > -0.00103f)
				{
						MilleniumItemType type = (MilleniumItemType)(int)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MilleniumItemType)).Length);


						MilleniumPuzzle prefab = Resources.Load("MilleniumItems/puzzle", typeof(MilleniumPuzzle)) as MilleniumPuzzle;
						MilleniumPuzzle millenium_item = Instantiate(prefab, Vector3.zero, Quaternion.Euler(-100, 0, 0)) as MilleniumPuzzle;
						millenium_item.tileManager = tileManager;

						float newLat = tileManager.getLat + UnityEngine.Random.Range(-0.0001f, 0.0001f);
						float newLon = tileManager.getLon + UnityEngine.Random.Range(-0.0001f, 0.0001f);

						if(newLat == previousLat || newLon == previousLon)
					{
						 newLat = tileManager.getLat + UnityEngine.Random.Range(-0.0001f, 0.0001f);
						 newLon = tileManager.getLon + UnityEngine.Random.Range(-0.0001f, 0.0001f);
					}

					previousLon = newLon;
					previousLat = newLat;

						spawnedItem[i] = true;

						millenium_item.tag = "MI" + i;

						millenium_item.Init(newLat, newLon);
						items.Add(millenium_item);	
			    }
		}
		}
	}


	public void itemPositions()
	{
		/// OUR LAT: 48.32232 OUR LON: 18.09462

		itemLats[0] = 48.30791f; itemLons[0] = 18.08611f;
		itemLats[1] = 48.30792f; itemLons[1] = 18.09080f;
		itemLats[2] = 48.31775f; itemLons[2] = 18.08789f;

		itemLats[3] = 48.32232f; itemLons[3] = 18.09462f;
		itemLats[4] = 48.32232f; itemLons[4] = 18.09538f;
		itemLats[5] = 48.34327f; itemLons[5] = 18.10541f;

		itemLats[6] = 48.30857f; itemLons[6] = 18.10280f;
		itemLats[7] = 48.29681f; itemLons[7] = 18.08975f;
		itemLats[8] = 48.29690f; itemLons[8] = 18.06753f;

		itemLats[9] = 48.31053f; itemLons[9] = 18.06865f;
		itemLats[10] = 48.31470f; itemLons[10] = 18.06859f;
		itemLats[11] = 48.32150f; itemLons[11] = 18.08550f;


		itemLats[12] = 48.35674f; itemLons[12] = 18.05522f;
		itemLats[13] = 48.30697f; itemLons[13] = 18.07781f;
		itemLats[14] = 48.31539f; itemLons[14] = 18.09034f;

		itemLats[15] = 48.31391f; itemLons[15] = 18.08823f;
		itemLats[16] = 48.31821f; itemLons[16] = 18.08650f;
		itemLats[17] = 48.31636f; itemLons[17] = 18.08868f;

		itemLats[18] = 48.31575f; itemLons[18] = 18.09592f;
		itemLats[19] = 48.30861f; itemLons[19] = 18.08642f;
		itemLats[20] = 48.30742f; itemLons[20] = 18.09286f;

	}


	public void UpdateItemPosition() {
			if (items.Count == 0)
				return;

			MilleniumPuzzle[] item = items.ToArray ();
			for (int i = 0; i < item.Length; i++) {
				item[i].UpdatePosition ();
			}
	}
}

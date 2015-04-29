﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {
	public GameObject star;
	public GameObject obstacle;
	public GameObject clock;
	public GameObject shield;
	public GameObject bomb;
	
	private int timeCount = 0;
	float timeElapsed = 0;
	float spawnCycle = 0.5f * 2;
	bool spawnPowerup = true;

	/* music name definition
	 * Music 0: The Big Bang
	 * Music 1: Gong Gong
	 * */
	List<List<float>> musicTime;	// Beat time
	List<List<int>> obstacleType;	// obstacle type
	public static List<float> musicTotalTime;		// total time of a music
	List<int> musicTotalBeats;
	List<float> pos;				// for each music the time of first beat might not be correct, we need to make some adjustment for the first beat

	void Start() {
		timeCount = 0;
		// These are the initializers!!
		musicTotalBeats = new List<int> (){200, 119, 370};
		pos = new List<float> (){0.2f, -0.3f, 0.0f};
		musicTime = new List<List<float>>();
		obstacleType = new List<List<int>>();


		musicTotalTime = new List<float>{210f, 300f, 300f};

		musicTime.Add (new List<float> (){
			0.7f, 
			0.9f,
			1.0f,
			1.8f,
			3.9f,
			4.3f,
			5.1f,
			5.3f,
			5.5f,
			5.6f,
			5.8f,
			5.9f,
			6.6f, 
			7.1f,
			7.2f,
			7.3f,
			7.4f,
			7.5f,
			7.6f, 
			9.1f, 
			9.4f, 
			9.8f,
			9.9f,
			8.9f, 
			10.3f,
			10.6f,
			10.1f,
			11.3f,
			11.4f,
			11.6f,
			11.8f,
			11.9f,
			12.0f,
			12.3f,
			11.6f,
			11.8f,
			13.9f,
			14.0f,
			14.8f,
			15.0f,
			15.7f,
			15.8f,
			15.9f,
			16.0f,
			16.1f,
			16.3f,
			16.5f,
			19.9f,
			20.5f,
			21.1f,
			21.8f,
			22.4f,
			23.0f,
			23.6f,
			24.2f,
			24.5f,
			24.8f,
			25.3f,
			26.3f,
			27.0f,
			27.6f,
			28.2f,
			28.8f,
			29.4f,
			30.1f,
			30.7f,
			31.3f,
			32.0f,
			32.6f,
			33.1f,
			33.8f,
			34.5f,
			35.1f,
			35.7f,
			36.3f,
			37.0f,
			37.6f,
			38.2f,
			38.8f,
			39.5f,
			40.1f,
			40.7f,
			41.3f,
			42.0f,
			42.6f,
			43.2f,
			43.8f,
			44.5f,
			45.1f,
			45.7f,
			46.3f,
			47.0f,
			47.6f,
			48.2f,
			48.8f,
			49.4f,
			50.1f,
			50.7f,
			51.3f,
			52.0f,
			52.6f,
			52.9f,
			53.2f,
			53.8f,
			54.5f,
			55.1f,
			55.7f,
			56.3f,
			57.0f,
			57.6f,
			58.2f,
			58.8f,
			59.4f,
			60.1f,
			60.7f,
			61.3f,
			61.9f,
			62.2f,
			62.5f,
			63.2f,
			63.8f,
			64.4f,
			65.0f,
			65.7f,
			66.3f,
			66.9f,
			67.6f,
			68.2f,
			68.8f,
			69.4f,
			70.0f,
			70.7f,
			71.3f,
			71.9f,
			72.5f,
			73.2f,
			73.8f,
			74.4f,
			75.0f,
			75.7f,
			76.3f,
			76.9f,
			77.5f,
			78.2f,
			78.8f,
			79.4f,
			80.0f,
			80.7f,
			81.3f,
			81.9f,
			82.5f,
			83.2f,
			83.8f,
			84.4f,
			85.0f,
			85.7f,
			86.3f,
			86.9f,
			87.5f,
			88.2f,
			88.8f,
			89.4f,
			90.0f,
			90.7f,
			91.3f,
			91.9f,
			92.5f,
			93.2f,
			93.8f,
			94.4f,
			95.0f,
			95.7f,
			96.3f,
			96.9f,
			97.5f,
			98.2f,
			98.8f,
			99.4f,
			100.0f,
			100.7f,
			101.3f,
			101.9f,
			102.5f,
			103.2f,
			103.8f,
			104.4f,
			105.0f,
			105.7f,
			106.3f,
			106.9f,
			107.5f,
			108.2f,
			108.8f,
			109.4f,
			110.0f,
			110.7f,
			111.3f,
			111.9f,
			112.5f,
			113.2f,
			113.8f,
			114.4f,
			115.0f,
			115.7f,
			116.3f,
			116.9f,
			117.5f,
			118.2f,
			118.8f,
			119.4f,
			120.0f,
			120.7f,
			121.3f,
			121.9f,
			122.5f,
			123.2f,
			123.8f,
			124.6f,
			125.0f,
			125.7f,
			126.3f,
			126.9f,
			127.5f,
			128.2f,
			128.8f,
			129.4f,
			130.0f,
			130.7f,
			131.3f,
			132.9f,
			132.5f,
			133.2f,
			133.8f,
			134.4f,
			135.0f,
			135.7f,
			136.3f,
			136.9f,
			137.5f,
			138.2f,
			138.8f,
			139.4f,
			140.0f,
			140.7f,
			141.3f,
			141.9f,
			142.5f,
			143.2f,
			143.8f,
			144.4f,
			145.0f,
			145.7f,
			146.3f,
			146.9f,
			147.5f,
			148.2f,
			148.8f,
			149.4f,
			150.0f,
			150.7f,
			151.3f,
			151.9f,
			152.5f,
			153.2f,
			153.8f,
			154.4f,
			155.0f,
			155.7f,
			156.3f,
			156.9f
		});
		// gong gong
		musicTime.Add (new List<float> (){
			12.6f,//*** gong  gong gong gong
			12.75f,
			13.5f,
			13.7f,
			14.4f,
			14.7f,//end

			16.3f,//** as fast as possible
			16.4f,
			16.5f,
			16.6f,
			16.7f,
			16.8f,
			16.9f,
			17.0f,
			17.1f,
			17.2f,
			17.3f,
			17.4f,
			17.5f,
			17.6f,
			17.7f,
			17.8f,
			17.9f,
			18.0f,
			18.1f,
			18.2f,
			18.3f,
			18.4f,
			18.5f,
			18.6f,
			18.7f,
			18.8f,
			18.9f,
			19.0f,
			19.1f,
			19.2f,
			19.3f,
			19.4f,
			19.5f,
			19.6f,
			19.7f,
			19.8f,
			19.9f,
			20.0f,
			20.1f,
			20.2f,
			20.3f,
			20.4f,
			20.5f,
			20.6f,
			20.7f,
			20.8f,
			20.9f,
			21.0f,
			21.1f,
			21.2f,
			21.3f,
			21.4f,
			21.5f,
			21.6f,
			21.7f,
			21.8f,
			21.9f,
			22.0f,
			22.1f,
			22.2f,
			22.3f,
			22.4f,
			22.5f,
			22.6f,
			22.7f,
			22.8f,
			22.9f,
			23.0f,//END

			23.7f,//***  5 points a beating loop: X OO OO There are total 2.5 loops.
			24.1f,//** interval values: 0.4 0.2 0.6 0.2 
			24.3f,
			24.9f,
			25.1f,//END
			25.6f,//*** interval between loop is 0.5
			26.0f,
			26.2f,
			26.8f,
			27.0f,//END
			27.5f,//***
			27.9f,
			28.1f,
			28.7f,
			28.9f,
			29.3f,
			29.7f,
			29.9f,//END
		    
			30.6f,//*** gongong he has head pain *** 3 loops--a b c
			30.7f,//*** intervals in loop: a 0.1+0.2+0.2+0.5+0.2 
			30.9f,
			31.1f,
			31.6f,
			31.8f,//***
				  //*** interval between loop is 0.6
			32.4f,//*** b 0.2+0.2+0.2+0.5+0.2
			32.6f,//*** gongong he has head pain ***
			32.8f,
			33.0f,
			33.5f,
			33.7f,//***

			34.3f,//*** c 0.2+0.2+0.2+0.5+0.2
			34.5f,//*** says money is not enough ***
			34.7f,
			34.9f,
			35.4f,
			35.6f,//*** END


			36.0f,//*** gonggonggonggonggonggonggonggong
			36.2f,
			36.6f,
			36.9f,
			37.2f,
			37.5f,
			37.8f,//*** END
			38.1f,
			38.4f,
			38.6f
			//10


		});

		musicTime.Add (new List<float> (){
			1.0f, //start, bage 3
			2.2f,
			3.4f,
			4.6f,
			5.8f,
			7.0f, // first 3 combo
			7.3f,
			7.6f,
			8.2f, // beat 1
			8.3f,
			8.4f,
			8.5f,
			8.6f,
			8.7f,
			8.8f,
			8.9f,
			9.0f,
			9.1f,
			9.2f,
			9.3f,
			9.4f, // beat 2
			9.5f,
			9.6f,
			9.7f,
			9.8f,
			9.9f,
			10.0f,
			10.1f,
			10.2f,
			10.3f,
			10.4f,
			10.5f,
			10.6f, // beat 3
			10.7f,
			10.8f,
			10.9f,
			11.0f,
			11.1f,
			11.2f,
			11.3f,
			11.4f,
			11.5f,
			11.6f,
			11.7f,
			11.8f, // beat 4
			11.9f,
			12.0f,
			12.1f,
			12.2f,
			12.3f,
			12.4f,
			12.5f,
			12.6f,
			12.7f,
			12.8f,
			12.9f,
			13.0f, // beat 5
			13.1f,
			13.2f,
			13.3f,
			13.4f,
			13.5f,
			13.6f,
			13.7f,
			13.8f,
			13.9f,
			14.0f,
			14.1f,
			14.2f, // beat 6
			14.3f,
			14.4f,
			14.5f,
			14.6f,
			14.7f,
			14.8f,
			14.9f,
			15.0f,
			15.1f,
			15.2f,
			15.3f,
			15.4f, // beat 7
			15.5f,
			15.6f,
			15.7f,
			15.8f,
			15.9f,
			16.0f,
			16.1f,
			16.2f,
			16.3f,
			16.4f,
			16.5f,
			16.6f, // beat 8
			16.7f,
			16.8f,
			16.9f,
			17.0f,
			17.1f,
			17.2f,
			17.3f,
			17.4f,
			17.5f,
			17.6f,
			17.7f,
			17.8f, // first word
			18.0f, 
			20.2f,
			21.4f,
			22.6f,
			23.8f,
			25.0f, // serise
			25.1f,
			25.2f,
			25.3f,
			25.4f,
			25.5f,
			25.6f,
			25.7f,
			25.8f,
			25.9f,
			26.0f,
			26.1f,
			26.2f,
			26.3f,
			26.4f,
			26.5f,
			26.6f,
			26.7f,
			26.8f,
			26.9f,
			27.0f,
			27.1f,
			27.2f,
			27.3f,
			27.4f,
			28.6f, // when the dark
			28.9f,
			29.2f,
			29.5f,
			29.8f,
			30.1f,
			30.4f,
			30.7f,
			31.0f,
			32.2f, // the sand
			32.3f,
			32.4f,
			32.5f,
			32.6f,
			32.7f,
			32.8f,
			32.9f,
			33.0f,
			33.1f,
			33.2f,
			33.3f,
			33.4f,
			33.5f,
			34.6f,
			35.8f,
			37.0f,
			37.2f,
			37.4f,
			37.6f,
			37.8f,
			38.0f,
			38.2f,// test
			38.4f,
			38.6f,
			38.8f,
			39.0f,
			39.2f,
			39.4f,
			40.6f,
			41.8f,
			43.0f,
			44.2f,
			45.4f,
			45.7f,
			46.0f,
			46.3f,
			46.6f, // want the 
			46.9f,
			47.2f,
			47.5f,
			47.8f,
			49.0f,
			50.2f,
			51.4f,
			52.6f,
			53.8f,
			55.0f, // so now we fly in the dream
			56.2f,
			57.4f,
			58.6f,
			59.8f,
			61.0f,
			62.2f,
			63.4f,
			64.6f,
			65.8f,
			67.0f,
			68.2f,
			69.4f,
			70.6f,
			71.8f,
			73.0f,
			74.2f,
			75.4f,
			76.6f,
			77.8f,
			79.0f,
			80.2f,
			81.4f,
			82.6f,
			83.8f,
			85.0f,
			86.2f,
			87.4f,
			88.6f,
			89.8f,
			91.0f,
			92.2f,
			93.4f,
			94.6f,
			95.8f,
			97.0f,
			98.2f,
			99.4f,
			100.6f,
			101.8f,
			103.0f,
			104.2f,
			105.4f,
			106.6f,
			107.8f,
			109.0f,
			110.2f,
			111.4f,
			112.6f,
			113.8f,
			115.0f,
			116.2f,
			117.4f,
			118.6f,
			119.8f,
			121.0f,
			122.2f,
			123.4f,
			124.6f,
			125.8f,
			127.0f,
			128.2f,
			129.4f,
			130.6f,
			131.8f,
			133.0f,
			134.2f,
			135.4f,
			136.6f,
			137.8f,
			139.0f,
			140.2f,
			141.4f,
			142.6f,
			143.8f,
			145.0f,
			146.2f,
			147.4f,
			148.6f,
			149.8f,
			151.0f,
			152.2f,
			153.4f,
			154.6f,
			155.8f,
			157.0f,
			158.2f,
			159.4f,
			160.6f,
			161.8f,
			163.0f,
			164.2f,
			165.4f,
			166.6f,
			167.8f,
			169.0f,
			170.2f,
			171.4f,
			172.6f,
			173.8f,
			175.0f,
			176.2f,
			177.4f,
			178.6f,
			179.8f,
			181.0f,
			182.2f,
			183.4f,
			184.6f,
			185.8f,
			187.0f,
			188.2f,
			189.4f,
			190.6f,
			191.8f,
			193.0f,
			194.2f,
			195.4f,
			196.6f,
			197.8f,
			199.0f,
			200.2f,
			201.4f,
			202.6f,
			203.8f,
			205.0f,
			206.2f,
			207.4f,
			208.6f,
			209.8f,
			211.0f,
			212.2f,
			213.4f,
			214.6f,
			215.8f,
			217.0f,
			218.2f,
			219.4f,
			220.6f,
			221.8f,
			223.0f,
			224.2f,
			225.4f,
			226.6f,
			227.8f,
			229.0f,
			230.2f,
			231.4f,
			232.6f,
			233.8f,
			235.0f,
			236.2f,
			237.4f,
			238.6f,
			239.8f,
			241.0f,
			242.2f,
			243.4f,
			244.6f,
			245.8f,
			247.0f,
			248.2f,
			249.4f,
			250.6f,
			251.8f,
			253.0f,
			254.2f,
			255.4f,
			256.6f,
			257.8f,
			259.0f,
			260.2f,
			261.4f,
			262.6f,
			263.8f,
			265.0f,
			266.2f,
			267.4f,
			268.6f,
			269.8f,
			271.0f,
			272.2f,
			273.4f,
			274.6f,
			275.8f,
			277.0f,
			278.2f,
			279.4f,
			280.6f,
			281.8f,
			283.0f,
			284.2f,
			285.4f,
			286.6f,
			287.8f,
			289.0f,
			290.2f,
			291.4f,
			292.6f,
			293.8f,
			295.0f,
			296.2f,
			297.4f,
			298.6f,
			299.8f,
		});

		for (int k = 0; k < 3; k++) {
			for (int i = 0; i < musicTotalBeats[k]; i++) {
				musicTime[k][i] += pos[k];
			}
		}

		obstacleType.Add (new List<int> (){
				1, 
				1, 
				3,
				3, 
				2,
				2,
				1, 
				1, 
				2, 
				2, 
				3, 
				3, 
				1, 
				8, 
				2, 
				2, 
				3, 
				3, 
				3, 
				2, 
				2, 
				1,
				1,
				2,
				2,
				3,
				3,
				3,
				8,
				9, 
				1,
				1,
				1, 
				1, 
				1,
				1,
				1,
				1,
				1, 
				4, 
				4, 
				4, 
				5, 
				5, 
				5,
				6, 
				6,
				6, 
				6, 
				6, 
				6, 
				5,
				5,
				5,
				5, 
				5, 
				5, 
				4, 
				8, 
				4, 
				4,
				6, 
				6, 
				6, 
				6, 
				6, 
				6, 
				6, 
				6, 
				6, 
				6,
				6, 
				2, 
				5, 
				8, 
				2, 
				2, 
				1, 
				1, 
				2, 
				1, 
				3, 
				4, 
				2, 
				1, 
				1, 
				2, 
				2, 
				2, 
				3, 
				4, 
				1, 
				1, 
				2, 
				1, 
				3, 
				1, 
				1, 
				3, 
				1, 
				1, 
				1, 
				2,
				1, 
				1, 
				1,
				2, 
				2, 
				1, 
				3, 
				2, 
				1, 
				3,
				1, 
				2, 
				2, 
				1, 
				2, 
				1, 
				2, 
				1, 
				1, 
				3, 
				4, 
				3, 
				3,
				4, 
				1, 
				1, 
				2, 
				2, 
				1, 
				3, 
				8, 
				1, 
				1, 
				1, 
				2, 
				2, 
				1, 
				1, 
				2, 
				2, 
				1,
				5,
				1, 
				2, 
				2, 
				2, 
				1, 
				1, 
				2, 
				1, 
				2, 
				2, 
				1, 
				1, 
				4, 
				4, 
				3, 
				3, 
				4, 
				3,
				3, 
				4, 
				1, 
				2, 
				1, 
				1, 
				1, 
				2, 
				2, 
				1, 
				3, 
				3, 
				4, 
				4, 
				3, 
				3, 
				4, 
				1,
				2, 
				2,
				1, 
				8, 
				5, 
				2, 
				1, 
				1, 
				1, 
				2, 
				1, 
				2, 
				1, 
				2,
				1,
				1, 
				2, 
				1, 
				1, 
				2, 
				1, 
				2, 
				2,
				1,
				2, 
				1, 
				1,
				2, 
				1, 
				1, 
				2, 
				2, 
				1, 
				2, 
				2, 
				1, 
				1, 
				2, 
				2, 
				1, 
				2, 
				2, 
				1, 
				3, 
				4, 
				2, 
				2, 
				5,
				1, 
				2, 
				2, 
				1, 
				2, 
				8, 
				1, 
				2, 
				1, 
				1, 
				2, 
				1, 
				4, 
				3, 
				4, 
				3, 
				2, 
				1,
				2, 
				1, 
				4, 
				3, 
				4, 
				3, 
				2});

		obstacleType.Add (new List<int> (){
			1,
			1,
			1,
			1,
			1,
			1,

			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			8,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			8,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,



			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,


			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
		
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		});

		obstacleType.Add (new List<int> (){
			1,
			3,
			6,
			6,
			7,
			2, // combo 3
			2,
			2,
			1, // beat 1
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1, // beat 2
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			8, // beat 3
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3, // beat 4
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			7, // beat 5
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1, // beat 6
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			8, // beat 7
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			7, // beat 8
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			9, // first word
			5,
			2,
			2,
			2,
			2, // seris
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			8, // test
			5, // when
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			1,
			3,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			2,
			2,
			2,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			2,
			3
		});
	}

	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed > musicTime[musicScript.musicflag][timeCount]) {
			GameObject temp;

			/* Obstacle Type definition
			 * 1, 2, 3: left, mid, right of stars
			 * 4, 5 ,6: left, right of Obstacles
			 * 7: bomb, random position
			 * 8: timer, random position
			 * 9: shield, random position
			 * */
			switch(obstacleType[musicScript.musicflag][timeCount]){
				case 1: case 2: case 3: temp = (GameObject)Instantiate(star);break;
				case 4: case 5: case 6: temp = (GameObject)Instantiate(obstacle);break;
				// about case 7 and case 8, if the flag is not activate, we make it as regular elements
				case 7: 
					if (challengeScript.bombflag > 0) {
						temp = (GameObject)Instantiate(bomb);
					}
					else{
						temp = (GameObject)Instantiate(obstacle);
					}
					break;
				case 8:					
					if (challengeScript.timeflag > 0) {
						temp = (GameObject)Instantiate(clock);
					}
					else{
						temp = (GameObject)Instantiate(star);
					}
					break;
				default: temp = (GameObject)Instantiate(shield);break;
			}
			
			Vector3 pos = temp.transform.position;
			
			switch(obstacleType[musicScript.musicflag][timeCount]){
				case 1: temp.transform.position = new Vector3(-1.5f + pos.x, pos.y, pos.z); break;
				case 2: temp.transform.position = new Vector3(pos.x, pos.y, pos.z); break;
				case 3: temp.transform.position = new Vector3(1.5f + pos.x, pos.y, pos.z); break;
				case 4: temp.transform.position = new Vector3(-2.2f + pos.x, pos.y, pos.z); break;
				case 5: temp.transform.position = new Vector3(pos.x, pos.y, pos.z); break;
				case 6: temp.transform.position = new Vector3(2.2f + pos.x, pos.y, pos.z); break;
				case 7: case 8: case 9: 
					// Generate a random position for case 7, 8 and 9
					System.Random rand = new System.Random();
					int res = rand.Next(0, 3);
					float randpos = 0f;
					if (res == 0) randpos = -1.0f;
					else if (res == 2) randpos = 1.0f;
					temp.transform.position = new Vector3(randpos + pos.x, pos.y, pos.z); break;
			}


			timeCount ++;
			if (timeCount >= musicTotalBeats[musicScript.musicflag]) {
				timeCount %= musicTotalBeats[musicScript.musicflag];
				timeElapsed = 0;
			}
		}
	}
}
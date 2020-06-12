﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapsample : MonoBehaviour
{

    [SerializeField] GameObject bc1;
    [SerializeField] GameObject pipe;
    [SerializeField] GameObject pipe2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ene1;
    [SerializeField] GameObject ene2;
    [SerializeField] GameObject ene3;
    [SerializeField] GameObject jb1;
    [SerializeField] GameObject jb2;
    [SerializeField] GameObject jb3;
    // Use this for initialization

    public int[,,] map =
    {
       {//1
        {1,1,2,1,1,1,1,8,1,1,1,1,1,8,1,1,1,1,1,8, },//
        {1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//5
        {1,1,1,1,8,1,1,1,1,1,8,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,1, },//10
        {1,0,0,0,1,1,1,8,1,1,1,1,1,1,1,8,1,1,1,8, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {1,0,0,0,0,0,5,0,0,0,5,0,0,0,0,0,0,0,0,1, },//15
        {8,1,1,1,8,1,1,1,1,1,1,1,8,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,1, },//20
        {1,0,0,0,1,1,1,1,8,1,1,1,1,8,1,1,1,1,1,8, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {1,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,0,0,0,1, },//25
        {8,1,1,8,1,1,1,1,1,1,8,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,1, },//30
        {8,0,0,0,1,1,1,8,1,1,1,1,1,1,1,1,1,8,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,0,0,1, },//35
        {1,1,1,8,1,1,1,1,1,8,1,1,1,1,1,1,0,0,0,8, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,8, },//40
        {8,0,0,0,1,8,1,1,1,1,1,1,8,1,1,1,8,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {8,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,0,0,0,1, },//45
        {1,1,1,8,1,1,1,1,1,8,1,1,1,8,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,0,0,0,8, },//50
        {1,0,0,0,1,1,1,8,1,1,8,1,1,1,1,8,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,5,0,0,0,5,0,0,0,5,0,0,0,0,0,1, },//55
        {1,1,1,8,1,1,1,1,1,1,1,8,1,1,1,1,0,0,0,8, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8, },
        {8,3,1,1,1,1,1,1,8,1,1,1,1,8,1,1,8,1,1,1, }//61
       },
       {//2
        {1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//5
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,6,0,0,0,0,0,6,0,0,0,0,0,1, },//10
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,1, },//15
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,6,0,0,0,6,0,0,6,0,0,0,0,0,1, },//20
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,1, },//25
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,1, },//30
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,1, },//35
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,6,0,0,0,0,6,0,0,0,0,0,0,1, },//40
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,6,0,0,6,0,0,0,0,6,0,0,0,0,0,1, },//45
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,6,0,0,0,0,6,0,0,0,0,0,1, },//50
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,6,0,0,0,6,0,0,0,0,1, },//55
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,6,0,0,0,6,0,0,0,0,0,6,0,0,0,0,1, },
        {1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, }//61 
       },
       {//3
        {1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },//
        {1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//5
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,1, },//10
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//15
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,1, },//20
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//25
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,1, },//30
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//35
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//40
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//45
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,1, },//50
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//55
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, }//61
       },
       {//4
        {1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },//
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,1, },//5
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,6,0,0,5,0,0,0,0,0,0,0,1, },//10
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,6,0,0,6,0,0,5,0,0,0,0,0,0,1, },//15
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//20
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,7,0,0,0,5,0,0,0,0,1, },//25
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,1, },//30
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,6,0,0,6,0,0,0,0,0,0,0,0,0,0,1, },//35
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,7,0,0,5,0,0,5,0,0,0,0,1, },//40
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },//45
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,5,0,0,0,5,0,0,0,0,0,0,1, },//50
        {1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,6,0,0,0,7,0,0,0,0,0,0,0,0,0,1, },//55
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1, },
        {1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, }//61
       }
    };

    //生成する座標
    //int[] px = { -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    //int[] py = { 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
    //    -1, -2, -3, -4, -5, -6 ,-7,-8,-9,-10,-11,-12,-13,-14,-15,-16,-17,-18,-19,-20,-21,-22 };
    int[] px = { -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int[] py = { 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14, -15, -16, -17, -18, -19, -20, -21, -22, -23, -24, -25
            , -26, -27, -28, -29, -30, -31, -32, -33, -34, -35, -36, -37, -38, -39, -40, -41, -42, -43, -44,-45,-46,-47,-48,-49,-50,
              -51,-52,-53,-54,-55,-56,-57,-58,-59,-60};
    //マップの生成
    void Map_st()
    {
        //y座標
        for (int lu = 0; lu < 61; lu++)
        {
            //x座標
            for (int na = 0; na < 20; na++)
            {
                switch (map[Clear.mp,lu, na])
                {
                    case 1:
                        GameObject subgo1 = Instantiate(bc1) as GameObject;
                        subgo1.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 2:
                        GameObject subgo2 = Instantiate(pipe) as GameObject;
                        subgo2.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 3:
                        GameObject subgo3 = Instantiate(pipe2) as GameObject;
                        subgo3.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 4:
                        GameObject subgo4 = Instantiate(player) as GameObject;
                        subgo4.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 5:
                        GameObject subgo5 = Instantiate(ene1) as GameObject;
                        subgo5.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 6:
                        GameObject subgo6 = Instantiate(ene2) as GameObject;
                        subgo6.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 7:
                        GameObject subgo7 = Instantiate(ene3) as GameObject;
                        subgo7.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 8:
                        GameObject subgo8 = Instantiate(jb1) as GameObject;
                        subgo8.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 9:
                        GameObject subgo9 = Instantiate(jb2) as GameObject;
                        subgo9.transform.position = new Vector3(px[na], py[lu], 0);
                        break;
                    case 10:
                        GameObject subgo10 = Instantiate(jb3) as GameObject;
                        subgo10.transform.position = new Vector3(px[na], py[lu], 0);
                        break;

                }
            }
        }
    }

    void Awake()
    {
        Map_st();
    }

}

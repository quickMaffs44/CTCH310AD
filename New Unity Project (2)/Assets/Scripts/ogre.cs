/* File: ogre.cs
 * Name: Earl Labios
 * Student #: 200389267
 * Date: Mar 12, 2019
 * Assignment 3
 * Part 3 
 * Lab B
*/


/*
 * Make it so that when you press a button, it lowers the ogre's intelligence, 
 * changes state, or presses button to raise intelligence
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ogre : MonoBehaviour {

    public int intel = 5; 

    float test(){
        return 5.0f; 
    }

    void Greet(){

        switch (intel) {

        case 5:
            print ("Hello, good sir! Do you like physics?");
            break; 

        case 4: 
            print ("Ello, guv!");
            break;

        case 3: 
            print ("What you want?!");
            break;

        case 2:
            print ("Ugh ugh... me want food.");
            break;
        case 1: 
            print ("Grrrrrr *fart*");
            break;

        default:
            print (" ... stares at you blankly");
            break;
        }

 
    }


    // Use this for initialization
    void Start () {

        Greet ();
        float testNum = test ();
        print (testNum);
        
    }

}
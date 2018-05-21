using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class esqueleto_de_codigo_para_mover_todas_as_partes_do_corpo : MonoBehaviour
{
	[SerializeField]
	protected Transform character,body,bottoms;
	[SerializeField]
	protected Transform eyes,hair,shoes,tops,hips;
	[SerializeField]
	protected Transform leftupleg,rightupleg,spine;
	[SerializeField]
	protected Transform leftleg,leftfoot,lefttoebase;
	[SerializeField]
	protected Transform lefttoe_end,rightleg,rightfoot;
	[SerializeField]
	protected Transform righttoebase,righttoe_end,spine1;
	[SerializeField]
	protected Transform spine2,leftshoulder,leftarm,leftforearm;
	[SerializeField]
	protected Transform lefthand,lefthandindex1,lefthandindex2;
	[SerializeField]
	protected Transform lefthandindex3,lefthandindex4,lefthandmiddle1;
	[SerializeField]
	protected Transform lefthandmiddle2,lefthandmiddle3,lefthandmiddle4;
	[SerializeField]
	protected Transform lefthandpinky1,lefthandpinky2,lefthandpinky3;
	[SerializeField]
	protected Transform lefthandpinky4,lefthandring1,lefthandring2,lefthandring3;
	[SerializeField]
	protected Transform lefthandring4,lefthandthumb1,lefthandthumb2,lefthandthumb3;
	[SerializeField]
	protected Transform lefthandthumb4,neck,head,headtop_end,rightshoulder,rightarm;
	[SerializeField]
	protected Transform rightforearm,righthand,righthandindex1,righthandindex2;
	[SerializeField]
	protected Transform righthandindex3,righthandindex4,righthandmiddle1,righthandmiddle2;
	[SerializeField]
	protected Transform righthandmiddle3,righthandmiddle4,righthandpinky1,righthandpinky2;
	[SerializeField]
	protected Transform righthandpinky3,righthandpinky4,righthandring1,righthandring2;
	[SerializeField]
	protected Transform righthandring3,righthandring4,righthandthumb1,righthandthumb2;
	[SerializeField]
	protected Transform righthandthumb3,righthandthumb4;

	void FixedUpdate ()
	{
		character.localPosition = 0;
		character.localEulerAngles = 0;

		body.localPosition = 0;
		body.localEulerAngles = 0;

		bottoms.localPosition = 0;
		bottoms.localEulerAngles = 0;

		eyes.localPosition = 0;
		eyes.localEulerAngles = 0;

		hair.localPosition = 0;
		hair.localEulerAngles = 0;

		shoes.localPosition = 0;
		shoes.localEulerAngles = 0;

		tops.localPosition = 0;
		tops.localEulerAngles = 0;

		hips.localPosition = 0;
		hips.localEulerAngles = 0;

		leftupleg.localPosition = 0;
		leftupleg.localEulerAngles = 0;

		rightupleg.localPosition = 0;
		rightupleg.localEulerAngles = 0;

		spine.localPosition = 0;
		spine.localEulerAngles = 0;

		leftleg.localPosition = 0;
		leftleg.localEulerAngles = 0;

		leftfoot.localPosition = 0;
		leftfoot.localEulerAngles = 0;

		lefttoebase.localPosition = 0;
		lefttoebase.localEulerAngles = 0;

		lefttoe_end.localPosition = 0;
		lefttoe_end.localEulerAngles = 0;

		rightleg.localPosition = 0;
		rightleg.localEulerAngles = 0;

		rightfoot.localPosition = 0;
		rightfoot.localEulerAngles = 0;

		righttoebase.localPosition = 0;
		righttoebase.localEulerAngles = 0;

		righttoe_end.localPosition = 0;
		righttoe_end.localEulerAngles = 0;

		spine1.localPosition = 0;
		spine1.localEulerAngles = 0;

		spine2.localPosition = 0;
		spine2.localEulerAngles = 0;

		leftshoulder.localPosition = 0;
		leftshoulder.localEulerAngles = 0;

		leftarm.localPosition = 0;
		leftarm.localEulerAngles = 0;

		leftforearm.localPosition = 0;
		leftforearm.localEulerAngles = 0;

		lefthand.localPosition = 0;
		lefthand.localEulerAngles = 0;

		lefthandindex1.localPosition = 0;
		lefthandindex1.localEulerAngles = 0;

		lefthandindex2.localPosition = 0;
		lefthandindex2.localEulerAngles = 0;

		lefthandindex3.localPosition = 0;
		lefthandindex3.localEulerAngles = 0;

		lefthandindex4.localPosition = 0;
		lefthandindex4.localEulerAngles = 0;

		lefthandmiddle1.localPosition = 0;
		lefthandmiddle1.localEulerAngles = 0;

		lefthandmiddle2.localPosition = 0;
		lefthandmiddle2.localEulerAngles = 0;

		lefthandmiddle3.localPosition = 0;
		lefthandmiddle3.localEulerAngles = 0;

		lefthandmiddle4.localPosition = 0;
		lefthandmiddle4.localEulerAngles = 0;

		lefthandpinky1.localPosition = 0;
		lefthandpinky1.localEulerAngles = 0;

		lefthandpinky2.localPosition = 0;
		lefthandpinky2.localEulerAngles = 0;

		lefthandpinky3.localPosition = 0;
		lefthandpinky3.localEulerAngles = 0;

		lefthandpinky4.localPosition = 0;
		lefthandpinky4.localEulerAngles = 0;

		lefthandring1.localPosition = 0;
		lefthandring1.localEulerAngles = 0;

		lefthandring2.localPosition = 0;
		lefthandring2.localEulerAngles = 0;

		lefthandring3.localPosition = 0;
		lefthandring3.localEulerAngles = 0;

		lefthandring4.localPosition = 0;
		lefthandring4.localEulerAngles = 0;

		lefthandthumb1.localPosition = 0;
		lefthandthumb1.localEulerAngles = 0;

		lefthandthumb2.localPosition = 0;
		lefthandthumb2.localEulerAngles = 0;

		lefthandthumb3.localPosition = 0;
		lefthandthumb3.localEulerAngles = 0;

		lefthandthumb4.localPosition = 0;
		lefthandthumb4.localEulerAngles = 0;

		neck.localPosition = 0;
		neck.localEulerAngles = 0;

		head.localPosition = 0;
		head.localEulerAngles = 0;

		headtop_end.localPosition = 0;
		headtop_end.localEulerAngles = 0;

		rightshoulder.localPosition = 0;
		rightshoulder.localEulerAngles = 0;

		rightarm.localPosition = 0;
		rightarm.localEulerAngles = 0;

		rightforearm.localPosition = 0;
		rightforearm.localEulerAngles = 0;

		righthand.localPosition = 0;
		righthand.localEulerAngles = 0;

		righthandindex1.localPosition = 0;
		righthandindex1.localEulerAngles = 0;

		righthandindex2.localPosition = 0;
		righthandindex2.localEulerAngles = 0;

		righthandindex3.localPosition = 0;
		righthandindex3.localEulerAngles = 0;

		righthandindex4.localPosition = 0;
		righthandindex4.localEulerAngles = 0;

		righthandmiddle1.localPosition = 0;
		righthandmiddle1.localEulerAngles = 0;

		righthandmiddle2.localPosition = 0;
		righthandmiddle2.localEulerAngles = 0;

		righthandmiddle3.localPosition = 0;
		righthandmiddle3.localEulerAngles = 0;

		righthandmiddle4.localPosition = 0;
		righthandmiddle4.localEulerAngles = 0;

		righthandpinky1.localPosition = 0;
		righthandpinky1.localEulerAngles = 0;

		righthandpinky2.localPosition = 0;
		righthandpinky2.localEulerAngles = 0;

		righthandpinky3.localPosition = 0;
		righthandpinky3.localEulerAngles = 0;

		righthandpinky4.localPosition = 0;
		righthandpinky4.localEulerAngles = 0;

		righthandring1.localPosition = 0;
		righthandring1.localEulerAngles = 0;

		righthandring2.localPosition = 0;
		righthandring2.localEulerAngles = 0;

		righthandring3.localPosition = 0;
		righthandring3.localEulerAngles = 0;

		righthandring4.localPosition = 0;
		righthandring4.localEulerAngles = 0;

		righthandthumb1.localPosition = 0;
		righthandthumb1.localEulerAngles = 0;

		righthandthumb2.localPosition = 0;
		righthandthumb2.localEulerAngles = 0;

		righthandthumb3.localPosition = 0;
		righthandthumb3.localEulerAngles = 0;

		righthandthumb4.localPosition = 0;
		righthandthumb4.localEulerAngles = 0;
	}
}
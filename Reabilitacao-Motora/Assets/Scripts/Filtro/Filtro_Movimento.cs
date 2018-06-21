using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Kalman;

public class Filtro_Movimento : MonoBehaviour
{
	[SerializeField]
	protected Transform hips;
	[SerializeField]
	protected Transform leftupleg, rightupleg, spine, leftleg, rightleg;
	[SerializeField]
	protected Transform spine1, spine2, leftshoulder, leftarm, leftforearm;
	[SerializeField]
	protected Transform rightshoulder, rightarm, rightforearm;

	IKalmanWrapper kalman_hips_position;
	IKalmanWrapper kalman_leftupleg_position, kalman_rightupleg_position, kalman_spine_position, kalman_leftleg_position, kalman_rightleg_position;
	IKalmanWrapper kalman_spine1_position, kalman_spine2_position, kalman_leftshoulder_position, kalman_leftarm_position, kalman_leftforearm_position;
	IKalmanWrapper kalman_rightshoulder_position, kalman_rightarm_position, kalman_rightforearm_position;
	
	IKalmanWrapper kalman_hips_rotation;
	IKalmanWrapper kalman_leftupleg_rotation, kalman_rightupleg_rotation, kalman_spine_rotation, kalman_leftleg_rotation, kalman_rightleg_rotation;
	IKalmanWrapper kalman_spine1_rotation, kalman_spine2_rotation, kalman_leftshoulder_rotation, kalman_leftarm_rotation, kalman_leftforearm_rotation;
	IKalmanWrapper kalman_rightshoulder_rotation, kalman_rightarm_rotation, kalman_rightforearm_rotation;
	bool t = false;

	KalmanFilterSimple1D kalman_X_hips;
    KalmanFilterSimple1D kalman_Y_hips;
    KalmanFilterSimple1D kalman_mod_hips;
    private float last_x_hips = 0;
    private float last_y_hips = 0;
    private float last_mod_hips = 0;

    KalmanFilterSimple1D kalman_X_leftleg;
    KalmanFilterSimple1D kalman_Y_leftleg;
    KalmanFilterSimple1D kalman_mod_leftleg;
    private float last_x_leftleg = 0;
    private float last_y_leftleg = 0;
    private float last_mod_leftleg = 0;

    KalmanFilterSimple1D kalman_X_rightleg;
    KalmanFilterSimple1D kalman_Y_rightleg;
    KalmanFilterSimple1D kalman_mod_rightleg;
    private float last_x_rightleg = 0;
    private float last_y_rightleg = 0;
    private float last_mod_rightleg = 0;


    //my value 0.005
    public float qq = 0.005f;
    
    //my value 0.01
    public float rr = 0.01f;
    
    //my value 0.0001
    public float init_state = 0.0001f;
    
    //bigger values faster rotations and more noise. my value 10
    public float headSmooth = 10;
	void Start ()
	{
		kalman_X_hips = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);
        kalman_Y_hips = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);
        kalman_mod_hips = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);

		kalman_X_leftleg = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);
        kalman_Y_leftleg = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);
        kalman_mod_leftleg = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);

		kalman_X_rightleg = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);
        kalman_Y_rightleg = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);
        kalman_mod_rightleg = new KalmanFilterSimple1D(f: 1, h: 1, q: qq, r: rr);

		// kalman_hips_position = new MatrixKalmanWrapper ();
		// kalman_leftupleg_position = new MatrixKalmanWrapper ();
		// kalman_rightupleg_position = new MatrixKalmanWrapper ();
		// kalman_spine_position = new MatrixKalmanWrapper ();
		// kalman_leftleg_position = new MatrixKalmanWrapper ();
		// kalman_rightleg_position = new MatrixKalmanWrapper ();
		// kalman_spine1_position = new MatrixKalmanWrapper ();
		// kalman_spine2_position = new MatrixKalmanWrapper ();
		// kalman_leftshoulder_position = new MatrixKalmanWrapper ();
		// kalman_leftarm_position = new MatrixKalmanWrapper ();
		// kalman_leftforearm_position = new MatrixKalmanWrapper ();
		// kalman_rightshoulder_position = new MatrixKalmanWrapper ();
		// kalman_rightarm_position = new MatrixKalmanWrapper ();
		// kalman_rightforearm_position = new MatrixKalmanWrapper ();

		// kalman_hips_rotation = new MatrixKalmanWrapper ();
		// kalman_leftupleg_rotation = new MatrixKalmanWrapper ();
		// kalman_rightupleg_rotation = new MatrixKalmanWrapper ();
		// kalman_spine_rotation = new MatrixKalmanWrapper ();
		// kalman_leftleg_rotation = new MatrixKalmanWrapper ();
		// kalman_rightleg_rotation = new MatrixKalmanWrapper ();
		// kalman_spine1_rotation = new MatrixKalmanWrapper ();
		// kalman_spine2_rotation = new MatrixKalmanWrapper ();
		// kalman_leftshoulder_rotation = new MatrixKalmanWrapper ();
		// kalman_leftarm_rotation = new MatrixKalmanWrapper ();
		// kalman_leftforearm_rotation = new MatrixKalmanWrapper ();
		// kalman_rightshoulder_rotation = new MatrixKalmanWrapper ();
		// kalman_rightarm_rotation = new MatrixKalmanWrapper ();
		// kalman_rightforearm_rotation = new MatrixKalmanWrapper ();
	}

	void LateUpdate ()
	{
		// do something with result
		t = !t;
		if (t) {
			return;
		}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		var result_hips = hips.localRotation;
		if(last_x_hips == 0)
		{
		    last_x_hips = hips.localRotation.x;
		}
		if (last_y_hips == 0)
		{
		    last_y_hips = hips.localRotation.y;
		}

		kalman_Y_hips.SetState(last_y_hips, init_state);
		kalman_Y_hips.Correct(-result_hips.y);

		kalman_X_hips.SetState(last_x_hips, init_state);
		kalman_X_hips.Correct(-result_hips.x);
		float mod_x = last_x_hips % -result_hips.x;

		kalman_mod_hips.SetState(last_mod_hips, init_state);
		kalman_mod_hips.Correct(mod_x);

		//small shakes
		if(mod_x > 0.01f && mod_x < 0.08f)
		{
		    mod_x = mod_x / 2;
		}

		Quaternion a = hips.localRotation;
		Quaternion b = new Quaternion(kalman_X_hips.State, kalman_Y_hips.State, hips.localRotation.z, hips.localRotation.w);
		float c = Time.deltaTime * headSmooth * mod_x + 0.3f;
		Quaternion d = Quaternion.Lerp(a, b, c);

		hips.localRotation = d;

		last_y_hips = (float)kalman_Y_hips.State;
		last_x_hips = (float)kalman_X_hips.State;
		last_mod_hips = (float)kalman_mod_hips.State;

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		var result_leftleg = leftleg.localRotation;
		if(last_x_leftleg == 0)
		{
		    last_x_leftleg = leftleg.localRotation.x;
		}
		if (last_y_leftleg == 0)
		{
		    last_y_leftleg = leftleg.localRotation.y;
		}

		kalman_Y_leftleg.SetState(last_y_leftleg, init_state);
		kalman_Y_leftleg.Correct(-result_leftleg.y);

		kalman_X_leftleg.SetState(last_x_leftleg, init_state);
		kalman_X_leftleg.Correct(-result_leftleg.x);
		mod_x = last_x_leftleg % -result_leftleg.x;

		kalman_mod_leftleg.SetState(last_mod_leftleg, init_state);
		kalman_mod_leftleg.Correct(mod_x);

		//small shakes
		if(mod_x > 0.01f && mod_x < 0.08f)
		{
		    mod_x = mod_x / 2;
		}

		a = leftleg.localRotation;
		b = new Quaternion(kalman_X_leftleg.State, kalman_Y_leftleg.State, leftleg.localRotation.z, leftleg.localRotation.w);
		c = Time.deltaTime * headSmooth * mod_x + 0.3f;
		d = Quaternion.Lerp(a, b, c);

		leftleg.localRotation = d;

		last_y_leftleg = (float)kalman_Y_leftleg.State;
		last_x_leftleg = (float)kalman_X_leftleg.State;
		last_mod_leftleg = (float)kalman_mod_leftleg.State;

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		var result_rightleg = rightleg.localRotation;
		if(last_x_rightleg == 0)
		{
		    last_x_rightleg = rightleg.localRotation.x;
		}
		if (last_y_rightleg == 0)
		{
		    last_y_rightleg = rightleg.localRotation.y;
		}

		kalman_Y_rightleg.SetState(last_y_rightleg, init_state);
		kalman_Y_rightleg.Correct(-result_rightleg.y);

		kalman_X_rightleg.SetState(last_x_rightleg, init_state);
		kalman_X_rightleg.Correct(-result_rightleg.x);
		mod_x = last_x_rightleg % -result_rightleg.x;

		kalman_mod_rightleg.SetState(last_mod_rightleg, init_state);
		kalman_mod_rightleg.Correct(mod_x);

		//small shakes
		if(mod_x > 0.01f && mod_x < 0.08f)
		{
		    mod_x = mod_x / 2;
		}

		a = rightleg.localRotation;
		b = new Quaternion(kalman_X_rightleg.State, kalman_Y_rightleg.State, rightleg.localRotation.z, rightleg.localRotation.w);
		c = Time.deltaTime * headSmooth * mod_x + 0.3f;
		d = Quaternion.Lerp(a, b, c);

		rightleg.localRotation = d;

		last_y_rightleg = (float)kalman_Y_rightleg.State;
		last_x_rightleg = (float)kalman_X_rightleg.State;
		last_mod_rightleg = (float)kalman_mod_rightleg.State;

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// hips.localEulerAngles = Vector3.Lerp(hips.localEulerAngles, kalman_hips_rotation.Update(hips.localEulerAngles), 1);
			// hips.position = kalman_hips_position.Update(hips.position);

			// leftupleg.localPosition = kalman_leftupleg_position.Update(leftupleg.localPosition);
			// leftupleg.localEulerAngles = kalman_leftupleg_rotation.Update(leftupleg.localEulerAngles);

			// // rightupleg.localPosition = kalman_rightupleg_position.Update(rightupleg.localPosition);
			// rightupleg.localEulerAngles = kalman_rightupleg_rotation.Update(rightupleg.localEulerAngles);

			// // spine.localPosition = kalman_spine_position.Update(spine.localPosition);
			// spine.localEulerAngles = kalman_spine_rotation.Update(spine.localEulerAngles);

			// // leftleg.localPosition = kalman_leftleg_position.Update(leftleg.localPosition);
			// leftleg.localEulerAngles = kalman_leftleg_rotation.Update(leftleg.localEulerAngles);

			// // rightleg.localPosition = kalman_rightleg_position.Update(rightleg.localPosition);
			// rightleg.localEulerAngles = kalman_rightleg_rotation.Update(rightleg.localEulerAngles);

			// // spine1.localPosition = kalman_spine1_position.Update(spine1.localPosition);
			// spine1.localEulerAngles = kalman_spine1_rotation.Update(spine1.localEulerAngles);

			// // spine2.localPosition = kalman_spine2_position.Update(spine2.localPosition);
			// spine2.localEulerAngles = kalman_spine2_rotation.Update(spine2.localEulerAngles);

			// // leftshoulder.localPosition = kalman_leftshoulder_position.Update(leftshoulder.localPosition);
			// leftshoulder.localEulerAngles = kalman_leftshoulder_rotation.Update(leftshoulder.localEulerAngles);

			// // leftarm.localPosition = kalman_leftarm_position.Update(leftarm.localPosition);
			// leftarm.localEulerAngles = kalman_leftarm_rotation.Update(leftarm.localEulerAngles);

			// // leftforearm.localPosition = kalman_leftforearm_position.Update(leftforearm.localPosition);
			// leftforearm.localEulerAngles = kalman_leftforearm_rotation.Update(leftforearm.localEulerAngles);

			// // rightshoulder.localPosition = kalman_rightshoulder_position.Update(rightshoulder.localPosition);
			// rightshoulder.localEulerAngles = kalman_rightshoulder_rotation.Update(rightshoulder.localEulerAngles);

			// // rightarm.localPosition = kalman_rightarm_position.Update(rightarm.localPosition);
			// rightarm.localEulerAngles = kalman_rightarm_rotation.Update(rightarm.localEulerAngles);

			// // rightforearm.localPosition = kalman_rightforearm_position.Update(rightforearm.localPosition);
			// rightforearm.localEulerAngles = kalman_rightforearm_rotation.Update(rightforearm.localEulerAngles);
	}
}
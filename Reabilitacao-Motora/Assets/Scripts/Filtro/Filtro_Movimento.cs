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
	void Awake ()
	{
		kalman_hips_position = new MatrixKalmanWrapper ();
		kalman_leftupleg_position = new MatrixKalmanWrapper ();
		kalman_rightupleg_position = new MatrixKalmanWrapper ();
		kalman_spine_position = new MatrixKalmanWrapper ();
		kalman_leftleg_position = new MatrixKalmanWrapper ();
		kalman_rightleg_position = new MatrixKalmanWrapper ();
		kalman_spine1_position = new MatrixKalmanWrapper ();
		kalman_spine2_position = new MatrixKalmanWrapper ();
		kalman_leftshoulder_position = new MatrixKalmanWrapper ();
		kalman_leftarm_position = new MatrixKalmanWrapper ();
		kalman_leftforearm_position = new MatrixKalmanWrapper ();
		kalman_rightshoulder_position = new MatrixKalmanWrapper ();
		kalman_rightarm_position = new MatrixKalmanWrapper ();
		kalman_rightforearm_position = new MatrixKalmanWrapper ();

		kalman_hips_rotation = new MatrixKalmanWrapper ();
		kalman_leftupleg_rotation = new MatrixKalmanWrapper ();
		kalman_rightupleg_rotation = new MatrixKalmanWrapper ();
		kalman_spine_rotation = new MatrixKalmanWrapper ();
		kalman_leftleg_rotation = new MatrixKalmanWrapper ();
		kalman_rightleg_rotation = new MatrixKalmanWrapper ();
		kalman_spine1_rotation = new MatrixKalmanWrapper ();
		kalman_spine2_rotation = new MatrixKalmanWrapper ();
		kalman_leftshoulder_rotation = new MatrixKalmanWrapper ();
		kalman_leftarm_rotation = new MatrixKalmanWrapper ();
		kalman_leftforearm_rotation = new MatrixKalmanWrapper ();
		kalman_rightshoulder_rotation = new MatrixKalmanWrapper ();
		kalman_rightarm_rotation = new MatrixKalmanWrapper ();
		kalman_rightforearm_rotation = new MatrixKalmanWrapper ();
	}

	void LateUpdate ()
	{
		
		t = !t;
		if (t) {
			return;
		}
		Debug.Log(hips.localEulerAngles);

		hips.localEulerAngles = Vector3.Lerp(hips.localEulerAngles, kalman_hips_rotation.Update(hips.localEulerAngles), 1);
		hips.localEulerAngles = new Vector3 (0, hips.localEulerAngles.y, hips.localEulerAngles.z);
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
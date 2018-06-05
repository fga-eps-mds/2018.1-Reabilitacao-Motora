using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Tests
{
	public static class Test_Joint
	{
		[Test]
		public static void TestHypot ()
		{
			float current1 = _Joint.Hypot(4f, 5f);
			float current2 = _Joint.Hypot(15f, 22f);
			float current3 = _Joint.Hypot(3f, 14f);
			float current4 = _Joint.Hypot(55f, 14f);
			float current5 = _Joint.Hypot(55f, 0f);
			float current6 = _Joint.Hypot(0f, 21f);
			float current7 = _Joint.Hypot(0f, 0f);

			float expected1 = 6.4031242374328485f;
			float expected2 = 26.627053911388696f;
			float expected3 = 14.317821063276353f;
			float expected4 = 56.753854494650845f;
			float expected5 = 55.0f;
			float expected6 = 21.0f;
			float expected7 = 0.0f;


			Assert.AreEqual(expected1, current1);
			Assert.AreEqual(expected2, current2);
			Assert.AreEqual(expected3, current3);
			Assert.AreEqual(expected4, current4);
			Assert.AreEqual(expected5, current5);
			Assert.AreEqual(expected6, current6);
			Assert.AreEqual(expected7, current7);
		}

		[Test]
		public static void TestAngle ()
		{
			Vector2 a = new Vector2(0f, 0f);
			Vector2 b = new Vector2(10f, 0f);
			Vector2 c = new Vector2(10f, 10f);
			Vector2 d = new Vector2(10f, 0f);
			float current1 = _Joint.Angle(a, b, c, d);
			float expected1 = 90.0f;
			Assert.AreEqual(expected1, current1);

			a = new Vector2(0f, 0f);
			b = new Vector2(0f, 10f);
			c = new Vector2(0f, 20f);
			d = new Vector2(0f, 10f);
			current1 = _Joint.Angle(a, b, c, d);
			expected1 = 180.0f;
			Assert.AreEqual(expected1, current1);

			a = new Vector2(0f, 0f);
			b = new Vector2(10f, 0f);
			c = new Vector2(5f, 5f);
			d = new Vector2(10f, 0f);
			current1 = _Joint.Angle(a, b, c, d);
			expected1 = 45.0f;
			Assert.AreEqual(expected1, current1);
		}
	}
}
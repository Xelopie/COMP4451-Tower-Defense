using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImage : Image
{
	protected override void Start()
	{
		base.Start();
		alphaHitTestMinimumThreshold = 0.5f;
	}
}

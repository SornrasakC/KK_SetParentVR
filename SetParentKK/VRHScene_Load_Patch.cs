﻿using System;
using System.Collections.Generic;
using Harmony;
using static SetParentKK.SetParentLoader;

namespace SetParentKK
{
	public static class VRHScene_Load_Patch
	{
		//This should hook to a method that loads as late as possible in the loading phase
		//Hooking method "MapSameObjectDisable" because: "Something that happens at the end of H scene loading, good enough place to hook" - DeathWeasel1337/Anon11
		//https://github.com/DeathWeasel1337/KK_Plugins/blob/master/KK_EyeShaking/KK.EyeShaking.Hooks.cs#L20
		[HarmonyPostfix]
		[HarmonyPatch(typeof(VRHScene), "MapSameObjectDisable")]
		public static void VRHSceneLoadPostfix(VRHScene __instance)
		{
			if (setParentObj != null)
				UnityEngine.Object.DestroyImmediate(setParentObj);

			setParentObj = __instance.gameObject.AddComponent<SetParent>();
			setParentObj.hSprite = __instance.sprites[0];
		}
	}
}

﻿
using UnityEngine;
using System;
using Mirror;
using System.Collections.Generic;
using OpenMMO;
using OpenMMO.Network;
using OpenMMO.DebugManager;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace OpenMMO.Network
{

    // ===================================================================================
    // BaseNetworkManager
    // ===================================================================================
    /// <summary>
    /// Abstract <c>Network Manager Base Class</c> that inherits the Mirror network manager.
    /// Partial class as to protect the various functions and methods. 
    /// </summary>
    public abstract partial class BaseNetworkManager : Mirror.NetworkManager
	{

		[Header("Debug Helper")]
		public DebugHelper debug;

        // -------------------------------------------------------------------------------
        // Awake (Base)
        // -------------------------------------------------------------------------------
        /// <summary>
        /// <c> Awake </c> function for the network manager component that overrides the mirror network manager awake function. 
        /// It initialized the debugger
        /// </summary>
        public override void Awake()
		{
			debug = new DebugHelper();
			debug.Init();
			base.Awake(); // required
		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameController {

    public static Player player;
    public static readonly Type[] listOfBs = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetTypes()
                    where typeof(WeaponModule).IsAssignableFrom(assemblyType)
                    select assemblyType).ToArray();

}

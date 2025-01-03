using System.Diagnostics;
using Terraria.ModLoader;

namespace ModOfFantasies
{
	public class ModOfFantasies : Mod
	{
		internal static ModOfFantasies Instance;

		public ModOfFantasies()
		{
            Debug.Assert(Instance == null);
            Instance = this;
		}

        public override void Unload()
        {
            Instance = null;
        }
    }
}
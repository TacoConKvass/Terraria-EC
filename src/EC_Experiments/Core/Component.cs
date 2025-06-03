using Terraria;

namespace EC.Core;

public class Component<T>
	where T : struct 
{
	public static class State {
		public static T[] NPCs = new T[Main.maxNPCs];
		public static T[] Projectiles = new T[Main.maxProjectiles];
		public static T[] Players = new T[Main.maxPlayers];
	}

	public static class Enabled {
		public static bool[] NPCs = new bool[Main.maxNPCs];
		public static bool[] Projectiles = new bool[Main.maxProjectiles];
		public static bool[] Players = new bool[Main.maxPlayers];
	}
}

public static class EntityExtensions {
	public static void SetEnabled<T>(this NPC npc, bool value) where T : struct {
		Component<T>.Enabled.NPCs[npc.whoAmI] = value;
	}
}
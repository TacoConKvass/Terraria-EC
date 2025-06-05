using EC.Core;
using Daybreak.Common.Features.Hooks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace EC.Components;

using Data = (int DustType, int Amount, Vector2 Range);

public class Items : ItemData<Data, Manager> { }
public class Projectiles : ProjectileData<Data, Manager> { }
public class NPCs : NPCData<Data, Manager> { }
public class Players : PlayerData<Data, Manager> { }

public class Manager : Manager<Data> {
	public override string ComponentName => "Test";
	public override string ComponentDescription => "TestDesc";

	public override object[] ItemInputs => [
		ItemID.CopperAxe, new Data(DustID.GemTopaz, 10, Vector2.One * 20)
	];
}

public class Test : ILoadable {
	public void Load(Mod mod) {
		GlobalItemHooks.OnHitNPC.Event += static (GlobalItem _, Item item, Player _, NPC target, NPC.HitInfo _, int _) => {
			var component = item.GetGlobalItem<Items>();
			if (component.Enabled)
				Execute(component.Data, target.Center);
		};
		GlobalProjectileHooks.OnHitNPC.Event += static (GlobalProjectile _, Projectile projectile, NPC target, NPC.HitInfo _, int _) => {
			var component = projectile.GetGlobalProjectile<Projectiles>();
			if (component.Enabled)
				Execute(component.Data, target.Center);
		};
		GlobalNPCHooks.OnHitNPC.Event += (GlobalNPC _, NPC npc, NPC target, NPC.HitInfo _) => {
			var component = npc.GetGlobalNPC<NPCs>();
			if (component.Enabled)
				Execute(component.Data, target.Center);
		};
		ModPlayerHooks.OnHitNPC.Event += (ModPlayer player, NPC target, NPC.HitInfo _, int _) => {
			var component = player.Player.GetModPlayer<Players>();
			if (component.Enabled)
				Execute(component.Data, target.Center);
		};
	}

	static void Execute(Data data, Vector2 position) {
		for (int i = 0; i < data.Amount; i++) 
			Dust.NewDust(position, (int)data.Range.X, (int)data.Range.Y, data.DustType);
	}

	public void Unload() { }
}
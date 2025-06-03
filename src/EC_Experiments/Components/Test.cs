using EC.Core;
using Daybreak.Common.Features.Hooks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EC.Components;


using Data = (int DustType, int Amount, Vector2 Range);

public class Test : Component<Data>, ILoadable {
	[ReinitializeDuringResizeArrays]
	public static class Defaults {
		public static Data[] Items = ItemID.Sets.Factory.CreateNamedSet("EC/Test")
			.Description("Test component - spawns dust on NPC hit")
			.RegisterCustomSet(new Data(), 
				ItemID.CopperAxe, new Data(DustID.Water, 20, new Vector2(20))
			);
		public static Data[] Projectiles = ProjectileID.Sets.Factory.CreateNamedSet("EC/Test")
			.Description("Test component - spawns dust on NPC hit")
			.RegisterCustomSet(new Data(),
				ProjectileID.Bullet, new Data(DustID.GemTopaz, 20, new Vector2(20))
			);
	}

	public void Load(Mod mod) {

		GlobalItemHooks.OnHitNPC.Event += static (GlobalItem self, Item item, Player _, NPC target, NPC.HitInfo _, int _) => {
			Data data = Defaults.Items[item.type];
			if (data != new Data()) Execute(data, target.Center);
		};

		GlobalProjectileHooks.OnSpawn.Event += (GlobalProjectile _, Projectile projectile, IEntitySource _) => {
			Data data = Defaults.Projectiles[projectile.type];
			State.Projectiles[projectile.whoAmI] = data;
			Enabled.Projectiles[projectile.whoAmI] = (data != new Data());
		};
		GlobalProjectileHooks.OnHitNPC.Event += static (GlobalProjectile self, Projectile projectile, NPC target, NPC.HitInfo _, int _) => {
			Main.NewText(Enabled.Projectiles[projectile.whoAmI]);
			if (Enabled.Projectiles[projectile.whoAmI]) Execute(State.Projectiles[projectile.whoAmI], target.Center);
		};
	}

	static void Execute(Data data, Vector2 position) {
		for (int i = 0; i < data.Amount; i++) Dust.NewDust(position, (int)data.Range.X, (int)data.Range.Y, data.DustType);
	}

	public void Unload() { }
}
using EC.Core;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ComponentData = (int DustType, int Amount, Microsoft.Xna.Framework.Vector2 Range);

namespace EC_Experiments.Components;

public class Test {
	public static readonly ComponentData Invalid = new();

	[ReinitializeDuringResizeArrays]
	public static class Values {
		public static ComponentData[] Items = ItemID.Sets.Factory.CreateNamedSet("EC/Test")
			.Description("Test component - spawns Dust on target hit")
			.RegisterCustomSet(new ComponentData(), 
				ItemID.CopperAxe, new ComponentData(DustID.Water, 20, new Vector2(20))
			);

		public static ComponentData[] Projectiles = ProjectileID.Sets.Factory.CreateNamedSet("EC/Test")
			.Description("Test component - spawns Dust on target hit")
			.RegisterCustomSet(new ComponentData(), 
				ProjectileID.Bullet, new ComponentData(DustID.Ice, 20, new Vector2(20))
			);

		public static ComponentData[] NPCs = NPCID.Sets.Factory.CreateNamedSet("EC/Test")
			.Description("Test component - spawns Dust on target hit")
			.RegisterCustomSet<ComponentData>(new());
	}

	public class Items : GlobalItem, IComponent<ComponentData> {
		public override bool InstancePerEntity { get; } = true;
		public ComponentData Data { get; set; }
		public bool Enabled { get; set; }

		public override void SetDefaults(Item entity) {
			Data = Values.Items[entity.type];
			Enabled = (Data == new ComponentData());
		}

		public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (Enabled) Execute(Data, target.Center);
		}

		public override void OnHitPvp(Item item, Player player, Player target, Player.HurtInfo hurtInfo) {
			if (Enabled) Execute(Data, target.Center);
		}
	}

	public class Projectiles : GlobalProjectile, IComponent<ComponentData> {
		public override bool InstancePerEntity { get; } = true;
		public ComponentData Data { get; set; }
		public bool Enabled { get; set; }

		public override void SetDefaults(Projectile entity) {
			Data = Values.Projectiles[entity.type];
			Enabled = (Data == new ComponentData());
		}

		public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) {
			if (Enabled) Execute(Data, target.Center);
		}

		public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info) {
			if (Enabled) Execute(Data, target.Center);
		}
	}
	public class NPCs : GlobalNPC, IComponent<ComponentData> {
		public override bool InstancePerEntity { get; } = true;
		public ComponentData Data { get; set; }
		public bool Enabled { get; set; }

		public override void SetDefaults(NPC entity) {
			Data = Values.NPCs[entity.type];
			Enabled = (Data != new ComponentData());
		}

		public override void OnHitNPC(NPC npc, NPC target, NPC.HitInfo hit) {
			if (Enabled) Execute(Data, target.Center);
		}

		public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo) {
			if (Enabled) Execute(Data, target.Center);
		}
	}

	public static void Execute(ComponentData data, Vector2 position) {
		for (int i = 0; i < data.Amount; i++) {
			Dust.NewDust(position, (int)data.Range.X, (int)data.Range.Y, data.DustType);
		}
	}
}
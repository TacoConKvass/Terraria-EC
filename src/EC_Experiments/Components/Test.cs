using EC.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ComponentData = (int DustType, int Amount);

namespace EC_Experiments.Components;

public class Test {
	[ReinitializeDuringResizeArrays]
	public static class Values {
		public static ComponentData[] Items = ItemID.Sets.Factory.CreateNamedSet("EC/Test").RegisterCustomSet(new ComponentData(), ItemID.CopperAxe, new ComponentData(DustID.Water, 20));
		public static ComponentData[] Projectiles = ProjectileID.Sets.Factory.CreateNamedSet("EC/Test").RegisterCustomSet(new ComponentData(), ProjectileID.Bullet, new ComponentData(DustID.Ice, 20));
		public static ComponentData[] NPCs = NPCID.Sets.Factory.CreateNamedSet("EC/Test").RegisterCustomSet<ComponentData>(new());
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
			if (Enabled) Execute_NPC(Data, target);
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
			if (Enabled) Execute_NPC(Data, target);
		}
	}
	public class NPCs : GlobalNPC, IComponent<ComponentData> {
		public override bool InstancePerEntity { get; } = true;
		public ComponentData Data { get; set; }
		public bool Enabled { get; set; }

		public override void SetDefaults(NPC entity) {
			Data = Values.NPCs[entity.type];
			Enabled = (Data == new ComponentData());
		}

		public override void OnHitNPC(NPC npc, NPC target, NPC.HitInfo hit) {
			if (Enabled) Execute_NPC(Data, target);
		}
	}

	public static void Execute_NPC(ComponentData data, NPC target) {
		for (int i = 0; i < data.Amount; i++) {
			Dust.NewDust(target.Center, target.width, target.height, data.DustType);
		}
	}
}
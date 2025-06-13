using Terraria;

namespace EC.Core;

public static class EntityExtensions
{
	public static void Enable<T>(this NPC entity) where T : NPCComponent {
		NPCComponent component = entity.GetGlobalNPC<T>();
		component.Enabled = true;
		component.OnEnabled(entity);
	}
	public static void Enable<T>(this Projectile entity) where T : ProjectileComponent {
		ProjectileComponent component = entity.GetGlobalProjectile<T>();
		component.Enabled = true;
		component.OnEnabled(entity);
	}

	public static void Enable<T>(this Item entity) where T : ItemComponent {
		NPCComponent component = entity.GetGlobalItem<T>();
		component.Enabled = true;
		component.OnEnabled(entity);
	}

	public static void Enable<T>(this Player entity) where T : PlayerComponent {
		NPCComponent component = entity.GetModPlayer<T>();
		component.Enabled = true;
		component.OnEnabled(entity);
	}
}
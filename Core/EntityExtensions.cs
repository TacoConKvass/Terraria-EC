using Terraria;

namespace EC.Core;

public static class EntityExtensions
{
	public static T Enable<T>(this NPC entity) where T : NPCComponent {
		NPCComponent component = entity.GetGlobalNPC<T>();
		if (!component.Enabled) component.OnEnabled(entity);
		component.Enabled = true;
		return (T)component;
	}

	public static T Enable<T>(this Projectile entity) where T : ProjectileComponent {
		ProjectileComponent component = entity.GetGlobalProjectile<T>();
		if (!component.Enabled) component.OnEnabled(entity);
		component.Enabled = true;
		return (T)component;
	}

	public static T Enable<T>(this Item entity) where T : ItemComponent {
		ItemComponent component = entity.GetGlobalItem<T>();
		if (!component.Enabled) component.OnEnabled(entity);
		component.Enabled = true;
		return (T)component;
	}

	public static T Enable<T>(this Player entity) where T : PlayerComponent {
		PlayerComponent component = entity.GetModPlayer<T>();
		if (!component.Enabled) component.OnEnabled(entity);
		component.Enabled = true;
		return (T)component;
	}

	public static void Disable<T>(this NPC entity) where T : NPCComponent {
		NPCComponent component = entity.GetGlobalNPC<T>();
		if (component.Enabled) component.OnDisabled(entity);
		component.Enabled = false;
	}

	public static void Disable<T>(this Projectile entity) where T : ProjectileComponent {
		ProjectileComponent component = entity.GetGlobalProjectile<T>();
		if (component.Enabled) component.OnDisabled(entity);
		component.Enabled = false;
	}

	public static void Disable<T>(this Item entity) where T : ItemComponent {
		ItemComponent component = entity.GetGlobalItem<T>();
		if (component.Enabled) component.OnDisabled(entity);
		component.Enabled = false;
	}

	public static void Disable<T>(this Player entity) where T : PlayerComponent {
		PlayerComponent component = entity.GetModPlayer<T>();
		if (component.Enabled) component.OnDisabled(entity);
		component.Enabled = false;
	}
}
using System.ComponentModel;
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

	public static T Get<T>(this NPC entity) where T : NPCComponent => entity.GetGlobalNPC<T>();

	public static T Get<T>(this Projectile entity) where T : ProjectileComponent => entity.GetGlobalProjectile<T>();

	public static T Get<T>(this Item entity) where T : ItemComponent => entity.GetGlobalItem<T>();

	public static T Get<T>(this Player entity) where T : PlayerComponent => entity.GetModPlayer<T>();

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
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using WeaponPacks;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;

namespace AncientMonkey;

public class PiercingWinds : GildedTemplate
{
    public override string EffectName => "Piercing Winds";
    public override string Description => "+25% projectile speed and 2x pierce";
    public override string Icon => VanillaSprites.FasterDartsUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.speed *= 1.25f);
        weapon.GetDescendants<FollowPathModel>().ForEach(model => model.speed *= 1.25f);
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce *= 2);
    }
}
public class SuperStrength : GildedTemplate
{
    public override string EffectName => "Super Strength";
    public override string Description => "+50% damage";
    public override string Icon => VanillaSprites.MapBuffIconDamage;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<DamageModel>().ForEach(model => model.damage *= 1.5f);
    }
}
public class FastHands : GildedTemplate
{
    public override string EffectName => "Fast Hands";
    public override string Description => "+30% attack speed";
    public override string Icon => VanillaSprites.BuffIconVillage2xx;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<WeaponModel>().ForEach(model => model.rate /= 1.3f);
    }
}
public class Incendiary : GildedTemplate
{
    public override string EffectName => "Incendiary";
    public override string Description => "Lights Bloons on fire";
    public override string Icon => VanillaSprites.DragonsBreathUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var fire = Game.instance.model.GetTowerFromId("Alchemist").GetDescendant<AddBehaviorToBloonModel>().Duplicate();
        fire.GetBehavior<DamageOverTimeModel>().damage = 2;
        fire.GetBehavior<DamageOverTimeModel>().interval = 1f;
        fire.lifespan = 5;
        fire.overlayType = "Fire";

        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.AddBehavior(fire));
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.collisionPasses = new int[] { -1, 0 });
    }
}
public class Shiny : GildedTemplate
{
    public override string EffectName => "Shiny";
    public override string Description => "+50% cash value";
    public override string Icon => VanillaSprites.ValuableBananasUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<CashModel>().ForEach(model => model.minimum *= 1.5f);
        weapon.GetDescendants<CashModel>().ForEach(model => model.maximum *= 1.5f);
    }
}
public class Fertilizer : GildedTemplate
{
    public override string EffectName => "Fertilizer";
    public override string Description => "Double Production";
    public override string Icon => VanillaSprites.GreaterProductionUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<EmissionsPerRoundFilterModel>().ForEach(model => model.count *= 2);
    }
}
public class GodBoost : GildedTemplate
{
    public override string EffectName => "God Boost";
    public override string Description => "+15% to all stats";
    public override string Icon => VanillaSprites.SunTempleUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.speed *= 1.15f);
        weapon.GetDescendants<FollowPathModel>().ForEach(model => model.speed *= 1.15f);
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce *= 1.15f);
        weapon.GetDescendants<DamageModel>().ForEach(model => model.damage *= 1.15f);
        weapon.GetDescendants<WeaponModel>().ForEach(model => model.rate /= 1.15f);
        weapon.GetDescendants<CashModel>().ForEach(model => model.minimum *= 1.15f);
        weapon.GetDescendants<CashModel>().ForEach(model => model.maximum *= 1.15f);
    }
}
public class WindBlast : GildedTemplate
{
    public override string EffectName => "Wind Blast";
    public override string Description => "+25% projectile speed, +10% damage, and knocksback Bloons";
    public override string Icon => VanillaSprites.DruidoftheStormUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var wind = new WindModel("WindModel_", 60, 120, 0.6f, false, "", 0.5f, "Ceramic");

        weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.speed *= 1.25f);
        weapon.GetDescendants<FollowPathModel>().ForEach(model => model.speed *= 1.25f);
        weapon.GetDescendants<DamageModel>().ForEach(model => model.damage *= 1.1f);
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.AddBehavior(wind));
    }
}
public class DoubleTap : GildedTemplate
{
    public override string EffectName => "Double Tap";
    public override string Description => "Shoots in a two round burst";
    public override string Icon => VanillaSprites.QuestIconDesperado;
    public override void Gild(AttackModel weapon)
    {
        var burst = new BurstWeaponBehaviorModel("BurstWeaponBehaviorModel_", 0.1f, 2, true);
        weapon.GetDescendants<WeaponModel>().ForEach(model => model.AddBehavior(burst));
    }
}
public class HawkEye : GildedTemplate
{
    public override string EffectName => "Hawk Eye";
    public override string Description => "+20% attack speed and Camo detection";
    public override string Icon => VanillaSprites.EnhancedEyesightUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<WeaponModel>().ForEach(model => model.rate /= 1.2f);
        weapon.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
    }
}
public class Tracking : GildedTemplate
{
    public override string EffectName => "Tracking";
    public override string Description => "Projectiles last 50% longer and seek out targets";
    public override string Icon => VanillaSprites.NevaMissTargetingUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var track = new TrackTargetModel("target", 6000, true, false, 360, false, 360, false, false, false);
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.AddBehavior(track));
        weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= 1.5f);
    }
}
public class StrongerCompound : GildedTemplate
{
    public override string EffectName => "Stronger Compound";
    public override string Description => "+60% duration and +50% strength to Bloon debuffs";
    public override string Icon => VanillaSprites.StrongerAcidUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<AddBehaviorToBloonModel>().ForEach(model => model.lifespan *= 1.6f);
        weapon.GetDescendants<SlowModel>().ForEach(model => model.lifespan *= 1.6f);
        weapon.GetDescendants<FreezeModel>().ForEach(model => model.lifespan *= 1.6f);
        weapon.GetDescendants<DamageOverTimeModel>().ForEach(model => model.damage *= 1.5f);
    }
}
public class Wither : GildedTemplate
{
    public override string EffectName => "Wither";
    public override string Description => "Bloons recieve +2 damage from all sources";
    public override string Icon => VanillaSprites.GrandSaboteurUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var track = new AddBonusDamagePerHitToBloonModel("AddBonusDamagePerHitToBloonModel_", "Wither", 3, 2, 6, true, false, false, null);
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.AddBehavior(track));
    }
}
public class Explosive : GildedTemplate
{
    public override string EffectName => "Explosive Rounds";
    public override string Description => "Projectiles explode on contact";
    public override string Icon => VanillaSprites.FragBombsUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var bomb = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        var effect = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        var sound = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate();
        weapon.weapons[0].projectile.AddBehavior(bomb);
        weapon.weapons[0].projectile.AddBehavior(effect);
        weapon.weapons[0].projectile.AddBehavior(sound);
    }
}
public class FreezingTouch : GildedTemplate
{
    public override string EffectName => "Freezing Touch";
    public override string Description => "Projectiles freeze Bloons";
    public override string Icon => VanillaSprites.RefreezeUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var frost = Game.instance.model.GetTowerFromId("IceMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate();
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.AddBehavior(frost));
        weapon.GetDescendants<ProjectileModel>().ForEach(model => model.collisionPasses = new int[] { -1, 0 });
    }
}
public class Multishot : GildedTemplate
{
    public override string EffectName => "Multishot";
    public override string Description => "Fires 3 projectiles at a time";
    public override string Icon => VanillaSprites.TripleShotUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<WeaponModel>().ForEach(model => model.emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 30, null, false, false));
    }
}
public class SentryUpgrade : GildedTemplate
{
    public override string EffectName => "Sentry Upgrade";
    public override string Description => "Upgrades the sentries to a stronger version";
    public override string Icon => VanillaSprites.SentryExpertUpgradeIcon;
    public override void Gild(AttackModel weapon) { }
}
public class TrapUpgrade : GildedTemplate
{
    public override string EffectName => "Trap Upgrade";
    public override string Description => "Increases trap capacity and cash multiplier by 25%";
    public override string Icon => VanillaSprites.SprocketsUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        weapon.GetDescendants<EatBloonModel>().ForEach(model => model.rbeCapacity *= 1.25f);
        weapon.GetDescendants<EatBloonModel>().ForEach(model => model.rbeCashMultiplier *= 1.25f);
    }
}
public class StaticShock : GildedTemplate
{
    public override string EffectName => "Static Shock";
    public override string Description => "Projectiles stike nearby Bloons with lightning";
    public override string Icon => VanillaSprites.HeartofThunderUpgradeIcon;
    public override void Gild(AttackModel weapon)
    {
        var lightning = Game.instance.model.GetTower(TowerType.Druid, 2).GetAttackModel().weapons[1].Duplicate();
        lightning.projectile.GetDamageModel().damage = 1;

        var createProjectile = new CreateProjectileOnIntervalModel("lightning", lightning.projectile, lightning.emission, 15, true, 50, TargetType.First, true, false, false, null);
        weapon.weapons[0].projectile.AddBehavior(createProjectile);
    }
}
/*
public class  : GildedTemplate
{
    public override string EffectName => "";
    public override string Description => "";
    public override string Icon => VanillaSprites.;
    public override void Gild(AttackModel weapon)
    {

    }
}*/
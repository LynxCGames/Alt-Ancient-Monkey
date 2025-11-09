using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using AncientMonkey;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity.Display.Animation;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System.Linq;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem.Collections.Generic;

namespace WeaponPacks;

// #### Common ####

public class BloonBite : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Bloon Bite";
    public override string CodeName => "BloonBite";
    public override Sprite CustomIcon => GetSprite("SilveriaLvl1-BloonBite");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
        var weapon = Game.instance.model.GetTowerFromId("BallOfLightTower").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var addBehaviorModel = Game.instance.model.GetTowerFromId("IceMonkey-004").GetAttackModel().weapons[0].projectile.
            GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
        addBehaviorModel.name = "Bite";
        addBehaviorModel.mutationId = "electricshock";
        addBehaviorModel.lifespan = 9999;
        addBehaviorModel.GetBehavior<CarryProjectileModel>().projectile.RemoveBehavior<DamageModel>();
        addBehaviorModel.GetBehavior<CarryProjectileModel>().projectile.pierce = 9999;
        addBehaviorModel.GetBehavior<CarryProjectileModel>().projectile.maxPierce = 9999;
        addBehaviorModel.ApplyOverlay<BiteOverlay>();

        var removeBloonModel = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
        removeBloonModel.cleanseCamo = true;

        weapon.weapons[0].Rate = 0.9f;
        weapon.weapons[0].SetEject(new Vector3(0.0f, 0.0f, 5f), false, false, false);
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().dontUseTowerPosition = true;
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().displayPath.assetPath = CreatePrefabReference<LaserBeamBloonBite>();
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().effectAtEndModel.assetId = CreatePrefabReference<LaserBeamParticle>();
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().displayLifetime = 0.2f;
        weapon.weapons[0].projectile.id = "123atk";
        weapon.weapons[0].projectile.pierce = 1;
        weapon.weapons[0].projectile.maxPierce = 1;
        weapon.weapons[0].projectile.GetDamageModel().damage = 2;
        weapon.weapons[0].projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)25;
        weapon.weapons[0].projectile.AddBehavior(addBehaviorModel);
        weapon.weapons[0].projectile.AddBehavior(removeBloonModel);
        weapon.weapons[0].projectile.UpdateCollisionPassList();
        weapon.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        wpn.weapons[0] = weapon.weapons[0];
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class VampiricRip : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Vampiric Rip";
    public override string CodeName => "VampiricRip";
    public override Sprite CustomIcon => GetSprite("SilveriaLvl1-VampRip");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var projectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.display = new PrefabReference() { guidRef = "" };
        projectile.RemoveBehavior<CreateSoundOnProjectileCollisionModel>();
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 2;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.ApplyDisplay<VampRip>();
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.scale = 1.25f;

        wpn.weapons[0].Rate = 0.4f;
        wpn.weapons[0].emission = new InstantDamageEmissionModel("", null);
        wpn.weapons[0].projectile = projectile;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class BloonBiteLvl20 : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bloon Bite Lvl 20";
    public override string CodeName => "BloonBiteLvl20";
    public override Sprite CustomIcon => GetSprite("SilveriaLvl20-BloonBite");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap", "Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().Duplicate();
        var weapon = Game.instance.model.GetTowerFromId("BallOfLightTower").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var bleedModel = Game.instance.model.GetTowerFromId("Sauda 11").GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().Duplicate();
        bleedModel.interval = 0.35f;
        bleedModel.damage = 5;

        var addBehaviorModel = Game.instance.model.GetTowerFromId("IceMonkey-004").GetAttackModel().weapons[0].projectile.
            GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
        addBehaviorModel.name = "Bite";
        addBehaviorModel.mutationId = "electricshock";
        addBehaviorModel.lifespan = 9999;
        addBehaviorModel.ApplyOverlay<BiteOverlay>();
        addBehaviorModel.GetBehavior<CarryProjectileModel>().projectile.RemoveBehavior<DamageModel>();
        addBehaviorModel.GetBehavior<CarryProjectileModel>().projectile.pierce = 9999;
        addBehaviorModel.GetBehavior<CarryProjectileModel>().projectile.maxPierce = 9999;
        addBehaviorModel.AddBehavior(bleedModel);

        var removeBloonModel = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
        removeBloonModel.cleanseCamo = true;

        var slowModifier = Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehaviors<SlowModifierForTagModel>()[1].Duplicate();
        var slowModel = Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate();
        slowModel.overlayType = "";
        slowModel.glueLevel = 0;
        slowModel.multiplier = 0.25f;

        var addBonusDamage = Game.instance.model.GetTowerFromId("IceMonkey-500").GetAttackModel().weapons[0].projectile.GetBehavior<AddBonusDamagePerHitToBloonModel>().Duplicate();
        addBonusDamage.perHitDamageAddition = 1.7f;

        weapon.weapons[0].Rate = 0.9f;
        weapon.weapons[0].SetEject(new Vector3(0.0f, 0.0f, 5f), false, false, false);
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().dontUseTowerPosition = true;
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().displayPath.assetPath = CreatePrefabReference<LaserBeamBloonBiteLv19>();
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().effectAtEndModel.assetId = CreatePrefabReference<LaserBeamParticle>();
        weapon.weapons[0].GetChild<LineProjectileEmissionModel>().displayLifetime = 0.2f;
        weapon.weapons[0].projectile.id = "123atk";
        weapon.weapons[0].projectile.pierce = 1;
        weapon.weapons[0].projectile.maxPierce = 1;
        weapon.weapons[0].projectile.GetDamageModel().damage = 2;
        weapon.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        weapon.weapons[0].projectile.AddBehavior(addBehaviorModel);
        weapon.weapons[0].projectile.AddBehavior(removeBloonModel);
        weapon.weapons[0].projectile.AddBehavior(slowModel);
        weapon.weapons[0].projectile.AddBehavior(slowModifier);
        weapon.weapons[0].projectile.AddBehavior(addBonusDamage);
        weapon.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("moabs", "Moabs", 5f, 1f, false, false, false));
        weapon.weapons[0].projectile.UpdateCollisionPassList();
        weapon.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        wpn.weapons[0] = weapon.weapons[0];
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class NightVigil : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Night Vigil";
    public override string CodeName => "NightVigil";
    public override Sprite CustomIcon => GetSprite("NightVigil-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-402").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 2;

        var removeBloonModel = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
        removeBloonModel.cleanseCamo = true;

        var bat = wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower;
        bat.RemoveBehavior<TowerExpireOnParentUpgradedModel>();
        bat.RemoveBehavior(bat.GetAttackModel(2));
        bat.GetBehavior<AirUnitModel>().GetBehavior<FighterMovementModel>().maxSpeed *= 2;
        bat.GetBehavior<AirUnitModel>().GetBehavior<FighterMovementModel>().rollRunUpDistance = 10;
        bat.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Batsy>();

        bat.GetAttackModel(0).weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        bat.GetAttackModel(0).weapons[0].projectile.RemoveBehavior<DamageModel>();

        bat.GetAttackModel(1).weapons[0].Rate = 0.15f;
        bat.GetAttackModel(1).weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        bat.GetAttackModel(1).weapons[0].projectile.pierce = 1;
        bat.GetAttackModel(1).weapons[0].projectile.GetDamageModel().damage = 1;
        bat.GetAttackModel(1).weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        bat.GetAttackModel(1).weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.18f;
        bat.GetAttackModel(1).weapons[0].projectile.AddBehavior(removeBloonModel);
        bat.GetAttackModel(1).weapons[0].projectile.UpdateCollisionPassList();

        WeaponMethods.AfterEffects(bat.GetAttackModel(1), gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class NightVigilLvl20 : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Night Vigil Lvl 20";
    public override string CodeName => "NightVigilLvl20";
    public override Sprite CustomIcon => GetSprite("NightVigil-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-402").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].GetBehavior<SubTowerFilterModel>().maxNumberOfSubTowers = 3;

        var removeBloonModel = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
        removeBloonModel.cleanseCamo = true;

        var bat = wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower;
        bat.RemoveBehavior<TowerExpireOnParentUpgradedModel>();
        bat.RemoveBehavior(bat.GetAttackModel(2));
        bat.GetBehavior<AirUnitModel>().GetBehavior<FighterMovementModel>().maxSpeed *= 2;
        bat.GetBehavior<AirUnitModel>().GetBehavior<FighterMovementModel>().rollRunUpDistance = 10;
        bat.GetBehavior<AirUnitModel>().display = CreatePrefabReference<Batsy>();

        bat.GetAttackModel(0).weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        bat.GetAttackModel(0).weapons[0].projectile.RemoveBehavior<DamageModel>();

        bat.GetAttackModel(1).weapons[0].Rate = 0.1f;
        bat.GetAttackModel(1).weapons[0].projectile.display = new PrefabReference() { guidRef = "" };
        bat.GetAttackModel(1).weapons[0].projectile.pierce = 1;
        bat.GetAttackModel(1).weapons[0].projectile.GetDamageModel().damage = 4;
        bat.GetAttackModel(1).weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        bat.GetAttackModel(1).weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.18f;
        bat.GetAttackModel(1).weapons[0].projectile.AddBehavior(removeBloonModel);
        bat.GetAttackModel(1).weapons[0].projectile.UpdateCollisionPassList();

        WeaponMethods.AfterEffects(bat.GetAttackModel(1), gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class VampiricRipLvl10 : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Vampiric Rip Lvl 10";
    public override string CodeName => "VampiricRipLvl10";
    public override Sprite CustomIcon => GetSprite("SilveriaLvl10-VampRip");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var slowModifier = Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehaviors<SlowModifierForTagModel>()[1].Duplicate();
        var slowModel = Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate();
        slowModel.overlayType = "";
        slowModel.glueLevel = 0;
        slowModel.multiplier = 0.25f;

        var projectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.display = new PrefabReference() { guidRef = "" };
        projectile.RemoveBehavior<CreateSoundOnProjectileCollisionModel>();
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 4;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(slowModel);
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(slowModifier);
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("moaby", "Moabs", 2f, 1f, false, false, false));
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.UpdateCollisionPassList();
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.ApplyDisplay<VampRip>();
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.scale = 1.25f;

        wpn.weapons[0].Rate = 0.3f;
        wpn.weapons[0].emission = new InstantDamageEmissionModel("", null);
        wpn.weapons[0].projectile = projectile;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class VampiricRipLvl20 : WeaponTemplate
{
    public override string WeaponPack => "SpookyPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Vampiric Rip Lvl 20";
    public override string CodeName => "VampiricRipLvl20";
    public override Sprite CustomIcon => GetSprite("SilveriaLvl20-VampRip");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var slowModifier = Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehaviors<SlowModifierForTagModel>()[1].Duplicate();
        var slowModel = Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate();
        slowModel.overlayType = "";
        slowModel.glueLevel = 0;
        slowModel.multiplier = 0.25f;

        var projectile = Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.display = new PrefabReference() { guidRef = "" };
        projectile.RemoveBehavior<CreateSoundOnProjectileCollisionModel>();
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 4;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(slowModel);
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(slowModifier);
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("moaby", "Moabs", 4f, 1f, false, false, false));
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.UpdateCollisionPassList();
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.ApplyDisplay<VampRip>();
        projectile.GetBehavior<CreateEffectOnContactModel>().effectModel.scale = 1.25f;

        wpn.weapons[0].Rate = 0.13f;
        wpn.weapons[0].emission = new InstantDamageEmissionModel("", null);
        wpn.weapons[0].projectile = projectile;
        wpn.weapons[0].AddBehavior(new LifeBasedAttackSpeedModel("", 0.2f, 0, 0.2f, ""));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Displays ####

// Vampiric Rip
public class VampRip : ModDisplay
{
    public override string BaseDisplay => "f3f329dc3af8af04cb22ec37bf5ab043";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Renderer genericRenderer in (Il2CppArrayBase<Renderer>)node.genericRenderers)
            genericRenderer.material.color = new Color(1f, 0.239215687f, 0.239215687f);
    }
}

// Bloon Bite
public class LaserBeamBloonBite : ModDisplay
{
    public static Color32 gold = new Color32(175, 0, 0, byte.MaxValue);
    public static Color32 goldLight = new Color32(170, 0, 0, byte.MaxValue);
    public override string BaseDisplay => "9febdb09af42b2144919434a864d81f8";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Material material in UnityDisplayNodeExt.GetRenderers(node, true).SelectMany(renderer => renderer.materials))
        {
            material.SetColor("_Color1", gold);
            material.SetColor("_Color2", goldLight);
            material.SetFloat("_Color1Power", 3f);
            material.SetFloat("_BeamPower", 3E-05f);
        }
    }
}
public class LaserBeamBloonBiteLv19 : ModDisplay
{
    public static Color32 gold = new Color32(175, 0, 0, byte.MaxValue);
    public static Color32 goldLight = new Color32(170, 0, 0, byte.MaxValue);
    public override string BaseDisplay => "b9f3014db2da83f48b34e662e9a79910";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Material material in UnityDisplayNodeExt.GetRenderers(node, true).SelectMany(renderer => renderer.materials))
        {
            material.SetColor("_Color1", gold);
            material.SetColor("_Color2", goldLight);
            material.SetFloat("_Color1Power", 3f);
            material.SetFloat("_BeamPower", 3E-05f);
        }
    }
}
public class LaserBeamParticle : ModDisplay
{
    public override string BaseDisplay => "8da4c42ab1a94af4495966cc2044ffd8";
}
public class BiteOverlay : ModBloonOverlay
{
    public override string BaseOverlay => "LaserShock";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Il2CppObjectBase genericRenderer in (Il2CppArrayBase<Renderer>)node.genericRenderers)
        {
            if (Il2CppSystemObjectExt.Is<SpriteRenderer>(genericRenderer) && node.GetComponentInChildren<CustomSpriteFrameAnimator>())
            {
                List<Sprite> list = new List<Sprite>();
                list.Add(GetSprite("Frame1", 10f));
                list.Add(GetSprite("Frame2", 10f));
                node.GetComponentInChildren<CustomSpriteFrameAnimator>().frames = list;
            }
        }
    }
}

// Night Vigil
public class Batsy : ModCustomDisplay
{
    public override string AssetBundleName => "vamp";
    public override string PrefabName => "batsy";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 60;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.239215687f, 0.07058824f, 0.09411765f));
        }
    }
}
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using AncientMonkey;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity.Display;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;

namespace WeaponPacks;

// #### Common ####

public class PsychoDart : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Psycho Dart";
    public override string CodeName => "PsychoDart";
    public override Sprite CustomIcon => GetSprite("PsychoDartIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 9999;

        var tracking = Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate();
        tracking.Lifespan = 9999;

        wpn.attackThroughWalls = true;
        wpn.weapons[0].Rate = 3.2f;
        wpn.weapons[0].emission = new SingleEmmisionTowardsTargetModel("SingleEmmisionTowardsTargetModel_", null, 0);
        wpn.weapons[0].projectile.ApplyDisplay<PsychoDartProj>();
        wpn.weapons[0].projectile.pierce = 8;
        wpn.weapons[0].projectile.scale *= 2;
        wpn.weapons[0].projectile.ignoreBlockers = true;
        wpn.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 9999f;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 2;
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(tracking);
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.3f));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class StickOfStone : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Stick of Stone";
    public override string CodeName => "StickOfStone";
    public override Sprite CustomIcon => GetSprite("StickOfStoneIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.attackThroughWalls = true;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 9999;

        var speedInRange = Game.instance.model.GetTowerFromId("Rosalia 4").GetAttackModel().weapons[0].GetBehavior<BloonsInRangeAttackSpeedModel>().Duplicate();
        speedInRange.rateIncreasePerStack = 0.1f;

        var exhaustProjectile1 = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        exhaustProjectile1.projectile.ApplyDisplay<QuakeStage1>();
        exhaustProjectile1.projectile.radius = 30;
        exhaustProjectile1.projectile.pierce = 9999;
        exhaustProjectile1.projectile.GetDamageModel().damage = 1;
        exhaustProjectile1.projectile.GetDamageModel().createPopEffect = true;
        exhaustProjectile1.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        exhaustProjectile1.projectile.GetBehavior<AgeModel>().Lifespan = 0.2f;

        var exhaustProjectile2 = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        exhaustProjectile2.projectile.ApplyDisplay<QuakeStage2>();
        exhaustProjectile2.projectile.radius = 40;
        exhaustProjectile2.projectile.pierce = 9999;
        exhaustProjectile2.projectile.GetDamageModel().damage = 1;
        exhaustProjectile2.projectile.GetDamageModel().createPopEffect = true;
        exhaustProjectile2.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        exhaustProjectile2.projectile.GetBehavior<AgeModel>().Lifespan = 0.2f;
        exhaustProjectile1.projectile.AddBehavior(exhaustProjectile2);

        var exhaustProjectile3 = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        exhaustProjectile3.projectile.ApplyDisplay<QuakeStage3>();
        exhaustProjectile3.projectile.radius = 50;
        exhaustProjectile3.projectile.pierce = 9999;
        exhaustProjectile3.projectile.GetDamageModel().damage = 2;
        exhaustProjectile3.projectile.GetDamageModel().createPopEffect = true;
        exhaustProjectile3.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        exhaustProjectile3.projectile.GetBehavior<AgeModel>().Lifespan = 0.7f;
        exhaustProjectile3.projectile.AddBehavior(new ClearHitBloonsModel("", 0.4f));
        exhaustProjectile2.projectile.AddBehavior(exhaustProjectile3);

        wpn.weapons[0].Rate = 2.7f;
        wpn.weapons[0].emission = new SingleEmmisionTowardsTargetModel("SingleEmmisionTowardsTargetModel_", null, 0);
        wpn.weapons[0].AddBehavior(speedInRange);
        wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.maxPierce = 1;
        wpn.weapons[0].projectile.scale *= 2;
        wpn.weapons[0].projectile.ignoreBlockers = true;
        wpn.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.15f;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 50f;
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(exhaustProjectile1);
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.3f));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class Geomancer : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Geomancer";
    public override string CodeName => "Geomancer";
    public override Sprite CustomIcon => GetSprite("GeomancerIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-100").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var bomb = Game.instance.model.GetTowerFromId("BombShooter-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        var effect = Game.instance.model.GetTowerFromId("BombShooter-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        effect.effectModel.ApplyDisplay<RockImpact>();

        var tracking = Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate();
        var speedInRange = Game.instance.model.GetTowerFromId("Rosalia 4").GetAttackModel().weapons[0].GetBehavior<BloonsInRangeAttackSpeedModel>().Duplicate();
        speedInRange.rateIncreasePerStack = 0.05f;

        wpn.weapons[0].Rate = 1.85f;
        wpn.weapons[0].emission = new RandomEmissionModel("randomEmmisionTowardsTargetModel_", 1, 100f, 50f, null, false, 0.0f, 0.0f, 0.0f, true);
        wpn.weapons[0].AddBehavior(speedInRange);
        wpn.weapons[0].AddBehavior(new BurstWeaponBehaviorModel("", 0.05f, 5, false));
        wpn.weapons[0].projectile.ApplyDisplay<Rock>();
        wpn.weapons[0].projectile.pierce = 7;
        wpn.weapons[0].projectile.scale /= 3.6f;
        wpn.weapons[0].projectile.GetDamageModel().damage = 4;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 99999;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 2;
        wpn.weapons[0].projectile.AddBehavior(bomb);
        wpn.weapons[0].projectile.AddBehavior(effect);
        wpn.weapons[0].projectile.AddBehavior(tracking);
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1f, 4f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1f, 18f, false, true, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1f, 18f, false, true, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1f, 18f, false, true, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class NeoBladesurge : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Neo Bladesurge";
    public override string CodeName => "NeoBladesurge";
    public override Sprite CustomIcon => GetSprite("NeoBladesurgeIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartMonkey-100").GetAttackModel().Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("DartMonkey-200").GetAttackModel().Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 9999;

        var tracking = Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate();
        tracking.Lifespan = 9999;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 3;
        createProjModel.projectile.GetDamageModel().damage = 1;

        wpn1.attackThroughWalls = true;
        wpn1.weapons[0].Rate = 3.2f;
        wpn1.weapons[0].emission = new SingleEmmisionTowardsTargetModel("SingleEmmisionTowardsTargetModel_", null, 0);
        wpn1.weapons[0].projectile.ApplyDisplay<PsychoDartProj>();
        wpn1.weapons[0].projectile.pierce = 8;
        wpn1.weapons[0].projectile.scale *= 2;
        wpn1.weapons[0].projectile.ignoreBlockers = true;
        wpn1.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 9999f;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 2;
        wpn1.weapons[0].projectile.AddBehavior(ageModel);
        wpn1.weapons[0].projectile.AddBehavior(tracking);
        wpn1.weapons[0].projectile.AddBehavior(createProjModel);
        wpn1.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.3f));
        wpn1.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        wpn2.weapons[0].Rate = 0.35f;
        wpn2.weapons[0].projectile.ApplyDisplay<Knife>();
        wpn2.weapons[0].projectile.pierce = 4;
        wpn2.weapons[0].projectile.scale += 1.1f;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 3;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 99;
        wpn2.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceram", "Ceramic", 3f, 1f, false, false, false));
        wpn2.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1f, 2f, false, true, false));
        wpn2.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1f, 3f, false, true, false));
        wpn2.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1f, 3f, false, true, false));
        wpn2.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        wpn3.weapons[0].Rate = 3;
        wpn3.weapons[0].projectile.ApplyDisplay<Sword>();
        wpn3.weapons[0].projectile.pierce = 999;
        wpn3.weapons[0].projectile.radius *= 3;
        wpn3.weapons[0].projectile.scale += 1.05f;
        wpn3.weapons[0].projectile.GetDamageModel().damage = 10;
        wpn3.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn3.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 0.7f;
        wpn3.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 50;
        wpn3.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1f, 18f, false, false, false));
        wpn3.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1f, 19f, false, true, false));
        wpn3.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1f, 23f, false, true, false));
        wpn3.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1f, 10f, false, true, false));
        wpn3.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1f, 4f, false, true, false));
        wpn3.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class SupaRiftstorm : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Supa-Riftstorm";
    public override string CodeName => "SupaRiftstorm";
    public override Sprite CustomIcon => GetSprite("SupaRiftstormIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "God Boost", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack1" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 9999;

        var tracking = Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate();
        tracking.Lifespan = 9999;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 3;
        createProjModel.projectile.GetDamageModel().damage = 1;

        wpn.weapons[0].projectile.ApplyDisplay<RiftDart>();
        wpn.weapons[0].projectile.pierce = 2;
        wpn.weapons[0].projectile.maxPierce = 2;
        wpn.weapons[0].projectile.scale *= 2;
        wpn.weapons[0].projectile.ignoreBlockers = true;
        wpn.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 9999f;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 2;
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(tracking);
        wpn.weapons[0].projectile.AddBehavior(createProjModel);
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 1f));
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);

        var projectile = Game.instance.model.GetTowerFromId("Druid-500").GetAttackModel().weapons[2].projectile.GetBehavior<CreateProjectileOnIntervalModel>().projectile.Duplicate();
        var orbitModel1 = Game.instance.model.GetTowerFromId("BoomerangMonkey-500").GetBehavior<OrbitModel>().Duplicate();
        orbitModel1.name = "Orbit1" + WeaponRarity + CodeName;
        orbitModel1.range = 22.5f;
        orbitModel1.count = 2;
        orbitModel1.projectile = projectile;
        orbitModel1.projectile.ApplyDisplay<Rift>();
        orbitModel1.projectile.scale = 0.75f;
        orbitModel1.projectile.pierce = 999999;
        orbitModel1.projectile.maxPierce = 999999;
        orbitModel1.projectile.ignorePierceExhaustion = true;
        orbitModel1.projectile.RemoveBehavior<RotateModel>();
        orbitModel1.projectile.RemoveBehavior<DamageModel>();
        orbitModel1.projectile.RemoveBehavior<TravelStraitModel>();
        orbitModel1.projectile.RemoveBehavior<FreezeModel>();
        orbitModel1.projectile.GetBehavior<DisplayModel>().positionOffset = new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0.0f, 0.0f, 10f);
        orbitModel1.projectile.GetBehavior<CreateProjectileOnIntervalModel>().projectile = wpn.weapons[0].projectile;
        orbitModel1.projectile.GetBehavior<CreateProjectileOnIntervalModel>().emission = Game.instance.model.GetTowerFromId("Phoenix").GetAttackModel().weapons[0].emission;
        orbitModel1.projectile.GetBehavior<CreateProjectileOnIntervalModel>().range = -145;
        orbitModel1.projectile.GetBehavior<CreateProjectileOnIntervalModel>().targetType = TargetType.first;
        orbitModel1.projectile.AddBehavior(new ClearHitBloonsModel("i", 1E-06f));
        orbitModel1.projectile.AddBehavior(new CantBeReflectedModel("c"));
        orbitModel1.projectile.AddBehavior(new DontDestroyOnContinueModel("u"));
        orbitModel1.projectile.AddBehavior(new RotateModel("p", -400f));
        orbitModel1.projectile.AddBehavior(new AgeModel("agemodel", 999999f, 99999, true, null));

        var orbitModel2 = Game.instance.model.GetTowerFromId("BoomerangMonkey-500").GetBehavior<OrbitModel>().Duplicate();
        orbitModel2.range = 0;
        orbitModel2.count = 1;
        orbitModel2.projectile.ApplyDisplay<PsychoAura>();
        orbitModel2.projectile.scale = 0.6f;
        orbitModel2.projectile.RemoveBehavior<DamageModel>();
        orbitModel2.projectile.GetBehavior<DisplayModel>().positionOffset = new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0.0f, 0.0f, 10f);

        var orbitModel3 = Game.instance.model.GetTowerFromId("BoomerangMonkey-500").GetBehavior<OrbitModel>().Duplicate();
        orbitModel3.range = 0;
        orbitModel3.count = 1;
        orbitModel3.projectile.ApplyDisplay<PsychoAura2>();
        orbitModel3.projectile.RemoveBehavior<DamageModel>();
        orbitModel3.projectile.GetBehavior<DisplayModel>().positionOffset = new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0.0f, 0.0f, 10f);

        towerModel.AddBehavior(orbitModel1);
        towerModel.AddBehavior(orbitModel2);
        towerModel.AddBehavior(orbitModel3);
        tower.UpdateRootModel(towerModel);
    }
}
public class GolemMaster : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Golem Master";
    public override string CodeName => "GolemMaster";
    public override Sprite CustomIcon => GetSprite("GolemMasterIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.GetDescendant<RotateToTargetModel>().rotateTower = false;
        wpn.weapons[0].Rate = 20;
        wpn.weapons[0].AddBehavior(new WeaponRateMinModel("", 20f));
        wpn.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        wpn.weapons[0].projectile.ApplyDisplay<blankdisplay.BlankDisplay>();
        wpn.weapons[0].projectile.AddBehavior(new CreateTowerModel("golemspawn", GetTowerModel<GolemTower>().Duplicate(), 0.0f, true, true, false, true, true));

        WeaponMethods.AfterEffects(wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower.GetAttackModel(), gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Displays ####

// Dart
public class PsychoDartProj : ModDisplay2D
{
    protected override string TextureName => "PsychoDart";
}

// Neo Bladesurge
public class Knife : ModDisplay
{
    public override string BaseDisplay => "8e1a5d16efbcbca468a121a8e4e574ec";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startColor = new Color(0.9137255f, 0.0235294122f, 1f);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).endColor = new Color(0.7137255f, 0.003921569f, 1f);
    }
}
public class Sword : ModDisplay
{
    public override string BaseDisplay => "f54fbbae11116a04dafbcde24ff646d8";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startColor = new Color(0.7137255f, 0.003921569f, 1f);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).endColor = new Color(0.7137255f, 0.003921569f, 1f);
    }
}

// Supa-Rift Storm
public class RiftDart : ModDisplay
{
    public override string BaseDisplay => "f54fbbae11116a04dafbcde24ff646d8";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startWidth /= 3f;
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startColor = new Color(0.9372549f, 0.7607843f, 0.9607843f);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).endColor = new Color(0.7137255f, 0.003921569f, 1f);
    }
}
public class Rift : ModDisplay
{
    public override string BaseDisplay => "229e6a36dc2ee3d42a75ca64a305e6ad";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}
public class PsychoAura : ModDisplay
{
    public Dictionary<string, Color> psColor = new Dictionary<string, Color>()
    {
      { "AbilityRadialPulse", Color.magenta },
      { "Pulse", Color.magenta },
      { "GlowPulse",  Color.magenta },
      { "DeathCloud", Color.magenta },
      { "Souls", Color.magenta }
    };

    public override string BaseDisplay => "54eb9481f9229534ca11e21ecd66ec78";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (ParticleSystem componentsInChild in (node).GetComponentsInChildren<ParticleSystem>())
        {
            if (psColor.ContainsKey((componentsInChild.gameObject).name))
                componentsInChild.startColor = psColor[componentsInChild.gameObject.name];
        }
    }
}
public class PsychoAura2 : ModDisplay
{
    public override string BaseDisplay => "12e86af1959e20a46a959673bbf077e6";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Renderer genericRenderer in (Il2CppArrayBase<Renderer>)node.genericRenderers)
            genericRenderer.material.color = new Color(0.7137255f, 0.003921569f, 1f);
    }
}

// Stick of Stone
public class QuakeStage1 : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "spikes1";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 90;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.286274523f, 0.141176477f, 0.05490196f));
        }
    }
}
public class QuakeStage2 : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "spikes2";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 90;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.286274523f, 0.141176477f, 0.05490196f));
        }
    }
}
public class QuakeStage3 : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "spikes3";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 90;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.286274523f, 0.141176477f, 0.05490196f));
        }
    }
}

// Geomancer
public class Rock : ModDisplay2D
{
    protected override string TextureName => "Rock";
}
public class RockImpact : ModDisplay
{
    public override string BaseDisplay => "f5ecd5c90fb5d0240aaa7b75c980dffe";
}

// Golem Master
public class Golem : ModCustomDisplay
{
    public override string AssetBundleName => "psychobotpath";
    public override string PrefabName => "golem";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 166;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.152941182f, 0.129411772f, 0.117647059f));
        }
    }
}
public class GolemSlam1 : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}
public class GolemSlam2 : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}
public class GolemSlam3 : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}

public class GolemTower : ModSubTower
{
    public override TowerSet TowerSet => TowerSet.Primary;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 0;
    public override string DisplayName => "Monkey Golem";
    public override string Name => "PsychomonkeyGolem";
    public override string Portrait => "Golem-Portrait";
    public override string Description => " ";
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.ApplyDisplay<Golem>();
        towerModel.range = 115;
        towerModel.showBuffs = false;
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 15f, 9, true, false));
        towerModel.AddBehavior(new OverrideCamoDetectionModel("CamoDetect", true));
        towerModel.AddBehavior(new CreditPopsToParentTowerModel("DamageForMainTower"));

        var createExhaustModel3 = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel3.projectile.ApplyDisplay<GolemSlam3>();
        createExhaustModel3.projectile.radius = 100;
        createExhaustModel3.projectile.scale *= 2;
        createExhaustModel3.projectile.pierce = 9999;
        createExhaustModel3.projectile.maxPierce = 9999;
        createExhaustModel3.projectile.GetDamageModel().damage = 100;
        createExhaustModel3.projectile.GetDamageModel().createPopEffect = true;
        createExhaustModel3.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createExhaustModel3.projectile.GetBehavior<AgeModel>().Lifespan = 0.7f;
        createExhaustModel3.projectile.AddBehavior(new DamageModifierForTagModel("Moabsdmgbad3", "Bad", 7f, 1f, false, false, false));
        createExhaustModel3.projectile.AddBehavior(new DamageModifierForTagModel("Moabsdmg3", "Moabs", 5f, 1f, false, false, false));

        var createExhaustModel2 = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel2.projectile.ApplyDisplay<GolemSlam2>();
        createExhaustModel2.projectile.radius = 75;
        createExhaustModel2.projectile.scale *= 2;
        createExhaustModel2.projectile.pierce = 9999;
        createExhaustModel2.projectile.maxPierce = 9999;
        createExhaustModel2.projectile.GetDamageModel().damage = 100;
        createExhaustModel2.projectile.GetDamageModel().createPopEffect = true;
        createExhaustModel2.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createExhaustModel2.projectile.GetBehavior<AgeModel>().Lifespan = 0.2f;
        createExhaustModel2.projectile.AddBehavior(createExhaustModel3);
        createExhaustModel2.projectile.AddBehavior(new DamageModifierForTagModel("Moabsdmgbad3", "Bad", 7f, 1f, false, false, false));
        createExhaustModel2.projectile.AddBehavior(new DamageModifierForTagModel("Moabsdmg3", "Moabs", 5f, 1f, false, false, false));

        var createExhaustModel1 = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel1.projectile.ApplyDisplay<GolemSlam1>();
        createExhaustModel1.projectile.radius = 50;
        createExhaustModel1.projectile.scale *= 2;
        createExhaustModel1.projectile.pierce = 9999;
        createExhaustModel1.projectile.maxPierce = 9999;
        createExhaustModel1.projectile.GetDamageModel().damage = 100;
        createExhaustModel1.projectile.GetDamageModel().createPopEffect = true;
        createExhaustModel1.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createExhaustModel1.projectile.GetBehavior<AgeModel>().Lifespan = 0.2f;
        createExhaustModel1.projectile.AddBehavior(createExhaustModel2);
        createExhaustModel1.projectile.AddBehavior(new DamageModifierForTagModel("Moabsdmgbad3", "Bad", 7f, 1f, false, false, false));
        createExhaustModel1.projectile.AddBehavior(new DamageModifierForTagModel("Moabsdmg3", "Moabs", 5f, 1f, false, false, false));

        towerModel.GetAttackModel().range = 115;
        towerModel.GetAttackModel().weapons[0].Rate = 2.6f;
        towerModel.GetAttackModel().weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 999;
        towerModel.GetAttackModel().weapons[0].projectile.maxPierce = 999;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 50;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.55f;
        towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(createExhaustModel1);
    }
}
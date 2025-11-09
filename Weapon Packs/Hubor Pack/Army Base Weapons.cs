using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using AncientMonkey;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity.Display;
using System.Collections.Generic;

namespace WeaponPacks;

// #### Common ####

public class ArmyBase : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Army Base";
    public override string CodeName => "ArmyBase";
    public override Sprite CustomIcon => GetSprite("ArmyBaseIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<Soldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 1;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Frozen | BloonProperties.Lead;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddFilter(new FilterOutBloonModel("leadpopping", "Lead"));
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class LongShots : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Long Shots";
    public override string CodeName => "LongShots";
    public override Sprite CustomIcon => GetSprite("LongShotsIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.pierce += 1;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 999;

        var createIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", projectile, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 75, true, -160f, TargetType.First, false, false, false, null);

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<Soldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 1;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Frozen | BloonProperties.Lead;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddFilter(new FilterOutBloonModel("leadpopping", "Lead"));
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(createIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BallisticShield : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Ballistic Shield";
    public override string CodeName => "BallisticShield";
    public override Sprite CustomIcon => GetSprite("BallisticShieldIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        // Soldier without Shield
        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var soldier = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).weapons[0].projectile.Duplicate();
        soldier.ApplyDisplay<NoShieldSoldier>();
        soldier.name = "AttackModel_Summon3_";
        soldier.pierce = 99999;
        soldier.hasDamageModifiers = true;
        soldier.GetDamageModel().damage = 1;
        soldier.GetDamageModel().immuneBloonProperties = BloonProperties.Frozen | BloonProperties.Lead;
        soldier.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        soldier.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        soldier.RemoveBehavior<CreateEffectOnExhaustedModel>();
        soldier.AddFilter(new FilterOutBloonModel("leadpopping", "Lead"));
        soldier.AddBehavior(ageModel);
        soldier.AddBehavior(new CantBeReflectedModel(""));
        soldier.AddBehavior(new ClearHitBloonsModel("", 2f));
        soldier.AddBehavior(new DontDestroyOnContinueModel(""));

        // Vest Shrapnel
        var dart = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        dart.pierce = 2;
        dart.display = new PrefabReference() { guidRef = "4f037aa86b2789a448901265ade0bff4" };

        var createDartModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createDartModel.emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0.0f, 360f, null, false, false);
        createDartModel.projectile = dart;

        // Shield Pop
        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter-002").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<ShieldPop>();

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile = soldier;

        var createExhaustModel = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel.fraction = 1;
        createExhaustModel.projectile.pierce = 1;
        createExhaustModel.projectile.maxPierce = 1;
        createExhaustModel.projectile.radius = 99;
        createExhaustModel.projectile.RemoveBehavior<DamageModel>();
        createExhaustModel.projectile.AddBehavior(createEffectModel);
        createExhaustModel.projectile.AddBehavior(createProjModel);
        createExhaustModel.projectile.AddBehavior(createDartModel);
        createExhaustModel.projectile.SetHitCamo(true);

        // Soldier with Shield
        var windModel = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel.distanceMax = 9;
        windModel.distanceMin = 8;
        windModel.speedMultiplier = 3;
        windModel.chance = 1;

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<ShieldSoldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 50;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 2;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(windModel);
        wpn.weapons[0].projectile.AddBehavior(createExhaustModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.1f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class DirtBike : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Dirt Bike";
    public override string CodeName => "DirtBike";
    public override Sprite CustomIcon => GetSprite("DirtBikeIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        wpn.weapons[0].Rate = 3f;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<DirtBikeSoldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 3;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speed *= 2.88f;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1f, 8f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1f, 8f, false, false, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GrenadeLauncher : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Grenade Launcher";
    public override string CodeName => "GrenadeLauncher";
    public override Sprite CustomIcon => GetSprite("GrenadeLauncherIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter-002").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius += 15;
        createProjModel.projectile.pierce = 999;
        createProjModel.projectile.GetDamageModel().damage = 4;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Black;

        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.ApplyDisplay<Grenade>();
        projectile.pierce = 1;
        projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Black;
        projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 999;
        projectile.AddBehavior(createEffectModel);
        projectile.AddBehavior(createProjModel);

        var createIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", projectile, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 65, true, -160f, TargetType.First, false, false, false, null);

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<DemomanSoldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 1;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(createIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class RoadHog : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Road Hog";
    public override string CodeName => "RoadHog";
    public override Sprite CustomIcon => GetSprite("RoadHogIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        wpn.weapons[0].Rate = 2f;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<RoadHogSoldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 9;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speed *= 5.76f;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1f, 8f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic", 1f, 8f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("bloonariusdmg", "Boss", 3f, 15f, false, true, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("airshipdmg", "Moabs", 2f, 0.0f, false, true, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class TankCommander : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Tank Commander";
    public override string CodeName => "TankCommander";
    public override Sprite CustomIcon => GetSprite("TankCommanderIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter-002").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.scale *= 2;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 35;
        createProjModel.projectile.pierce = 999;
        createProjModel.projectile.GetDamageModel().damage = 10;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Black;
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("moabdmg", "Moabs", 6f, 0.0f, false, true, false));
        createProjModel.projectile.SetHitCamo(true);

        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.ApplyDisplay<TankMissile>();
        projectile.pierce = 1;
        projectile.scale *= 2.1f;
        projectile.GetDamageModel().damage = 10;
        projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Black;
        projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 999;
        projectile.AddBehavior(createEffectModel);
        projectile.AddBehavior(createProjModel);

        var createIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", projectile, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 55, true, -250f, TargetType.Strong, false, false, false, null);

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<TankSoldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 1;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(createIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PatrolJeep : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Patrol Jeep";
    public override string CodeName => "PatrolJeep";
    public override Sprite CustomIcon => GetSprite("PatrolJeepIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        // Soldier without Shield
        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var soldier = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).weapons[0].projectile.Duplicate();
        soldier.ApplyDisplay<NoShieldSoldier>();
        soldier.name = "AttackModel_Summon3_";
        soldier.pierce = 99999;
        soldier.hasDamageModifiers = true;
        soldier.GetDamageModel().damage = 1;
        soldier.GetDamageModel().immuneBloonProperties = BloonProperties.Frozen | BloonProperties.Lead;
        soldier.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        soldier.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        soldier.RemoveBehavior<CreateEffectOnExhaustedModel>();
        soldier.AddFilter(new FilterOutBloonModel("leadpopping", "Lead"));
        soldier.AddBehavior(ageModel);
        soldier.AddBehavior(new CantBeReflectedModel(""));
        soldier.AddBehavior(new ClearHitBloonsModel("", 2f));
        soldier.AddBehavior(new DontDestroyOnContinueModel(""));

        // Vest Shrapnel
        var dart = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        dart.radius = 30;
        dart.pierce = 9999;
        dart.display = new PrefabReference() { guidRef = "" };
        dart.GetDamageModel().damage = 2;

        var createDartModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createDartModel.emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0.0f, 360f, null, false, false);
        createDartModel.projectile = dart;

        // Shield Pop
        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter-400").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile = soldier;

        var createExhaustModel = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel.fraction = 1;
        createExhaustModel.projectile.pierce = 1;
        createExhaustModel.projectile.maxPierce = 1;
        createExhaustModel.projectile.radius = 99;
        createExhaustModel.projectile.RemoveBehavior<DamageModel>();
        createExhaustModel.projectile.AddBehavior(createEffectModel);
        createExhaustModel.projectile.AddBehavior(createProjModel);
        createExhaustModel.projectile.AddBehavior(createDartModel);
        createExhaustModel.projectile.SetHitCamo(true);

        // Soldier with Shield
        var windModel = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel.distanceMax = 9;
        windModel.distanceMin = 8;
        windModel.speedMultiplier = 3;
        windModel.chance = 1;

        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.pierce = 4;
        projectile.GetDamageModel().damage = 3;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 999;

        var createIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", projectile, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 15, true, -180f, TargetType.First, false, false, false, null);

        var shockwave = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        shockwave.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<JeepGunner>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 150;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 2;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(windModel);
        wpn.weapons[0].projectile.AddBehavior(createExhaustModel);
        wpn.weapons[0].projectile.AddBehavior(createIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(shockwave);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.0f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("blimpdmg", "Moab", 1f, 1f, false, true, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramdmg", "Ceramic", 2f, 0.0f, false, false, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class MechaCommander : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Mecha Commander";
    public override string CodeName => "MechaCommander";
    public override Sprite CustomIcon => GetSprite("MechaCommander");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter-400").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 35;
        createProjModel.projectile.pierce = 999;
        createProjModel.projectile.GetDamageModel().damage = 25;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("moabdmg", "Moabs", 6f, 0.0f, false, true, false));
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 1f, 15f, false, true, false));
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("Boss", "Boss", 4f, 20f, false, true, false));
        createProjModel.projectile.SetHitCamo(true);

        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.ApplyDisplay<MechaMissile>();
        projectile.pierce = 1;
        projectile.scale = 1.6f;
        projectile.GetDamageModel().damage = 25;
        projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 999;
        projectile.AddBehavior(createEffectModel);
        projectile.AddBehavior(createProjModel);

        var createIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", projectile, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 55, true, -9999f, TargetType.Strong, false, false, false, null);

        wpn.weapons[0].Rate = 18;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<MechaSoldier>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.pierce = 99999;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 1;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(createIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 2f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 2f, 10f, false, true, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class ArmoredBattalion : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Armored Battalion Popvoy";
    public override string CodeName => "ArmoredBattalion";
    public override Sprite CustomIcon => GetSprite("ArmoredBatalionIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Spawns soldiers that travel along the track.\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = 1000;

        // Soldier without Shield
        var ageModel = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().weapons[0].projectile.GetBehavior<AgeModel>().Duplicate();
        ageModel.Lifespan = 999999;
        ageModel.rounds = 999;

        var windModel1 = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel1.distanceMax = 8f;
        windModel1.distanceMin = 8f;
        windModel1.speedMultiplier = 3f;
        windModel1.chance = 1f;

        var windModel2 = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate();
        windModel2.distanceMax = 3f;
        windModel2.distanceMin = 3f;
        windModel2.speedMultiplier = 5f;
        windModel2.affectMoab = true;
        windModel2.chance = 1f;

        var soldier = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).weapons[0].projectile.Duplicate();
        soldier.ApplyDisplay<UnarmoredSoldier>();
        soldier.name = "AttackModel_Summon3_";
        soldier.pierce = 99999;
        soldier.radius *= 6;
        soldier.hasDamageModifiers = true;
        soldier.GetDamageModel().damage = 75;
        soldier.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        soldier.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        soldier.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        soldier.RemoveBehavior<CreateEffectOnExhaustedModel>();
        soldier.AddFilter(new FilterOutBloonModel("leadpopping", "Lead"));
        soldier.AddBehavior(ageModel);
        soldier.AddBehavior(windModel1);
        soldier.AddBehavior(windModel2);
        soldier.AddBehavior(new CantBeReflectedModel(""));
        soldier.AddBehavior(new ClearHitBloonsModel("", 2f));
        soldier.AddBehavior(new DontDestroyOnContinueModel(""));
        soldier.AddBehavior(new DamageModifierForTagModel("blimps", "Moabs", 10f, 1f, false, true, false));
        soldier.AddBehavior(new DamageModifierForTagModel("booss", "Boss", 30f, 1f, false, true, false));

        // Vest Shrapnel
        var dart = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        dart.radius = 60;
        dart.pierce = 9999;
        dart.display = new PrefabReference() { guidRef = "" };
        dart.GetDamageModel().damage = 10;

        var createDartModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createDartModel.emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0.0f, 360f, null, false, false);
        createDartModel.projectile = dart;

        // Shield Pop
        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter-400").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<ReinforcementPop>();
        createEffectModel.effectModel.lifespan = 0.2f;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile = soldier;

        var createExhaustModel = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().Duplicate();
        createExhaustModel.fraction = 1;
        createExhaustModel.projectile.pierce = 1;
        createExhaustModel.projectile.maxPierce = 1;
        createExhaustModel.projectile.radius = 99;
        createExhaustModel.projectile.RemoveBehavior<DamageModel>();
        createExhaustModel.projectile.AddBehavior(createEffectModel);
        createExhaustModel.projectile.AddBehavior(createProjModel);
        createExhaustModel.projectile.AddBehavior(createDartModel);
        createExhaustModel.projectile.SetHitCamo(true);

        // Soldier with Shield
        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.pierce = 4;
        projectile.GetDamageModel().damage = 3;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 999;

        var createIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", projectile, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 10, true, -290f, TargetType.First, false, false, false, null);

        var spikes = Game.instance.model.GetTowerFromId("DartMonkey-002").GetAttackModel().weapons[0].projectile.Duplicate();
        spikes.ApplyDisplay<SpikeProj>();
        spikes.pierce = 50;
        spikes.GetDamageModel().damage = 2;
        spikes.GetBehavior<TravelStraitModel>().Speed = 1E-05f;
        spikes.GetBehavior<TravelStraitModel>().Lifespan = 999;
        spikes.AddBehavior(new DamageModifierForTagModel("ceramdmg", "Ceramic", 3f, 0.0f, false, false, false));
        spikes.AddBehavior(new ClearHitBloonsModel("", 0.0f));

        var createSpikeIntervalModel = new CreateProjectileOnIntervalModel
            ("Dart", spikes, new SingleEmmisionTowardsTargetModel("singleEmission", null, 0.0f), 100, true, -999f, TargetType.First, false, false, false, null);

        var shockwave = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        shockwave.projectile.GetDamageModel().damage = 5;
        shockwave.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        wpn.weapons[0].Rate = 24;
        wpn.weapons[0].emission = new NecromancerEmissionModel("BaseDeploy_", 1, 1, 1, 1, 1, 1, 0, null, null, null, -1, -1, -1, -1, 1);
        wpn.weapons[0].projectile.ApplyDisplay<ArmoredGunner>();
        wpn.weapons[0].projectile.name = "AttackModel_Summon3_";
        wpn.weapons[0].projectile.radius *= 6;
        wpn.weapons[0].projectile.pierce = 400;
        wpn.weapons[0].projectile.hasDamageModifiers = true;
        wpn.weapons[0].projectile.GetDamageModel().damage = 10;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 999999;
        wpn.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        wpn.weapons[0].projectile.AddBehavior(ageModel);
        wpn.weapons[0].projectile.AddBehavior(windModel1);
        wpn.weapons[0].projectile.AddBehavior(windModel2);
        wpn.weapons[0].projectile.AddBehavior(createExhaustModel);
        wpn.weapons[0].projectile.AddBehavior(createSpikeIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(createIntervalModel);
        wpn.weapons[0].projectile.AddBehavior(shockwave);
        wpn.weapons[0].projectile.AddBehavior(new CantBeReflectedModel(""));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.0f));
        wpn.weapons[0].projectile.AddBehavior(new DontDestroyOnContinueModel(""));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("blimpdmg", "Moab", 2f, 1f, false, true, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramdmg", "Ceramic", 2f, 0.0f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("bossesdamage", "Boss", 20f, 1f, false, true, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Displays ####

// Army Base / Long Shots
public class Soldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "soldierbase";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 70;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.0f, 0.3137255f, 0.0f));
        }
    }
}

// Dirt Bikes
public class DirtBikeSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "dirtbike";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 86;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.298039228f, 0.203921571f, 0.129411772f));
        }
    }
}

// Road Hogs
public class RoadHogSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "roadhog";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 86;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}

// Grenade Launcher
public class DemomanSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "grenadier";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 72;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.0f, 0.3137255f, 0.0f));
        }
    }
}
public class Grenade : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}

// Tank Commander
public class TankSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "czolg";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 68;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.06666667f, 0.09411765f, 0.05490196f));
        }
    }
}
public class TankMissile : ModDisplay
{
    public override string BaseDisplay => "8e0d78b06dad4ad4194549b307dc758c";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}

// Mecha Commander
public class MechaSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "mecha";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 57;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}
public class MechaMissile : ModDisplay
{
    public override string BaseDisplay => "a87f54abeb22ec8499d3af0af45a0944";
    public override void ModifyDisplayNode(UnityDisplayNode node) => SetMeshTexture(node, Name);
}

// Ballistic Shield
public class ShieldSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "003";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 70;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}
public class NoShieldSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "003noshield";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 70;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}
public class ShieldPop : ModDisplay
{
    public override string BaseDisplay => "6d84b13b7622d2744b8e8369565bc058";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        RendererExt.SetMainTexture(((Il2CppArrayBase<Renderer>)node.genericRenderers)[0], GetTexture("Void"));
        RendererExt.SetMainTexture(((Il2CppArrayBase<Renderer>)node.genericRenderers)[3], GetTexture("Void"));
        RendererExt.SetMainTexture(((Il2CppArrayBase<Renderer>)node.genericRenderers)[2], GetTexture("Shield"));
        RendererExt.SetMainTexture(((Il2CppArrayBase<Renderer>)node.genericRenderers)[1], GetTexture("Void"));
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[2].GetComponent<ParticleSystem>().maxParticles = 1;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[2].GetComponent<ParticleSystem>().startSize *= 9f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[2].GetComponent<ParticleSystem>().startColor = Color.white;
        Transform transform = ((Il2CppArrayBase<Renderer>)node.genericRenderers)[2].transform;
        transform.localScale *= 2.5f;
    }
}

// Patrol Jeep
public class JeepGunner : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "jeepgunner";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 67;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}

// Armored Battalion Popvoy
public class ArmoredGunner : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "abpgunner";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 41;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}
public class UnarmoredSoldier : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "abpunarmored";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 41;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.129411772f, 0.129411772f, 0.129411772f));
        }
    }
}
public class ReinforcementPop : ModDisplay
{
    public Dictionary<string, Color> psColor = new Dictionary<string, Color>()
    {
      { "RadialBlast", Color.white },
      { "PowerPulse", Color.grey },
      { "SolidRadialRings", Color.white }
    };
    public override string BaseDisplay => "373bb6317fec0364b89c6cb1db619672";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (ParticleSystem componentsInChild in node.GetComponentsInChildren<ParticleSystem>())
        {
            if (psColor.ContainsKey(componentsInChild.gameObject.name))
                componentsInChild.startColor = psColor[componentsInChild.gameObject.name];
        }
    }
}
public class SpikeProj : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}
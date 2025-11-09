using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using AncientMonkey;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Unity.Display.Animation;
using Il2CppSystem.Collections.Generic;

namespace WeaponPacks;

// #### Common ####

// #### Rare ####

public class SpaceCadet : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Space Cadet";
    public override string CodeName => "SpaceCadet";
    public override Sprite CustomIcon => GetSprite("SpaceCadetIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BallOfLightTower").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.weapons[0].Rate *= 1.5f;
        wpn.weapons[0].animation = 0;
        wpn.weapons[0].animateOnMainAttack = false;
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.maxPierce = 1;
        wpn.weapons[0].projectile.GetDamageModel().damage = 2;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)9;
        wpn.weapons[0].projectile.GetBehavior<DisplayModel>().positionOffset = new Il2CppAssets.Scripts.Simulation.SMath.Vector3(0.0f, 0.0f, 500f);
        wpn.weapons[0].projectile.RemoveBehavior<DamageModifierForTagModel>();

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class TeslaStrike : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Tesla Strike";
    public override string CodeName => "TeslaStrike";
    public override Sprite CustomIcon => GetSprite("TeslaStrikeIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Stronger Compound", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-030").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var shock = Game.instance.model.GetTowerFromId("IceMonkey-004").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().
            projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
        shock.mutationId = "electricshock";
        shock.name = "voltage";
        shock.ApplyOverlay<ElectroOverlay>();

        var slow = Game.instance.model.GetTowerFromId("BombShooter-400").GetAttackModel().weapons[0].projectile.
            GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<SlowModel>().Duplicate();
        slow.Lifespan = 0.12f;

        wpn.RemoveBehavior<RotateToPointerModel>();
        wpn.weapons[0].Rate = 4.1f;
        wpn.weapons[0].animation = 0;
        wpn.weapons[0].animateOnMainAttack = false;
        wpn.weapons[0].RemoveBehavior<EjectEffectModel>();
        wpn.weapons[0].projectile.ApplyDisplay<Target>();
        wpn.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustFractionModel>();
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.collisionPasses = new int[] { -1, 0, 1 };
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.pierce = 9999;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().damage = 12;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.AddBehavior(shock);
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.AddBehavior(slow);
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.AddBehavior(new DamageModifierForTagModel("Moabsbd", "Moabs", 3f, 15f, false, false, false));
        wpn.weapons[0].projectile.GetBehavior<CreateEffectOnExpireModel>().assetId = Game.instance.model.GetTowerFromId("BattleCat").GetAbility().GetBehavior<CreateEffectOnAbilityModel>().effectModel.assetId;
        wpn.weapons[0].projectile.AddBehavior(new RotateModel("targetspin", -300f));
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class AsteroidCleaner : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Asteroid Cleaner";
    public override string CodeName => "AsteroidCleaner";
    public override Sprite CustomIcon => GetSprite("AsteroidCleaner-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var retarget = Game.instance.model.GetTowerFromId("BoomerangMonkey-400").GetAttackModel().weapons[0].projectile.GetBehavior<RetargetOnContactModel>().Duplicate();
        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<AsteroidCrack>();
        createEffectModel.effectModel.scale = 0.8f;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 10;
        createProjModel.projectile.pierce = 9999;
        createProjModel.projectile.maxPierce = 9999;
        createProjModel.projectile.GetDamageModel().damage = 5;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        createProjModel.projectile.RemoveBehavior<DamageModifierForTagModel>();
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("2137damage", "Moab", 4f, 1f, false, false, false));
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("ceramiki", "Ceramic", 2f, 1f, false, false, false));

        wpn.weapons[0].Rate = 0.3f;
        wpn.weapons[0].projectile.ApplyDisplay<Asteroid>();
        wpn.weapons[0].projectile.scale = 0.9f;
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.maxPierce = 1;
        wpn.weapons[0].projectile.GetDamageModel().damage = 5;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 1000;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("2115damage", "Moab", 2f, 1f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceramiki2", "Ceramic", 1f, 1f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(createEffectModel);
        wpn.weapons[0].projectile.AddBehavior(createProjModel);
        wpn.weapons[0].projectile.AddBehavior(retarget);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonCompactor : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bloon Compactor";
    public override string CodeName => "BloonCompactor";
    public override Sprite CustomIcon => GetSprite("BloonCompactorIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("PatFusty 20").GetAbility(1).GetBehavior<ActivateAttackModel>().attacks[0].Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartMonkey-100").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;

        var filterOutTagModel = new FilterOutTagModel("FilterOutTagModel_ProjectileSqueeze", "Moabs", new Il2CppStringArray(0L));
        var filterInvisibleModel = new FilterInvisibleModel("FilterInvisibleModel_", true, false);
        var filters = new FilterModel[] { filterOutTagModel, filterInvisibleModel };

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>();
        createEffectModel.effectModel.ApplyDisplay<HeavyDuty>();

        var removeModel = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
        removeModel.cleanseCamo = false;
        removeModel.cleanseRegen = true;

        var rebound = Game.instance.model.GetTowerFromId("DartMonkey-300").GetAttackModel().weapons[0].projectile.GetBehavior<ProjectileBlockerCollisionReboundModel>().Duplicate();
        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        var addBehavior = Game.instance.model.GetTowerFromId("IceMonkey-004").GetAttackModel().weapons[0].projectile.
            GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
        addBehavior.mutationId = "Ice:Icicles";

        wpn.GetBehavior<AttackFilterModel>().filters = filters;
        wpn.GetBehavior<TargetStrongModel>().isSelectable = true;
        wpn.AddBehavior(new TargetFirstModel("TargetFirstModel_", true, false));
        wpn.weapons[0].Rate = 3;
        wpn.weapons[0].projectile.radius *= 5;
        wpn.weapons[0].projectile.pierce = 33;
        wpn.weapons[0].projectile.filters = filters;
        wpn.weapons[0].projectile.GetDamageModel().damage = 6;
        wpn.weapons[0].projectile.GetDamageModel().maxDamage = 30;
        wpn.weapons[0].projectile.GetDamageModel().distributeToChildren = true;
        wpn.weapons[0].projectile.RemoveBehavior<CreateSoundOnDelayedCollisionModel>();
        wpn.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan = 1.5f;
        wpn.weapons[0].projectile.GetBehavior<ProjectileFilterModel>().filters = filters;
        wpn.weapons[0].projectile.AddBehavior(removeModel);
        wpn.weapons[0].projectile.AddBehavior(createEffectModel);

        wpn2.weapons[0].Rate = 7;
        wpn2.weapons[0].projectile.ApplyDisplay<RubberBlock>();
        wpn2.weapons[0].projectile.scale *= 3;
        wpn2.weapons[0].projectile.radius = 50;
        wpn2.weapons[0].projectile.pierce = 70;
        wpn2.weapons[0].projectile.maxPierce = 70;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 30;
        wpn2.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed += 2;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 6.5f;
        wpn2.weapons[0].projectile.AddBehavior(rebound);
        wpn2.weapons[0].projectile.AddBehavior(createProjModel);
        wpn2.weapons[0].projectile.AddBehavior(addBehavior);
        wpn2.weapons[0].projectile.AddBehavior(new RotateModel("targetspin", -300f));
        wpn2.weapons[0].projectile.AddBehavior(new MapBorderReboundModel("bouncer", false, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        towerModel.AddBehavior(wpn2);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class MoabFlattener : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Moab-Flattener";
    public override string CodeName => "MoabFlattener";
    public override Sprite CustomIcon => GetSprite("MoabFlattenerIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("PatFusty 20").GetAbility(1).GetBehavior<ActivateAttackModel>().attacks[0].Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartMonkey-100").GetAttackModel().Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("PatFusty 20").GetAbility(1).GetBehavior<ActivateAttackModel>().attacks[0].Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;

        var filterOutBadModel = new FilterOutTagModel("FilterOutTagModel_ProjectileSqueeze", "Bad", new Il2CppStringArray(0L));
        var filterOutZomgModel = new FilterOutTagModel("FilterOutTagModel_ProjectileSqueeze2", "Zomg", new Il2CppStringArray(0L));
        var filterInvisibleModel = new FilterInvisibleModel("FilterInvisibleModel_", true, false);
        var filters = new FilterModel[] { filterOutBadModel, filterOutZomgModel, filterInvisibleModel };

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>();
        createEffectModel.effectModel.ApplyDisplay<HeavyDuty>();

        var removeModel = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetAttackModel().weapons[0].projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
        removeModel.cleanseCamo = false;
        removeModel.cleanseRegen = true;

        var rebound = Game.instance.model.GetTowerFromId("DartMonkey-300").GetAttackModel().weapons[0].projectile.GetBehavior<ProjectileBlockerCollisionReboundModel>().Duplicate();
        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        var addBehavior = Game.instance.model.GetTowerFromId("IceMonkey-004").GetAttackModel().weapons[0].projectile.
            GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<AddBehaviorToBloonModel>().Duplicate();
        addBehavior.mutationId = "Ice:Icicles";

        var projectile = Game.instance.model.GetTowerFromId("DartMonkey-102").GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.ApplyDisplay<RubberBlock>();
        projectile.scale *= 3;
        projectile.radius = 30;
        projectile.pierce = 10;
        projectile.GetDamageModel().damage = 60;
        projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        projectile.GetBehavior<TravelStraitModel>().Lifespan = 3;
        projectile.AddBehavior(new RotateModel("targetspin", -300f));

        wpn1.GetBehavior<AttackFilterModel>().filters = filters;
        wpn1.GetBehavior<TargetStrongModel>().isSelectable = true;
        wpn1.AddBehavior(new TargetFirstModel("TargetFirstModel_", true, false));
        wpn1.weapons[0].Rate = 4.5f;
        wpn1.weapons[0].projectile.radius *= 5;
        wpn1.weapons[0].projectile.pierce = 45;
        wpn1.weapons[0].projectile.filters = filters;
        wpn1.weapons[0].projectile.GetDamageModel().damage = 40;
        wpn1.weapons[0].projectile.GetDamageModel().maxDamage = 140;
        wpn1.weapons[0].projectile.GetDamageModel().distributeToChildren = true;
        wpn1.weapons[0].projectile.RemoveBehavior<SlowModel>();
        wpn1.weapons[0].projectile.RemoveBehavior<CreateSoundOnDelayedCollisionModel>();
        wpn1.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan = 1.5f;
        wpn1.weapons[0].projectile.GetBehavior<ProjectileFilterModel>().filters = filters;
        wpn1.weapons[0].projectile.AddBehavior(removeModel);
        wpn1.weapons[0].projectile.AddBehavior(createEffectModel);

        wpn2.weapons[0].Rate = 7;
        wpn2.weapons[0].projectile.ApplyDisplay<MoabBlock>();
        wpn2.weapons[0].projectile.scale *= 3;
        wpn2.weapons[0].projectile.radius = 50;
        wpn2.weapons[0].projectile.pierce = 999;
        wpn2.weapons[0].projectile.maxPierce = 999;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 90;
        wpn2.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed += 2;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 3f;
        wpn2.weapons[0].projectile.AddBehavior(rebound);
        wpn2.weapons[0].projectile.AddBehavior(createProjModel);
        wpn2.weapons[0].projectile.AddBehavior(addBehavior);
        wpn2.weapons[0].projectile.AddBehavior(new RotateModel("targetspin", -300f));
        wpn2.weapons[0].projectile.AddBehavior(new MapBorderReboundModel("bouncer", false, false));
        wpn2.weapons[0].projectile.AddBehavior(new CreateProjectileOnExpireModel("rubbershards", projectile, new ArcEmissionModel("", 5, 0.0f, 360f, null, false, false), false, false));

        wpn3.GetBehavior<TargetStrongModel>().isSelectable = true;
        wpn3.AddBehavior(new TargetFirstModel("TargetFirstModel_", true, false));
        wpn3.weapons[0].Rate = 12.5f;
        wpn3.weapons[0].projectile.radius *= 5;
        wpn3.weapons[0].projectile.pierce = 4;
        wpn3.weapons[0].projectile.RemoveBehavior<SlowModel>();
        wpn3.weapons[0].projectile.RemoveBehavior<CreateSoundOnDelayedCollisionModel>();
        wpn3.weapons[0].projectile.GetBehavior<DelayBloonChildrenSpawningModel>().Lifespan = 5;

        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class MegaRocket : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Mega Rocket";
    public override string CodeName => "MegaRocket";
    public override Sprite CustomIcon => GetSprite("MegaRocket-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-040").GetAbility().GetBehavior<ActivateAttackModel>().attacks[0].Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.GetBehavior<TargetStrongModel>().isSelectable = true;
        wpn.AddBehavior(new TargetFirstModel("TargetFirstModel_", true, false));
        wpn.weapons[0].Rate = 5;
        wpn.weapons[0].animation = 0;
        wpn.weapons[0].animateOnMainAttack = false;
        wpn.weapons[0].GetBehavior<EjectEffectModel>().effectModel.scale *= 3.9f;
        wpn.weapons[0].projectile.scale += 2;
        wpn.weapons[0].projectile.ApplyDisplay<Target>();
        wpn.weapons[0].projectile.RemoveBehavior<DamageModel>();
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.pierce = 9034;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.maxPierce = 9050;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.GetDamageModel().damage = 1600;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.GetDamageModel().distributeToChildren = false;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.GetDamageModel().overrideDistributeBlocker = false;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Black;
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.RemoveBehavior<RemoveBloonModifiersModel>();
        wpn.weapons[0].projectile.GetBehavior<CreateProjectileOnExpireModel>().projectile.AddBehavior(new DamageModifierForTagModel("Moabsbe", "Moabs", 11f, 1f, false, false, false));
        wpn.weapons[0].projectile.GetBehavior<CreateEffectProjectileAfterTimeModel>().effectModel.scale *= 3.9f;
        wpn.weapons[0].projectile.AddBehavior(new RotateModel("targetspin", -300f));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}


// #### Displays ####

// Top Path
public class Punch : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}
public class Asteroid : ModDisplay
{
    public override string BaseDisplay => "f54fbbae11116a04dafbcde24ff646d8";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, Name);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startColor = new Color(0.63f, 0.0f, 1f, 1f);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).endColor = new Color(0.63f, 0.0f, 1f, 0.0f);
    }
}
public class AsteroidCrack : ModDisplay
{
    public override string BaseDisplay => "0dbf845c78671364ab619d96d40696a5";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Renderer genericRenderer in (Il2CppArrayBase<Renderer>)node.genericRenderers)
            genericRenderer.material.color = Color.magenta;
    }
}

// Middle Path
public class Target : ModDisplay
{
    public override string BaseDisplay => "9dccc16d26c1c8a45b129e2a8cbd17ba";
    public override void ModifyDisplayNode(UnityDisplayNode node) => Set2DTexture(node, Name);
}
public class ElectroOverlay : ModBloonOverlay
{
    public override string BaseOverlay => "LaserShock";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (Renderer genericRenderer in (Il2CppArrayBase<Renderer>)node.genericRenderers)
        {
            if (Il2CppSystemObjectExt.Is<SpriteRenderer>(genericRenderer) && node.GetComponentInChildren<CustomSpriteFrameAnimator>())
            {
                List<Sprite> list = new List<Sprite>();
                list.Add(GetSprite("Electro1", 10f));
                list.Add(GetSprite("Electro2", 10f));
                list.Add(GetSprite("Electro3", 10f));
                list.Add(GetSprite("Electro4", 10f));
                node.GetComponentInChildren<CustomSpriteFrameAnimator>().frames = list;
            }
            if (Il2CppSystemObjectExt.Is<MeshRenderer>(genericRenderer))
                RendererExt.SetMainTexture(genericRenderer, GetTexture("ElectricShock"));
        }
    }
}

// Bottom Path
public class HeavyDuty : ModDisplay
{
    public override string BaseDisplay => "f5ecd5c90fb5d0240aaa7b75c980dffe";
}
public class RubberBlock : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "projectileblock";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 17;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.286274523f, 0.141176477f, 0.05490196f));
        }
    }
}
public class MoabBlock : ModCustomDisplay
{
    public override string AssetBundleName => "ancientmonkey";
    public override string PrefabName => "gigablock";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Transform transform = node.transform.GetChild(0).transform;
        transform.localScale *= 38f;
        foreach (Renderer meshRenderer in UnityDisplayNodeExt.GetMeshRenderers(node, true))
        {
            RendererExt.ApplyOutlineShader(meshRenderer);
            RendererExt.SetOutlineColor(meshRenderer, new Color(0.286274523f, 0.141176477f, 0.05490196f));
        }
    }
}
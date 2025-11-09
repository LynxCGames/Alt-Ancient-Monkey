using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using AncientMonkey;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Display;

namespace WeaponPacks;

// #### Common ####

public class Boxer : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Boxer";
    public override string CodeName => "Boxer";
    public override Sprite CustomIcon => GetSprite("BoxerIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 2;
        createProjModel.projectile.GetDamageModel().damage = 1;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;

        wpn.weapons[0].Rate = 0.7f;
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.maxPierce = 1;
        wpn.weapons[0].projectile.radius = 3.14f;
        wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn.weapons[0].projectile.AddBehavior(createProjModel);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class WelterweightElite : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Welterweight Elite";
    public override string CodeName => "WelterweightElite";
    public override Sprite CustomIcon => GetSprite("WelterweightIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 2;
        createProjModel.projectile.GetDamageModel().damage = 1;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;

        var critText = Game.instance.model.GetTowerFromId("DartMonkey-004").GetAttackModel().weapons[0].projectile.GetBehavior<ShowTextOnHitModel>().Duplicate();
        var crit = Game.instance.model.GetTowerFromId("DartMonkey-004").GetAttackModel().weapons[0].GetBehavior<CritMultiplierModel>().Duplicate();
        crit.damage = 10;
        crit.lower = 5;
        crit.upper = 5;
        crit.displayModel.display = new PrefabReference() { guidRef = "" };

        wpn.weapons[0].Rate = 0.4f;
        wpn.weapons[0].AddBehavior(crit);
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.maxPierce = 1;
        wpn.weapons[0].projectile.radius = 3.14f;
        wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn.weapons[0].projectile.AddBehavior(createProjModel);
        wpn.weapons[0].projectile.AddBehavior(critText);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonBrawler : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Bloon Brawler";
    public override string CodeName => "BloonBrawler";
    public override Sprite CustomIcon => GetSprite("BloonBrawlerIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var spikedGloveModifier = Game.instance.model.GetTowerFromId("Sauda 11").GetAttackModel().weapons[0].projectile.GetBehavior<SaudaAfflictionDamageModifierModel>().Duplicate();
        spikedGloveModifier.lv11NonMoabBonus = 1.5f;
        spikedGloveModifier.lv7NonMoabBonus = 1.5f;
        spikedGloveModifier.lv11MoabBonus = 1.5f;
        spikedGloveModifier.lv7MoabBonus = 1.5f;

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<Slam>();

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 8;
        createProjModel.projectile.pierce *= 2;
        createProjModel.projectile.GetDamageModel().damage = 2;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;
        createProjModel.projectile.AddBehavior(spikedGloveModifier);

        var burst = Game.instance.model.GetTowerFromId("Desperado").GetAttackModel().weapons[0].GetBehavior<BurstWeaponBehaviorModel>().Duplicate();
        burst.count = 2;
        burst.interval = 0.15f;

        wpn.weapons[0].Rate = 0.5f;
        wpn.weapons[0].AddBehavior(burst);
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.maxPierce = 1;
        wpn.weapons[0].projectile.radius = 3.14f;
        wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn.weapons[0].projectile.GetDamageModel().damage = 3;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn.weapons[0].projectile.AddBehavior(createProjModel);
        wpn.weapons[0].projectile.AddBehavior(createEffectModel);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class Flailndao : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Flailndao";
    public override string CodeName => "Flailndao";
    public override Sprite CustomIcon => GetSprite("FlailnadoIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var spikedGloveModifier = Game.instance.model.GetTowerFromId("Sauda 11").GetAttackModel().weapons[0].projectile.GetBehavior<SaudaAfflictionDamageModifierModel>().Duplicate();
        spikedGloveModifier.lv11NonMoabBonus = 1.5f;
        spikedGloveModifier.lv7NonMoabBonus = 1.5f;
        spikedGloveModifier.lv11MoabBonus = 1.5f;
        spikedGloveModifier.lv7MoabBonus = 1.5f;

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<Bounce>();

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 8;
        createProjModel.projectile.pierce *= 4;
        createProjModel.projectile.GetDamageModel().damage = 4;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;
        createProjModel.projectile.AddBehavior(spikedGloveModifier);
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("moabic", "Moabs", 2f, 1f, false, false, false));

        var burst = Game.instance.model.GetTowerFromId("Desperado").GetAttackModel().weapons[0].GetBehavior<BurstWeaponBehaviorModel>().Duplicate();
        burst.count = 2;
        burst.interval = 0.15f;

        var retarget = Game.instance.model.GetTowerFromId("BoomerangMonkey-400").GetAttackModel().weapons[0].projectile.GetBehavior<RetargetOnContactModel>().Duplicate();
        retarget.distance = 40;

        wpn.weapons[0].Rate = 0.5f;
        wpn.weapons[0].AddBehavior(burst);
        wpn.weapons[0].projectile.pierce = 3;
        wpn.weapons[0].projectile.radius = 3.14f;
        wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn.weapons[0].projectile.GetDamageModel().damage = 4;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 300;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.25f;
        wpn.weapons[0].projectile.AddBehavior(createProjModel);
        wpn.weapons[0].projectile.AddBehavior(createEffectModel);
        wpn.weapons[0].projectile.AddBehavior(retarget);
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("moaber", "Moabs", 2f, 1f, false, false, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PrimalMonkey : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Primal Monkey";
    public override string CodeName => "PrimalMonkey";
    public override Sprite CustomIcon => GetSprite("PrimalMonkeyIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn1.name = "Attack" + WeaponRarity + CodeName;
        wpn2.name = "Attack" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;

        // Weapon 1
        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<Slam>();

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 30;
        createProjModel.projectile.pierce *= 8;
        createProjModel.projectile.GetDamageModel().damage = 2;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("moabic", "Moabs", 2f, 1f, false, false, false));

        wpn1.weapons[0].Rate = 0.7f;
        wpn1.weapons[0].projectile.pierce = 1;
        wpn1.weapons[0].projectile.maxPierce = 1;
        wpn1.weapons[0].projectile.radius = 3.14f;
        wpn1.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn1.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn1.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn1.weapons[0].projectile.AddBehavior(createProjModel);
        wpn1.weapons[0].projectile.AddBehavior(createEffectModel);

        // Weapon 2
        var createEffect2Model = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffect2Model.effectModel.ApplyDisplay<PrimalSlam>();
        createEffect2Model.effectModel.scale /= 2;

        var createProj2Model = Game.instance.model.GetTowerFromId("BombShooter-400").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProj2Model.projectile.radius = 40;
        createProj2Model.projectile.pierce = 9999;
        createProj2Model.projectile.maxPierce = 9999;
        createProj2Model.projectile.GetDamageModel().damage = 12;
        createProj2Model.projectile.GetDamageModel().createPopEffect = true;
        createProj2Model.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createProj2Model.projectile.AddBehavior(new DamageModifierForTagModel("Cerami", "Ceramic", 2f, 1f, false, false, false));
        createProj2Model.projectile.AddBehavior(new DamageModifierForTagModel("moab", "Moabs", 3f, 10f, false, false, false));

        wpn2.weapons[0].Rate = 3;
        wpn2.weapons[0].projectile.pierce = 1;
        wpn2.weapons[0].projectile.maxPierce = 1;
        wpn2.weapons[0].projectile.radius = 30.454f;
        wpn2.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn2.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn2.weapons[0].projectile.AddBehavior(createProj2Model);
        wpn2.weapons[0].projectile.AddBehavior(createEffect2Model);

        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class Atomweight : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Atomweight";
    public override string CodeName => "Atomweight";
    public override Sprite CustomIcon => GetSprite("AtomweightIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn1.name = "Attack" + WeaponRarity + CodeName;
        wpn2.name = "Attack" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;

        // Weapon 1
        var createProj1Model = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProj1Model.projectile.radius = 2;
        createProj1Model.projectile.GetDamageModel().damage = 1;
        createProj1Model.projectile.GetDamageModel().createPopEffect = true;
        createProj1Model.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;

        var critText = Game.instance.model.GetTowerFromId("DartMonkey-004").GetAttackModel().weapons[0].projectile.GetBehavior<ShowTextOnHitModel>().Duplicate();
        var crit = Game.instance.model.GetTowerFromId("DartMonkey-004").GetAttackModel().weapons[0].GetBehavior<CritMultiplierModel>().Duplicate();
        crit.damage = 10;
        crit.lower = 2;
        crit.upper = 3;
        crit.displayModel.ApplyDisplay<AtomweightCrit>();

        var tracking = Game.instance.model.GetTowerFromId("NinjaMonkey-001").GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>().Duplicate();
        tracking.distance = 80;
        tracking.maxSeekAngle = 360;

        wpn1.weapons[0].Rate = 0.05f;
        wpn1.weapons[0].emission = new RandomEmissionModel("random", 1, 1f, 30f, null, false, 0.0f, 0.0f, 0.0f, true);
        wpn1.weapons[0].AddBehavior(crit);
        wpn1.weapons[0].projectile.ApplyDisplay<AtomweightProj>();
        wpn1.weapons[0].projectile.pierce = 3;
        wpn1.weapons[0].projectile.maxPierce = 3;
        wpn1.weapons[0].projectile.radius = 3.14f;
        wpn1.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn1.weapons[0].projectile.GetDamageModel().damage = 1;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 300;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 99f;
        wpn1.weapons[0].projectile.AddBehavior(createProj1Model);
        wpn1.weapons[0].projectile.AddBehavior(critText);
        wpn1.weapons[0].projectile.AddBehavior(tracking);
        wpn1.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.2f));

        // Weapon 2
        var createProj2Model = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProj2Model.projectile.radius = 2;
        createProj2Model.projectile.GetDamageModel().damage = 20;
        createProj2Model.projectile.GetDamageModel().createPopEffect = true;
        createProj2Model.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;

        var knockoutText = Game.instance.model.GetTowerFromId("DartMonkey-004").GetAttackModel().weapons[0].projectile.GetBehavior<ShowTextOnHitModel>().Duplicate();
        knockoutText.text = "KNOCKOUT!";

        var knockout = Game.instance.model.GetTowerFromId("DartMonkey-004").GetAttackModel().weapons[0].GetBehavior<CritMultiplierModel>().Duplicate();
        knockout.damage = 10;
        knockout.lower = 2;
        knockout.upper = 3;
        knockout.displayModel.display = new PrefabReference() { guidRef = "" };

        wpn2.weapons[0].Rate = 4f;
        wpn2.weapons[0].emission = new RandomEmissionModel("random", 1, 1f, 30f, null, false, 0.0f, 0.0f, 0.0f, true);
        wpn2.weapons[0].AddBehavior(knockout);
        wpn2.weapons[0].projectile.ApplyDisplay<AtomweightProj>();
        wpn2.weapons[0].projectile.pierce = 1;
        wpn2.weapons[0].projectile.maxPierce = 1;
        wpn2.weapons[0].projectile.radius = 3.14f;
        wpn2.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 100;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 300;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 99f;
        wpn2.weapons[0].projectile.AddBehavior(createProj2Model);
        wpn2.weapons[0].projectile.AddBehavior(knockoutText);
        wpn1.weapons[0].projectile.AddBehavior(tracking);
        wpn2.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("", 0.2f));

        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        tower.UpdateRootModel(towerModel);
    }
}
public class PrimordialAncestor : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Primordial Ancestor";
    public override string CodeName => "PrimordialAncestor";
    public override Sprite CustomIcon => GetSprite("PrimordialAncestorIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn1.name = "Attack" + WeaponRarity + CodeName;
        wpn2.name = "Attack" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;

        // Weapon 1
        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<PrimalSlam>();

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter-400").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 40;
        createProjModel.projectile.pierce = 9999;
        createProjModel.projectile.maxPierce = 9999;
        createProjModel.projectile.GetDamageModel().damage = 12;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("Cerami", "Ceramic", 2f, 1f, false, false, false));
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("moabic", "Moabs", 2f, 1f, false, false, false));

        wpn1.weapons[0].Rate = 0.7f;
        wpn1.weapons[0].projectile.pierce = 1;
        wpn1.weapons[0].projectile.maxPierce = 1;
        wpn1.weapons[0].projectile.radius = 3.14f;
        wpn1.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn1.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn1.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn1.weapons[0].projectile.AddBehavior(createProjModel);
        wpn1.weapons[0].projectile.AddBehavior(createEffectModel);

        // Weapon 2
        var createEffect2Model = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffect2Model.effectModel.ApplyDisplay<PrimoSlam>();
        createEffect2Model.effectModel.scale /= 2;

        var createProj2Model = Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProj2Model.projectile.radius = 60;
        createProj2Model.projectile.pierce = 9999;
        createProj2Model.projectile.maxPierce = 9999;
        createProj2Model.projectile.GetDamageModel().damage = 35;
        createProj2Model.projectile.GetDamageModel().createPopEffect = true;
        createProj2Model.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        createProj2Model.projectile.AddBehavior(new DamageModifierForTagModel("Cerami", "Ceramic", 2f, 1f, false, false, false));
        createProj2Model.projectile.AddBehavior(new DamageModifierForTagModel("moab", "Moabs", 3f, 10f, false, false, false));

        wpn2.weapons[0].Rate = 3;
        wpn2.weapons[0].projectile.pierce = 1;
        wpn2.weapons[0].projectile.maxPierce = 1;
        wpn2.weapons[0].projectile.radius = 30.454f;
        wpn2.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn2.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 2;
        wpn2.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.05f;
        wpn2.weapons[0].projectile.AddBehavior(createProj2Model);
        wpn2.weapons[0].projectile.AddBehavior(createEffect2Model);

        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class Spopartacus : WeaponTemplate
{
    public override string WeaponPack => "HuborPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Spopartacus";
    public override string CodeName => "Spopartacus";
    public override Sprite CustomIcon => GetSprite("SpopartacusIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var spikedGloveModifier = Game.instance.model.GetTowerFromId("Sauda 11").GetAttackModel().weapons[0].projectile.GetBehavior<SaudaAfflictionDamageModifierModel>().Duplicate();
        spikedGloveModifier.lv11NonMoabBonus = 1.5f;
        spikedGloveModifier.lv7NonMoabBonus = 1.5f;
        spikedGloveModifier.lv11MoabBonus = 1.5f;
        spikedGloveModifier.lv7MoabBonus = 1.5f;

        var createEffectModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate();
        createEffectModel.effectModel.ApplyDisplay<Bounce>();

        var createProjModel = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate();
        createProjModel.projectile.radius = 8;
        createProjModel.projectile.pierce *= 8;
        createProjModel.projectile.GetDamageModel().damage = 10;
        createProjModel.projectile.GetDamageModel().createPopEffect = true;
        createProjModel.projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)17;
        createProjModel.projectile.AddBehavior(spikedGloveModifier);
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("moabic", "Moabs", 2f, 1f, false, false, false));
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("bads", "Bad", 6f, 1f, false, false, false));
        createProjModel.projectile.AddBehavior(new DamageModifierForTagModel("cerami", "Ceramic", 2f, 1f, false, false, false));

        var burst = Game.instance.model.GetTowerFromId("Desperado").GetAttackModel().weapons[0].GetBehavior<BurstWeaponBehaviorModel>().Duplicate();
        burst.count = 2;
        burst.interval = 0.15f;

        var retarget = Game.instance.model.GetTowerFromId("BoomerangMonkey-400").GetAttackModel().weapons[0].projectile.GetBehavior<RetargetOnContactModel>().Duplicate();
        retarget.distance = 40;

        wpn.weapons[0].Rate = 0.5f;
        wpn.weapons[0].AddBehavior(burst);
        wpn.weapons[0].projectile.pierce = 5;
        wpn.weapons[0].projectile.radius = 3.14f;
        wpn.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-500").GetAttackModel().weapons[0].projectile.display;
        wpn.weapons[0].projectile.GetDamageModel().damage = 25;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 300;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.25f;
        wpn.weapons[0].projectile.AddBehavior(createProjModel);
        wpn.weapons[0].projectile.AddBehavior(createEffectModel);
        wpn.weapons[0].projectile.AddBehavior(retarget);
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("moaber", "Moabs", 2f, 1f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("bads", "Bad", 6f, 1f, false, false, false));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("ceram", "Ceramic", 2f, 1f, false, false, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Displays ####

// Top Path
public class AtomweightCrit : ModDisplay
{
    public override string BaseDisplay => "8e1a5d16efbcbca468a121a8e4e574ec";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "AtomweightProj");
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).endColor = new Color(1f, 0.7529412f, 0.847058833f);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startColor = Color.cyan;
    }
}
public class AtomweightProj : ModDisplay
{
    public override string BaseDisplay => "8e1a5d16efbcbca468a121a8e4e574ec";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, ((ModContent)this).Name);
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).startColor = Color.cyan;
        UnityDisplayNodeExt.GetRenderer<TrailRenderer>(node, true).endColor = Color.white;
    }
}

// Middle Path
public class Slam : ModDisplay
{
    public override string BaseDisplay => "f5ecd5c90fb5d0240aaa7b75c980dffe";
}
public class Bounce : ModDisplay
{
    public override string BaseDisplay => "981a5d7806b304446b250c37a7ea6986";
}

// Bottom Path
public class PrimalSlam : ModDisplay
{
    public override string BaseDisplay => "a8f4820d2574d544494a26690207c720";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[0].GetComponent<ParticleSystem>().startSize /= 3f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[1].GetComponent<ParticleSystem>().startSize /= 3f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[2].GetComponent<ParticleSystem>().startSize /= 30f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[2].GetComponent<ParticleSystem>().maxParticles = 3;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[3].GetComponent<ParticleSystem>().startSize /= 3f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[4].GetComponent<ParticleSystem>().startSize /= 3f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[5].GetComponent<ParticleSystem>().startSize /= 30f;
        ((Il2CppArrayBase<Renderer>)node.genericRenderers)[5].GetComponent<ParticleSystem>().maxParticles = 3;
    }
}
public class PrimoSlam : ModDisplay
{
    public override string BaseDisplay => "a8f4820d2574d544494a26690207c720";
}
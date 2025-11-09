using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using static AncientMonkey.AncientMonkey;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Linq;
using AncientMonkey;

namespace WeaponPacks;

// #### Godly ####

public class ApexPlasmaMaster : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Apex Plasma Master";
    public override string CodeName => "ApexPlasmaMaster";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ApexPlasmaMasterUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-Paragon").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlaiveDominus : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Glaive Dominus";
    public override string CodeName => "GlaiveDominus";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GlaiveDominusUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetAttackModel(2).Duplicate();
        var orbit = Game.instance.model.GetTowerFromId("BoomerangMonkey-Paragon").GetBehavior<OrbitModel>().Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        orbit.name = "AttackOrbit" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        towerModel.AddBehavior(orbit);
        tower.UpdateRootModel(towerModel);
    }
}
public class CrucibleSteelFlame : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Crucible of Steel and Flame";
    public override string CodeName => "CrucibleofSteelandFlame";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TackShooterParagonIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Hawk Eye"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter-Paragon").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BOMB : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Ballistic Obliteration Missile Bunker";
    public override string CodeName => "BallisticObliterationMissileBunker";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BombParagonIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-Paragon").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class NauticSiegeCore : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Nautic Siege Core";
    public override string CodeName => "NauticSiegeCore";
    public override SpriteReference Icon => CreateSpriteReference("2d1bab2254b903140a10baf0b269b81d");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-Paragon").GetAttackModel().Duplicate();
        var preEmptive = Game.instance.model.GetTowerFromId("MonkeySub-Paragon").GetBehavior<PreEmptiveStrikeLauncherModel>().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        preEmptive.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        towerModel.AddBehavior(preEmptive);
        tower.UpdateRootModel(towerModel);
    }
}/*
public class NavarchOfTheSeas : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Navarch Of The Seas";
    public override string CodeName => "NavarchOfTheSeas";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.NavarchOfTheSeasUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-Paragon").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}*/
public class GoliathDoomship : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Goliath Doomship";
    public override string CodeName => "GoliathDoomship";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GoliathDoomshipUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AirUnitModel>().Duplicate();
        var wpn1 = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AttackAirUnitModel>().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn1);
        ace.AddBehavior(wpn2);
        ace.AddBehavior(wpn3);
        phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}/*
public class MagusPerfectus : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Magus Perfectus";
    public override string CodeName => "MagusPerfectus";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MagusPerfectusUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-Paragon").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}*/
public class AscendedShadow : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Ascended Shadow";
    public override string CodeName => "AscendedShadow";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AscendedShadowUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel(2).Duplicate();
        var wpn4 = Game.instance.model.GetTowerFromId("NinjaMonkey-Paragon").GetAttackModel(3).Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn4.name = "Attack4" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn4.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn4, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        towerModel.AddBehavior(wpn4);
        tower.UpdateRootModel(towerModel);
    }
}
public class MunitionsFactory : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Mega Massive Munitions Factory";
    public override string CodeName => "MegaMassiveMunitionsFactory";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SpikeFactoryParagonIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-520").GetAttackModel().Duplicate();
        var weaponModel = Game.instance.model.GetTowerFromId("SpikeFactory-Paragon").GetAttackModel().weapons[0].Duplicate();
        wpn.weapons[0] = weaponModel;
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MasterBuilder : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override string WeaponName => "Master Builder";
    public override string CodeName => "MasterBuilder";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MasterBuilderUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAttackModel(2).Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Omega ####

public class Bloonarius : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Bloonarius";
    public override string CodeName => "Bloonarius";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonariusPortrait);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Bloonarius travels along the track";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var summon1 = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        summon1.name = "Attack1" + WeaponRarity + CodeName;
        summon1.range = 100000;
        summon1.weapons[0].rate = 40;
        summon1.weapons[0].emission = new NecromancerEmissionModel("Bloonarius.", 99999999, 999999, 1, 1, 1, 50, 0, null, null, null, 1, 100, 1, 1, 2);
        summon1.weapons[0].projectile.name = "AttackModel_Summon_";
        summon1.weapons[0].projectile.pierce = 100;
        summon1.weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Bloonarius5).display;
        summon1.weapons[0].projectile.GetDamageModel().damage = 45000;
        summon1.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        summon1.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = false;
        summon1.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespanFrames = 99999;
        summon1.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speedFrames *= 0.4f;
        summon1.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 9999;
        summon1.weapons[0].projectile.RemoveBehavior<CreateEffectOnExhaustedModel>();
        summon1.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("Clearhit", 1f));
        summon1.weapons[0].projectile.AddBehavior(new AgeModel("AgeModel_Projectile", 9999, 9999, true, new EndOfRoundClearBypassModel("EndOfRoundClearBypassModel_", "Apopalypse")));

        var summon2 = summon1.Duplicate();
        summon2.weapons[0].rate = 25;
        summon2.weapons[0].emission = new NecromancerEmissionModel("Bloonarius.", 99999999, 999999, 5, 10, 1, 75, 0, null, null, null, 1, 100, 1, 1, 2);
        summon2.weapons[0].projectile.pierce = 10;
        summon2.weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Bfb).display;
        summon2.weapons[0].projectile.GetDamageModel().damage = 300;
        summon2.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speedFrames *= 2f;
        summon2.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 9999;

        var summon3 = summon1.Duplicate();
        summon3.weapons[0].rate = 12;
        summon3.weapons[0].emission = new NecromancerEmissionModel("Bloonarius.", 99999999, 999999, 25, 50, 1, 75, 0, null, null, null, 1, 100, 1, 1, 2);
        summon3.weapons[0].projectile.pierce = 3;
        summon3.weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Red).display;
        summon3.weapons[0].projectile.GetDamageModel().damage = 10;
        summon3.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().speedFrames *= 5f;
        summon3.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().disableRotateWithPathDirection = true;
        summon3.weapons[0].projectile.GetBehavior<TravelAlongPathModel>().lifespan = 9999;

        WeaponMethods.AfterEffects(summon1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(summon2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(summon3, gilded, gildedEffect, degree);
        towerModel.AddBehavior(summon1);
        towerModel.AddBehavior(summon2);
        towerModel.AddBehavior(summon3);
        tower.UpdateRootModel(towerModel);
    }
}
public class Lych : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Lych";
    public override string CodeName => "Lych";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LychPortrait);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Summons Lyches to help attack Bloons";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var lych = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
        lych.name = "Attack" + WeaponRarity + CodeName;
        lych.range = tower.towerModel.range;
        lych.GetDescendant<RotateToTargetModel>().rotateTower = false;
        lych.weapons[0].Rate = 30;
        lych.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        lych.weapons[0].projectile.ApplyDisplay<blankdisplay.BlankDisplay>();
        lych.weapons[0].projectile.AddBehavior(new CreateTowerModel("LychTower", GetTowerModel<LychMinion>().Duplicate(), 0f, true, false, false, true, true));

        WeaponMethods.AfterEffects(lych.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower.GetAttackModel(), gilded, gildedEffect, degree);
        towerModel.AddBehavior(lych);
        tower.UpdateRootModel(towerModel);
    }
}
public class LychMinion : ModTower
{
    public override string Portrait => VanillaSprites.LychPortrait;
    public override string Name => "Lych";
    public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.DartMonkey + "-002";

    public override bool DontAddToShop => true;
    public override int Cost => 0;

    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;

    public override string DisplayName => "Lych";
    public override string Description => "";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.GetAttackModel().range = 50;
        towerModel.GetAttackModel().GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        towerModel.GetAttackModel().weapons[0].rate = 0.2f;
        towerModel.GetAttackModel().weapons[0].projectile.display = Game.instance.model.GetBloon(BloonType.Lych5).display;
        towerModel.GetAttackModel().weapons[0].projectile.scale *= 0.3f;
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 75;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 600;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 3;

        towerModel.range = 50;
        towerModel.radius = 0;
        towerModel.displayScale *= 0.6f;
        towerModel.isGlobalRange = false;
        towerModel.AddBehavior(new CreditPopsToParentTowerModel("CreditPopsToParentTowerModel_"));
        towerModel.display = Game.instance.model.GetBloon(BloonType.Lych5).display;
        towerModel.ignoreTowerForSelection = true;

        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 40f, 3, false, false));
    }
}
public class Vortex : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Vortex";
    public override string CodeName => "Vortex";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.VortexPortrait);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Periodically creates a deveastating shockwave";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var explosion = Game.instance.model.GetTowerFromId("MortarMonkey-500").GetDescendant<Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.CreateEffectOnExpireModel>().Duplicate();
        var vort = Game.instance.model.GetTowerFromId("BoomerangMonkey-500").GetAttackModel("AttackModel_OrbitAttack_").Duplicate();
        vort.name = "Attack" + WeaponRarity + CodeName;
        vort.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        vort.weapons[0].rate = 12f;
        vort.weapons[0].projectile.pierce = 99999;
        vort.weapons[0].projectile.RemoveBehaviors<DamageModifierForTagModel>();
        vort.weapons[0].projectile.GetDamageModel().damage = 4000;
        vort.weapons[0].projectile.radius = 1000;
        vort.weapons[0].projectile.GetDamageModel().distributeToChildren = true;
        vort.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        vort.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
        vort.weapons[0].projectile.AddBehavior(new SlowModel("SlowModel_", 0, 3, "Stun:Strong", 999999, "Stun", true, false, null, false, false, false, 0));
        vort.weapons[0].projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("AddBonusDamagePerHitToBloonModel_", "SuperBrittle", 10, 7, 6, true, false, false, ""));
        vort.weapons[0].projectile.AddBehavior(explosion);
        vort.fireWithoutTarget = true;

        WeaponMethods.AfterEffects(vort, gilded, gildedEffect, degree);
        towerModel.AddBehavior(vort);
        tower.UpdateRootModel(towerModel);
    }
}
public class Dreadbloon : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Dreadbloon";
    public override string CodeName => "Dreadbloon";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DreadbloonPortrait);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Summons Dreadbloon to fly around and shoot rock Bloons";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetBehavior<AirUnitModel>().Duplicate();
        ace.display = Game.instance.model.GetBloon("Dreadbloon5").display;

        var seeking = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
        seeking.distance = 999;
        seeking.constantlyAquireNewTarget = true;

        var wpn1 = Game.instance.model.GetTowerFromId("MonkeyAce-220").GetBehavior<AttackAirUnitModel>().Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn1.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn1.weapons[0].projectile.display = Game.instance.model.GetBloon("DreadRockBloonStandard5").display;
        wpn1.weapons[0].projectile.GetDamageModel().damage = 150;
        wpn1.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn1.weapons[0].projectile.pierce = 8;
        wpn1.weapons[0].projectile.AddBehavior(seeking);
        wpn1.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2;

        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-020").GetBehavior<AttackAirUnitModel>().Duplicate();
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn2.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn2.weapons[0].projectile.display = Game.instance.model.GetBloon("DreadRockBloonStandard5").display;
        wpn2.weapons[0].rate = 0.33f;
        wpn2.weapons[0].projectile.GetDamageModel().damage = 1200;
        wpn2.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn2.weapons[0].projectile.pierce = 10;
        wpn2.weapons[0].emission = new ArcEmissionModel("Arc", 5, 0, 90, null, false, true);

        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn1);
        ace.AddBehavior(wpn2);

        phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class Phayze : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Phayze";
    public override string CodeName => "Phayze";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PhayzePortrait);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Orbiting Phayzes deal continuous damage to nearby Bloons";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var orbit = Game.instance.model.GetTowerFromId("BoomerangMonkey-500").GetBehavior<OrbitModel>().Duplicate();
        orbit.name = "Attack" + WeaponRarity + CodeName;
        orbit.count = 2;
        orbit.projectile.display = Game.instance.model.GetBloon("Phayze5").display;
        orbit.projectile.scale *= 0.5f;
        orbit.range = 50;

        var orbitDamage = Game.instance.model.GetTowerFromId("BoomerangMonkey-500").GetAttackModel("AttackModel_OrbitAttack_").Duplicate();
        orbitDamage.name = "Attack" + WeaponRarity + CodeName;
        orbitDamage.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        orbitDamage.weapons[0].rate = 0.1f;
        orbitDamage.weapons[0].projectile.pierce = 9999999;
        orbitDamage.weapons[0].projectile.RemoveBehaviors<DamageModifierForTagModel>();
        orbitDamage.weapons[0].projectile.GetDamageModel().damage = 250;
        orbitDamage.weapons[0].projectile.GetDamageModel().maxDamage = 999999;
        orbitDamage.weapons[0].projectile.radius = 50;
        orbitDamage.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        WeaponMethods.AfterEffects(orbitDamage, gilded, gildedEffect, degree);
        towerModel.AddBehavior(orbitDamage);
        towerModel.AddBehavior(orbit);
        tower.UpdateRootModel(towerModel);

    }
}
public class Blastapopoulos : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Blastapopoulos";
    public override string CodeName => "Blastapopoulos";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BlastapopoulosPortrait);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Creates infernal heatwaves that occasionally become stronger";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var fireballs = Game.instance.model.GetTowerFromId("TackShooter-003").GetAttackModel().Duplicate();
        fireballs.name = "Attack" + WeaponRarity + CodeName;
        fireballs.range = tower.towerModel.range;
        fireballs.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        fireballs.weapons[0].rate = 0.8f;
        fireballs.weapons[0].projectile.pierce = 10;
        fireballs.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("LordPhoenix").GetAttackModel(1).weapons[0].projectile.display;
        fireballs.weapons[0].projectile.GetDamageModel().damage = 200;
        fireballs.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        fireballs.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan = 9999;
        fireballs.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
        fireballs.weapons[0].projectile.AddBehavior(new PushBackModel("PushBackModel_", 20, "", 0.6f, 0.5f, 0.5f, 0.25f, true));

        var darkFire = fireballs.weapons[0].projectile.Duplicate();
        darkFire.pierce = 20;
        darkFire.display = Game.instance.model.GetTowerFromId("DarkPhoenixV1").GetAttackModel(1).weapons[0].projectile.display;
        darkFire.GetDamageModel().damage = 750;
        darkFire.GetBehavior<PushBackModel>().pushAmount = 45;

        fireballs.weapons[0].AddBehavior(new ChangeProjectilePerEmitModel("ChangeProjectilePerEmitModel_", fireballs.weapons[0].projectile, darkFire, 6, 6, 5, null, 0, 0, 0));

        WeaponMethods.AfterEffects(fireballs, gilded, gildedEffect, degree);
        towerModel.AddBehavior(fireballs);
        tower.UpdateRootModel(towerModel);
    }
}
public class Glitch : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 7;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override string WeaponName => "Glitch";
    public override string CodeName => "Glitch";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FxPortalIcon);
    public override string? Notes => "Notes: Are you sure you want this?";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        if (AncientMonkey.AncientMonkey.mod.level < 4)
        {
            AncientMonkey.AncientMonkey.mod.upgradeCost = 10000000;

            var panel = MenuUi.extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("upgradePanel");
            panel.GetComponentFromChildrenByName<ModHelperText>("upgradeTitle").Text.text = $"7ow&r Up9r@d3: ${AncientMonkey.AncientMonkey.mod.upgradeCost}";
            panel.GetComponentFromChildrenByName<ModHelperText>("upgradeTextLeft").Text.text = "" +
                "- Un1o(k$ G1!tc#ed we@p0n$\n" +
                "- Re$etz t#e c0$t of @l1 up9ra8e$";
            panel.GetComponentFromChildrenByName<ModHelperButton>("upgradeButton").Button.SetOnClick(new Function(() =>
            {
                InGame game = InGame.instance;

                if (game.GetCash() >= AncientMonkey.AncientMonkey.mod.upgradeCost && AncientMonkey.AncientMonkey.mod.level == 3)
                {
                    game.AddCash(-AncientMonkey.AncientMonkey.mod.upgradeCost);
                    tower.worth += MathF.Round(AncientMonkey.AncientMonkey.mod.upgradeCost * 0.7f);
                    panel.GetComponentFromChildrenByName<ModHelperText>("upgradeTextLeft").Text.text = "N0 mor3 up9r@dez @t t#is t!me";
                    panel.GetComponentFromChildrenByName<ModHelperText>("upgradeTitle").Text.text = "7ow&r U6gr@de: M@xe8";
                    GlitchedUpgrade.UpgradeTower();
                }
            }));
        }
    }
}

// #### Glitched ####

public class GlitchedDart : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Dart";
    public override string CodeName => "GlitchedDart";
    public override SpriteReference Icon => GetSpriteReference("GlitchedDart");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn.weapons[0].rate = 0.7f;
        wpn.weapons[0].emission = new ArcEmissionModel("", 100, 0, 120, null, false, false);
        wpn.weapons[0].projectile.pierce = 999;
        wpn.weapons[0].projectile.GetDamageModel().damage = 6000;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan = 9999;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed /= 2;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedBoomerang : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Boomerang";
    public override string CodeName => "GlitchedBoomerang";
    public override SpriteReference Icon => GetSpriteReference("GlitchedBoomerang");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn.weapons[0].rate = 0.1f;
        wpn.weapons[0].emission = new ArcEmissionModel("", 5, 0, 50, null, false, false);
        wpn.weapons[0].projectile.pierce = 50;
        wpn.weapons[0].projectile.GetDamageModel().damage = 12000;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedSniper : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Sniper";
    public override string CodeName => "GlitchedSniper";
    public override SpriteReference Icon => GetSpriteReference("GlitchedSniper");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-040").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn.weapons[0].rate = 0.1f;
        wpn.weapons[0].projectile.pierce = 30;
        wpn.weapons[0].projectile.maxPierce = 30;
        wpn.weapons[0].projectile.GetDamageModel().damage = 24000;
        wpn.weapons[0].projectile.GetDescendants<DamageModel>().ForEach(model => model.immuneBloonProperties = Il2Cpp.BloonProperties.None);
        wpn.weapons[0].projectile.GetBehavior<EmitOnDamageModel>().projectile.GetDamageModel().damage = 4000;
        wpn.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
        wpn.weapons[0].projectile.AddBehavior(new SlowModel("SlowModel_", 0.5f, 3, "Stun:Strong", 999999, "Stun", true, false, null, false, false, false, 0));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedAce : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Ace";
    public override string CodeName => "GlitchedAce";
    public override SpriteReference Icon => GetSpriteReference("GlitchedAce");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AirUnitModel>().Duplicate();

        var wpn1 = Game.instance.model.GetTowerFromId("MonkeyAce-200").GetBehavior<AttackAirUnitModel>().Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn1.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn1.weapons[0].rate = 0.6f;
        wpn1.weapons[0].emission = new ArcEmissionModel("", 60, 0, 360, null, true, false);
        wpn1.weapons[0].projectile.pierce = 25;
        wpn1.weapons[0].projectile.GetDamageModel().damage = 7000;
        wpn1.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;

        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-300").GetBehaviors<AttackAirUnitModel>().First(model => model.name == "AttackAirUnitModel_Anti-MoabMissile_").Duplicate();
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn2.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn2.weapons[0].rate = 0.1f;
        wpn2.weapons[0].projectile.GetDescendants<DamageModel>().ForEach(model => model.damage = 14000);
        wpn2.weapons[0].projectile.GetDescendants<DamageModel>().ForEach(model => model.immuneBloonProperties = Il2Cpp.BloonProperties.None);

        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn1);
        ace.AddBehavior(wpn2);
        phoenix.towerModel.ApplyDisplay<blankdisplay.BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedMagic : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Magic";
    public override string CodeName => "GlitchedMagic";
    public override SpriteReference Icon => GetSpriteReference("GlitchedMagic");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn.weapons[0].rate = 0.8f;
        wpn.weapons[0].emission = new ArcEmissionModel("", 6, 0, 60, null, false, false);
        wpn.weapons[0].projectile.pierce = 15;
        wpn.weapons[0].projectile.GetDamageModel().damage = 7000;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;

        var magic1 = wpn.weapons[0].projectile.Duplicate();
        var magic2 = wpn.weapons[0].projectile.Duplicate();

        magic1.AddBehavior(new CreateProjectileOnContactModel("", magic2, new ArcEmissionModel("", 6, 0, 60, null, false, false), true, false, false));
        wpn.weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("", magic1, new ArcEmissionModel("", 6, 0, 60, null, false, false), true, false, false));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedShuriken : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Shuriken";
    public override string CodeName => "GlitchedShuriken";
    public override SpriteReference Icon => GetSpriteReference("GlitchedShuriken");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var seeking = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate();
        seeking.distance = 999;
        seeking.constantlyAquireNewTarget = true;

        var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn.weapons[0].rate = 1f;
        wpn.weapons[0].emission = new ArcEmissionModel("", 100, 0, 360, null, true, false);
        wpn.weapons[0].projectile.pierce = 12;
        wpn.weapons[0].projectile.GetDamageModel().damage = 4000;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        wpn.weapons[0].projectile.AddBehavior(seeking);
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan = 9999;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedSpikes : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Spikes";
    public override string CodeName => "GlitchedSpikes";
    public override SpriteReference Icon => GetSpriteReference("GlitchedSpikes");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects => ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate = 0.8f;
        wpn.weapons[0].projectile.pierce = 40;
        wpn.weapons[0].projectile.GetDamageModel().damage = 1000;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;

        var wpn2 = wpn.weapons[0].Duplicate();
        for (int i = 0; i < 11; i++)
        {
            wpn.AddWeapon(wpn2);
        }

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlitchedBananas : WeaponTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 8;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override string WeaponName => "Glitched Bananas";
    public override string CodeName => "GlitchedBananas";
    public override SpriteReference Icon => GetSpriteReference("GlitchedBananas");
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        var wpn = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetDescendants<EmissionsPerRoundFilterModel>().ForEach(model => model.count = 8);
        wpn.GetDescendants<CashModel>().ForEach(model => model.minimum = 8000);
        wpn.GetDescendants<CashModel>().ForEach(model => model.maximum = 12000);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using AncientMonkey;

namespace WeaponPacks;

// #### Common ####

public class Dart : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Dart";
    public override string CodeName => "Dart";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SharpShotsUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects => 
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Boomerang : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Boomerang";
    public override string CodeName => "Boomerang";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ImprovedRangsUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Bomb : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Bomb";
    public override string CodeName => "Bomb";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BiggerBombsUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects => 
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Tack : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Tack";
    public override string CodeName => "Tack";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FasterShootingUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither","Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Ice : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Ice";
    public override string CodeName => "Ice";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PermafrostUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Hawk Eye", "Stronger Compound", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("IceMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Glue : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Glue";
    public override string CodeName => "Glue";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GlueSoakUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("GlueGunner").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Revolver : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Revolver";
    public override string CodeName => "Revolver";
    public override SpriteReference Icon => CreateSpriteReference("233612271d9f1a54da1bcdebb68e2bd1");
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class TripleShot : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Triple Shot";
    public override string CodeName => "TripleShot";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TripleShotUpgradeIcon);
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-032").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Crossbow : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Crossbow";
    public override string CodeName => "Crossbow";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CrossBowUpgradeIcon);
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-003").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GlaiveRichochet : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Glaive Richochet";
    public override string CodeName => "GlaiveRicochet";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GlaiveRicochetUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-300").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class HotRang : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Hot Rang";
    public override string CodeName => "RedHotRangs";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RedHotRangsUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-102").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MissileLauncher : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Missile Launcher";
    public override string CodeName => "MissileLauncher";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MissileLauncherUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-220").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class ClusterBomb : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Cluster Bomb";
    public override string CodeName => "ClusterBombs";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ClusterBombsUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-003").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BladeShooter : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Blade Shooter";
    public override string CodeName => "BladeShooter";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BladeShooterUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter-230").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BigIron : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Big Iron";
    public override string CodeName => "BigIron";
    public override SpriteReference Icon => CreateSpriteReference("16f57259afd98674ca76f22d1882dded");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-320").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class SharpShooter : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Sharp Shooter";
    public override string CodeName => "SharpShooter";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SharpShooterUpgradeIcon);
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-204").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BionicBoomer : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bionic Boomer";
    public override string CodeName => "BionicBoomerang";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BionicBoomerangUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-230").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class KylieBoomerang : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Kylie Boomerang";
    public override string CodeName => "KylieBoomerang";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.KylieBoomerangUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-203").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MoabMauler : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Moab Mauler";
    public override string CodeName => "MoabMauler";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MoabMaulerUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-030").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class RecursiveCluster : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Recursive Cluster";
    public override string CodeName => "RecursiveCluster";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RecursiveClusterUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-024").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class RingOfFire : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Ring Of Fire";
    public override string CodeName => "RingOfFire";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RingOfFireUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter-420").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Overdrive : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Overdrive";
    public override string CodeName => "Overdrive";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.OverdriveUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter-204").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Icicles : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Icicles";
    public override string CodeName => "Icicles";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.IciclesUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Stronger Compound", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("IceMonkey-204").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonLiquefier : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bloon Liquefier";
    public override string CodeName => "BloonLiquefier";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonLiquefierUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("GlueGunner-410").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MoabGlue : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Moab Glue";
    public override string CodeName => "MoabGlue";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MoabGlueUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("GlueGunner-023").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class TwinSixes : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Twin Sixes";
    public override string CodeName => "Twin Sixes";
    public override SpriteReference Icon => CreateSpriteReference("8bf7b09804555834e927a4307fe3e32c");
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-400").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Deadeye : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Deadeye";
    public override string CodeName => "Deadeye";
    public override SpriteReference Icon => CreateSpriteReference("a652da86d6af82b429dea9c825025718");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-230").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveFilter<FilterIfAttackHasTargetModel>();
        wpn.drawRangeCircle = false;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Enforcer : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Enforcer";
    public override string CodeName => "Enforcer";
    public override SpriteReference Icon => CreateSpriteReference("9f9fd740f1c2b2645b39f04fbb92310f");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-023").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.drawRangeCircle = false;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class UltraJuggernaut : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Ultra Juggernaut";
    public override string CodeName => "UltraJuggernaut";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UltraJuggernautUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class CrossBowMaster : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Crossbow Master";
    public override string CodeName => "CrossBowMaster";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CrossBowMasterUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PermaCharge : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Perma Charge";
    public override string CodeName => "PermaCharge";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PermaChargeUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Wind Blast",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-052").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MoabEliminator : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Moab Eliminator";
    public override string CodeName => "MoabEliminator";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MoabEliminatorUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-050").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BombBlitz : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Bomb Blitz";
    public override string CodeName => "BombBlitz";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BombBlitzUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class TackZone : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Tack Zone";
    public override string CodeName => "TheTackZone";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TheTackZoneUpgradeIcon);
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SuperBrittle : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Super Brittle";
    public override string CodeName => "SuperBrittle";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SuperBrittleUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Stronger Compound", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("IceMonkey-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class IcicleImpale : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Icicles Impale";
    public override string CodeName => "IcicleImpale";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.IcicleImpaleUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Stronger Compound", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("IceMonkey-205").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonSolver : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Bloon Solver";
    public override string CodeName => "TheBloonSolver";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TheBloonSolverUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("GlueGunner-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SuperGlue : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Super Glue";
    public override string CodeName => "SuperGlue";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SuperGlueUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("GlueGunner-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class TheBlazingSun : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "The Blazing Sun";
    public override string CodeName => "TheBlazingSun";
    public override SpriteReference Icon => CreateSpriteReference("e886d7e23dd9fad4dbcca4a2fa0da56b");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class TheDesertPhantom : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "The Desert Phantom";
    public override string CodeName => "TheDesertPhantom";
    public override SpriteReference Icon => CreateSpriteReference("6b5cc0e7f075986489ea3e0ed933440a");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects => 
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-025").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.drawRangeCircle = false;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class GlaiveLord : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Glaive Lord";
    public override string CodeName => "GlaiveLord";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GlaiveLordUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "Note: Only attacks in close range\n\n";
    public override string[] GildedEffects =>
        ["Super Strength", "God Boost", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-502").GetAttackModel(1).Duplicate();
        var orbit = Game.instance.model.GetTowerFromId("BoomerangMonkey-502").GetBehavior<OrbitModel>().Duplicate();
        orbit.name = "Orbit" + WeaponRarity + CodeName;
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        towerModel.AddBehavior(orbit);
        tower.UpdateRootModel(towerModel);
    }
}
public class MoabDomination : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Moab Domination";
    public override string CodeName => "MoabDomination";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MoabDominationUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BoomerangMonkey-025").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonCrush : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Bloon Crush";
    public override string CodeName => "BloonCrush";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonCrushUpgradeIcon);
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Tracking", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BombShooter-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class InfernoRing : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Inferno Ring";
    public override string CodeName => "InfernoRing";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.InfernoRingUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("TackShooter-520").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("TackShooter-520").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn2.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        towerModel.AddBehavior(wpn2);
        tower.UpdateRootModel(towerModel);
    }
}
public class GoldenJustice : WeaponTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Golden Justice";
    public override string CodeName => "GoldenJustice";
    public override SpriteReference Icon => CreateSpriteReference("0ac01535cbb1e244a938e4f58af12664");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Desperado-250").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveFilter<FilterIfAttackHasTargetModel>();
        wpn.drawRangeCircle = false;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
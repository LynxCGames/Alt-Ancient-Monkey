using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using AncientMonkey;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.Display;

namespace WeaponPacks;

// #### Common ####

public class MinecraftCow : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Minecraft Cow";
    public override string CodeName => "MinecraftCow";
    public override Sprite CustomIcon => GetSprite("MinecraftCowIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate /= 3;
        wpn.weapons[0].projectile.ApplyDisplay<Milk>();
        wpn.weapons[0].projectile.pierce = 6;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Cat : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Cat";
    public override string CodeName => "Cat";
    public override Sprite CustomIcon => GetSprite("Cat-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects => 
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate = 2;
        wpn.weapons[0].projectile.pierce = 5;
        wpn.weapons[0].projectile.ApplyDisplay<Stars1>();
        wpn.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
        wpn.weapons[0].projectile.AddBehavior(new AgeModel("AgeModel_", 2, 1, false, null));
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class ChickenJockey : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Chicken Jockey";
    public override string CodeName => "ChickenJockey";
    public override Sprite CustomIcon => GetSprite("ChickenJockey-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
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
        wpn.weapons[0].projectile.ApplyDisplay<Egg>();
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed /= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 2;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class RadicalRolls : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Radical Rolls";
    public override string CodeName => "RadicalRolls";
    public override Sprite CustomIcon => GetSprite("RadicalRolls-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate = 1.6f;
        wpn.weapons[0].projectile.pierce = 7;
        wpn.weapons[0].projectile.ApplyDisplay<Stars1>();
        wpn.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
        wpn.weapons[0].projectile.AddBehavior(new AgeModel("AgeModel_", 2, 1, false, null));
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class FlintAndSteel : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Flint and Steel (CJ)";
    public override string CodeName => "FlintAndSteel";
    public override Sprite CustomIcon => GetSprite("FlintAndSteel-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
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
        wpn.weapons[0].emission = new ParallelEmissionModel("PEM_", 2, 10, 0, false, null);
        wpn.weapons[0].projectile.pierce += 2;
        wpn.weapons[0].projectile.GetDamageModel().damage += 1;
        wpn.weapons[0].projectile.ApplyDisplay<Egg>();
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed /= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 2;

        var wpn2 = wpn.weapons[0].Duplicate();
        wpn2.emission = new ArcEmissionModel("AEM_", 2, 0, 60, null, false, false);
        wpn.AddWeapon(wpn2);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class SpicyMilk : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Spicy Milk";
    public override string CodeName => "SpicyMilk";
    public override Sprite CustomIcon => GetSprite("SpicyMilkIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate /= 3f;
        wpn.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 15, null, false, false);
        wpn.weapons[0].projectile.ApplyDisplay<SpicyMilkDisplay>();
        wpn.weapons[0].projectile.pierce = 6;
        wpn.weapons[0].projectile.GetDamageModel().damage += 3;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BeautifulBackflips : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Beautiful Backflips";
    public override string CodeName => "BeautifulBackflips";
    public override Sprite CustomIcon => GetSprite("BeautifulBackflips-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate = 1f;
        wpn.weapons[0].projectile.pierce = 22;
        wpn.weapons[0].projectile.ApplyDisplay<Stars3>();
        wpn.weapons[0].projectile.GetDamageModel().damage = 8;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
        wpn.weapons[0].projectile.AddBehavior(new AgeModel("AgeModel_", 8, 1, false, null));
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####
public class TheNether : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "The Nether (CJ)";
    public override string CodeName => "TheNether";
    public override Sprite CustomIcon => GetSprite("TheNether-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.weapons[0].rate *= 0.4f;
        wpn.weapons[0].emission = new ParallelEmissionModel("PEM_", 5, 30, 0, false, null);
        wpn.weapons[0].projectile.pierce += 2;
        wpn.weapons[0].projectile.GetDamageModel().damage += 2;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.ApplyDisplay<Egg>();
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed /= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 2;

        var wpn2 = wpn.weapons[0].Duplicate();
        wpn2.emission = new ArcEmissionModel("AEM_", 15, 0, 270, null, false, false);
        wpn.AddWeapon(wpn2);

        var wpn3 = wpn.weapons[0].Duplicate();
        wpn3.emission = new LerpEmissionModel("Lerp_", null);
        wpn.AddWeapon(wpn3);
        wpn.AddWeapon(wpn3);
        wpn.AddWeapon(wpn3);
        wpn.AddWeapon(wpn3);

        var wpn4 = wpn.weapons[0].Duplicate();
        wpn4.emission = new ArcEmissionModel("AEM_", 10, 180, 180, null, false, false);
        wpn.AddWeapon(wpn4);

        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class LavaMilk : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Lava Milk";
    public override string CodeName => "LavaMilk";
    public override Sprite CustomIcon => GetSprite("LavaMilkIcon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Tracking", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate /= 4.2f;
        wpn.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 15, 0, 50, null, false, false);
        wpn.weapons[0].projectile.ApplyDisplay<LavaMilkDisplay>();
        wpn.weapons[0].projectile.pierce = 6;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        wpn.weapons[0].projectile.GetDamageModel().damage += 3;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class LavaChicken : WeaponTemplate
{
    public override string WeaponPack => "MemePack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Lava Chicken";
    public override string CodeName => "LavaChicken";
    public override Sprite CustomIcon => GetSprite("LavaChicken-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "God Boost"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.weapons[0].rate *= 0.4f;
        wpn.weapons[0].emission = new ParallelEmissionModel("PEM_", 16, 60, 0, false, null);
        wpn.weapons[0].projectile.pierce += 3;
        wpn.weapons[0].projectile.GetDamageModel().damage += 1;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.ApplyDisplay<Egg>();
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed /= 2;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 2;

        var wpn2 = wpn.weapons[0].Duplicate();
        wpn2.emission = new ArcEmissionModel("AEM_", 15, 0, 270, null, false, false);
        wpn.AddWeapon(wpn2);

        var wpn3 = wpn.weapons[0].Duplicate();
        wpn3.emission = new LerpEmissionModel("Lerp_", null);
        wpn.AddWeapon(wpn3);
        wpn.AddWeapon(wpn3);
        wpn.AddWeapon(wpn3);
        wpn.AddWeapon(wpn3);

        var wpn4 = wpn.weapons[0].Duplicate();
        wpn4.emission = new ArcEmissionModel("AEM_", 25, 180, 360, null, false, false);
        wpn.AddWeapon(wpn4);

        var wpn5 = wpn.weapons[0].Duplicate();
        wpn5.rate *= 0.75f;
        wpn5.emission = new RandomEmissionModel("REM_", 10, 3850, 500, null, true, 0.7f, 1.4f, 5, true);
        wpn5.projectile.GetDamageModel().damage += 4;
        wpn.AddWeapon(wpn5);
        wpn.AddWeapon(wpn5);

        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// Minecraft Cow Projectiles
public class Milk : ModDisplay2D
{
    protected override string TextureName => "MilkIcon";
}
public class SpicyMilkDisplay : ModDisplay2D
{
    protected override string TextureName => "SpicyMilkIcon";
}
public class LavaMilkDisplay : ModDisplay2D
{
    protected override string TextureName => "LavaMilkIcon";
}

// Cat Projectiles
public class Stars1 : ModCustomDisplay
{
    public override string AssetBundleName => "lerpprojectiles";
    public override Il2CppAssets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 0, 5);
    public override string PrefabName => "Stars1";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        node.transform.GetComponent<ParticleSystem>().Play();
    }
}
public class Stars3 : ModCustomDisplay
{
    public override string AssetBundleName => "lerpprojectiles";
    public override Il2CppAssets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 0, 5);
    public override string PrefabName => "Stars3";
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        node.transform.GetComponent<ParticleSystem>().Play();
    }
}

// Chicken Jockey Projectile
public class Egg : ModDisplay2D
{
    protected override string TextureName => "Egg-Icon";
}
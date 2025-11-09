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

namespace WeaponPacks;

// #### Common ####

// #### Rare ####

public class PlasmaDart : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Plasma Dart";
    public override string CodeName => "PlasmaDart";
    public override Sprite CustomIcon => GetSprite("PlasmaDart-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.weapons[0].projectile.ApplyDisplay<PlasmaDartProj>();
        wpn.weapons[0].projectile.pierce = 5;
        wpn.weapons[0].projectile.GetDamageModel().damage = 3;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class PlasmaBalls : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Plasma Balls";
    public override string CodeName => "PlasmaBalls";
    public override Sprite CustomIcon => GetSprite("PlasmaBalls-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.weapons[0].Rate *= 0.56f;
        wpn.weapons[0].projectile.ApplyDisplay<PlasmaBallProj>();
        wpn.weapons[0].projectile.pierce = 19;
        wpn.weapons[0].projectile.GetDamageModel().damage = 8;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 1.125f;

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MoabIncineration : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "MOAB Incineration";
    public override string CodeName => "MoabIncineration";
    public override Sprite CustomIcon => GetSprite("MoabIncineration-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Stronger Compound", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var addBehavior = Game.instance.model.GetTowerFromId("MortarMonkey-003").GetDescendant<AddBehaviorToBloonModel>().Duplicate();
        addBehavior.ApplyOverlay<Plasma>();
        addBehavior.lifespan *= 1.5f;
        addBehavior.GetBehavior<DamageOverTimeModel>().Interval *= 0.667f;
        addBehavior.GetBehavior<DamageOverTimeModel>().damage += 3;
        addBehavior.GetBehavior<DamageOverTimeModel>().damageModifierModels.AddTo(new DamageModifierForTagModel("DamageModifierForTagModel_", "Moabs", 2f, 0, false, true));

        wpn.weapons[0].projectile.ApplyDisplay<PlasmaDartProj>();
        wpn.weapons[0].projectile.pierce = 13;
        wpn.weapons[0].projectile.GetDamageModel().damage = 3;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 1.602f;
        wpn.weapons[0].projectile.AddBehavior(addBehavior);
        wpn.weapons[0].projectile.UpdateCollisionPassList();

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PlasmaBeams : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Plasma Beams";
    public override string CodeName => "PlasmaBeams";
    public override Sprite CustomIcon => GetSprite("PlasmaBeams-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.weapons[0].Rate *= 0.56f;
        wpn.weapons[0].projectile.ApplyDisplay<PlasmaBeamProj>();
        wpn.weapons[0].projectile.pierce = 18;
        wpn.weapons[0].projectile.radius /= 2.5f;
        wpn.weapons[0].projectile.GetDamageModel().damage = 5;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 0.56f;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 2.5f;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class PlasmaGuns : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Plasma Guns";
    public override string CodeName => "PlasmaGuns";
    public override Sprite CustomIcon => GetSprite("PlasmaGuns-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        ThrowMarkerOffsetModel[] emissionOffsets = { new ThrowMarkerOffsetModel("Gun_Left", -3.5f, 0, 7, 0), new ThrowMarkerOffsetModel("Gun_Right", 3.5f, 0, 7, 0) };

        wpn.weapons[0].Rate *= 0.187f;
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[0].ejectZ = 0;
        wpn.weapons[0].emission = new EmissionWithOffsetsModel("EmissionsWithOffsetsModel_", emissionOffsets, 2, false, null, 0, false);
        wpn.weapons[0].projectile.ApplyDisplay<PlasmaBeamProj>();
        wpn.weapons[0].projectile.pierce = 18;
        wpn.weapons[0].projectile.radius = 21;
        wpn.weapons[0].projectile.GetDamageModel().damage = 7;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 0.28f;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 6.25f;
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs", 1.2f, 1, false, true));
        wpn.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1.35f, 1, false, true));
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class StellarPlasma : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Stellar Plasma";
    public override string CodeName => "StellarPlasma";
    public override Sprite CustomIcon => GetSprite("SolarPlasmaBalls-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Super Strength", "Fast Hands", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        wpn.weapons[0].Rate = 3;
        wpn.weapons[0].projectile.id = "SolarPlasmaBall";
        wpn.weapons[0].projectile.ApplyDisplay<SolarPlasmaBall>();
        wpn.weapons[0].projectile.pierce = 50;
        wpn.weapons[0].projectile.GetDamageModel().damage = 2000;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        wpn.weapons[0].projectile.RemoveBehavior<TravelStraitModel>();
        wpn.weapons[0].projectile.AddBehavior(new TravelAlongPathModel("TravelAlongPathModel_", 20, 30, false, true, 0));
        wpn.weapons[0].projectile.AddBehavior(new ClearHitBloonsModel("ClearHitBloonsModel", 0.2f));

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonDisintigration : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Bloon Disintigration";
    public override string CodeName => "BloonDisintigration";
    public override Sprite CustomIcon => GetSprite("BloonDisintigration-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Fast Hands", "God Boost", "Wind Blast", "Hawk Eye", "Tracking", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        var addBehavior = Game.instance.model.GetTowerFromId("MortarMonkey-003").GetDescendant<AddBehaviorToBloonModel>().Duplicate();
        addBehavior.ApplyOverlay<Plasma>();
        addBehavior.lifespan *= 1.5f;
        addBehavior.applyOnlyIfDamaged = false;
        addBehavior.GetBehavior<DamageOverTimeModel>().Interval = 0.1f;
        addBehavior.GetBehavior<DamageOverTimeModel>().damage = 85;
        addBehavior.GetBehavior<DamageOverTimeModel>().damageModifierModels.AddTo(new DamageModifierForTagModel("DamageModifierForTagModel_", "Moabs", 5, 0, false, true));

        wpn.weapons[0].projectile.ApplyDisplay<PlasmaDartProj>();
        wpn.weapons[0].projectile.pierce = 13;
        wpn.weapons[0].projectile.GetDamageModel().damage = 0;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 1.602f;
        wpn.weapons[0].projectile.AddBehavior(addBehavior);
        wpn.weapons[0].projectile.UpdateCollisionPassList();

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GigaPlasmaGuns : WeaponTemplate
{
    public override string WeaponPack => "DarksTowerPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Giga Plasma Guns";
    public override string CodeName => "GigaPlasmaGuns";
    public override Sprite CustomIcon => GetSprite("GigaPlasmaGuns-Icon");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string Notes => "";
    public override string[] GildedEffects =>
        ["Piercing Winds", "Super Strength", "God Boost", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;

        ThrowMarkerOffsetModel[] emissionOffsets = { new ThrowMarkerOffsetModel("Gun_Left", -3.5f, 0, 7, 0), new ThrowMarkerOffsetModel("Gun_Right", 3.5f, 0, 7, 0) };

        wpn.weapons[0].Rate *= 0.1f;
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[0].ejectZ = 0;
        wpn.weapons[0].emission = new EmissionWithOffsetsModel("EmissionsWithOffsetsModel_", emissionOffsets, 2, false, null, 0, false);
        wpn.weapons[0].projectile.ApplyDisplay<SolarPlasmaBeamProj>();
        wpn.weapons[0].projectile.pierce = 1;
        wpn.weapons[0].projectile.radius = 21;
        wpn.weapons[0].projectile.GetDamageModel().damage = 100;
        wpn.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed *= 0.84f;
        wpn.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 15.625f;
        wpn.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);

        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

public class PlasmaDartProj : ModDisplay2D
{
    protected override string TextureName => "PlasmaDart";
}
public class PlasmaBallProj : ModDisplay2D
{
    protected override string TextureName => "PlasmaBall";
}
public class PlasmaBeamProj : ModDisplay2D
{
    protected override string TextureName => "PlasmaBeam";
}
public class SolarPlasmaBeamProj : ModDisplay2D
{
    protected override string TextureName => "SolarPlasmaBeam";
}

public class Plasma : ModBloonOverlay
{
    private static Material plasma2dMaterial;
    public override string BaseOverlay => Game.instance.model.GetTowerFromId("MortarMonkey-003").GetDescendant<AddBehaviorToBloonModel>().overlayType;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        var spriteAnimator = node.GetComponentInChildren<CustomSpriteFrameAnimator>();
        if (spriteAnimator)
        {
            if (!plasma2dMaterial)
            {
                plasma2dMaterial = spriteAnimator.spriteRenderer.sharedMaterial.Duplicate();
                plasma2dMaterial.color = new Color(1, 0, 4);
                plasma2dMaterial.name = "Plasma2DMaterial";
            }

            spriteAnimator.spriteRenderer.material = plasma2dMaterial;
            return;
        }

        foreach (var renderer in node.GetMeshRenderers())
        {
            renderer.SetMainTexture(GetTexture("Plasma"));
            //renderer.material.mainTexture.TrySaveToPNG(Path.Combine(Application.persistentDataPath, node.name + node.genericRenderers.IndexOf(renderer) + ".png"));
        }

        //node.genericRenderers[0].material.mainTexture = GetTexture("Plasma");
    }
}

public class SolarPlasmaBall : ModCustomDisplay
{
    public override string AssetBundleName => "lerpprojectiles";
    public override string PrefabName => "PlasmaBallFixed";
    public override float Scale => 1;
}
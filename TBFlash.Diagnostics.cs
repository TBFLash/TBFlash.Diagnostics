using System;
using System.Text;
using SimAirport.Modding.Base;
using SimAirport.Modding.Settings;
using SimAirport.Logging;
using UnityEngine;
using TBFlash.LeakingUrinal;

namespace TBFlash.Diagnostics
{
    public class Mod : BaseMod
    {
        public override string Name => "TBDiagnostics";

        public override string InternalName => "TBFlash.Diagnostics";

        public override string Description => "For comparing base configurations to a Mod's configuration";

        public override string Author => "TBFlash";

        public override SettingManager SettingManager { get; set; }

        public override void OnTick()
        {
        }
		public override void OnLoad(SimAirport.Modding.Data.GameState state)
        {
            if (Game.isLoaded)
            {
                foreach(SmartObject smo in Game.current.objectCache.smartObjects.FindAll(IsBaseClass))
                {
                    Game.Logger.Write(Log.FromPool("\n\n----------BASE CLASS----------"));
                    //  Game.Logger.Write(Log.FromPool(PlaceableConfigData(smo.placeableObject.Config)).WithCodepoint());
                    //  Game.Logger.Write(Log.FromPool(SmartObjectData(smo)).WithCodepoint());
                    //  Game.Logger.Write(Log.FromPool(PlaceableObjectData(smo.placeableObject)).WithCodepoint());
                    Game.Logger.Write(Log.FromPool($"smo.GetType()----\n{smo.GetType()}\n----"));
                    //  Game.Logger.Write(Log.FromPool($"isassignable? {typeof(IJsonSaveable).IsAssignableFrom(smo.GetType())}"));
                    //  Game.Logger.Write(Log.FromPool((smo as ToiletUtility)?.leavePosition.ToString()));
                    Game.Logger.Write(Log.FromPool("----------END BASE CLASS----------\n\n"));
                }

                foreach (SmartObject smo in Game.current.objectCache.smartObjects.FindAll(IsModClass))
                {
                    Game.Logger.Write(Log.FromPool("\n\n----------MOD CLASS----------"));
                    //  Game.Logger.Write(Log.FromPool(PlaceableConfigData(smo.placeableObject.Config)).WithCodepoint());
                    //  Game.Logger.Write(Log.FromPool(SmartObjectData(smo)).WithCodepoint());
                    //  Game.Logger.Write(Log.FromPool(PlaceableObjectData(smo.placeableObject)).WithCodepoint());
                    Game.Logger.Write(Log.FromPool($"smo.GetType()----\n{smo.GetType()}\n----"));
                    //  Game.Logger.Write(Log.FromPool($"isassignable? {typeof(IJsonSaveable).IsAssignableFrom(smo.GetType())}"));
                    //  Game.Logger.Write(Log.FromPool((smo as TBFlash_LeakingUrinal)?.leavePosition.ToString()));
                    Game.Logger.Write(Log.FromPool("----------END MOD CLASS----------\n\n"));
                }

                Game.Logger.Write(Log.FromPool("\n---------GameSerializer.AllSubtypes---------"));
                foreach (Type type in GameSerializer.AllSubtypes(typeof(IJsonSaveable)))
                {
                    Game.Logger.Write(Log.FromPool($"Type: {type}"));
                }
                Game.Logger.Write(Log.FromPool("---------END GameSerializer.AllSubtypes---------\n"));

                /*  Game.Logger.Write(Log.FromPool("\n---------Assembly.GetExportedTypes---------"));
                foreach (Type type in typeof(IJsonSaveable).Assembly.GetExportedTypes())
                {
                    Game.Logger.Write(Log.FromPool($"Exported Type: {type}"));
                }
                Game.Logger.Write(Log.FromPool("---------END Assembly.GetExportedTypes---------\n"));
                */
            }
        }

        private static bool IsBaseClass(SmartObject smo)
        {
            return smo.placeableObject.MyZeroAllocName.Equals("Urinal");
        }

        private static bool IsModClass(SmartObject smo)
        {
            return smo.placeableObject.MyZeroAllocName.Equals("TBFlash_LeakingUrinal");
        }

        private String PlaceableObjectData(PlaceableObject po)
        {
            StringBuilder text = new StringBuilder();
            text.Append("\n-----PlaceableObject Data-----");
            text.Append("\nbDezone: ").Append(po.bDezone);
            text.Append("\nbWriteToMapCache: ").Append(po.bWriteToMapCache);
            text.Append("\nCanBeDestroyed: ").Append(po.CanBeDestroyed);
            text.Append("\ncollectionIndex: ").Append(po.collectionIndex);
            text.Append("\nconstructionDuration: ").Append(po.constructionDuration);
            text.Append("\nconstructionState: ").Append(po.constructionState);
            text.Append("\nconstructionType: ").Append(po.constructionType);
            text.Append("\nCreatePrice: ").Append(po.CreatePrice);
            text.Append("\nfacingConfig: ").Append(FacingConfigData(po.facingConfig));
            text.Append("\nheight: ").Append(po.height);
            text.Append("\nHidden: ").Append(po.Hidden);
            text.Append("\nHourlyPrice: ").Append(po.HourlyPrice);
            text.Append("\niprefab: ").Append(po.iprefab);
            text.Append("\nIsCrosswalk: ").Append(po.IsCrosswalk);
            text.Append("\nisDestroyable: ").Append(po.isDestroyable);
            text.Append("\nisFootprintSet: ").Append(po.isFootprintSet);
            text.Append("\nisPseudoWall: ").Append(po.isPseudoWall);
            text.Append("\nMaxAllowed: ").Append(po.MaxAllowed);
            text.Append("\nMyZeroAllocName: ").Append(po.MyZeroAllocName);
            text.Append("\nPieceCountTotal: ").Append(po.PieceCountTotal);
            text.Append("\nPlacementSound: ").Append(po.PlacementSound);
            text.Append("\nplacementVOffset: ").Append(po.placementVOffset);
            text.Append("\nprefab: ").Append(po.prefab);
            text.Append("\nrequiresSectorRebuild: ").Append(po.requiresSectorRebuild);
            text.Append("\nrequiresSecureArea: ").Append(po.requiresSecureArea);
            text.Append("\nrotateType: ").Append(po.rotateType);
            text.Append("\nSector: -----").Append(po.Sector).Append("\n-----");
            text.Append("\nsnapToGridSize: ").Append(po.snapToGridSize);
            text.Append("\nVerticalHeight: ").Append(po.VerticalHeight);
            text.Append("\nwidth: ").Append(po.width);
            text.Append("\nfacing: ").Append(po.facing);
            text.Append("\nisBuilt: ").Append(po.isBuilt);
            text.Append("\nisPlaced: ").Append(po.isPlaced);
            text.Append("\nMarkers: -----");
            foreach (Marker mo in po.Markers())
            {
                text.Append(MarkerData(mo));
            }
            text.Append("\n: -----").Append(po.Inspect()).Append("\n-----");
            text.Append("\n: ").Append(po.OddRotation());

            return text.ToString();
        }

        private String SmartObjectData(SmartObject smo)
        {
            StringBuilder text = new StringBuilder();

            text.Append("\n-----SmartObject Data-----");
            text.Append("\ncurrentEnterLockDuration: ").Append(smo.currentEnterLockDuration);
            text.Append("\nDebugName: ").Append(smo.DebugName);
            text.Append("\nDisplayCategory: ").Append(smo.DisplayCategory);
            text.Append("\nFunctioningForTasks: ").Append(smo.FunctioningForTasks);
            text.Append("\nIdleTime: ").Append(smo.IdleTime);
            text.Append("\niprefab: ").Append(smo.iprefab);
            text.Append("\nLevel: ").Append(smo.Level);
            text.Append("\nmaxStaffAssigned: ").Append(smo.maxStaffAssigned);
            text.Append("\nnCurrent: ").Append(smo.nCurrent);
            text.Append("\nPosition: ").Append(smo.Position);
            text.Append("\nprefab: ").Append(smo.prefab);
            text.Append("\nqueueTypeMask: ").Append(smo.queueTypeMask);
            text.Append("\nrequiresStaffType: ").Append(smo.requiresStaffType);
            text.Append("\nreservedTasks: ").Append(smo.reservedTasks);
            text.Append("\nRunningTasks: ").Append(smo.RunningTasks);
            text.Append("\nsavedStaffPerSchedule: ").Append(smo.savedStaffPerSchedule);
            text.Append("\nScheduleAssigned: ").Append(smo.ScheduleAssigned);
            text.Append("\nScheduleWorkType: ").Append(smo.ScheduleWorkType);
            text.Append("\nSector: -----\n").Append(smo.Sector).Append("\n-----");
            text.Append("\nstaffHere: ").Append(smo.staffHere);
            text.Append("\nSubSector: ").Append(smo.SubSector);
            text.Append("\nVisualCenter");
            text.Append("\n\tx: : ").Append(smo.VisualCenter.x);
            text.Append("\n\ty: : ").Append(smo.VisualCenter.y);
            text.Append("\nacceptsQueueGeometry: ").Append(smo.acceptsQueueGeometry);
            text.Append("\nconcurrency: ").Append(smo.concurrency);
            text.Append("\nconnection: ").Append(smo.connection);
            text.Append("\nDequeuedOTW: ").Append(smo.DequeuedOTW);
            text.Append("\nisBeingRepaired: ").Append(smo.isBeingRepaired);
            text.Append("\nmanager: -----\n").Append(smo.manager.Inspect(true)).Append("\n-----");
            text.Append("\nmanager.parent.GameObject: ").Append(GameObjectData(smo.manager.parent.gameObject));
            text.Append("\nmanager.queues[0].obj.gameObject: ").Append(GameObjectData(smo.manager.queues[0].obj.gameObject));
            text.Append("\nmanager.queues[0].obj.gameObject.gameObject: ").Append(GameObjectData(smo.manager.queues[0].obj.gameObject.gameObject));
            text.Append("\nplaceableObject: ").Append(smo.placeableObject);
            text.Append("\nqueueEnabled: ").Append(smo.queueEnabled);
            text.Append("\nstaffLimit: ").Append(smo.staffLimit);
            text.Append("\nTimingDisplayCategory: ").Append(smo.TimingDisplayCategory);
            text.Append("\nvendingMachine: ").Append(smo.vendingMachine);
            text.Append("\nvendorObject: ").Append(smo.vendorObject);
            text.Append("\nworkSortOrder: ").Append(smo.workSortOrder);
            text.Append("\nGetZone: ").Append(smo.GetZone());
            text.Append("\nInSecureArea: ").Append(smo.InSecureArea());
            text.Append("\nInspect:-----\n ").Append(smo.Inspect()).Append("\n-----");
            text.Append("\nIsStaffed: ").Append(smo.IsStaffed());
            text.Append("\nNumberOfStaffServing: ").Append(smo.NumberOfStaffServing());

            return text.ToString();
        }
        private String PlaceableConfigData(PlaceableObjectConfig poc)
        {
            StringBuilder text = new StringBuilder();

            text.Append("\n-----PlaceableConfig Data-----");
            text.Append("\nAssetPath: ").Append(poc.AssetPath);
            text.Append("\nbackFacing: ").Append(FacingConfigData(poc.backFacing));
            text.Append("\nBlockedByProps");
            foreach (PlaceableObject.GroupType gt in poc.BlockedByProps)
            {
                text.Append("\n\t").Append(gt);
            }
            text.Append("\nbWriteToMapCache: ").Append(poc.bWriteToMapCache);
            text.Append("\nComponentConfigData: ").Append(poc.ComponentConfigData.ToString());
            text.Append("\nconstructionDuration: ").Append(poc.constructionDuration);
            text.Append("\nconstructionType: ").Append(poc.constructionType);
            text.Append("\nCreatePrice: ").Append(poc.CreatePrice);
            text.Append("\nDisplayCategories: ");
            foreach (UIModal.DisplayCategory dc in poc.DisplayCategories)
            {
                text.Append("\n\t").Append(dc);
            }
            text.Append("\nfrontFacing: ").Append(FacingConfigData(poc.frontFacing));
            text.Append("\nheight: ").Append(poc.height);
            text.Append("\nHidden: ").Append(poc.Hidden);
            text.Append("\nHourlyPrice: ").Append(poc.HourlyPrice);
            text.Append("\nHourlyPriceCategory: ").Append(poc.HourlyPriceCategory);
            text.Append("\nInvariantModel: ").Append(poc.InvariantModel);
            text.Append("\ni18nDescKey: ").Append(poc.i18nDescKey);
            text.Append("\ni18nNameKey: ").Append(poc.i18nNameKey);
            text.Append("\nisDestroyable: ").Append(poc.isDestroyable);
            text.Append("\nIsModded: ").Append(poc.IsModded);
            text.Append("\nisPseudoWall: ").Append(poc.isPseudoWall);
            text.Append("\nleftFacing: ").Append(FacingConfigData(poc.leftFacing));
            text.Append("\nLocalizedName: ").Append(poc.LocalizedName);
            text.Append("\nMaintainable_MTBF: ").Append(poc.Maintainable_MTBF);
            text.Append("\nMaxAllowed: ").Append(poc.MaxAllowed);
            text.Append("\nname: ").Append(poc.name);
            text.Append("\npath: ").Append(poc.path);
            text.Append("\nPlacementSound: ").Append(poc.PlacementSound);
            text.Append("\nrequiredAdministrators: ");
            foreach(string str in poc.requiredAdministrators)
            {
                text.Append("\n\t").Append(str);
            }
            text.Append("\nRequiredLevels: ");
            foreach(TechTreeLevel.TechTreeLevels ttl in poc.RequiredLevels)
            {
                text.Append("\n\t").Append(ttl);
            }
            text.Append("\nRequiresGameObject: ").Append(poc.RequiresGameObject);
            text.Append("\nrequiresSectorRebuild: ").Append(poc.requiresSectorRebuild);
            text.Append("\nrequiresSecureArea: ").Append(poc.requiresSecureArea);
            text.Append("\nrightFacing: ").Append(FacingConfigData(poc.rightFacing));
            text.Append("\nrotateType: ").Append(poc.rotateType);
            text.Append("\nShouldDezone: ").Append(poc.ShouldDezone);
            text.Append("\nsnapToGridSize: ").Append(poc.snapToGridSize);
            text.Append("\nStaffRequired: ").Append(poc.StaffRequired);
            text.Append("\nwidth: ").Append(poc.width);
            text.Append("\nZeroAllocName: ").Append(poc.ZeroAllocName);

            return text.ToString();
        }

        private StringBuilder FacingConfigData(FacingConfig fc)
        {
            StringBuilder text = new StringBuilder();
            if (fc == null)
            {
                return text;
            }
            text.Append("\n\tenabled: ").Append(fc.enabled);
            foreach(Marker mo in fc.markers)
            {
                text.Append(MarkerData(mo));
            }
            return text;
        }
        private StringBuilder MarkerData(Marker mo)
        {
            StringBuilder text = new StringBuilder();

            text.Append("\n\tmarkerTag: ").Append(mo.tag);
            text.Append("\n\t\tblocksConstruction: ").Append(mo.blocksConstruction);
            text.Append("\n\t\treceiverType: ").Append(mo.receiverType);
            text.Append("\n\t\tRelativeLevel: ").Append(mo.RelativeLevel);
            text.Append("\n\t\trotateEnabled: ").Append(mo.rotateEnabled);
            text.Append("\n\t\tselected: ").Append(mo.selected);
            text.Append("\n\t\torientation-X: ").Append(mo.orientation.x);
            text.Append("\n\t\torientation-Y: ").Append(mo.orientation.y);
            text.Append("\n\t\tposition-X: ").Append(mo.position.x);
            text.Append("\n\t\tposition-Y: ").Append(mo.position.y);
            text.Append("\n\t\tworldPosition: ").Append(mo.worldPosition);
            text.Append("\n\t\tdirection: ").Append(mo.direction);

            return text;
        }

        private StringBuilder GameObjectData(GameObject goo)
        {
            StringBuilder text = new StringBuilder();
            text.Append("\n\tactiveInHierarchy : ").Append(goo.activeInHierarchy);
            text.Append("\n\tactiveSelf : ").Append(goo.activeSelf);
            text.Append("\n\tgameObject : ").Append(goo.gameObject);
            text.Append("\n\tisStatic : ").Append(goo.isStatic);
            text.Append("\n\tlayer : ").Append(goo.layer);
            text.Append("\n\ttag : ").Append(goo.tag);
            text.Append("\n\tscene.buildIndex : ").Append(goo.scene.buildIndex);
            text.Append("\n\tscene.isLoaded : ").Append(goo.scene.isLoaded);
            text.Append("\n\tscene.isSubScene : ").Append(goo.scene.isSubScene);
            text.Append("\n\tscene.name : ").Append(goo.scene.name);
            text.Append("\n\ttag : ").Append(goo.tag);
            return text;
        }
    }
}

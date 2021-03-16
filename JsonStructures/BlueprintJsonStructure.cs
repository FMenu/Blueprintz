using System;
using System.Numerics;

namespace Blueprintz.JsonStructures
{
    public class BlueprintJsonStructure
    {
        public string Author;
        public string Description;
        public string ModifiedUtc;
        public Entity[] Entities;

        public BlueprintJsonStructure(string author, string description, DateTime currentTime, Firework[] _fireworks, Fuse[] _fuses)
        {
            Author = author;
            Description = description;
            ModifiedUtc = currentTime.ToString("o");
            Entities = new Entity[_fireworks.Length+_fuses.Length];
            for (int i = 0; i < _fireworks.Length; i++)
            {
                Firework _firework = _fireworks[i];
                Entities[i] = new Entity(_firework.id, _firework.fireworkIndentifier, _firework.position, _firework.rotation, _firework.isKinematic);
            }

            for (int i = 0; i < _fuses.Length; i++)
            {
                Fuse _fuse = _fuses[i];
                Entities[i+_fireworks.Length] = new Entity(_fuse.id, "FuseConnectionEntityDefinition", _fuse.speed, _fuse.idConnectionA, _fuse.idConnectionB);
            }
        }
    }
}

public class Entity
{
    public string EntityInstanceId;
    public string EntityDefinitionId;
    public CustomComponent CustomComponentData;

    public Entity(string instanceId, string definitionId, Vector3 position, Quaternion rotations, bool isKinematic)
    {
        EntityInstanceId = instanceId;
        EntityDefinitionId = definitionId;
        CustomComponentData = new CustomComponent(definitionId, position, rotations, isKinematic);
    }

    public Entity(string instanceId, string definitionId, int FuseSpeed, string FuseAOwnerId, string FuseBOwnerId)
    {
        EntityInstanceId = instanceId;
        EntityDefinitionId = definitionId;
        CustomComponentData = new CustomComponent(definitionId, FuseSpeed, FuseAOwnerId, FuseBOwnerId);
    }

    public class CustomComponent
    {
        public Behavior RocketBehavior;
        public Behavior CakeBehavior;
        public Behavior PreloadedTubeBehavior;
        public Behavior FirecrackerBehavior;
        public Behavior RomanCandleBehavior;
        public Behavior ZipperBehavior;
        public Behavior WhistlerBehavior;

        public Behavior FuseConnection;

        public CustomComponent(string definitionId, Vector3 pos, Quaternion rotation, bool kinematic)
        {
            if (definitionId.StartsWith("Rocket_")) RocketBehavior = new Behavior(pos, rotation, kinematic);
            else if (definitionId.StartsWith("Cake_")) CakeBehavior = new Behavior(pos, rotation, kinematic);
            else if (definitionId.StartsWith("PreloadedTube_")) PreloadedTubeBehavior = new Behavior(pos, rotation, kinematic);
            else if (definitionId.StartsWith("Firecracker_")) FirecrackerBehavior = new Behavior(pos, rotation, kinematic);
            else if (definitionId.StartsWith("RomanCandle_")) RomanCandleBehavior = new Behavior(pos, rotation, kinematic);
            else if (definitionId.StartsWith("Zipper_")) ZipperBehavior = new Behavior(pos, rotation, kinematic);
            else if (definitionId.StartsWith("Whistler_")) WhistlerBehavior = new Behavior(pos, rotation, kinematic);
        }

        public CustomComponent(string definitionId, int FuseSpeed, string FuseAOwnerId, string FuseBOwnerId)
        {
            switch (FuseSpeed)
            {
                case 1:
                    FuseConnection = new Behavior("SlowFuseConnectionType", FuseAOwnerId, FuseBOwnerId);
                    break;
                case 2:
                    FuseConnection = new Behavior("MediumFuseConnectionType", FuseAOwnerId, FuseBOwnerId);
                    break;
                case 3:
                    FuseConnection = new Behavior("FastFuseConnectionType", FuseAOwnerId, FuseBOwnerId);
                    break;
                case 4:
                    FuseConnection = new Behavior("InstantFuseConnectionType", FuseAOwnerId, FuseBOwnerId);
                    break;
            }
        }
    }
    public class Behavior
    {
        public CustomData CustomData;

        public Behavior(Vector3 pos, Quaternion rot, bool kin)
        {
            CustomData = new CustomData(pos, rot, kin);
        }

        public Behavior(string FuseTypeId, string FuseAOwnerId, string FuseBOwnerId)
        {
            CustomData = new CustomData(FuseTypeId, FuseAOwnerId, FuseBOwnerId);
        }
    }

    public class CustomData
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public bool IsKinematic;

        public string FuseTypeId;
        public string FuseAOwnerId;
        public string FuseBOwnerId;

        public CustomData(Vector3 pos, Quaternion rot, bool kin)
        {
            this.Position = pos;
            this.Rotation = rot;
            this.IsKinematic = kin;
        }

        public CustomData(string FuseTypeId, string FuseAOwnerId, string FuseBOwnerId)
        {
            this.FuseTypeId = FuseTypeId;
            this.FuseAOwnerId = FuseAOwnerId;
            this.FuseBOwnerId = FuseBOwnerId;
        }
    }
}
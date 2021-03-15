using System.Numerics;

namespace Blueprintz.JsonStructures
{
    public class FMCakeJsonStructure
    {
        public string Author;
        public string Description;
        public string ModifiedUtc;
        public EntitiesArray[] Entities;

        public FMCakeJsonStructure(string author, string description, string utc, int arraySize, string[] guids, string[] defIds, Vector3[] positions, Quaternion[] rotations, bool[] areKinematic)
        {
            Author = author;
            Description = description;
            ModifiedUtc = utc;
            Entities = new EntitiesArray[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Entities[i] = new EntitiesArray
                (
                    guids[i], defIds[i], positions[i],
                    rotations[i], areKinematic[i]
                );
            }
        }

        public class EntitiesArray
        {
            public EntitiesArray(string instanceId, string definitionId, Vector3 position, Quaternion rotations, bool isKinematic)
            {
                EntityInstanceId = instanceId;
                EntityDefinitionId = definitionId;
                CustomComponentData = new Data1(position, rotations, isKinematic);
            }
            public string EntityInstanceId;
            public string EntityDefinitionId;
            public Data1 CustomComponentData;
            public class Data1
            {
                public Data1(Vector3 pos, Quaternion rotation, bool kinematic)
                    => CakeBehavior = new Behavior(pos, rotation, kinematic);
                public Behavior CakeBehavior;
                public class Behavior
                {
                    public Vector3 Position;
                    public Quaternion Rotation;
                    public bool IsKinematic;
                    public Behavior(Vector3 pos, Quaternion rot, bool kin)
                    {
                        Position = pos;
                        Rotation = rot;
                        IsKinematic = kin;
                    }
                }
            }
        }
    }
}

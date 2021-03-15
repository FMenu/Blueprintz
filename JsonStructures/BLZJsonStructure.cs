using System.Numerics;

namespace Blueprintz.JsonStructures
{
    public class BLZJsonStructure
    {
        public string map;
        public FireworksArray[] fireworks;
        public FuseArray[] fuses;

        public BLZJsonStructure(string map, int fireworksArraySize, int fuseArraySize, bool hasFuses, string[] ids, string[] names, Vector3[] positions, Quaternion[] rotations, bool[] areStatic, int[] speeds, string [][] connected)
        {
            this.map = map;
            fireworks = new FireworksArray[fireworksArraySize];
            for (int i = 0; i < fireworksArraySize; i++)
                fireworks[i] = new FireworksArray(ids[i], names[i], positions[i], rotations[i], areStatic[i]);
            if (hasFuses)
            {
                fuses = new FuseArray[fuseArraySize];
                for (int i = 0; i < fuseArraySize; i++)
                    fuses[i] = new FuseArray(speeds[i], connected[i]);
            }
            else fuses = new FuseArray[0];
        }

        public class FireworksArray
        {
            public string id;
            public string name;
            public Vector3 position;
            public Quaternion rotation;
            public bool isFixed;
            public FireworksArray(string id, string name, Vector3 pos, Quaternion rot, bool isFixed)
            {
                this.id = id;
                this.name = name;
                this.isFixed = isFixed;
                position = pos;
                rotation = rot;
            }
        }

        public class FuseArray
        {
            public int speed;
            public string[] connected;
            public FuseArray(int speed, string[] connected)
            {
                this.speed = speed;
                this.connected = connected;
            }
        }
    }
}

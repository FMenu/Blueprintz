using Blueprintz.JsonStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Blueprintz.Editor
{
    public class Fireworks
    {
        private Dictionary<string, Firework> fireworks = new Dictionary<string, Firework>();
        private Dictionary<string, Fuse> fuses = new Dictionary<string, Fuse>();
        private string name, description, map;
        public Fireworks(string name, string description, Map map)
        {
            this.name = name;
            this.description = description;
            this.map = map.ToDescriptionString();
        }


        public BLZJsonStructure ToBLZStructure()
        {
            GetValueArrays(out Firework[] fireworks, out Fuse[] fuses);
            return new BLZJsonStructure(name, description, map, fireworks, fuses);
        }

        public BlueprintJsonStructure ToBlueprintStructure()
        {
            GetValueArrays(out Firework[] fireworks, out Fuse[] fuses);
            return new BlueprintJsonStructure("Blueprintz by FMenu", description, DateTime.UtcNow, fireworks, fuses);
        }

        public void GetValueArrays(out Firework[] _fireworks, out Fuse[] _fuses)
        {
            KeyValuePair<string, Firework>[] fireworkPair = this.fireworks.ToArray();
            KeyValuePair<string, Fuse>[] fusePair = this.fuses.ToArray();
            List<Firework> fireworks = new List<Firework>();
            List<Fuse> fuses = new List<Fuse>();
            foreach (KeyValuePair<string, Firework> pair in fireworkPair) fireworks.Add(pair.Value);
            foreach (KeyValuePair<string, Fuse> pair in fusePair) fuses.Add(pair.Value);
            _fireworks = fireworks.ToArray();
            _fuses = fuses.ToArray();
        }

        public string AddFirework(Firework firework)
        {
            string identifier = Guid.NewGuid().ToString();
            fireworks.Add(identifier, firework);
            return identifier;
        }

        public Firework GetFirework(string id) => fireworks[id];
        public Fuse GetFuse(string id) => fuses[id];

        public string AddFuse(string fromId, string toId, FuseSpeed speed)
        {
            if (fireworks.TryGetValue(fromId, out Firework firework) && fireworks.TryGetValue(toId, out Firework firework1))
            {
                Fuse fuse = new Fuse(Guid.NewGuid(), firework.id, firework1.id, (int)speed);
                string identifier = Guid.NewGuid().ToString();
                fuses.Add(identifier, fuse);
                return identifier;
            }
            else return null;
        }

        public bool RemoveFirework(string id) => fireworks.Remove(id);
    }

    public enum FuseSpeed : uint
    {
        Slow = 3,
        Medium = 2,
        Fast = 1,
        Instant = 0
    }

    public enum Map
    {
        [Description("town")]
        Town = 1,
        [Description("ranch")]
        Ranch = 2
    }
}

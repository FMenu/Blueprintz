using System;
using System.Numerics;

namespace Blueprintz.JsonStructures
{
    public class BLZJsonStructure
    {
        public string projectName;
        public string projectDescription;
        public string map;
        public Firework[] fireworks;
        public Fuse[] fuses;

        public BLZJsonStructure(string _projectName, string _projectDescription, string _map, Firework[] _fireworks, Fuse[] _fuses)
        {
            this.projectName = _projectName;
            this.projectDescription = _projectDescription;
            this.map = _map;
            this.fireworks = _fireworks;
            this.fuses = _fuses;
        }
    }
}

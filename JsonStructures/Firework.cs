using System;
using System.Numerics;

namespace Blueprintz.JsonStructures
{
    public class Firework
    {
        public string id;
        public string fireworkIndentifier;
        public Vector3 position;
        public Quaternion rotation;
        public bool isKinematic;

        public Firework(string _fireworkIndentifier, Vector3 _position, Quaternion _rotation, bool _isKinematic, Guid _id = new Guid())
        {
            if (_id == new Guid()) _id = Guid.NewGuid();
            this.id = _id.ToString();
            this.fireworkIndentifier = _fireworkIndentifier;
            this.position = _position;
            this.rotation = _rotation;
            this.isKinematic = _isKinematic;
        }
    }
}
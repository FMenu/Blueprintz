using System;

namespace Blueprintz.JsonStructures
{
    public class Fuse
    {
        public string id;
        public string idConnectionA;
        public string idConnectionB;
        public int speed;

        public Fuse(Guid _id, string _idConnectionA, string _idConnectionB, int _speed)
        {
            this.id = _id.ToString();
            this.idConnectionA = _idConnectionA;
            this.idConnectionB = _idConnectionB;
            this.speed = _speed;
        }
    }
}
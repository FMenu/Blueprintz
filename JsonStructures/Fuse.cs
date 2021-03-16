namespace Blueprintz.JsonStructures
{
    public class Fuse
    {
        public string id;
        public string idConnectionA;
        public string idConnectionB;
        public int speed;

        public Fuse(string _id, string _idConnectionA, string _idConnectionB, int _speed)
        {
            this.id = _id;
            this.idConnectionA = _idConnectionA;
            this.idConnectionB = _idConnectionB;
            this.speed = _speed;
        }
    }
}
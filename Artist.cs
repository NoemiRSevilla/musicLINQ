using System;

namespace JsonData {
    public class Artist {
        public string ArtistName;
        public string RealName;
        public int Age;
        public string Hometown;
        public int GroupId;
        public Group Group;

        internal static Artist Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
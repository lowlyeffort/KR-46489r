using System;
using System.Collections.Generic;
using System.Text;

namespace KR_46489r
{
    public class Galaxy
    {
        public string galaxyname;
        public string GalaxyName
        {
            get { return this.galaxyname; }
            set { this.galaxyname = value; }
        }
        public string galaxytype;
        public string Type
        {
            get { return this.galaxytype; }
            set { this.galaxytype = value; }
        }
        public string galaxyage;
        public string Age
        {
            get { return this.galaxyage; }
            set
            {
                if (!double.TryParse(value.Remove(value.Length - 1, 1), out _) || char.ToLower(value[^1]) != 'M' && char.ToLower(value[^1]) != 'B')
                { this.galaxyage = value; }
                else
                { throw new ArgumentException("You have entered an improper age value!"); }
            }
        }
    }
}
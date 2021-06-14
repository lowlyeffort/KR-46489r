using System;
using System.Collections.Generic;
using System.Text;

namespace KR_46489r
{
    // ne uspqh da napravq raboteshta proverka za klasa na zvezdite
    // zatova kato izhod izlizat vkaranite ot input danni
    public class Star
    {
        public string GalaxyName { get; set; }
        public string starname;
        public string StarName
        {
            get { return this.starname; }
            set { this.starname = value; }
        }
        public string starType;
        public string StarType
        {
            get { return this.starType; }
            set { this.starType = value; }
        }
    }
    public class Planet
    {
        public string StarName { get; set; }
        public string planetname;
        public string PlanetName
        {
            get { return this.planetname; }
            set { this.planetname = value; }
        }
        public string Data { get; set; }
    }
    public class Moon
    {
        public string PlanetName { get; set; }
        public string moonname;
        public string MoonName
        {
            get { return this.moonname; }
            set { this.moonname = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Galaxy> galaxies = new List<Galaxy>();
            List<Star> stars = new List<Star>();
            List<Planet> planets = new List<Planet>();
            List<Moon> moons = new List<Moon>();
            string input = Console.ReadLine().Trim();
            string[] data = input.Split(' ');
            while (!"exit".Equals(input))
            {
                if ("add".Equals(data[0]))
                {
                    switch (data[1])
                    {
                        case "galaxy":
                            string[] typesOfGalaxies =
                                {"elliptical", "lenticular", "spiral", "irregular"};
                            string galaxyName = input.Split('[')[1].Split(']')[0];
                            Galaxy galaxy = new Galaxy();
                            galaxy.galaxyname = galaxyName;

                            if (Array.Exists(typesOfGalaxies, element => element == input.Split(']')[1].Split()[1]))
                            {
                                galaxy.galaxytype = input.Split(']')[1].Split(' ')[1];
                            }
                            else
                            {
                                throw new ArgumentException("You have entered an unknown/undocumented type of galaxy!");
                            }
                            galaxy.galaxyage = input.Split(']')[1].Split(' ')[2];
                            galaxies.Add(galaxy);
                            break;

                        case "star":
                            Star star = new Star
                            {
                                GalaxyName = input.Split('[')[1].Split(']')[0],
                                starname = input.Split('[')[2].Split(']')[0],
                                StarType = input.Split(']')[2].Trim() 
                            };
                            stars.Add(star);
                            break;

                        case "planet":
                            Planet planet = new Planet();
                            string[] planetType = {"terrestrial", "giant planet", "ice giant", "mesoplanet", "mini-neptune", "planetar", "super-earth", "super-jupiter", "sub-earth"};
                            Planet newPlanet = new Planet
                            {
                                StarName = input.Split('[')[1].Split(']')[0],
                                planetname = input.Split('[')[2].Split(']')[0]
                            };
                            string planetData = input.Split(']')[2].Trim();
                            if (Array.Exists(planetType, value => value == planetData.Remove(planetData.Length - 3).Trim()))
                            {
                                newPlanet.Data = planetData;
                            }
                            else
                            {
                                throw new ArgumentException("Improper or wrong planet!" + planetData.Split(' ')[^1]);
                            }
                            planets.Add(newPlanet);
                            break;
                        case "moon":
                            Moon moon = new Moon
                            {
                                PlanetName = input.Split('[')[1].Split(']')[0],
                                moonname = input.Split('[')[2].Split(']')[0]
                            };
                            moons.Add(moon);
                            break;
                    }
                }
                else if ("stats".Equals(data[0]))
                {
                    Console.WriteLine("--- Stats ---");
                    Console.WriteLine($"Galaxies: {galaxies.Count}");
                    Console.WriteLine($"Stars: {stars.Count}");
                    Console.WriteLine($"Planets: {planets.Count}");
                    Console.WriteLine($"Moons: {moons.Count}");
                    Console.WriteLine("--- End of stats ---");
                }
                else if ("list".Equals(data[0]))
                {
                    string ObjectsOf = "";
                    switch (data[1])
                    {
                        case "galaxies":
                            Console.WriteLine("--- List of all researched galaxies ---");
                            foreach (var galaxy in galaxies)
                            {
                                ObjectsOf += galaxy.galaxyname + ", ";
                            }
                            Console.WriteLine(ObjectsOf.Remove(ObjectsOf.Length - 2, 2));
                            Console.WriteLine("--- End of galaxies list ---");
                            break;
                        case "stars":
                            Console.WriteLine("--- List of all researched stars ---");
                            foreach (var star in stars)
                            {
                                ObjectsOf += star.starname + ", ";
                            }
                            Console.WriteLine(ObjectsOf.Remove(ObjectsOf.Length - 2, 2));
                            Console.WriteLine("--- End of stars list ---");
                            break;
                        case "planets":
                            Console.WriteLine("--- List of all researched planets ---");
                            foreach (var planet in planets)
                            {
                                ObjectsOf += planet.planetname + ", ";
                            }
                            Console.WriteLine(ObjectsOf.Remove(ObjectsOf.Length - 2, 2));
                            Console.WriteLine("--- End of planets list ---");
                            break;
                        case "moons":
                            Console.WriteLine("--- List of all researched moons ---");
                            foreach (var moon in moons)
                            {
                                ObjectsOf += moon.moonname + ", ";
                            }
                            Console.WriteLine(ObjectsOf.Remove(ObjectsOf.Length - 2, 2));
                            Console.WriteLine("--- End of moons list ---");
                            break;
                        default:
                            Console.WriteLine("none");
                            break;
                    }
                }
                else if ("print".Equals(data[0]))
                {
                    string print = input.Split('[')[1].Split(']')[0];
                    Galaxy foundGalaxy = galaxies.Find(currentGalaxy => currentGalaxy.galaxyname == print);
                    if (foundGalaxy != null)
                    {
                        Console.WriteLine($"--- Data for {foundGalaxy.galaxyname} galaxy ---");
                        Console.WriteLine("Type: " + foundGalaxy.galaxytype);
                        Console.WriteLine("Age: " + foundGalaxy.galaxyage);
                        Console.WriteLine("Stars: ");
                    }
                    else
                    {
                        Console.WriteLine("none");
                    }
                    if (stars.Exists(star => star.GalaxyName == print))
                    {
                        foreach (Star star in stars)
                        {
                            if (star.GalaxyName == print)
                            {
                                Console.WriteLine("\tName: " + star.starname);
                                Console.WriteLine("\tClass: " + star.StarType);
                                Console.WriteLine("\tPlanets: ");

                                if (planets.Exists(planet => planet.StarName == star.starname))
                                {
                                    foreach (Planet planet in planets)
                                    {
                                        if (planet.StarName == star.starname)
                                        {
                                            Console.WriteLine("\t\tName: " + planet.planetname);
                                            Console.WriteLine("\t\tType: " + planet.Data.Remove(planet.Data.Length - 3).Trim());
                                            Console.WriteLine("\t\tSupport life: " + planet.Data.Split(' ')[^1]);
                                            Console.WriteLine("\t\tMoons: ");

                                            if (moons.Exists(moon => moon.PlanetName == planet.planetname))
                                            {
                                                foreach (Moon moon in moons)
                                                {
                                                    if (moon.PlanetName == planet.planetname)
                                                    {
                                                        Console.WriteLine("\t\t\t " + moon.moonname);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("none");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("none");
                                    Console.WriteLine("Moons: ");
                                    Console.WriteLine("none");
                                }
                            }
                        }
                        Console.WriteLine($"--- End of data for {print} galaxy ---");
                    }
                    else
                    {
                        Console.WriteLine("none");
                        Console.WriteLine("Planets: ");
                        Console.WriteLine("none");
                        Console.WriteLine("Moons: ");
                        Console.WriteLine("none");
                    }
                }
                input = Console.ReadLine().Trim();
                data = input.Split(' ');
            }
        }
    }
}
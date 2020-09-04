using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist vernonArtist = Artists.FirstOrDefault(artist => artist.Hometown == "Mount Vernon");
            Console.WriteLine(vernonArtist.ArtistName, vernonArtist.Age);

            //Who is the youngest artist in our collection of artists?
            List<Artist> youngestArtist = Artists.OrderBy(artists => artists.Age).ToList();
            Console.WriteLine(youngestArtist[0].ArtistName);

            //Display all artists with 'William' somewhere in their real name
            List<Artist> william = Artists.Where(artists => artists.RealName.Contains("William")).ToList();
            Console.WriteLine(william);
            // Display all groups with names less than 8 characters in length.
            List<Group> eightCharacters = Groups.Where(groups => groups.GroupName.Length == 8).ToList();
            Console.WriteLine(eightCharacters);
            //Display the 3 oldest artist from Atlanta
            List<Artist> ATL = Artists.OrderByDescending(artists => artists.Hometown.Contains("Atlanta")).ToList();
            Console.WriteLine(ATL[0].ArtistName);
            Console.WriteLine(ATL[1].ArtistName);
            Console.WriteLine(ATL[2].ArtistName);
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var joinedGroups = Groups.Join(Artists,
                g => g.Id,
                a => a.GroupId,
                (joinedGroups, joinedA) => {
                    joinedGroups.Members.Add(joinedA);
                    return joinedGroups;
            }).ToList();

            List<Group> notNewYork = joinedGroups.Where(g=>g.Members.Any(a=>a.Hometown!="New York City")).ToList();

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            // List<Group> wuTangClan = joinedGroups.Where(g => g.GroupName.Contains("Wu-Tang Clan").Select(g.Members)).ToList();
            List<Artist> WTmembers = Groups.FirstOrDefault(g => g.GroupName == "Wu-Tang Clan").Members;
            foreach (var member in WTmembers)
            {
                Console.WriteLine(member.ArtistName);
            }
            Console.WriteLine(Groups.Count);
        }
    }
}
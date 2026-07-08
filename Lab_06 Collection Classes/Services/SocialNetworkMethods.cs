using Lab_06_Collection_Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_06_Collection_Classes.Services
{
    internal class SocialNetworkMethods
    {
        static Dictionary<string, SocialUser> users = new Dictionary<string, SocialUser>();
        public static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nSocial Network");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Friend");
                Console.WriteLine("3. Add Interest");
                Console.WriteLine("4. Show User");
                Console.WriteLine("5. Find Mutual Friends");
                Console.WriteLine("6. Suggest Friends by Interest");
                Console.WriteLine("7. Remove Duplicate Tags");
                Console.WriteLine("0. Exit");

                Console.Write("Enter Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;

                    case 2:
                        AddFriend();
                        break;

                    case 3:
                        AddInterest();
                        break;

                    case 4:
                        ShowUser();
                        break;

                    case 5:
                        FindMutualFriends();
                        break;

                    case 6:
                        SuggestFriends();
                        break;

                    case 7:
                        RemoveDuplicateTags();
                        break;
                }
            } while (choice != 0);
        }

        static void AddUser()
        {
            Console.Write("Enter User Name : ");
            string name = Console.ReadLine();

            users[name] = new SocialUser(name);

            Console.WriteLine("User Added.");
        }

        static void AddFriend()
        {
            Console.Write("Enter User Name : ");
            string user = Console.ReadLine();

            Console.Write("Enter Friend Name : ");
            string friend = Console.ReadLine();

            if (users.ContainsKey(user))
            {
                users[user].Friends.Add(friend);
                Console.WriteLine("Friend Added.");
            }
        }

        static void AddInterest()
        {
            Console.Write("Enter User Name : ");
            string user = Console.ReadLine();

            Console.Write("Enter Interest : ");
            string interest = Console.ReadLine();

            if (users.ContainsKey(user))
            {
                users[user].Interests.Add(interest);
                Console.WriteLine("Interest Added.");
            }
        }

        static void ShowUser()
        {
            Console.Write("Enter User Name : ");
            string user = Console.ReadLine();

            if (!users.ContainsKey(user))
                return;

            Console.WriteLine("\nFriends");

            foreach (string f in users[user].Friends)
                Console.WriteLine(f);

            Console.WriteLine("\nInterests");

            foreach (string i in users[user].Interests)
                Console.WriteLine(i);
        }

        static void FindMutualFriends()
        {
            Console.Write("Enter First User : ");
            string u1 = Console.ReadLine();

            Console.Write("Enter Second User : ");
            string u2 = Console.ReadLine();

            if (users.ContainsKey(u1) && users.ContainsKey(u2))
            {
                HashSet<string> mutual = new HashSet<string>(users[u1].Friends);

                mutual.IntersectWith(users[u2].Friends);

                Console.WriteLine("\nMutual Friends");

                foreach (string f in mutual)
                    Console.WriteLine(f);
            }
        }

        static void SuggestFriends()
        {
            Console.Write("Enter User Name : ");
            string user = Console.ReadLine();

            if (!users.ContainsKey(user))
                return;

            Console.WriteLine("\nSuggested Users");

            foreach (var u in users)
            {
                if (u.Key == user)
                    continue;

                HashSet<string> common = new HashSet<string>(users[user].Interests);

                common.IntersectWith(u.Value.Interests);

                if (common.Count > 0)
                    Console.WriteLine(u.Key);
            }
        }

        static void RemoveDuplicateTags()
        {
            HashSet<string> tags = new HashSet<string>();

            Console.Write("How Many Tags : ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Enter Tag : ");
                tags.Add(Console.ReadLine());
            }

            Console.WriteLine("\nUnique Tags");

            foreach (string tag in tags)
                Console.WriteLine(tag);
        }
    }
}

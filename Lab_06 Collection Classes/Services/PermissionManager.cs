using System;
using System.Collections.Generic;
using Lab_06_Collection_Classes.Models;

namespace Lab_06_Collection_Classes.Services
{
    internal class PermissionMethods
    {
        static Dictionary<string, HashSet<string>> roles = new Dictionary<string, HashSet<string>>();
        static Dictionary<string, User> users = new Dictionary<string, User>();
        public static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nRole Based Permission System");
                Console.WriteLine("1. Add Role");
                Console.WriteLine("2. Add Permission to Role");
                Console.WriteLine("3. Add User");
                Console.WriteLine("4. Assign Role to User");
                Console.WriteLine("5. Show User Permissions");
                Console.WriteLine("6. Check Permission");
                Console.WriteLine("7. Merge Permissions");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Role Name : ");
                        string role = Console.ReadLine();
                        AddRole(role);
                        Console.WriteLine("Role Added Successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Role Name : ");
                        role = Console.ReadLine();

                        Console.Write("Enter Permission : ");
                        string permission = Console.ReadLine();

                        AddPermission(role, permission);
                        Console.WriteLine("Permission Added Successfully.");
                        break;

                    case 3:
                        Console.Write("Enter User Name : ");
                        string user = Console.ReadLine();

                        AddUser(user);
                        Console.WriteLine("User Added Successfully.");
                        break;

                    case 4:
                        Console.Write("Enter User Name : ");
                        user = Console.ReadLine();

                        Console.Write("Enter Role Name : ");
                        role = Console.ReadLine();

                        AssignRole(user, role);
                        Console.WriteLine("Role Assigned Successfully.");
                        break;

                    case 5:
                        Console.Write("Enter User Name : ");
                        user = Console.ReadLine();

                        ShowPermissions(user);
                        break;

                    case 6:
                        Console.Write("Enter User Name : ");
                        user = Console.ReadLine();

                        Console.Write("Enter Permission : ");
                        permission = Console.ReadLine();

                        if (CheckPermission(user, permission))
                            Console.WriteLine("Permission Granted");
                        else
                            Console.WriteLine("Permission Denied");

                        break;

                    case 7:
                        Console.Write("Enter First Role : ");
                        string role1 = Console.ReadLine();

                        Console.Write("Enter Second Role : ");
                        string role2 = Console.ReadLine();

                        Console.WriteLine("Merged Permissions :");
                        MergePermissions(role1, role2);
                        break;

                    case 0:
                        Console.WriteLine("Program Ended.");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

            } while (choice != 0);
        }

        static void AddRole(string role)
        {
            roles[role] = new HashSet<string>();
        }

        static void AddPermission(string role, string permission)
        {
            roles[role].Add(permission);
        }

        static void AddUser(string name)
        {
            users[name] = new User(name);
        }

        static void AssignRole(string user, string role)
        {
            users[user].Roles.Add(role);
        }

        static bool CheckPermission(string user, string permission)
        {
            foreach (string role in users[user].Roles)
            {
                if (roles[role].Contains(permission))
                    return true;
            }

            return false;
        }

        static void ShowPermissions(string user)
        {
            HashSet<string> permissions = new HashSet<string>();

            foreach (string role in users[user].Roles)
            {
                permissions.UnionWith(roles[role]);
            }

            foreach (string p in permissions)
            {
                Console.WriteLine(p);
            }
        }

        static void MergePermissions(string role1, string role2)
        {
            HashSet<string> merged = new HashSet<string>();

            merged.UnionWith(roles[role1]);
            merged.UnionWith(roles[role2]);

            foreach (string p in merged)
            {
                Console.WriteLine(p);
            }
        }
    }
}
/*
===== Role Based Permission System =====
1. Add Role
2. Add Permission to Role
3. Add User
4. Assign Role to User
5. Show User Permissions
6. Check Permission
7. Merge Permissions
0. Exit

Enter Choice : 1
Enter Role Name : Admin
Role Added Successfully.

Enter Choice : 2
Enter Role Name : Admin
Enter Permission : Read
Permission Added Successfully.

Enter Choice : 2
Enter Role Name : Admin
Enter Permission : Write
Permission Added Successfully.

Enter Choice : 3
Enter User Name : Bhavik
User Added Successfully.

Enter Choice : 4
Enter User Name : Bhavik
Enter Role Name : Admin
Role Assigned Successfully.

Enter Choice : 5
Enter User Name : Bhavik
Read
Write

Enter Choice : 6
Enter User Name : Bhavik
Enter Permission : Write
Permission Granted

Enter Choice : 7
Enter First Role : Admin
Enter Second Role : Viewer
Merged Permissions:
Read
Write

Enter Choice : 0
Program Ended.
*/
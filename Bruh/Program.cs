// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;

// Nama: Muhammad Athariq Purbaya
// Nickname : 12.Purbaya
// ID: 1955723840 - 547

public class Person
{
    public int id;
    public string fname;
    public string lname;
    public string password;
    public string username;

    public Person(int id, string fname, string lname, string password, string username)
    {
        this.id = id;
        this.fname = fname;
        this.lname = lname;
        this.password = password;
        this.username = username;
    }

    static int searchId(List<Person> p, int identity)
    {
        int count = 0;
        foreach (Person person in p)
        {
            if (person.id == identity)
            {
                return count;
            }
            count++;
        }
        Console.WriteLine("Id Tidak Ditemukan.");
        return -1;
    }

    static bool checkPW(string pw)
    {
        if (pw.Any(c => char.IsDigit(c) == true)) 
        {
            if (pw.Any(char.IsUpper) == true)
            {
                if (pw.Any(char.IsLower) == true)
                {
                    if (pw.Length > 7)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public static void Main()
    {
        int identification = 1;
        bool selesai = false;
        List<Person> persCollection = new List<Person>(100);
        while (selesai == false)
        {
            Console.Clear();
            Console.WriteLine("== BASIC AUTHENTICATION ==");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("5. Exit");
            Console.Write("Input : ");
            string choice = Console.ReadLine();

            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Masukkan Nama Depan : ");
                    string fname = Console.ReadLine();

                    Console.Write("Masukkan Nama Belakang : ");
                    string lname = Console.ReadLine();

                    Console.Write("Masukkan Password : ");
                    string password = Console.ReadLine();

                    if (checkPW(password) == false)
                    {
                        while (checkPW(password) == false)
                        {
                            Console.WriteLine("Password must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number. : ");
                            Console.Write("Password : ");
                            password = Console.ReadLine();
                        }
                    }

                    string username = fname[..2] + lname[..2];

                    persCollection.Add(new Person (identification, fname, lname, password, username));
                    Console.WriteLine(persCollection.Count());
                    identification = identification + 1;

                    Console.WriteLine();
                    Console.WriteLine("Data User Berhasil Dibuat");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("== SHOW USERS ==");
                    foreach (Person p in persCollection)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Id = " + p.id);
                        Console.WriteLine("Name = " + p.fname + " " + p.lname);
                        Console.WriteLine("Password = " + p.password);
                        Console.WriteLine("Username = " + p.username);
                        Console.WriteLine("==========================");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Menu");
                    Console.WriteLine("1. Edit User");
                    Console.WriteLine("2. Delete User");
                    Console.WriteLine("3. Back");
                    string subchoice1 = Console.ReadLine();

                    switch(subchoice1)
                    {
                         case "2":
                            Console.Write("Id Yang Ingin Dihapus :");
                            int idHapus = Convert.ToInt32(Console.ReadLine());
                            idHapus = searchId(persCollection, idHapus);
                            if (idHapus != -1 )
                            {
                                persCollection.Remove(persCollection[idHapus]);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Akun Berhasil Dihapus.");
                            Console.ReadLine();
                            break;

                         case "1":
                            Console.WriteLine("Id Yang Ingin Dihapus :");
                            int idUp = Convert.ToInt32(Console.ReadLine());
                            idUp = searchId(persCollection, idUp);
                            if (idUp != -1)
                            {
                                Console.Write("Masukkan Nama Depan : ");
                                string fnameSub = Console.ReadLine();

                                Console.Write("Masukkan Nama Belakang : ");
                                string lnameSub = Console.ReadLine();

                                Console.Write("Masukkan Password : ");
                                string passwordSub = Console.ReadLine();

                                if (checkPW(passwordSub) == false)
                                {
                                    while (checkPW(passwordSub) == false)
                                    {
                                        Console.WriteLine("Password must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number. : ");
                                        Console.Write("Password : ");
                                        passwordSub = Console.ReadLine();
                                    }
                                }

                                persCollection[idUp].fname = fnameSub;
                                persCollection[idUp].lname = lnameSub;
                                persCollection[idUp].password = passwordSub;
                            }
                            Console.WriteLine();
                            Console.WriteLine("Akun Berhasil Diperbarui.");
                            Console.ReadLine();
                            break;

                        case "3":
                            break;

                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Id Yang Ingin Dicari :");
                    int cari = Convert.ToInt32(Console.ReadLine());
                    cari = searchId(persCollection, cari);
                    if (cari != -1)
                    {
                        Console.WriteLine("==========================");
                        Console.WriteLine("Id = " + persCollection[cari].id);
                        Console.WriteLine("Name = " + persCollection[cari].fname + " " + persCollection[cari].lname);
                        Console.WriteLine("Password = " + persCollection[cari].password);
                        Console.WriteLine("Username = " + persCollection[cari].username);
                        Console.WriteLine("==========================");
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.Write("Username : ");
                    string un = Console.ReadLine();

                    Console.Write("Password : ");
                    string pw = Console.ReadLine();

                    foreach (Person item in persCollection)
                    {
                        if (item.username == un)
                        {
                            if (item.password == pw)
                            {
                                Console.WriteLine("Login Sukses");
                                Console.ReadLine();

                                pw = "yay109";
                                break;
                            }
                        }
                    }

                    if (pw != "yay109")
                    {
                        Console.WriteLine("Login Gagal");
                        Console.ReadLine();
                        break;
                    }
                    break;


                case "5":
                    selesai = true;
                    break;

            }
        }

    }
}

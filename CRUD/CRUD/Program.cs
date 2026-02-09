namespace CRUD;
internal class Program
{
    static List<string> Ids = new List<string>();
    static void Main(string[] args)
    {
        var newId = string.Empty;
        while (true)
        {
            Console.WriteLine("1. Add id");
            Console.WriteLine("2. Delete id");
            Console.WriteLine("3. Display id");
            Console.WriteLine("4. Update id");
            Console.WriteLine("5. Quit");
            Console.Write("Kiriting: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("ID ni kiriting: ");
                newId = Console.ReadLine();
                var res = ValidateId(newId);
                var exists = Ids.Contains(newId);
                if (res == true || exists == false)
                {
                    AddId(newId);
                    Console.WriteLine("ID muvaffaqiyatli qoshildi");

                }
                else
                {
                    Console.WriteLine("ID notogri formatta qoshildi");
                }
            }
            else if (choice == 2)
            {
                Console.Write("ID ni kiriting: ");
                newId = Console.ReadLine();
                var exists = Ids.Contains(newId);
                if (exists == true)
                {
                    DeleteId(newId);
                    Console.WriteLine("ID muvaffaqiyatli ochirildi");
                }
                else
                {
                    Console.WriteLine("Bunday id mavjud emas");

                }
            }
            else if (choice == 3)
            {
                DisplayIds();

            }

            else if (choice == 4)
            {
                Console.Write("Eski id ji kiriting: ");
                var oldId = Console.ReadLine();
                Console.Write("Yangi id ni kirting: ");
                newId = Console.ReadLine();
                var validateRes = ValidateId(newId);
                var exists = Ids.Contains(oldId);
                if (validateRes == true && exists == true)
                {
                    UpdateId(oldId, newId);
                    Console.WriteLine("ID muvaffaqiyatli yangilandi");

                }
                else
                {
                    Console.WriteLine("Id yangilashda xatolik yuz berdi");
                }
            }

            else
            {
                Console.WriteLine("quit");
                break;
            
            }
            
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void AddId(string id)
    {
        Ids.Add(id);
    }

    static void DeleteId(string id)
    {
        Ids.Remove(id);
    }

    static void DisplayIds()
    {
        foreach (var id in Ids)
        {
            Console.WriteLine(id);

        }
    }

    static void UpdateId(string oldId, string newId)
    {
        var index = Ids.IndexOf(oldId);
        if (index != -1)
        {
            Ids[index] = newId;
        }
    }

    static bool ValidateId(string id)
    {
        if (id.Length != 9)
        {
            return false;
        }

        if (!char.IsUpper(id[0]) || !char.IsUpper(id[1]))
        {
            return false;
        }

        for (int i = 2; i < id.Length; ++i)
        {
            if (!char.IsDigit(id[i]))
            {
                return false;
            }
        }
        return true;
    }
}
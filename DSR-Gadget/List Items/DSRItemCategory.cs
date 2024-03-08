using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
namespace DSR_Gadget
{
    class DSRItemCategory
    {
        public string Name;
        public int ID;
        public List<DSRItem> Items;

        private DSRItemCategory(string name, int id, string itemList, bool showIDs)
        {
            Name = name;
            ID = id;
            Items = new List<DSRItem>();

            foreach (string line in Regex.Split(itemList, "[\r\n]+"))
                Items.Add(new DSRItem(line, showIDs));
            Items.Sort();

        }

        public override string ToString()
        {
            return Name;
        }

        Dictionary<string, int> folderValues = new Dictionary<string, int>
{
    { "Armor", 0x10000000 },
    { "Spells", 0x40000000 },
    { "Items", 0x40000000 },
    { "Keys", 0x40000000 },
    { "Upgrade Material", 0x40000000 },
    { "Rings", 0x20000000 },
    { "Weapons", 0x00000000 }
};

        public static List<DSRItemCategory> All = new List<DSRItemCategory>()
{

}
 .Concat
(
    Directory.GetFiles("Armor", "*.txt")
    
    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x10000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
.Concat
(
    Directory.GetFiles("Keys", "*.txt")
    
    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x40000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
.Concat
(
    Directory.GetFiles("Weapons", "*.txt")

    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x00000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
            .Concat
(
    Directory.GetFiles("Upgrades", "*.txt")

    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x40000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
.Concat
(
    Directory.GetFiles("Rings", "*.txt")

    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x20000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
.Concat
(
    Directory.GetFiles("Goods", "*.txt")

    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x40000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
            .Concat
(
    Directory.GetFiles("Spells", "*.txt")

    .Select
    (
        file => new DSRItemCategory
        (
            char.IsDigit(Path.GetFileNameWithoutExtension(file)[0]) ? Path.GetFileNameWithoutExtension(file).Substring(1) : Path.GetFileNameWithoutExtension(file),
            0x40000000,
            File.ReadAllText(file),
            Path.GetFileNameWithoutExtension(file).StartsWith("1") ? true : false
        )
    )
 )
 .ToList();


    }

}

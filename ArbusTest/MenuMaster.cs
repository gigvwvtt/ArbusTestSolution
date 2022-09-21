using System.ComponentModel.DataAnnotations;

namespace ArbusTest;

public class MenuMaster
{
    public Item[][] Menu { get; private set; }
    private int totalPages;

    public MenuMaster(List<Item> items, int numberOfItemsOnPage)
    {
        var list = ItemsValidation(items);
        
        if (list.Count > 0)
            FillPages(list, numberOfItemsOnPage);
        else
            throw new Exception("В меню нет элементов");
    }

    public int GetItemsAmount()
    {
        return Menu.SelectMany(x => x).Count(x => x != null);
    }

    public int GetTotalPages()
    {
        return totalPages;
    }
    
    /// <param name="page">Значение от единицы</param>
    public int GetItemsCountFromPage(int page)
    {
        return Menu[page-1].Count(i => i != null);
    }
    
    /// <param name="page">Значение от единицы</param>
    public List<Item> GetItemsFromPage(int page)
    {
        return Menu[page-1].ToList();
    }

    public List<Item> GetFirstItemsFromPages()
    {
        var a = Menu.Select(x => x.First());
        return Menu.Select(x => x.First()).ToList();
    }

    private void FillPages(List<Item> items, int numberOfItemsOnPage)
    {
        totalPages = items.Count % 2 == 0
            ? items.Count / numberOfItemsOnPage
            : items.Count / numberOfItemsOnPage + 1;

        Menu = new Item[totalPages][];

        for (var j = 0; j < Menu.Length; j++)
        {
            Menu[j] = new Item[numberOfItemsOnPage];
            for (var k = 0; k < Menu[j].Length; k++)
            {
                var index = (Menu[j].Length * j) + k;
                Menu[j][k] = index < items.Count ? items[index] : null;
            }
        }
    }

    public static List<Item> ItemsValidation(List<Item> items)
    {
         var list = new List<Item>();
         
         foreach (var item in items)
         {
             if (string.IsNullOrWhiteSpace(item.Name))
                 throw new Exception("Не указано название блюда");
             if (item.Name.Length is < 2 or > 50)
                 throw new Exception("Некорректное имя блюда");
             if (item.Price < 0)
                 throw new Exception("Значение цены ниже нуля");
             else
                 list.Add(item);
         }
         return list;
    }
}
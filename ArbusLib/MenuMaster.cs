namespace ArbusTest;

public class MenuMaster
{
    public Item[][] Menu { get; private set; }
    private int _totalPages;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="items">Список позиций в меню</param>
    /// <param name="numberOfItemsOnPage">Количество позиций на каждой странице</param>
    /// <exception cref="Exception"></exception>
    public MenuMaster(List<Item> items, int numberOfItemsOnPage)
    {
        var list = ItemsValidation(items);

        if (list.Count > 0)
            FillPages(list, numberOfItemsOnPage);
        else
            throw new Exception("В меню нет элементов.");
    }

    public int GetItemsAmount()
    {
        try
        {
            return Menu.SelectMany(x => x).Count(x => x != null);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Элементы отсутствуют.\r\n{ex.Message}");
            return 0;
        }
    }

    public int GetTotalPages()
    {
        return _totalPages;
    }

    /// <param name="page">Значение от единицы</param>
    public int GetItemsCountFromPage(int page)
    {
        try
        {
            PageCheck(page);
            return Menu[page - 1].Count(i => i != null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }

    /// <param name="page">Значение от единицы</param>
    public List<Item> GetItemsFromPage(int page)
    {
        try
        {
            PageCheck(page);
            return Menu[page - 1].ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Item>();
        }
            
    }

    public List<Item> GetFirstItemsFromPages()
    {
        try
        {
            return Menu.Select(x => x.First()).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Item>();
        }
    }

    private void FillPages(List<Item> items, int numberOfItemsOnPage)
    {
        if (numberOfItemsOnPage <= 0)
            throw new Exception("Неправильно указано количество позиций на каждой странице");
        
        _totalPages = items.Count % numberOfItemsOnPage == 0
                    ? items.Count / numberOfItemsOnPage
                    : items.Count / numberOfItemsOnPage + 1;

        Menu = new Item[_totalPages][];

        try
        {
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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

    private void PageCheck(int page)
    {
        if (page > GetTotalPages() || page < 1)
            throw new Exception("Указана неверная страница");
    }
}
using ArbusTest;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void ItemsValidation_EmptyName_Test()
    {
        var list = new List<Item>()
        {
            new Item("", 2, Category.Alcohol)
        };
        var test = () => MenuMaster.ItemsValidation(list);

        var exception = Assert.Throws<Exception>(test);
        var expected = "Не указано название блюда";
        Assert.Equal(expected, exception.Message);
    }
    
    [Fact]
    public void ItemsValidation_ShortName_Test()
    {
        var list = new List<Item>()
        {
            new Item("a", 2, Category.Alcohol)
        };
        var test = () => MenuMaster.ItemsValidation(list);

        var exception = Assert.Throws<Exception>(test);
        var expected = "Некорректное имя блюда";
        Assert.Equal(expected, exception.Message);
    }

    [Fact]
    public void ItemsValidation_LongName_Test()
    {
        var list = new List<Item>()
        {
            new Item("sddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", 2, Category.Alcohol)
        };
        var test = () => MenuMaster.ItemsValidation(list);

        var exception = Assert.Throws<Exception>(test);
        var expected = "Некорректное имя блюда";
        Assert.Equal(expected, exception.Message);
    }

    [Fact]
    public void ItemsValidation_NegativePrice_Test()
    {
        var list = new List<Item>()
        {
            new Item("Матча", -12, Category.Alcohol)
        };
        var test = () => MenuMaster.ItemsValidation(list);

        var exception = Assert.Throws<Exception>(test);
        var expected = "Значение цены ниже нуля";
        Assert.Equal(expected, exception.Message);
    }

    [Fact]
    public void GetItemsAmount_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", 22, Category.Alcohol),
            new("Латте", 80, Category.HotDrink),
            new("Смузи", 90, Category.ColdDrink),
            new("Джин", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.GetItemsAmount();

        var expected = list.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetTotalPages_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", 22, Category.Alcohol),
            new("Латте", 80, Category.HotDrink),
            new("Смузи", 90, Category.ColdDrink),
            new("Джин", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        var onPage = 2;

        var menu = new MenuMaster(list, onPage);
        var actual = menu.GetTotalPages();

        var expected = list.Count % onPage == 0
            ? list.Count / onPage
            : list.Count / onPage + 1;;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetItemsCountFromPage_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", 22, Category.Alcohol),
            new("Латте", 80, Category.HotDrink),
            new("Смузи", 90, Category.ColdDrink),
            new("Джин", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        var onPage = 3;
        var page = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.GetItemsCountFromPage(page);

        var expected = list.Count - onPage * (page - 1);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetItemsFromPage_Test()
    {
        var list = new List<Item>()
        {
            new("Матча",22, Category.Alcohol),
            new("Латте", 80, Category.HotDrink),
            new("Смузи", 90, Category.ColdDrink),
            new("Джин", 150, Category.Alcohol),
            new("Тоник", 150, Category.Alcohol),
            new("Американо", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.GetItemsFromPage(3);

        var expected = new List<Item>
        {
            new("Тоник", 150, Category.Alcohol),
            new("Американо", 150, Category.Alcohol)
        };
        Assert.NotStrictEqual(expected, actual);
    }

    [Fact]
    public void GetFirstItemsFromPages_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", 22, Category.Alcohol),
            new("Латте", 80, Category.HotDrink),
            new("Смузи", 90, Category.ColdDrink),
            new("Джин", 150, Category.Alcohol),
            new("Тоник", 150, Category.Alcohol),
            new("Американо", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.GetFirstItemsFromPages();

        var expected = new List<Item>
        {
            new("Матча", 22, Category.Alcohol),
            new("Смузи", 90, Category.ColdDrink),
            new("Тоник", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        Assert.NotStrictEqual(expected, actual);
    }

    [Fact]
    public void FillPages_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", 22, Category.Alcohol),
            new("Латте", 80, Category.HotDrink),
            new("Смузи", 90, Category.ColdDrink),
            new("Джин", 150, Category.Alcohol),
            new("Тоник", 150, Category.Alcohol),
            new("Американо", 150, Category.Alcohol),
            new("Эскимо", 40, Category.Iceсream)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.Menu;

        var expected = new[]
        {
            new Item[]
            {
                new("Матча", 22, Category.Alcohol),
                new("Латте", 80, Category.HotDrink)
            },
            new Item[]
            {
                new("Смузи", 90, Category.ColdDrink),
                new("Джин", 150, Category.Alcohol)
            },
            new Item[]
            {
                new("Тоник", 150, Category.Alcohol),
                new("Американо", 150, Category.Alcohol)
            },
            new Item[]
            {
                new("Эскимо", 40, Category.Iceсream),
                null
            }
        };
        Assert.NotStrictEqual(expected, actual);
    }
}
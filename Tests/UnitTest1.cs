using ArbusTest;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void ItemsValidation_EmptyName_Test()
    {
        var list = new List<Item>()
        {
            new Item("", Category.Alcohol, 2)
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
            new Item("a", Category.Alcohol, 2)
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
            new Item("sddddddddddddddddddddddddddddddddddddddddddddddddddddddddd", Category.Alcohol, 2)
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
            new Item("Матча", Category.Alcohol, -12)
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
            new("Матча", Category.Alcohol, 22),
            new("Латте", Category.HotDrink, 80),
            new("Смузи", Category.ColdDrink, 90),
            new("Джин", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
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
            new("Матча", Category.Alcohol, 22),
            new("Латте", Category.HotDrink, 80),
            new("Смузи", Category.ColdDrink, 90),
            new("Джин", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
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
            new("Матча", Category.Alcohol, 22),
            new("Латте", Category.HotDrink, 80),
            new("Смузи", Category.ColdDrink, 90),
            new("Джин", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
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
            new("Матча", Category.Alcohol, 22),
            new("Латте", Category.HotDrink, 80),
            new("Смузи", Category.ColdDrink, 90),
            new("Джин", Category.Alcohol, 150),
            new("Тоник", Category.Alcohol, 150),
            new("Американо", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.GetItemsFromPage(3);

        var expected = new List<Item>
        {
            new("Тоник", Category.Alcohol, 150),
            new("Американо", Category.Alcohol, 150)
        };
        Assert.NotStrictEqual(expected, actual);
    }

    [Fact]
    public void GetFirstItemsFromPages_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", Category.Alcohol, 22),
            new("Латте", Category.HotDrink, 80),
            new("Смузи", Category.ColdDrink, 90),
            new("Джин", Category.Alcohol, 150),
            new("Тоник", Category.Alcohol, 150),
            new("Американо", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.GetFirstItemsFromPages();

        var expected = new List<Item>
        {
            new("Матча", Category.Alcohol, 22),
            new("Смузи", Category.ColdDrink, 90),
            new("Тоник", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
        };
        Assert.NotStrictEqual(expected, actual);
    }

    [Fact]
    public void FillPages_Test()
    {
        var list = new List<Item>()
        {
            new("Матча", Category.Alcohol, 22),
            new("Латте", Category.HotDrink, 80),
            new("Смузи", Category.ColdDrink, 90),
            new("Джин", Category.Alcohol, 150),
            new("Тоник", Category.Alcohol, 150),
            new("Американо", Category.Alcohol, 150),
            new("Эскимо", Category.Iceсream, 40)
        };
        var onPage = 2;

        var master = new MenuMaster(list, onPage);
        var actual = master.Menu;

        var expected = new[]
        {
            new Item[]
            {
                new("Матча", Category.Alcohol, 22),
                new("Латте", Category.HotDrink, 80)
            },
            new Item[]
            {
                new("Смузи", Category.ColdDrink, 90),
                new("Джин", Category.Alcohol, 150),
            },
            new Item[]
            {
                new("Тоник", Category.Alcohol, 150),
                new("Американо", Category.Alcohol, 150)
            },
            new Item[]
            {
                new("Эскимо", Category.Iceсream, 40),
                null
            }
        };
        Assert.NotStrictEqual(expected, actual);
    }
}
using ArbusTest;

var onPage = 2;
var items = new List<Item>
{
    new Item("Матча", Category.Alcohol, 2),
    new Item("Латте", Category.HotDrink, 80),
    new Item("Смузи", Category.ColdDrink, 90),
    new Item("Джин", Category.Alcohol, 150),
    new Item("Эскимо", Category.Iceсream, 40)
};


var master = new MenuMaster(items, onPage);

Console.WriteLine("ItemsAmount " + master.GetItemsAmount());
Console.WriteLine("TotalPages " + master.GetTotalPages());
Console.WriteLine("ItemsCountFromPage " + master.GetItemsCountFromPage(1));
Console.WriteLine("ItemsFromPage " + string.Join(", ", master.GetItemsFromPage(1)));
Console.WriteLine("FirstItemsFromPages " + string.Join(", ", master.GetFirstItemsFromPages()));

Console.ReadKey();
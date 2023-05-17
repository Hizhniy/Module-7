abstract class Delivery
{
    public string Address;

    public virtual DateTime RecieveDateTime { get; set; }

    public virtual void CheckAddress(string Address)
    {
        this.Address = Address;
    }
}

class HomeDelivery : Delivery
{
    public string AddInfoForCourier;
    public string DeliveryInterval;
}

class PickPointDelivery : Delivery
{
    protected byte PickPointID
    {
        get { return PickPointID; }
        set
        {
            if (value >= 0) PickPointID = value;
            else Console.WriteLine("Аппарат не найден");
        }
    }

    public override DateTime RecieveDateTime
    {
        get { return RecieveDateTime; }
        set
        {
            if (RecieveDateTime >= DateTime.Today) RecieveDateTime = value; // проверяем, чтобы прошлую дату не указали
            else Console.WriteLine("Сейчас нельзя вернуться в прошлое...");
        }
    }

    public DateTime TillDateTime; // хранение до
    
    public PickPointDelivery()
    {
        TillDateTime = RecieveDateTime.AddDays(7);
    }
    
    public PickPointDelivery(byte days)
    {
        TillDateTime = RecieveDateTime.AddDays(days);
    }

    public override void CheckAddress(string Address)
    {
        if (PickPointID == 8) Address = "г. Санкт-Петербург, Дворцовая площадь, 1";
        else Address = "г. Москва, ул. Петровка, 38";
    }
}

class Reciever
{
    public string RecieverName;
    public string RecieverPhoneNumber;
}

class Courier
{
    public string CourierName;
    public string CourierPhoneNumber;
    public string CourierCity;
}

class CourierCompany
{
    private Courier couriers;

    public CourierCompany()
    {
        couriers = new Courier();
    }
}

class ShopDelivery : Delivery
{
    public byte ShopID
    {
        get { return ShopID; }
        set
        {
            if (value >= 0) ShopID = value;
            else Console.WriteLine("Магазин не найден");
        }
    }
}

class MoscowShopDelivery : ShopDelivery
{
    public string MoscowArea;
}

class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    class Product
    {
        public string[] Products;
    }

    public double OveralCost;
}

class Orders // Индексаторы
{
    private Order<Delivery, int>[] lake;

    public Orders(Order<Delivery, int>[] lake)
    {
        this.lake = lake;
    }

    public Order<Delivery, int> this[int index]
    {
        get
        {
            if (index >= 0 && index < lake.Length) return lake[index];
            else return null;
        }
        private set
        {
            if (index >= 0 && index < lake.Length)
            {
                lake[index] = value;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
    }
}
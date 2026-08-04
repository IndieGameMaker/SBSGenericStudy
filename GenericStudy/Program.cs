namespace GenericStudy;

/*
 * 제너릭(Generic)
 * 1. 코드의 재사용성
 * 2. 타입의 안정성
 * 3. 성능 향상 : object Boxing / Unboxing 
 */


class Program
{
    static void Main(string[] args)
    {
        // int 타입
        Box<int> intBox = new Box<int>();
        intBox.Set(123);
        Console.WriteLine(intBox.Get());
        
        // string 타입
        Box<string> strBox = new Box<string>();
        strBox.Set("문자열 지정");
        Console.WriteLine(strBox.Get());
        
        // 제너릭 타입의 인벤토리 사용
        // Inventory<string> stringInventory = new Inventory<string>();
        // stringInventory.Add("Sword");
        // stringInventory.Add("Shield");
        // stringInventory.DisplayItems();
        
        // 제약 조건을 가진 제너릭 타입의 인벤토리 사용
        Inventory<Weapon> weaponInventory = new Inventory<Weapon>();
        weaponInventory.Add(new Weapon { Name = "Sword", Damage = 10 });
        weaponInventory.Add(new Weapon { Name = "Axe", Damage = 15 });
        weaponInventory.DisplayItems();
    }
    
    // static int AddInt(int a, int b) => a + b;
    // static float AddFloat(float a, float b) => a + b;
}

// 제너릭(Generic) 클래스
public class Box<T>
{
    public T Item;
    
    public void Set(T item)
    {
        Item = item;
    }

    public T Get() => Item;
}

// 제너릭 타입의 인벤토리
public class Inventory<T> where T : Item
{
    private List<T> _items = new List<T>();
    
    public void Add(T item)
    {
        _items.Add(item);
    }
    
    public void Remove(T item)
    {
        _items.Remove(item);
    }
    
    public void DisplayItems()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item.Name);
        }
    }
}

public class Item
{
    public string Name { get; set; }
}

public class Weapon : Item
{
    public int Damage { get; set; }
}

public class GameManager
{
    public void StartGame() => Console.WriteLine("게임 시작");
}

public class AudioManager
{
    public void PlaySound(string clip) => Console.WriteLine($"사운드 재생 {clip}");
}

// 제너릭 싱글턴 (Generic Singleton)
public class Singleton<T> where T : class, new()
{
    private static T? _instance;

    // private 생성자 (외부 클래스에서 인스턴스 생성 불가)
    private Singleton() {}
    
    // 외부 접근 가능한 프로퍼티
    public static T Instance
    {
        get
        {
            if (_instance == null) // 인스턴스가 아직 생성되지 않은 경우
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}
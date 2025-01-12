namespace Services.Contracts
{
    public interface IServiceManager
    {
        // İleride diyelim ki siparişlerle ilgili Order Servise ihtiyacımız olursa burada tanımlayabiliriz.
        // Yine burada Authentication işlemleri yapılabilir. Bununla ilgili servis buraya yazılablir.
        // Kısaca burası servisleri yöneteceğimiz arayüz olacaktır.
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
    }

}

using UILayer;

try
{
    App app = new App();
    app.RunUI(true);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}
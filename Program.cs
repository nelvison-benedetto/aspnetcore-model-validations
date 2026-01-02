namespace _5_aspnetcore_model_validations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddXmlSerializerFormatters();  //add xml formatter x input/output, di default aspnetcore supporta solo json, ora supporta anche application/xml text/xml
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();

            //lesson 76-77 Custom Binding e come apply, non cosnigliato usarlo spesso, no code here.

        }
    }
}

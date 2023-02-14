// See https://aka.ms/new-console-template for more information
using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();
//await QueryMethods();
await QueryLinq();
async Task QueryLinq()
{
    var streamerNombre = "netflix";
    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre!, $"%{streamerNombre}%")
                           select i).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task QueryFilter()
{
    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre == "Netflix").ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task QueryFilterLike(string streamingNombre)
{
    var streamers = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre!, $"%{streamingNombre}%")).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;

    // asume que existe almenos un elemento, si no existe retorna una excepción detiene la ejecución del programa
    var firstAsync = await streamer.Where(y=>y.Nombre!.Contains("a")).FirstAsync();

    // retorna el primer registro, si no existe retorna nulo y no detiene el programa
    var firstOrDefault = await streamer.Where(y => y.Nombre!.Contains("a")).FirstOrDefaultAsync();
    // se puede usar tambien de la siguiente manera
    var firstOrDefault2 = await streamer.FirstOrDefaultAsync(y=>y.Nombre!.Contains("a"));

    //el resultado debe ser un unico valor, si es mas de un registro lanza una excepción, si no existe el valor tambien lanza el error
    var singleAsync = await streamer.Where(y=>y.Id==1).SingleAsync();

    //retorna siempre un valor, si no existe returna null
    var singleOrDefaultAsync = await  streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();


    var resultado = await streamer.FindAsync(1);

}
async void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");

    }
}
async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "asdasdasdassd"
    };
    dbContext!.Streamers.Add(streamer);
    await dbContext.SaveChangesAsync();


    var movies = new List<Video>
    {
        new Video
        {
            Nombre="Cenicienta",
            StreamerId=streamer.Id
        },
        new Video
        {
            Nombre="101 dalmatas",
            StreamerId=streamer.Id
        }
    };
    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}

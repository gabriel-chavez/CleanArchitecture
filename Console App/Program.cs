// See https://aka.ms/new-console-template for more information
using CleanArchitecture.Domain;
using CleanArchitecture.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
Console.WriteLine("");
//StreamerDbContext dbContext = new();
//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();
//await QueryMethods();
//await QueryLinq();
//await TrackingAndNotTraking();
//await AddNewStreamerWithVideo();
//await AddNewActorWithVideo();
//await AddNewDiretorWithVideo();
//await MultipleEntitiesQuery();

//async Task MultipleEntitiesQuery()
//{
//    var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

//    var actor = await dbContext!.Actores!.Select(q => q.Nombre).ToListAsync();

//    var videoWithDirector = await dbContext!.Videos!
//        .Where(q=>q.Director!=null)
//        .Include(q => q.Director)
//        .Select(q =>
//            new
//            {
//                DirectorNombreCompleto = $"{q.Director.Nombre} {q.Director.Apellido}",
//                Movie = q.Nombre
//            }

//        ).ToListAsync();

//    foreach (var pelicula in videoWithDirector)
//    {
//        Console.WriteLine($"{pelicula.Movie} - {pelicula.DirectorNombreCompleto}");
//    }
//}
   

//async Task AddNewDiretorWithVideo()
//{
//    var director = new Director
//    {
//        Nombre = "Lorenzo",
//        Apellido = "Basteri",
//        VideoId = 1
//    };
//    await dbContext.AddAsync(director);
//    await dbContext.SaveChangesAsync();
//}

//async Task AddNewActorWithVideo()
//{
//    var actor = new Actor
//    {
//        Nombre = "Brad",
//        Apellido = "Pitt"
//    };

//    await dbContext.AddAsync(actor);
//    await dbContext.SaveChangesAsync();



//    var videoActor = new VideoActor
//    {
//        ActorId = actor.Id,
//        VideoId = 1
//    };

//    await dbContext.AddAsync(videoActor);
//    await dbContext.SaveChangesAsync();


//}

//async Task AddNewStreamerWithVideo()
//{
//    var pantaya = new Streamer
//    {
//        Nombre = "Pantaya"
//    };
//    var hungerGames = new Video
//    {
//        Nombre = "hungerGames",
//        Streamer = pantaya
//    };
//    await dbContext.AddAsync(hungerGames);
//    await dbContext.SaveChangesAsync();


//}

//async Task TrackingAndNotTraking()
//{
//    //obtiene el resultado y lo guarda en el contexto para el rastreo 
//    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x=>x.Id==1);
//    //obtiene el resultado y no es rastreado por el contexto //optimizado para el rendimiento de aplicaciones, EF no realiza ningun procesamiento o almacenamiento adicional
//    //Solo para operaciones de lectura
//    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==2);

//    streamerWithTracking.Nombre = "Neflix Super";
//    streamerWithNoTracking.Nombre = "Amazon Plus";
    
//    await dbContext!.SaveChangesAsync();
//}

//async Task QueryLinq()
//{
//    var streamerNombre = "netflix";
//    var streamers = await (from i in dbContext.Streamers
//                           where EF.Functions.Like(i.Nombre!, $"%{streamerNombre}%")
//                           select i).ToListAsync();
//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }
//}
//async Task QueryFilter()
//{
//    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre == "Netflix").ToListAsync();
//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }
//}
//async Task QueryFilterLike(string streamingNombre)
//{
//    var streamers = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre!, $"%{streamingNombre}%")).ToListAsync();
//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
//    }
//}
//async Task QueryMethods()
//{
//    var streamer = dbContext!.Streamers!;

//    // asume que existe almenos un elemento, si no existe retorna una excepción detiene la ejecución del programa
//    var firstAsync = await streamer.Where(y=>y.Nombre!.Contains("a")).FirstAsync();

//    // retorna el primer registro, si no existe retorna nulo y no detiene el programa
//    var firstOrDefault = await streamer.Where(y => y.Nombre!.Contains("a")).FirstOrDefaultAsync();
//    // se puede usar tambien de la siguiente manera
//    var firstOrDefault2 = await streamer.FirstOrDefaultAsync(y=>y.Nombre!.Contains("a"));

//    //el resultado debe ser un unico valor, si es mas de un registro lanza una excepción, si no existe el valor tambien lanza el error
//    var singleAsync = await streamer.Where(y=>y.Id==1).SingleAsync();

//    //retorna siempre un valor, si no existe returna null
//    var singleOrDefaultAsync = await  streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();


//    var resultado = await streamer.FindAsync(1);

//}
//async void QueryStreaming()
//{
//    var streamers = dbContext!.Streamers!.ToList();
//    foreach (var streamer in streamers)
//    {
//        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");

//    }
//}
//async Task AddNewRecords()
//{
//    Streamer streamer = new()
//    {
//        Nombre = "NETFLIX",
//        Url = "asdasdasdassd"
//    };
//    dbContext!.Streamers.Add(streamer);
//    await dbContext.SaveChangesAsync();


//    var movies = new List<Video>
//    {
//        new Video
//        {
//            Nombre="STRANGER",
//            StreamerId=streamer.Id
//        },
//        new Video
//        {
//            Nombre="COBRA KAI",
//            StreamerId=streamer.Id
//        }
//    };
//    await dbContext.AddRangeAsync(movies);
//    await dbContext.SaveChangesAsync();
//}

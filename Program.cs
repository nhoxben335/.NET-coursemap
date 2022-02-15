using Microsoft.EntityFrameworkCore;
using nscccoursemap_nhoxben335.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// add the code from https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-6.0&tabs=visual-studio-code

// introduced a db context (database)
builder.Services.AddDbContext<NSCCCourseMapContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("NSCCCourseMapContext"))); 

    var app = builder.Build();
    using (var scope = app.Services.CreateScope()){
    
    var services = scope.ServiceProvider;
     SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using OnlineDoctorApp.Services;  // Your existing using

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();  // Enables Razor Pages (required for About.cshtml)
builder.Services.AddSingleton<IAppointmentService, AppointmentService>();  // Your appointment service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");  // Handles errors in production
    app.UseHsts();  // Adds security headers (optional but recommended)
}

app.UseHttpsRedirection();  // Redirects HTTP to HTTPS (add this for security)
app.UseStaticFiles();  // Serves CSS, JS, etc.
app.UseRouting();  // Enables routing
app.MapRazorPages();  // Maps Razor Pages routes (e.g., /About)

app.Run();

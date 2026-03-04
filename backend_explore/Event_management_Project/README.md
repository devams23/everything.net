# Event Management Project

A simple ASP.NET Core Web API for event management with JWT auth and role-based access.

## Features
- JWT login, refresh, and logout flow (`Controllers/Auth/AuthController.cs`, `Services/Implementations/AuthService.cs`, `Security/Services/TokenService.cs`)
- Role-based access for Admin, Organizer, and Attendee (`Program.cs`, `Repository/Models/Entities/Enums.cs`, `Common/UserContextExtensions.cs`)
- Event CRUD with ownership checks and date validation (`Controllers/EventsController.cs`, `Services/Implementations/EventService.cs`)
- Registration flow with capacity-based confirmed/waitlisted status (`Controllers/RegistrationsController.cs`, `Services/Implementations/RegistrationService.cs`)
- Global exception handling with consistent JSON error response (`Middlewares/GlobalExceptionMiddleware.cs`, `Common/Exceptions/ApiException.cs`)
- Request rate limiting for auth and API usage (`Program.cs`)